using System;
using System.Runtime.InteropServices;

namespace Saver.WindowsMedia
{
    [StructLayout(LayoutKind.Sequential), UnmanagedName("RECT")]
    public struct Rect
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    [StructLayout(LayoutKind.Sequential), UnmanagedName("WM_MEDIA_TYPE")]
    public struct WMMediaType
    {
        public Guid majorType;
        public Guid subType;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fixedSizeSamples;
        [MarshalAs(UnmanagedType.Bool)]
        public bool temporalCompression;
        public int sampleSize;
        public Guid formatType;
        public IntPtr unkPtr;
        public int formatSize;
        public IntPtr formatPtr;
    }

    [StructLayout(LayoutKind.Sequential), UnmanagedName("BITMAPINFOHEADER")]
    public struct BitmapInfoHeader
    {
        public int size;
        public int width;
        public int height;
        public short planes;
        public short bitCount;
        public int compression;
        public int sizeImage;
        public int xPelsPerMeter;
        public int yPelsPerMeter;
        public int clrUsed;
        public int clrImportant;
    }

    [StructLayout(LayoutKind.Sequential), UnmanagedName("WMVIDEOINFOHEADER")]
    public struct VideoInfoHeader
    {
        public Rect srcRect;
        public Rect targetRect;
        public int bitRate;
        public int bitErrorRate;
        public long avgTimePerFrame;
        public BitmapInfoHeader bmiHeader;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 2), UnmanagedName("WM_STREAM_PRIORITY_RECORD")]
    public struct WMStreamPrioritizationRecord
    {
        public short streamNumber;
        public bool mandatory;
    }
}
