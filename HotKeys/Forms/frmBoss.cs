using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace HotKeys.Forms
{
    public partial class frmBoss : BaseForm
    {
        private Process[] processes;

        private string GetProcessPriorityClass(Process process)
        {
            try
            {
                return Enum.GetName(typeof(ProcessPriorityClass), process.PriorityClass);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string GetProcessCommand(Process process)
        {
            try
            {
                if (string.IsNullOrEmpty(process.StartInfo.FileName))
                    return process.MainModule.FileName;
                return string.Format("{0} {1}", process.StartInfo.FileName, process.StartInfo.Arguments);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private Bitmap GetProcessIcon(Process process)
        {
            try
            {
                Bitmap bitmap = Icon.ExtractAssociatedIcon(process.MainModule.FileName).ToBitmap();
                bitmap.Tag = "disposed";
                return bitmap;
            }
            catch (Exception)
            {
                return Properties.Resources.application_icon;
            }
        }

        private void ReleaseIcons()
        {
            foreach (Bitmap bitmap in imageList.Images)
            {
                if (bitmap.Tag != null && string.Compare("disposed", bitmap.Tag.ToString(), true) == 0)
                    bitmap.Dispose();
            }
            imageList.Images.Clear();
        }

        private void LoadProcesses()
        {
            processes = Process.GetProcesses();
            ReleaseIcons();
            lst.Items.Clear();
            Thread thread = new Thread(() =>
            {
                List<ProcessInfoHolder> holders = new List<ProcessInfoHolder>();
                foreach (Process process in processes)
                {
                    ProcessInfoHolder holder = new ProcessInfoHolder();
                    holder.name = process.ProcessName;
                    imageList.Images.Add(GetProcessIcon(process));
                    holder.pid = process.Id.ToString();
                    holder.priority = GetProcessPriorityClass(process);
                    holder.command = GetProcessCommand(process);
                    holders.Add(holder);
                }
                Invoke((MethodInvoker)delegate
                {
                    List<ProcessInfoHolder> _holders = holders;
                    lst.BeginUpdate();
                    int index = 0;
                    foreach (ProcessInfoHolder holder in _holders)
                    {
                        ListViewItem item = new ListViewItem(holder.name);
                        item.ImageIndex = index++;
                        ListViewSubItem pidItem = new ListViewSubItem(item, holder.pid);
                        ListViewSubItem priorityItem = new ListViewSubItem(item, holder.priority);
                        ListViewSubItem commandItem = new ListViewSubItem(item, holder.command);
                        item.SubItems.AddRange(new ListViewSubItem[] { pidItem, priorityItem, commandItem });
                        lst.Items.Add(item);
                    }
                    lst.EndUpdate();
                    txtName.Focus();
                });
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public frmBoss()
        {
            InitializeComponent();
            LoadProcesses();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ReleaseIcons();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private class ProcessInfoHolder
        {
            public string name;
            public string pid;
            public string priority;
            public string command;
        }

        private void MessageWarning(string message)
        {
            MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MessageInfo(string message)
        {
            MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void btnPriorityMax_Click(object sender, EventArgs e)
        {

        }

        private void btnPriorityNormal_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EnableInput(bool enable)
        {
            btnRefresh.Enabled = enable;
            btnClose.Enabled = enable;
            txtName.Enabled = enable;
            btnForceStop.Enabled = enable;
        }

        private string GetProcessInfo(Process process)
        {
            return string.Format("{0}[{1}]", process.ProcessName, process.Id);
        }

        private void btnForceStop_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim().ToUpper();
            if (name.Length > 0)
            {
                EnableInput(false);
                Thread thread = new Thread(() =>
                {
                    processes = Process.GetProcesses();
                    StringBuilder report = new StringBuilder();
                    foreach (Process process in processes)
                    {
                        string _name = process.ProcessName.ToUpper();
                        if (_name.Contains(name))
                        {
                            string processInfo = GetProcessInfo(process);
                            try
                            {
                                process.CloseMainWindow();
                                process.WaitForExit(1000);
                                if (!process.HasExited)
                                {
                                    process.Close();
                                    process.WaitForExit(5000);
                                }
                                if (!process.HasExited)
                                {
                                    process.Kill();
                                    process.WaitForExit(5000);
                                }
                                report.Append(process.HasExited ? string.Format("'{0}' has been KILL.", processInfo) : 
                                    string.Format("'{0}' could NOT KILL: unknown reason.", processInfo));
                            } catch(Exception ex)
                            {
                                report.Append(string.Format("'{0}' could NOT KILL: {1}.", processInfo, ex.Message));
                            }
                            report.Append(Environment.NewLine);
                        }
                    }
                    Invoke((MethodInvoker)delegate
                    {
                        if (report.Length > 0)
                        {
                            MessageInfo(report.ToString());
                            LoadProcesses();
                        }
                        else
                        {
                            MessageWarning("No process match!");
                        }
                        EnableInput(true);
                    });
                });
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            if (lst.SelectedItems.Count > 0)
            {
                Process process = processes[lst.SelectedIndices[0]];
                txtName.Text = process.ProcessName;
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnForceStop_Click(null, null);
        }
    }
}
