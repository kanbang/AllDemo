using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.SysManage
{
    public partial class frmDataCut : Form
    {
        public frmDataCut()
        {
            InitializeComponent();
        }

        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        private void frmDataCut_Load(object sender, EventArgs e)
        {
            if (txtDCPath.Text != "" && txtFile.Text != "")
            {
                btnFCut.Enabled = true;
            }
        }

        private void btnSFile_Click(object sender, EventArgs e)
        {
            ofDialogFile.InitialDirectory = "C:\\";
            ofDialogFile.Filter = "all files (*.*)|*.*";
            ofDialogFile.RestoreDirectory = true;
            ofDialogFile.ShowDialog();
            txtFile.Text = ofDialogFile.FileName.ToString().Trim();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            fbDialogPath.ShowDialog();
            txtDCPath.Text = fbDialogPath.SelectedPath.ToString().Trim()+"\\";
        }

        private void btnDCut_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要压缩数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    datacon.getcom("dbcc shrinkdatabase (db_SMS,10)");
                    MessageBox.Show("数据压缩成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFCut_Click(object sender, EventArgs e)
        {
            try
            {
                doperate.compressFile(txtFile.Text.Trim(), txtDCPath.Text.Trim() + ".rar");
                MessageBox.Show("文件压缩成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnDCut.Enabled = true;
            txtDCPath.ReadOnly = true;
            btnFCut.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDataCut_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void txtDCPath_TextChanged(object sender, EventArgs e)
        {
            txtDCPath.ReadOnly = false;
            btnFCut.Enabled = true;
            btnDCut.Enabled = false;
        }
    }
}