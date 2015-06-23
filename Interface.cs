using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Saver.WindowsMedia
{
    [ComImport, SuppressUnmanagedCodeSecurity, Guid("D16679F2-6CA0-472D-8D31-2F5D55AEE155"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfileManager
    {
        void CreateEmptyProfile([In] Version dwVersion, out IWMProfile ppProfile);
        void LoadProfileByID([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidProfile, out IWMProfile ppProfile);
        void LoadProfileByData([In] string pwszProfile, out IWMProfile ppProfile);
        void SaveProfile([In] IWMProfile pIWMProfile, [Out] StringBuilder pwszProfile, ref int pdwLength);
        void GetSystemProfileCount(out int pcProfiles);
        void LoadSystemProfile([In] int dwProfileIndex, out IWMProfile ppProfile);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("7A924E51-73C1-494D-8019-23D37ED9B89A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfileManager2 : IWMProfileManager
    {
        void GetSystemProfileVersion(out Version pdwVersion);
        void SetSystemProfileVersion(Version dwVersion);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("96406BDB-2B2B-11D3-B36B-00C04F6108FF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfile
    {
        void GetVersion(out Version pdwVersion);
        void GetName([Out] StringBuilder pwszName, ref int pcchName);
        void SetName([In] string pwszName);
        void GetDescription([Out] StringBuilder pwszDescription, ref int pcchDescription);
        void SetDescription([In] string pwszDescription);
        void GetStreamCount(out int pcStreams);
        void GetStream([In] int dwStreamIndex, out IWMStreamConfig ppConfig);
        void GetStreamByNumber([In] short wStreamNum, out IWMStreamConfig ppConfig);
        void RemoveStream([In] IWMStreamConfig pConfig);
        void RemoveStreamByNumber([In] short wStreamNum);
        void AddStream([In] IWMStreamConfig pConfig);
        void ReconfigStream([In] IWMStreamConfig pConfig);
        void CreateNewStream([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidStreamType, out IWMStreamConfig ppConfig);
        void GetMutualExclusionCount(out int pcME);
        void GetMutualExclusion([In] int dwMEIndex, out IWMMutualExclusion ppME);
        void RemoveMutualExclusion([In] IWMMutualExclusion pME);
        void AddMutualExclusion([In] IWMMutualExclusion pME);
        void CreateNewMutualExclusion(out IWMMutualExclusion ppME);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("07E72D33-D94E-4BE7-8843-60AE5FF7E5F5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfile2 : IWMProfile
    {
        void GetProfileID(out Guid pguidID);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("00EF96CC-A461-4546-8BCD-C9A28F0E06F5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfile3 : IWMProfile2
    {
        void GetStorageFormat(out StorageFormat pnStorageFormat);
        void SetStorageFormat([In] StorageFormat nStorageFormat);
        void GetBandwidthSharingCount(out int pcBS);
        void GetBandwidthSharing([In] int dwBSIndex, out IWMBandwidthSharing ppBS);
        void RemoveBandwidthSharing([In] IWMBandwidthSharing pBS);
        void AddBandwidthSharing([In] IWMBandwidthSharing pBS);
        void CreateNewBandwidthSharing(out IWMBandwidthSharing ppBS);
        void GetStreamPrioritization(out IWMStreamPrioritization ppSP);
        void SetStreamPrioritization([In] IWMStreamPrioritization pSP);
        void RemoveStreamPrioritization();
        void CreateNewStreamPrioritization(out IWMStreamPrioritization ppSP);
        void GetExpectedPacketCount([In] long msDuration, out long pcPackets);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("96406BDC-2B2B-11D3-B36B-00C04F6108FF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamConfig
    {
        void GetStreamType(out Guid pguidStreamType);
        void GetStreamNumber(out short pwStreamNum);
        void SetStreamNumber([In] short wStreamNum);
        void GetStreamName([Out] StringBuilder pwszStreamName, ref short pcchStreamName);
        void SetStreamName([In] string pwszStreamName);
        void GetConnectionName([Out] StringBuilder pwszInputName, ref short pcchInputName);
        void SetConnectionName([In] string pwszInputName);
        void GetBitrate(out int pdwBitrate);
        void SetBitrate([In] int pdwBitrate);
        void GetBufferWindow(out int pmsBufferWindow);
        void SetBufferWindow([In] int msBufferWindow);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("7688D8CB-FC0D-43BD-9459-5A8DEC200CFA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamConfig2 : IWMStreamConfig
    {
        void GetTransportType(out TransportType pnTransportType);
        void SetTransportType([In] TransportType nTransportType);
        void AddDataUnitExtension([In] Guid guidExtensionSystemID, [In] short cbExtensionDataSize, [In, MarshalAs(UnmanagedType.LPArray)] byte[] pbExtensionSystemInfo, [In] int cbExtensionSystemInfo);
        void GetDataUnitExtensionCount(out short pcDataUnitExtensions);
        void GetDataUnitExtension([In] short wDataUnitExtensionNumber, out Guid pguidExtensionSystemID, out short pcbExtensionDataSize, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pbExtensionSystemInfo, ref int pcbExtensionSystemInfo);
        void RemoveAllDataUnitExtensions();
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("CB164104-3AA9-45A7-9AC9-4DAEE131D6E1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamConfig3 : IWMStreamConfig2
    {
        void GetLanguage([Out] StringBuilder pwszLanguageString, ref short pcchLanguageStringLength);
        void SetLanguage([In] string pwszLanguageString);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("96406BDD-2B2B-11D3-B36B-00C04F6108FF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamList
    {
        void GetStreams([Out, MarshalAs(UnmanagedType.LPArray)] short[] pwStreamNumArray, ref short pcStreams);
        void AddStream([In] short wStreamNum);
        void RemoveStream([In] short wStreamNum);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("96406BDE-2B2B-11D3-B36B-00C04F6108FF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMMutualExclusion : IWMStreamList
    {
        void GetType(out Guid pguidType);
        void SetType([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidType);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("0302B57D-89D1-4BA2-85C9-166F2C53EB91"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMMutualExclusion2 : IWMMutualExclusion
    {
        void GetName([Out] StringBuilder pwszName, ref short pcchName);
        void SetName([In] string pwszName);
        void GetRecordCount(out short pwRecordCount);
        void AddRecord();
        void RemoveRecord([In] short wRecordNumber);
        void GetRecordName([In] short wRecordNumber, [Out] StringBuilder pwszRecordName, ref short pcchRecordName);
        void SetRecordName([In] short wRecordNumber, [In] string pwszRecordName);
        void GetStreamsForRecord([In] short wRecordNumber, [Out, MarshalAs(UnmanagedType.LPArray)] short[] pwStreamNumArray, ref short pcStreams);
        void AddStreamForRecord([In] short wRecordNumber, [In] short wStreamNumber);
        void RemoveStreamForRecord([In] short wRecordNumber, [In] short wStreamNumber);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("AD694AF1-F8D9-42F8-BC47-70311B0C4F9E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMBandwidthSharing : IWMStreamList
    {
        void GetType(out Guid pguidType);
        void SetType([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidType);
        void GetBandwidth(out int pdwBitrate, out int pmsBufferWindow);
        void SetBandwidth([In] int dwBitrate, [In] int msBufferWindow);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("8C1C6090-F9A8-4748-8EC3-DD1108BA1E77"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamPrioritization
    {
        void GetPriorityRecords([Out, MarshalAs(UnmanagedType.LPArray)] WMStreamPrioritizationRecord[] pRecordArray, ref short pcRecords);
        void SetPriorityRecords([In, MarshalAs(UnmanagedType.LPArray)] WMStreamPrioritizationRecord[] pRecordArray, [In] short cRecords);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("A970F41E-34DE-4A98-B3BA-E4B3CA7528F0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMCodecInfo
    {
        void GetCodecInfoCount([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidType, out int pcCodecs);
        void GetCodecFormatCount([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidType, [In] int dwCodecIndex, out int pcFormat);
        void GetCodecFormat([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidType, [In] int dwCodecIndex, [In] int dwFormatIndex, out IWMStreamConfig ppIStreamConfig);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("AA65E273-B686-4056-91EC-DD768D4DF710"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMCodecInfo2 : IWMCodecInfo
    {
        void GetCodecName([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidType, [In] int dwCodecIndex, [Out] StringBuilder wszName, ref int pcchName);
        void GetCodecFormatDesc([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidType, [In] int dwCodecIndex, [In] int dwFormatIndex, out IWMStreamConfig ppIStreamConfig, [Out] StringBuilder wszDesc, ref int pcchDesc);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("7E51F487-4D93-4F98-8AB4-27D0565ADC51"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMCodecInfo3 : IWMCodecInfo2
    {
        void GetCodecFormatProp([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidType, [In] int dwCodecIndex, [In] int dwFormatIndex, [In, MarshalAs(UnmanagedType.LPWStr)] string pszName, out AttrDataType pType, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pValue, ref int pdwSize);
        void GetCodecProp([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidType, [In] int dwCodecIndex, [In, MarshalAs(UnmanagedType.LPWStr)] string pszName, out AttrDataType pType, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pValue, ref int pdwSize);
        void SetCodecEnumerationSetting([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidType, [In] int dwCodecIndex, [In, MarshalAs(UnmanagedType.LPWStr)] string pszName, [In] AttrDataType Type, [In, MarshalAs(UnmanagedType.LPArray)] byte[] pValue, [In] int dwSize);
        void GetCodecEnumerationSetting([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidType, [In] int dwCodecIndex, [In, MarshalAs(UnmanagedType.LPWStr)] string pszName, out AttrDataType pType, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pValue, ref int pdwSize);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("96406BCE-2B2B-11D3-B36B-00C04F6108FF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMMediaProps
    {
        void GetType(out Guid pguidType);
        //void GetMediaType([Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(MediaTypeMarshaler))] out object pType, ref int pcbType);
        void GetMediaType([Out] IntPtr pType, ref int pcbType);
        //void SetMediaType([In, MarshalAs(UnmanagedType.LPStruct)] WMMediaType pType);
        void SetMediaType([In] IntPtr pType);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("96406BCF-2B2B-11D3-B36B-00C04F6108FF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMVideoMediaProps : IWMMediaProps
    {
        new void GetType(out Guid pguidType);
        new void GetMediaType([Out] IntPtr pType, ref int pcbType);
        new void SetMediaType([In] IntPtr pType);

        void GetMaxKeyFrameSpacing(out long pllTime);
        void SetMaxKeyFrameSpacing([In] long llTime);
        void GetQuality(out int pdwQuality);
        void SetQuality([In] int dwQuality);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("96406BD5-2B2B-11D3-B36B-00C04F6108FF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMInputMediaProps : IWMMediaProps
    {
        void GetConnectionName([Out] StringBuilder pwszName, ref short pcchName);
        void GetGroupName([Out] StringBuilder pwszName, ref short pcchName);
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("96406BD4-2B2B-11D3-B36B-00C04F6108FF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMWriter
    {
        void SetProfileByID([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidProfile);
        void SetProfile([In] IWMProfile pProfile);
        void SetOutputFilename([In] string pwszFilename);
        void GetInputCount(out int pcInputs);
        void GetInputProps([In] int dwInputNum, out IWMInputMediaProps ppInput);
        void SetInputProps([In] int dwInputNum, [In] IWMInputMediaProps pInput);
        void GetInputFormatCount([In] int dwInputNumber, out int pcFormats);
        void GetInputFormat([In] int dwInputNumber, [In] int dwFormatNumber, out IWMInputMediaProps pProps);
        void BeginWriting();
        void EndWriting();
        void AllocateSample([In] int dwSampleSize, out INSSBuffer ppSample);
        void WriteSample([In] int dwInputNum, [In] long cnsSampleTime, [In] SampleFlag dwFlags, [In] INSSBuffer pSample);
        void Flush();
    }

    [ComImport, SuppressUnmanagedCodeSecurity, Guid("E1CD3524-03D7-11D2-9EED-006097D2D7CF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface INSSBuffer
    {
        void GetLength(out int pdwLength);
        void SetLength([In] int dwLength);
        void GetMaxLength(out int pdwLength);
        void GetBuffer(out IntPtr ppdwBuffer);
        void GetBufferAndLength(out IntPtr ppdwBuffer, out int pdwLength);
    }
}
