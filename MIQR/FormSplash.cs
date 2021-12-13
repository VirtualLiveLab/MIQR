using System.Drawing;
using System.Windows.Forms;

namespace MIQR
{
    public partial class FormSplash : Form
    {
        public FormSplash()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.smn;
        }
    }
}