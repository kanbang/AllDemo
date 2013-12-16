using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace SMS.SysManage
{
    public partial class frmDataRevert : Form
    {
        public frmDataRevert()
        {
            InitializeComponent();
        }

        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        private void btnSel_Click(object sender, EventArgs e)
        {
            ofDialogFile.InitialDirectory = "D:\\";
            ofDialogFile.Filter = "bak files (*.bak)|*.bak";
            ofDialogFile.RestoreDirectory = true;
            ofDialogFile.ShowDialog();
            txtDRPath.Text = ofDialogFile.FileName.ToString().Trim();
        }

        private void btnDRevert_Click(object sender, EventArgs e)
        {
            try
            {
                datacon.getcom("use master restore database db_SMS from disk='" + txtDRPath.Text.Trim() + "'");
                MessageBox.Show("���ݻ�ԭ�ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDataRevert_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}