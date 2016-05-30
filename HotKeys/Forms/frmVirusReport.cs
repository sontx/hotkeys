using System;
using System.Windows.Forms;
using VirusTotal.Objects;

namespace HotKeys.Forms
{
    public partial class frmVirusReport : BaseForm
    {
        public frmVirusReport(Report fileReport)
        {
            InitializeComponent();
            foreach (ScanEngine scan in fileReport.Scans)
            {
                if (scan.Detected)
                {
                    ListViewItem item = new ListViewItem(scan.Name);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, scan.Result));
                    lst.Items.Add(item);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
