using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;

namespace HotKeys
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeMessage
    {
        public IntPtr handle;
        public uint msg;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public System.Drawing.Point p;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct STARTUPINFO
    {
        public Int32 cb;
        public string lpReserved;
        public string lpDesktop;
        public string lpTitle;
        public Int32 dwX;
        public Int32 dwY;
        public Int32 dwXSize;
        public Int32 dwYSize;
        public Int32 dwXCountChars;
        public Int32 dwYCountChars;
        public Int32 dwFillAttribute;
        public Int32 dwFlags;
        public Int16 wShowWindow;
        public Int16 cbReserved2;
        public IntPtr lpReserved2;
        public IntPtr hStdInput;
        public IntPtr hStdOutput;
        public IntPtr hStdError;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PROCESS_INFORMATION
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public int dwProcessId;
        public int dwThreadId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class SECURITY_ATTRIBUTES
    {
        public int nLength;
        public unsafe byte* lpSecurityDescriptor;
        public int bInheritHandle;
    }

    public enum PROCESS_INFORMATION_CLASS : int
    {
        ProcessBasicInformation = 0,
        ProcessQuotaLimits,
        ProcessIoCounters,
        ProcessVmCounters,
        ProcessTimes,
        ProcessBasePriority,
        ProcessRaisePriority,
        ProcessDebugPort,
        ProcessExceptionPort,
        ProcessAccessToken,
        ProcessLdtInformation,
        ProcessLdtSize,
        ProcessDefaultHardErrorMode,
        ProcessIoPortHandlers,
        ProcessPooledUsageAndLimits,
        ProcessWorkingSetWatch,
        ProcessUserModeIOPL,
        ProcessEnableAlignmentFaultFixup,
        ProcessPriorityClass,
        ProcessWx86Information,
        ProcessHandleCount,
        ProcessAffinityMask,
        ProcessPriorityBoost,
        ProcessDeviceMap,
        ProcessSessionInformation,
        ProcessForegroundInformation,
        ProcessWow64Information,
        ProcessImageFileName,
        ProcessLUIDDeviceMapsEnabled,
        ProcessBreakOnTermination,
        ProcessDebugObjectHandle,
        ProcessDebugFlags,
        ProcessHandleTracing,
        ProcessIoPriority,
        ProcessExecuteFlags,
        ProcessResourceManagement,
        ProcessCookie,
        ProcessImageInformation,
        ProcessCycleTime,
        ProcessPagePriority,
        ProcessInstrumentationCallback,
        ProcessThreadStackAllocation,
        ProcessWorkingSetWatchEx,
        ProcessImageFileNameWin32,
        ProcessImageFileMapping,
        ProcessAffinityUpdateMode,
        ProcessMemoryAllocationMode,
        MaxProcessInfoClass
    }

    public enum STANDARD_RIGHTS : uint
    {
        WRITE_OWNER = 524288,
        WRITE_DAC = 262144,
        READ_CONTROL = 131072,
        DELETE = 65536,
        SYNCHRONIZE = 1048576,
        STANDARD_RIGHTS_REQUIRED = 983040,
        STANDARD_RIGHTS_WRITE = READ_CONTROL,
        STANDARD_RIGHTS_EXECUTE = READ_CONTROL,
        STANDARD_RIGHTS_READ = READ_CONTROL,
        STANDARD_RIGHTS_ALL = 2031616,
        SPECIFIC_RIGHTS_ALL = 65535,
        ACCESS_SYSTEM_SECURITY = 16777216,
        MAXIMUM_ALLOWED = 33554432,
        GENERIC_WRITE = 1073741824,
        GENERIC_EXECUTE = 536870912,
        GENERIC_READ = UInt16.MaxValue,
        GENERIC_ALL = 268435456
    }

    public enum PROCESS_RIGHTS : uint
    {
        PROCESS_TERMINATE = 1,
        PROCESS_CREATE_THREAD = 2,
        PROCESS_SET_SESSIONID = 4,
        PROCESS_VM_OPERATION = 8,
        PROCESS_VM_READ = 16,
        PROCESS_VM_WRITE = 32,
        PROCESS_DUP_HANDLE = 64,
        PROCESS_CREATE_PROCESS = 128,
        PROCESS_SET_QUOTA = 256,
        PROCESS_SET_INFORMATION = 512,
        PROCESS_QUERY_INFORMATION = 1024,
        PROCESS_SUSPEND_RESUME = 2048,
        PROCESS_QUERY_LIMITED_INFORMATION = 4096,
        PROCESS_ALL_ACCESS = STANDARD_RIGHTS.STANDARD_RIGHTS_REQUIRED | STANDARD_RIGHTS.SYNCHRONIZE | 65535
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_BASIC_INFORMATION
    {
        public int ExitStatus;
        public int PebBaseAddress;
        public int AffinityMask;
        public int BasePriority;
        public int UniqueProcessId;
        public int InheritedFromUniqueProcessId;

        public int Size
        {
            get { return (6 * 4); }
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct LARGE_INTEGER
    {
        internal int lowpart;
        internal int highpart;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LUID_AND_ATTRIBUTES
    {
        public LARGE_INTEGER Luid;
        public UInt32 Attributes;
    }

    public struct TOKEN_PRIVILEGES
    {
        public UInt32 PrivilegeCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public LUID_AND_ATTRIBUTES[] Privileges;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        internal int Left;
        internal int Top;
        internal int Right;
        internal int Bottom;
    }

    internal sealed class WinAPI
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(HandleRef hwnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustTokenPrivileges(IntPtr TokenHandle,
            [MarshalAs(UnmanagedType.Bool)]bool DisableAllPrivileges,
            ref TOKEN_PRIVILEGES NewState,
            UInt32 Zero,
            IntPtr Null1,
            IntPtr Null2);

        [DllImport("advapi32.dll", EntryPoint = "LookupPrivilegeValueA")]
        public static extern int LookupPrivilegeValue(string lpSystemName, string lpName,
        LARGE_INTEGER lpLuid);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenProcessToken(IntPtr ProcessHandle,
              UInt32 DesiredAccess, out IntPtr TokenHandle);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentProcess();

        [DllImport("advapi32.dll")]
        public static extern int SetKernelObjectSecurity(int Handle,
        SecurityInfos SecurityInformation, byte[] SecurityDescriptor);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekMessage(out NativeMessage lpMsg, HandleRef hWnd,
            uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

        [DllImport("user32.dll")]
        public static extern bool WaitMessage();

        [DllImport("kernel32.dll")]
        public static extern bool CreateProcess(
            string lpApplicationName,
            string lpCommandLine,
            ref SECURITY_ATTRIBUTES lpProcessAttributes,
            ref SECURITY_ATTRIBUTES lpThreadAttributes,
            bool bInheritHandles,
            uint dwCreationFlags,
            IntPtr lpEnvironment,
            string lpCurrentDirectory,
            [In] ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetPriorityClass(IntPtr handle, uint priorityClass);

        [DllImport("KERNEL32.DLL")]
        public static extern int OpenProcess(PROCESS_RIGHTS dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern int NtSetInformationProcess(int processHandle,
           PROCESS_INFORMATION_CLASS processInformationClass, IntPtr processInformation, uint processInformationLength);

        [DllImport("kernel32.dll")]
        public static extern uint FormatMessage(uint dwFlags, IntPtr lpSource,
           uint dwMessageId, uint dwLanguageId, [Out] StringBuilder lpBuffer,
           uint nSize, IntPtr Arguments);

        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32")]
        public static extern long GetPrivateProfileString(string section, string key, string def,
            StringBuilder retVal, int size, string filepath);

        public static string GetLastError()
        {
            int i = Marshal.GetHRForLastWin32Error();
            return Marshal.GetExceptionForHR(i).Message;
        }
    }
}