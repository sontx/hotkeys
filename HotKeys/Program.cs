using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace HotKeys
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Tasks.LoadSettings();
            HotkeyRegistor.Unregister();
            HotkeyRegistor.Register();
            Application.AddMessageFilter(new MessageFilter());
            Application.Run();
            HotkeyRegistor.Unregister();
        }
    }
}