using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (txt1.Text=="test")
            {
                if (txt2.Text == "test")
                {
                    Form1 f = new Form1();
                    this.Hide();
                    f.Show();
                }
            }
        }
    }
}
