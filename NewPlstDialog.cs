using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MM_PlaylistEditor
{
    public partial class NewPlstDialog : Form
    {
        public NewPlstDialog()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            
        }
        public string GetResult()
        {
            return txtName.Text;
        }
    }
}
