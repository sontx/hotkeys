using System.Windows.Forms;

namespace HotKeys.Forms
{
    public partial class frmSettings : BaseForm
    {
        public frmSettings()
        {
            InitializeComponent();
            chkStartup.Checked = (bool)Properties.Settings.Default["AutoStartup"];
            chkTaskbar.Checked = (bool)Properties.Settings.Default["ShowInTaskbar"];
        }

        private void bntOK_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void chkStartup_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkStartup.Checked)
                Protector.SetAutoStartup();
            else
                Protector.RemAutoStartup();
            Properties.Settings.Default["AutoStartup"] = chkStartup.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkTaskbar_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkTaskbar.Checked)
                Tasks.ShowInTaskbar();
            else
                Tasks.HideInTaskbar();
            Properties.Settings.Default["ShowInTaskbar"] = chkTaskbar.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}