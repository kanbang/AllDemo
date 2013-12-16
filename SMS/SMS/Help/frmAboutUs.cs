using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SMS.Help
{
    public partial class frmAboutUs : Form
    {
        public frmAboutUs()
        {
            InitializeComponent();
        }

        private void frmAboutUs_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\AboutUs.txt";
            System.IO.StreamReader reader = new System.IO.StreamReader(path, System.Text.Encoding.Default);
            this.txtAboutUs.Text = reader.ReadToEnd();
            reader.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAboutUs_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}