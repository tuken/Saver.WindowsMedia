using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saver.WindowsMedia
{
    [Flags, UnmanagedName("(define)")]
    public enum SampleFlag
    {
        None = 0,
        CleanPoint = 0x1,
        Discontinuity = 0x2,
        Dataloss = 0x4
    }

    [UnmanagedName("WMT_VERSION")]
    public enum Version
    {
        VER_4_0	= 0x40000,
        VER_7_0	= 0x70000,
        VER_8_0	= 0x80000,
        VER_9_0	= 0x90000
    }

    [UnmanagedName("WMT_STORAGE_FORMAT")]
    public enum StorageFormat
    {
        MP3 = 0,
        V1 = 1
    }

    [UnmanagedName("WMT_TRANSPORT_TYPE")]
    public enum TransportType
    {
        Unreliable = 0,
        Reliable = 1
    }

    [UnmanagedName("WMT_ATTR_DATATYPE")]
    public enum AttrDataType
    {
        DWORD = 0,
        STRING = 1,
        BINARY = 2,
        BOOL = 3,
        QWORD = 4,
        WORD = 5,
        GUID = 6
    }
}
