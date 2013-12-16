using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS.Help
{
    public partial class frmUserManage : Form
    {
        public frmUserManage()
        {
            InitializeComponent();
        }

        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        private void frmUserManage_Load(object sender, EventArgs e)
        {
            DataSet myds = datacon.getds("select UserID as 用户编号,UserName as 用户名,UserPwd as 用户密码,"
                + "UserRight as 用户权限 from tb_User", "tb_User");
            dgvUInfo.DataSource=myds.Tables["tb_User"];
            doperate.cboxBind("select UserName from tb_User", "tb_User", "UserName", cboxUName);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int P_int_returnValue = doperate.InsertUser(cboxUName.Text.Trim(), txtUPwd.Text.Trim(), cboxURight.Text.Trim());
                if (P_int_returnValue == 100)
                {
                    MessageBox.Show("该用户已经存在", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("用户信息添加成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmUserManage_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                doperate.updateUser(Convert.ToInt32(dgvUInfo[0, dgvUInfo.CurrentCell.RowIndex].Value),
                    txtUPwd.Text.Trim(), cboxURight.Text.Trim());
                MessageBox.Show("用户信息修改成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmUserManage_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                datacon.getcom("delete from tb_User where UserID="
                    + Convert.ToString(dgvUInfo[0, dgvUInfo.CurrentCell.RowIndex].Value).Trim() + "");
                MessageBox.Show("删除用户信息成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmUserManage_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvUInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboxUName.Text = Convert.ToString(dgvUInfo[1,dgvUInfo.CurrentCell.RowIndex].Value).Trim();
            txtUPwd.Text = Convert.ToString(dgvUInfo[2, dgvUInfo.CurrentCell.RowIndex].Value).Trim();
            cboxURight.Text = Convert.ToString(dgvUInfo[3, dgvUInfo.CurrentCell.RowIndex].Value).Trim();
        }

        private void frmUserManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}