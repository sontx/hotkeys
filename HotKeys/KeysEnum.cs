using System.Windows.Forms;

namespace HotKeys
{
    internal enum KEYS_ENUM : uint
    {
        ALT = 0x1,
        CTRL = 0x2,
        SHIFT = 0x4,
        BACKSPACE = Keys.Back,
        DEL = Keys.Delete,
        SPACE = Keys.Space,
        TAB = Keys.Tab,
        LEFT = Keys.Left,
        RIGHT = Keys.Right,
        UP = Keys.Up,
        DOWN = Keys.Down,
        ESC = Keys.Escape,
        F1 = Keys.F1,
        F2 = Keys.F2,
        F3 = Keys.F3,
        F4 = Keys.F4,
        F5 = Keys.F5,
        F6 = Keys.F6,
        F7 = Keys.F7,
        F8 = Keys.F8,
        F9 = Keys.F9,
        F10 = Keys.F10,
        F11 = Keys.F11,
        F12 = Keys.F12,
    }

    internal enum KEY_MOD : uint
    {
        KEY1 = KEYS_ENUM.CTRL,
        KEY2 = KEYS_ENUM.ALT
    }

    internal enum MEDIA_KEYNEXT : uint
    {
        KEY = KEYS_ENUM.LEFT,
        ID = 0x1
    }

    internal enum MEDIA_KEYBACK : uint
    {
        KEY = KEYS_ENUM.RIGHT,
        ID = 0x2
    }

    internal enum MEDIA_KEYPAUSE : uint
    {
        KEY = KEYS_ENUM.SPACE,
        ID = 0x3
    }

    internal enum MEDIA_KEYSTOP : uint
    {
        KEY = KEYS_ENUM.DEL,
        ID = 0x4
    }

    internal enum MEDIA_KEYVOLUMEUP : uint
    {
        KEY = KEYS_ENUM.UP,
        ID = 0x5
    }

    internal enum MEDIA_KEYVOLUMEDOWN : uint
    {
        KEY = KEYS_ENUM.DOWN,
        ID = 0x6
    }

    internal enum MEDIA_KEYVOLUMEMUTE : uint
    {
        KEY = KEYS_ENUM.BACKSPACE,
        ID = 0x7
    }

    internal enum KEY_HELP : uint
    {
        KEY = KEYS_ENUM.F1,
        ID = 0x8
    }

    internal enum KEY_SETTINGS : uint
    {
        KEY = Keys.S,
        ID = 0x9
    }

    internal enum KEY_EXIT : uint
    {
        KEY = KEYS_ENUM.ESC,
        ID = 0xA
    }

    internal enum KEY_RESTART_EXPLORER : uint
    {
        KEY = KEYS_ENUM.F2,
        ID = 0xB
    }

    internal enum KEY_OPEN_TASKMGR : uint
    {
        KEY = KEYS_ENUM.F3,
        ID = 0xC
    }

    internal enum KEY_OPEN_FILE : uint
    {
        KEY = KEYS_ENUM.F4,
        ID = 0xD
    }

    internal enum KEY_LOG_OFF : uint
    {
        KEY = KEYS_ENUM.F5,
        ID = 0xE
    }

    internal enum KEY_RESTART_SYSTEM : uint
    {
        KEY = KEYS_ENUM.F6,
        ID = 0xF
    }

    internal enum KEY_KILLER : uint
    {
        KEY = Keys.K,
        ID = 0x10
    }

    internal enum KEY_BOSS : uint
    {
        KEY = Keys.B,
        ID = 0x11
    }

    internal enum KEY_TOOLS : uint
    {
        KEY = Keys.X,
        ID = 0x12
    }
}