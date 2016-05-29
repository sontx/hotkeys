using System;
using System.Windows.Forms;

namespace HotKeys
{
    internal class TaskBar : IDisposable
    {
        private NotifyIcon icon = null;
        private ContextMenu menu = null;
        private const int TIMEOUT = 1000;

        private void InitMenu()
        {
            MenuItem item1 = new MenuItem("Settings", MenuClick);
            MenuItem item2 = new MenuItem("Help", MenuClick);
            MenuItem item3 = new MenuItem("About", MenuClick);
            MenuItem itemsp1 = new MenuItem("-");
            MenuItem item4 = new MenuItem("Exit", MenuClick);
            item1.Name = "mnSettings";
            item2.Name = "mnHelp";
            item3.Name = "mnAbout";
            item4.Name = "mnExit";
            menu = new ContextMenu(new MenuItem[] { item1, item2, item3, itemsp1, item4 });
            icon.ContextMenu = menu;
        }

        public TaskBar()
        {
            icon = new NotifyIcon();
            icon.Text = Application.ProductName;
            icon.Icon = Properties.Resources.icon;
            icon.Visible = true;
            icon.ShowBalloonTip(TIMEOUT, Application.
                ProductName, "I'm showing your system tray!", ToolTipIcon.Info);
            InitMenu();
        }

        private void MenuClick(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            if (item == null) return;
            switch (item.Name)
            {
                case "mnSettings":
                    Tasks.Settings();
                    break;

                case "mnHelp":
                    Tasks.Help();
                    break;

                case "mnAbout":
                    MessageBox.Show("Hotkeys v4\nAuthor: Gin.\nContact: xuanson33bk@gmail.com\nThanks for: Genbox and RestSharp.org"
                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "mnExit":
                    Tasks.Exit();
                    break;
            }
        }

        public void Dispose()
        {
            menu.Dispose();
            menu = null;
            icon.Visible = false;
            icon.Dispose();
            icon = null;
            GC.Collect();
        }
    }
}