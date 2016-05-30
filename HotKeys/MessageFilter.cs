using System.Security.Permissions;
using System.Windows.Forms;

namespace HotKeys
{
    internal class MessageFilter : IMessageFilter
    {
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != 0x312) return false;
            switch (m.WParam.ToInt32())
            {
                case (int)MEDIA_KEYNEXT.ID:
                    Tasks.MediaNext();
                    break;

                case (int)MEDIA_KEYBACK.ID:
                    Tasks.MediaBack();
                    break;

                case (int)MEDIA_KEYPAUSE.ID:
                    Tasks.MediaPause();
                    break;

                case (int)MEDIA_KEYSTOP.ID:
                    Tasks.MediaStop();
                    break;

                case (int)MEDIA_KEYVOLUMEUP.ID:
                    Tasks.MediaVolumeUp();
                    break;

                case (int)MEDIA_KEYVOLUMEDOWN.ID:
                    Tasks.MediaVolumeDown();
                    break;

                case (int)MEDIA_KEYVOLUMEMUTE.ID:
                    Tasks.MediaVolumeMute();
                    break;

                case (int)KEY_HELP.ID:
                    Tasks.Help();
                    break;

                case (int)KEY_SETTINGS.ID:
                    Tasks.Settings();
                    break;

                case (int)KEY_EXIT.ID:
                    Tasks.Exit();
                    break;

                case (int)KEY_RESTART_EXPLORER.ID:
                    Tasks.RestartExplorer();
                    break;

                case (int)KEY_OPEN_TASKMGR.ID:
                    Tasks.OpenTaskMgr();
                    break;

                case (int)KEY_OPEN_FILE.ID:
                    Tasks.OpenFile();
                    break;

                case (int)KEY_LOG_OFF.ID:
                    Tasks.LogOff();
                    break;

                case (int)KEY_RESTART_SYSTEM.ID:
                    Tasks.RestartSystem();
                    break;

                case (int)KEY_KILLER.ID:
                    Tasks.Killer();
                    break;

                case (int)KEY_BOSS.ID:
                    Tasks.Boss();
                    break;

                case (int)KEY_TOOLS.ID:
                    Tasks.Tools();
                    break;
            }
            return true;
        }
    }
}