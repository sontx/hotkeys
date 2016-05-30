using System;
namespace HotKeys
{
    internal static class HotkeyRegistor
    {
        public static void Register()
        {
            /* mod key*/
            uint mod = (uint)(KEY_MOD.KEY1 | KEY_MOD.KEY2);
            IntPtr h = IntPtr.Zero;
            //next
            WinAPI.RegisterHotKey(h, (int)MEDIA_KEYNEXT.ID, mod, (uint)MEDIA_KEYNEXT.KEY);
            //back
            WinAPI.RegisterHotKey(h, (int)MEDIA_KEYBACK.ID, mod, (uint)MEDIA_KEYBACK.KEY);
            //pause
            WinAPI.RegisterHotKey(h, (int)MEDIA_KEYPAUSE.ID, mod, (uint)MEDIA_KEYPAUSE.KEY);
            //stop
            WinAPI.RegisterHotKey(h, (int)MEDIA_KEYSTOP.ID, mod, (uint)MEDIA_KEYSTOP.KEY);
            //volume up
            WinAPI.RegisterHotKey(h, (int)MEDIA_KEYVOLUMEUP.ID, mod, (uint)MEDIA_KEYVOLUMEUP.KEY);
            //volume down
            WinAPI.RegisterHotKey(h, (int)MEDIA_KEYVOLUMEDOWN.ID, mod, (uint)MEDIA_KEYVOLUMEDOWN.KEY);
            //volume mute
            WinAPI.RegisterHotKey(h, (int)MEDIA_KEYVOLUMEMUTE.ID, mod, (uint)MEDIA_KEYVOLUMEMUTE.KEY);
            //help
            WinAPI.RegisterHotKey(h, (int)KEY_HELP.ID, mod, (uint)KEY_HELP.KEY);
            //settings
            WinAPI.RegisterHotKey(h, (int)KEY_SETTINGS.ID, mod, (uint)KEY_SETTINGS.KEY);
            //exit
            WinAPI.RegisterHotKey(h, (int)KEY_EXIT.ID, mod, (uint)KEY_EXIT.KEY);
            //restart explorer
            WinAPI.RegisterHotKey(h, (int)KEY_RESTART_EXPLORER.ID, mod, (uint)KEY_RESTART_EXPLORER.KEY);
            //open taskmgr
            WinAPI.RegisterHotKey(h, (int)KEY_OPEN_TASKMGR.ID, mod, (uint)KEY_OPEN_TASKMGR.KEY);
            //open file
            WinAPI.RegisterHotKey(h, (int)KEY_OPEN_FILE.ID, mod, (uint)KEY_OPEN_FILE.KEY);
            //log off
            WinAPI.RegisterHotKey(h, (int)KEY_LOG_OFF.ID, mod, (uint)KEY_LOG_OFF.KEY);
            //restart system
            WinAPI.RegisterHotKey(h, (int)KEY_RESTART_SYSTEM.ID, mod, (uint)KEY_RESTART_SYSTEM.KEY);
            //killer
            WinAPI.RegisterHotKey(h, (int)KEY_KILLER.ID, mod, (uint)KEY_KILLER.KEY);
            //tools
            bool r= WinAPI.RegisterHotKey(h, (int)KEY_TOOLS.ID, mod, (uint)KEY_TOOLS.KEY);
        }

        public static void Unregister()
        {
            IntPtr h = IntPtr.Zero;
            WinAPI.UnregisterHotKey(h, (int)MEDIA_KEYNEXT.ID);
            WinAPI.UnregisterHotKey(h, (int)MEDIA_KEYBACK.ID);
            WinAPI.UnregisterHotKey(h, (int)MEDIA_KEYPAUSE.ID);
            WinAPI.UnregisterHotKey(h, (int)MEDIA_KEYSTOP.ID);
            WinAPI.UnregisterHotKey(h, (int)MEDIA_KEYVOLUMEUP.ID);
            WinAPI.UnregisterHotKey(h, (int)MEDIA_KEYVOLUMEDOWN.ID);
            WinAPI.UnregisterHotKey(h, (int)MEDIA_KEYVOLUMEMUTE.ID);
            WinAPI.UnregisterHotKey(h, (int)KEY_HELP.ID);
            WinAPI.UnregisterHotKey(h, (int)KEY_SETTINGS.ID);
            WinAPI.UnregisterHotKey(h, (int)KEY_EXIT.ID);
            WinAPI.UnregisterHotKey(h, (int)KEY_RESTART_EXPLORER.ID);
            WinAPI.UnregisterHotKey(h, (int)KEY_OPEN_TASKMGR.ID);
            WinAPI.UnregisterHotKey(h, (int)KEY_OPEN_FILE.ID);
            WinAPI.UnregisterHotKey(h, (int)KEY_LOG_OFF.ID);
            WinAPI.UnregisterHotKey(h, (int)KEY_RESTART_SYSTEM.ID);
            WinAPI.UnregisterHotKey(h, (int)KEY_KILLER.ID);
            WinAPI.UnregisterHotKey(h, (int)KEY_TOOLS.ID);
        }
    }
}