using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace HotKeys
{
    internal static class Tasks
    {
        private static TaskBar icon = null;
        private static ToolsList tools;

        static Tasks()
        {
            tools = new ToolsList(Properties.Settings.Default["ConfigINI"].ToString());
        }

        private static void SendKey(byte key)
        {
            WinAPI.keybd_event(key, 0, 0, 0);
            WinAPI.keybd_event(key, 0, 0x2, 0);
        }

        public static bool KillProcess(string name)
        {
            Process[] ps = Process.GetProcessesByName(name);
            if (ps == null) return false;
            if (ps.Length < 1) return false;
            foreach (Process p in ps)
            {
                try
                {
                    p.CloseMainWindow();
                    p.WaitForExit(5000);
                    if (p.HasExited) continue;
                    p.Close();
                    p.WaitForExit(5000);
                    if (p.HasExited) continue;
                    p.Kill();
                }
                catch { }
            }
            foreach (Process p in ps)
            {
                try
                {
                    if (!p.HasExited) return false;
                }
                catch { }
            }
            ps = null;
            GC.Collect();
            return true;
        }

        public static void LoadSettings()
        {
            if ((bool)Properties.Settings.Default["AutoStartup"])
                Protector.SetAutoStartup();
            else
                Protector.RemAutoStartup();
            if ((bool)Properties.Settings.Default["ShowInTaskbar"])
                ShowInTaskbar();
            else
                HideInTaskbar();
        }

        public static void ShowTools()
        {
            tools.Show();
        }

        public static void ShowInTaskbar()
        {
            if (icon != null) return;
            icon = new TaskBar();
        }

        public static void HideInTaskbar()
        {
            if (icon == null) return;
            icon.Dispose();
            icon = null;
        }

        private static bool RunApp(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static bool OpenFile(string path)
        {
            try
            {
                Process.Start("explorer", path);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static bool EnableShutdown()
        {
            IntPtr hToken;
            LARGE_INTEGER luid;
            TOKEN_PRIVILEGES mPriv;
            try
            {
                if (!WinAPI.OpenProcessToken(Process.GetCurrentProcess().Handle, 0x20 | 0x8, out hToken)) return false;
                luid = new LARGE_INTEGER();
                if (WinAPI.LookupPrivilegeValue(null, "SeShutdownPrivilege", luid) != 0) throw new Exception();
                mPriv = new TOKEN_PRIVILEGES();
                mPriv.PrivilegeCount = 1;
                mPriv.Privileges[0].Attributes = 0x2;
                mPriv.Privileges[0].Luid = luid;
                if (!WinAPI.AdjustTokenPrivileges(hToken, false, ref mPriv, (uint)(4 +
                    (12 * mPriv.PrivilegeCount)), IntPtr.Zero, IntPtr.Zero)) throw new Exception();
            }
            catch
            {
                GC.Collect();
                return false;
            }
            GC.Collect();
            return true;
        }

        //next
        public static void MediaNext()
        {
            SendKey(0xB0);
        }

        //back
        public static void MediaBack()
        {
            SendKey(0xB1);
        }

        //pause
        public static void MediaPause()
        {
            SendKey(0xB3);
        }

        //stop
        public static void MediaStop()
        {
            SendKey(0xB2);
        }

        //volume up
        public static void MediaVolumeUp()
        {
            SendKey(0xAF);
        }

        //volume down
        public static void MediaVolumeDown()
        {
            SendKey(0xAE);
        }

        //volume mute
        public static void MediaVolumeMute()
        {
            SendKey(0xAD);
        }

        //help
        public static void Help()
        {
            string s = null;
            string sp = "....................................................." + Environment.NewLine;

            s += "Modifier Keys: CTRL + ALT" + Environment.NewLine;
            s += (Keys)KEY_HELP.KEY + " \t Show Help" + Environment.NewLine;
            s += (Keys)KEY_SETTINGS.KEY + " \t Show Settings" + Environment.NewLine;
            s += ((Keys)KEY_EXIT.KEY).ToString().ToUpper() + " \t Exit Program" + Environment.NewLine;
            s += sp;
            s += "Media Hotkeys." + Environment.NewLine;
            s += sp;
            s += ((Keys)MEDIA_KEYNEXT.KEY).ToString().ToUpper() + " \t Next" + Environment.NewLine;
            s += ((Keys)MEDIA_KEYBACK.KEY).ToString().ToUpper() + " \t Back" + Environment.NewLine;
            s += ((Keys)MEDIA_KEYPAUSE.KEY).ToString().ToUpper() + " \t Pause" + Environment.NewLine;
            s += ((Keys)MEDIA_KEYSTOP.KEY).ToString().ToUpper() + " \t Stop" + Environment.NewLine;
            s += ((Keys)MEDIA_KEYVOLUMEUP.KEY).ToString().ToUpper() + " \t Increase The Volume" + Environment.NewLine;
            s += ((Keys)MEDIA_KEYVOLUMEDOWN.KEY).ToString().ToUpper() + " \t Decrease The Volume" + Environment.NewLine;
            s += ((Keys)MEDIA_KEYVOLUMEMUTE.KEY).ToString().ToUpper() + " \t Muting" + Environment.NewLine;
            s += sp;
            s += "System Hotkeys." + Environment.NewLine;
            s += sp;
            s += (Keys)KEY_RESTART_EXPLORER.KEY + " \t Restart explorer" + Environment.NewLine;
            s += (Keys)KEY_OPEN_TASKMGR.KEY + " \t Open Task Manager" + Environment.NewLine;
            s += (Keys)KEY_OPEN_FILE.KEY + " \t Open Any File" + Environment.NewLine;
            s += (Keys)KEY_LOG_OFF.KEY + " \t Logoff System" + Environment.NewLine;
            s += (Keys)KEY_RESTART_SYSTEM.KEY + " \t Restart System" + Environment.NewLine;
            s += (Keys)KEY_KILLER.KEY + " \t Show Killer" + Environment.NewLine;
            s += (Keys)KEY_BOSS.KEY + " \t Show Boss" + Environment.NewLine;
            s += (Keys)KEY_TOOLS.KEY + " \t Show Tools Menu" + Environment.NewLine;
            s += sp;
            s += "Author: Gin.";
            MessageBox.Show(s, Application.ProductName + " - Help"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            GC.Collect();
        }

        //settings
        public static void Settings()
        {
            using (Forms.frmSettings f = new Forms.frmSettings())
            {
                f.ShowDialog();
                f.Dispose();
                GC.Collect();
            }
        }

        //exit
        public static void Exit()
        {
            HotkeyRegistor.Unregister();
            HideInTaskbar();
            Application.ExitThread();
        }

        //restart explorer
        public static void RestartExplorer()
        {
            KillProcess("explorer");
            RunApp("explorer");
        }

        //open taskmgr
        public static void OpenTaskMgr()
        {
            RunApp("taskmgr");
        }

        //open file
        public static void OpenFile()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select any file!";
                dlg.Filter = "Executable files|*.exe|All files|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    OpenFile(dlg.FileName);
                }
            }
            GC.Collect();
        }

        //log off
        public static void LogOff()
        {
            WinAPI.ExitWindowsEx(4, 0);
        }

        //restart system
        public static void RestartSystem()
        {
            if (!EnableShutdown())
            {
                MessageBox.Show("Can't restart your system!",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            WinAPI.ExitWindowsEx(6, 0);
        }

        //killer
        public static void Killer()
        {
            using (Forms.frmKiller f = new Forms.frmKiller())
            {
                f.ShowDialog();
                f.Dispose();
                GC.Collect();
            }
        }

        public static void Boss()
        {
            using (Forms.frmBoss f = new Forms.frmBoss())
            {
                f.ShowDialog();
                f.Dispose();
                GC.Collect();
            }
        }

        public static void Tools()
        {
            ShowTools();
        }
    }
}