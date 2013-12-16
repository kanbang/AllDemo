using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
namespace SMS.Help
{
    public partial class frmRightManage : Form
    {
        public frmRightManage()
        {
            InitializeComponent();
        }
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        private void frmRightManage_Load(object sender, EventArgs e)
        {
            doperate.cboxBind("select UserName from tb_User", "tb_User", "UserName", cboxUName);
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            datacon.getcom("update tb_User set UserRight='" 
                + cboxURight.Text.Trim() + "'where UserName='" + cboxUName.Text.Trim() + "'");
            MessageBox.Show("权限修改成功！","信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboxUName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLiteDataReader sqlread = datacon.getread("select UserName,UserRight from tb_User "
                + "where UserName='" + cboxUName.Text + "'");
            if (sqlread.Read())
            {
                cboxURight.Text = sqlread["UserRight"].ToString().Trim();
            }
            sqlread.Close();
        }

        private void frmRightManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}