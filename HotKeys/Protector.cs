using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

namespace HotKeys
{
    internal sealed class Protector
    {
        private const string HK_RUN = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";

        public static bool SetAutoStartup()
        {
            RegistryKey key = null;
            try
            {
                key = Registry.CurrentUser.OpenSubKey(HK_RUN,true);
                key.SetValue(Application.ProductName, Application.ExecutablePath, RegistryValueKind.String);
                key.Close();
                key = null;
            }
            catch
            {
                if (key != null) key.Close();
                return false;
            }
            return true;
        }

        public static void RemAutoStartup()
        {
            RegistryKey key = null;
            try
            {
                key = Registry.CurrentUser.OpenSubKey(HK_RUN,true);
                key.DeleteValue(Application.ProductName);
                key.Close();
                key = null;
            }
            catch
            {
            }
            if (key != null) key.Close();
        }

        public static bool ProtectProcess()
        {
            try
            {
                var rsd = new RawSecurityDescriptor(ControlFlags.None, new SecurityIdentifier(
                    WellKnownSidType.LocalSystemSid, null), null, null, new RawAcl(2, 0));
                rsd.SetFlags(ControlFlags.DiscretionaryAclPresent | ControlFlags.DiscretionaryAclDefaulted);
                var rawsd = new byte[rsd.BinaryLength];
                rsd.GetBinaryForm(rawsd, 0);
                return WinAPI.SetKernelObjectSecurity(WinAPI.GetCurrentProcess(), SecurityInfos.DiscretionaryAcl, rawsd) != 0;
            }
            catch
            {
                return false;
            }
        }

        unsafe static public bool ProcessPriority(int priority)
        {
            return WinAPI.NtSetInformationProcess(Process.GetCurrentProcess().Id,
                PROCESS_INFORMATION_CLASS.ProcessIoPriority, (IntPtr)(&priority), 4) != 0;
        }
    }
}