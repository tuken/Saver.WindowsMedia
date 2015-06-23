using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace Saver.WindowsMedia
{
    public class Util
    {
        public static void CopyMemory(IntPtr dst, IntPtr src, int size)
        {
            byte[] temp = new byte[size];
            Marshal.Copy(src, temp, 0, size);
            Marshal.Copy(temp, 0, dst, size);
        }
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Struct | AttributeTargets.Class)]
    internal class UnmanagedNameAttribute : Attribute
    {
        private string m_name;

        public UnmanagedNameAttribute(string name)
        {
            m_name = name;
        }

        public override string ToString()
        {
            return m_name;
        }
    }

    internal class MediaTypeMarshaler : ICustomMarshaler
    {
        static private MediaTypeMarshaler marshaler = null;

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            if (ManagedObj == null)
                return IntPtr.Zero;

            if (!(ManagedObj is WMMediaType))
                throw new ArgumentException("Specified object is not a MediaType object.", "ManagedObj");

            WMMediaType mt = (WMMediaType)ManagedObj;
            
            IntPtr ptr = Marshal.AllocCoTaskMem(this.GetNativeDataSize(mt));
            if (ptr == IntPtr.Zero)
                throw new Exception("Unable to allocate memory to marshal WMMediaType.");

            Marshal.StructureToPtr(mt, ptr, false);
            if (mt.formatSize > 0)
            {
                IntPtr dataPtr = new IntPtr(ptr.ToInt64() + Marshal.SizeOf(typeof(WMMediaType)));
                Util.CopyMemory(mt.formatPtr, dataPtr, mt.formatSize);
            }

            return ptr;
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            if (pNativeData == IntPtr.Zero)
                return null;

            WMMediaType mt = (WMMediaType)Marshal.PtrToStructure(pNativeData, typeof(WMMediaType));
            if (mt.formatSize > 0)
            {
                if (mt.formatType == FormatType.VideoInfo)
                {
                    IntPtr dataPtr = new IntPtr(pNativeData.ToInt64() + Marshal.SizeOf(typeof(WMMediaType)));
                    VideoInfoHeader vih = (VideoInfoHeader)Marshal.PtrToStructure(dataPtr, typeof(VideoInfoHeader));
                    Marshal.StructureToPtr(vih, mt.formatPtr, false);
                }
            }

            return mt;
        }

        public void CleanUpManagedData(object ManagedObj)
        {
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            Marshal.FreeCoTaskMem(pNativeData);
        }

        public int GetNativeDataSize()
        {
            return Marshal.SizeOf(typeof(WMMediaType));
        }

        public int GetNativeDataSize(WMMediaType mt)
        {
            int size = Marshal.SizeOf(typeof(WMMediaType));
            size += mt.formatSize;
            return size;
        }

        public static ICustomMarshaler GetInstance(string cookie)
        {
            if (marshaler == null)
                marshaler = new MediaTypeMarshaler();

            return marshaler;
        }
    }
}
