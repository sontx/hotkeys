/************************************************************************/
/* [application1]
 * name=name
 * path=path
 * [appsgroup1]
 * name=group name
 * name1=name1
 * path1=path1
 * name2=name2
 * path2=path2
 * ...........
/************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;
namespace HotKeys
{
    internal class ToolsListImporter
    {
        private string path;
        protected List<Object> sections = new List<Object>();
        private const int MAX_MEMBERS = 50;
        private const string SEC_APPLICATION = "application";
        private const string SEC_APPSGROUP = "appsgroup";
        private const string KEY_NAME = "name";
        private const string KEY_PATH = "path";

        protected class App
        {
            public string Name;
            public string Path;
        }

        protected class AppsGroup
        {
            public string Name;
            public List<App> Apps;
        }

        private string ReadINI(string section, string key)
        {
            StringBuilder sb = new StringBuilder(255);
            WinAPI.GetPrivateProfileString(section, key, null, sb, sb.Capacity, path);
            return sb.ToString();
        }

        private void WriteINI(string section, string key, string value)
        {
            WinAPI.WritePrivateProfileString(section, key, value, path);
        }

        /// <summary>
        /// Nhập cấu nội dung file ini với cấu trúc đã đc định nghĩa vào list
        /// </summary>
        protected void ImportINI()
        {
            string s;
            App app;
            AppsGroup apps;
            //quyet tu 1 -> max_members, cai nao la app or appsgroup thi add vao list
            for (int i = 1; i <= MAX_MEMBERS; i++)
            {
                s = ReadINI(SEC_APPLICATION + i.ToString(), KEY_NAME);
                if (!string.IsNullOrWhiteSpace(s))//la 1 app
                {
                    app = new App();
                    app.Name = s;
                    app.Path = ReadINI(SEC_APPLICATION + i.ToString(), KEY_PATH);
                    sections.Add(app);
                }
                s = ReadINI(SEC_APPSGROUP + i.ToString(), KEY_NAME);
                if (!string.IsNullOrWhiteSpace(s))//la 1 appsgroup
                {
                    apps = new AppsGroup();
                    apps.Name = s;
                    apps.Apps = new List<App>();
                    for (int j = 1; j <= MAX_MEMBERS; j++)//import cac apps trong 1 group
                    {
                        s = ReadINI(SEC_APPSGROUP + i.ToString(), KEY_NAME + j.ToString());
                        if (!string.IsNullOrWhiteSpace(s))//la 1 app
                        {
                            app = new App();
                            app.Name = s;
                            app.Path = ReadINI(SEC_APPSGROUP + i.ToString(), KEY_PATH + j.ToString());
                            apps.Apps.Add(app);
                        }
                    }
                    sections.Add(apps);
                }
            }
        }

        public ToolsListImporter(string path)
        {
            this.path =Path.GetFullPath(path);
        }
    }

    internal class ToolsList:ToolsListImporter,IDisposable
    {
        private ContextMenu menu = null;
        private _Form form=new _Form();
        private Point point;
        private class _MenuItem:MenuItem
        {
            public string Path;
            public string Group;
            public _MenuItem(string text,string path, EventHandler onClick)
                :base(text,onClick)
            {
                this.Path = path;
                Group = null;
            }
            public _MenuItem(string text, string path,string group, EventHandler onClick)
                : base(text, onClick)
            {
                this.Path = path;
                this.Group = group;
            }
        }
        private class _Form : Form
        { 
            public _Form()
            {
                Opacity = 0.01;
                ShowInTaskbar = false;
                FormBorderStyle = FormBorderStyle.None;
                Size = new System.Drawing.Size(1, 1);
                TopMost = true;
            }
        }
        private void BuildMenu()
        {
            App app;
            AppsGroup apps;
            menu = new ContextMenu();
            _MenuItem item;
            foreach(Object obj in sections)
            {
                //them 1 application vao menu
                app = obj as App;
                if(app!=null)
                {
                    menu.MenuItems.Add(new _MenuItem(app.Name,app.Path,MenuItemClick));
                    continue;
                }
                //them 1 applications group vao menu
                apps = obj as AppsGroup;
                item = new _MenuItem(apps.Name, null, apps.Name,MenuItemClick);
                //them cac applications vao group menu do
                foreach(App a in apps.Apps)
                {
                    item.MenuItems.Add(new _MenuItem(a.Name, a.Path,apps.Name, MenuItemClick));
                }
                menu.MenuItems.Add(item);
            }
            RECT rect;
            WinAPI.GetWindowRect(new HandleRef(form, menu.Handle), out rect);
            point = new Point(0, Screen.PrimaryScreen.Bounds.Bottom - rect.Top + rect.Bottom);
        }
        private void MenuItemClick(object sender,EventArgs e)
        {
            _MenuItem item = sender as _MenuItem;
            if (item == null) return;
            if(!File.Exists(item.Path))
            {
                MessageBox.Show(string.Format("'{0}' not found!", item.Name), 
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Process.Start(item.Path);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message,Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void Dispose()
        {
            if (menu != null)
            {
                menu.Dispose();
                menu = null;
            }
            if(form!=null)
            {
                form.Dispose();
                form = null;
            }
        }
        public void Show()
        {
            form.Show();
            form.Location = point;
            menu.Show(form,point);
            form.Hide();
        }
        public ToolsList(string path):base(path)
        {
            ImportINI();
            BuildMenu();
        }
    }
}