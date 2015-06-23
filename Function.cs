using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Saver.WindowsMedia
{
    [SuppressUnmanagedCodeSecurity]
    public class Function
    {
        [DllImport("wmvcore.dll", PreserveSig = false)]
        public static extern void WMCreateProfileManager(out IWMProfileManager ppProfileManager);

        [DllImport("WMVCore.dll", PreserveSig = false)]
        public static extern void WMCreateWriter(IntPtr pUnkCert, out IWMWriter ppWriter);
    }
}
