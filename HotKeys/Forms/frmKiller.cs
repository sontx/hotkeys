using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using VirusTotal.Objects;
using System.Text;
namespace HotKeys.Forms
{
    public partial class frmKiller : Form
    {
        private Process[] pros;
        private byte[] GetAPIKey()
        {
            byte[] buff = { 102, 99, 53, 52, 56, 101, 48, 101, 100, 98, 99, 48,
                              102, 99, 56, 56, 54, 50, 102, 100, 55, 54, 101, 52,
                              48, 97, 99, 54, 54, 102, 52, 100, 97, 57, 102, 51,
                              98, 48, 48, 101, 52, 52, 50, 52, 54, 100, 57, 56,
                              100, 99, 48, 53, 100, 101, 50, 54, 102, 99, 99, 98,
                              53, 101, 56, 50 };
            return buff;
        }
        public void DecSort()
        {
            Process temp;
            for (int i = 0, j; i < pros.Length - 1; i++)
                for (j = i + 1; j < pros.Length; j++)
                    if (string.Compare(pros[i].ProcessName, pros[j].ProcessName, true) > 0)
                    {
                        temp = pros[i];
                        pros[i] = pros[j];
                        pros[j] = temp;
                    }
        }

        private void GetAllProcesses()
        {
            pros = Process.GetProcesses();
            DecSort();
            cmbProcess.Items.Clear();
            txtLocal.Text = null;
            txtStartAt.Text = null;
            txtDes.Text = null;
            labVirus.Text = "";
            labVirus.Visible = false;
            pic.Image = null;
            foreach (Process p in pros)
            {
                cmbProcess.Items.Add(p.ProcessName);
            }
        }

        private string GetProcessPath(Process pro)
        {
            return pro.MainModule.FileName;
        }

        private string GetStartAt(Process pro)
        {
            return pro.StartTime.ToString("hh:mm:ss dd/MM/yyyy");
        }

        private string GetDescription(Process pro)
        {
            return pro.MainModule.FileVersionInfo.FileDescription;
        }

        public frmKiller()
        {
            InitializeComponent();
            GetAllProcesses();
        }

        private void cmbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            Process p = pros[cmbProcess.SelectedIndex];
            try
            {
                txtLocal.Text = GetProcessPath(p);
                pic.Image = System.Drawing.Icon.ExtractAssociatedIcon(txtLocal.Text).ToBitmap();
            }
            catch (System.Exception ex)
            {
                txtLocal.Text = ex.Message;
                pic.Image = Properties.Resources.application_icon;
            }
            try
            {
                txtStartAt.Text = GetStartAt(p);
            }
            catch (System.Exception ex)
            {
                txtStartAt.Text = ex.Message;
            }
            try
            {
                txtDes.Text = GetDescription(p);
            }
            catch (System.Exception ex)
            {
                txtDes.Text = ex.Message;
            }
        }

        private void llabVirus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!File.Exists(txtLocal.Text)) return;
            labVirus.Text = "Wait...";
            Thread th = new Thread(() =>
            {
                try
                {
                    VirusTotal.VirusTotal vt = new VirusTotal.VirusTotal(Encoding.ASCII.GetString(GetAPIKey()));
                    FileInfo fi = new FileInfo(txtLocal.Text);
                    Report fileReport = vt.GetFileReport(fi);
                    if (fileReport.ResponseCode != ReportResponseCode.Present)
                    {
                        vt.ScanFile(fi);
                        fileReport = vt.GetFileReport(fi);
                    }
                    int countOfDetected = 0;
                    foreach (ScanEngine scan in fileReport.Scans)
                    {
                        if (scan.Detected) countOfDetected++;
                    }
                    Invoke((MethodInvoker)delegate
                    {
                        labVirus.ForeColor = countOfDetected > 0 ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                        labVirus.Text = string.Format("{0}/{1}", countOfDetected, fileReport.Scans.Count);
                        labVirus.Visible = true;
                        if (countOfDetected > 0)
                        {
                            frmVirusReport reportForm = new frmVirusReport(fileReport);
                            reportForm.Show(this);
                        }
                    });
                }
                catch
                {
                    Invoke((MethodInvoker)delegate
                    {
                        labVirus.ForeColor = System.Drawing.SystemColors.ControlText;
                        labVirus.Text = "Error!";
                    });
                }
            });
            th.IsBackground = true;
            th.Start();
        }

        private void bntRefresh_Click(object sender, EventArgs e)
        {
            GetAllProcesses();
        }

        private void bntKill_Click(object sender, EventArgs e)
        {
            string p = cmbProcess.SelectedItem.ToString();
            if (Tasks.KillProcess(p))
            {
                MessageBox.Show(p + " has been killed!", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAllProcesses();
            }
            else
            {
                MessageBox.Show(p + " hasn't been killed!", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}