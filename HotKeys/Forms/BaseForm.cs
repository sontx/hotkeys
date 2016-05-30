using System.Windows.Forms;

namespace HotKeys.Forms
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            KeyPreview = true;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == (char)Keys.Escape)
                Close();
        }
    }
}
