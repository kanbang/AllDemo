using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
//download by http://www.codefans.net
namespace SMS
{
    public partial class frmLogin : Form
    {
        public static string M_str_name;//记录登录用户名字
        public static string M_str_pwd;//记录登录用户密码
        public static string M_str_right;//记录登录用户的权限
        BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        public frmLogin()
        {
            InitializeComponent();
        }
 
        private void frmLogin_Load(object sender, EventArgs e)
        {
            doperate.cboxBind("select UserName from tb_User", "tb_User", "UserName", cboxUName);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //int P_int_returnValue = doperate.UserLogin(cboxUName.Text.Trim(), txtPwd.Text.Trim());
            //if (P_int_returnValue == 100)
           // {
                M_str_name = cboxUName.Text;
                M_str_pwd = txtPwd.Text.Trim();
                frmMain fmain = new frmMain();
                this.Hide();
                fmain.Show();
            //}
            //if (P_int_returnValue == -100)
            //{
            //	MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //	txtPwd.Text = "";
            ///	cboxUName.Focus();
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cboxUName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLiteDataReader sqlread = datacon.getread("select UserName,UserRight from tb_User where UserName='" + cboxUName.Text + "'");
            if (sqlread.Read())
            {
                labURight.Text = sqlread["UserRight"].ToString();
                M_str_right = labURight.Text;
            }
            sqlread.Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}