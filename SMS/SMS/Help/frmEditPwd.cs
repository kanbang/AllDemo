using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.Help
{
    public partial class frmEditPwd : Form
    {
        public frmEditPwd()
        {
            InitializeComponent();
        }
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        private void frmEditPwd_Load(object sender, EventArgs e)
        {
            txtUName.Text = SMS.frmLogin.M_str_name;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtFUNPwd.Text.Trim() != txtUNPwd.Text.Trim())
            {
                errorPrPwd.SetError(txtFUNPwd, "�������벻һ�£�");
            }
            else
            {
                if (txtUOPwd.Text.Trim() != SMS.frmLogin.M_str_pwd)
                {
                    MessageBox.Show("�û�����������������������룡", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    datacon.getcom("update tb_User set UserPwd='"+txtUNPwd.Text.Trim()+"'where UserName='"+txtUName.Text.Trim()+"'");
                    MessageBox.Show("�����޸ĳɹ���", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditPwd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}