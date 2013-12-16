using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SMS.SysManage
{
    public partial class frmDataStore : Form
    {
        public frmDataStore()
        {
            InitializeComponent();
        }

        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        private void btnSel_Click(object sender, EventArgs e)
        {
            fbDialogFile.ShowDialog();
            txtDSPath.Text = fbDialogFile.SelectedPath.ToString().Trim()+"\\";
        }

        private void btnDStore_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(txtDSPath.Text.Trim() + ".bak"))
                {
                    MessageBox.Show("该文件已经存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDSPath.Text = "";
                    txtDSPath.Focus();
                }
                else
                {
                    datacon.getcom("backup database db_SMS to disk='" + txtDSPath.Text.Trim() + ".bak'");
                    MessageBox.Show("数据备份成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDataStore_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}