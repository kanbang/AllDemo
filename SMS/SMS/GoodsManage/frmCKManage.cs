using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace SMS.GoodsManage
{
    public partial class frmCKManage : Form
    {
        public int M_int_GNum;
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        public frmCKManage()
        {
            InitializeComponent();
        }

        private void frmCKManage_Load(object sender, EventArgs e)
        {
            dgvCGManage.Controls.Add(hScrollBar1);
            doperate.cboxBind("select GoodsID from tb_GoodsInfo", "tb_GoodsInfo", "GoodsID", cboxGID);
            DataSet myds = datacon.getds("select CheckID as 盘点编号,GoodsID as 货物编号,StoreName as 仓库名称,"
                + "GoodsName as 货物名称,GoodsUnit as 计量单位,CheckNum as 盘点数量,PALNum as 盈亏数量,CheckDate as 盘点日期,"
                + "CheckPeople as 盘点人,CheckRemark as 备注,Editer as 修改人,EditDate as 修改日期 from tb_Check", "tb_Check");
            dgvCGManage.DataSource = myds.Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!doperate.validateNum(txtCKNum.Text.Trim()))
                {
                    errorPrRNum.SetError(txtCKNum, "输入必须为数字！");
                }
                else
                {
                    errorPrRNum.Clear();
                    int P_int_returnValue = doperate.InsertCheck(Convert.ToInt32(cboxGID.Text.Trim()), txtSName.Text.Trim(),
                         txtGName.Text.Trim(), cboxGUnit.Text.Trim(), Convert.ToInt32(txtCKNum.Text.Trim()),
                         Convert.ToInt32(txtPALNum.Text.Trim()), txtCGPeople.Text.Trim(), txtCGRemark.Text.Trim());
                    if (P_int_returnValue == 100)
                    {
                        MessageBox.Show("这批产品已经过盘点，您可以对盘点结果进行修改！",
                            "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("盘点货物成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmCKManage_Load(sender, e);
                    }
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
                if (!doperate.validateNum(txtCKNum.Text.Trim()))
                {
                    errorPrRNum.SetError(txtCKNum, "输入必须为数字！");
                }
                else
                {
                    errorPrRNum.Clear();
                    datacon.getcom("update tb_Check set CheckNum=" + txtCKNum.Text.Trim() + ",PALNum=" + txtPALNum.Text.Trim()
                        + ",CheckPeople='" + txtCGPeople.Text.Trim() + "',CheckRemark='" + txtCGRemark.Text.Trim()
                        + "',Editer='" + SMS.frmLogin.M_str_name + "',EditDate='" + DateTime.Now.ToShortDateString() + "'where CheckID="
                        + Convert.ToString(dgvCGManage[0, dgvCGManage.CurrentCell.RowIndex].Value).Trim() + "");
                    MessageBox.Show("货物盘点资料修改成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmCKManage_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                datacon.getcom("delete from tb_Check where CheckID="
                    + Convert.ToString(dgvCGManage[0, dgvCGManage.CurrentCell.RowIndex].Value).Trim() + "");
                MessageBox.Show("货物盘点资料删除成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCKManage_Load(sender,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCGManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboxGID.Text = Convert.ToString(dgvCGManage[1, dgvCGManage.CurrentCell.RowIndex].Value).Trim();
            txtSName.Text = Convert.ToString(dgvCGManage[2, dgvCGManage.CurrentCell.RowIndex].Value).Trim();
            txtGName.Text = Convert.ToString(dgvCGManage[3, dgvCGManage.CurrentCell.RowIndex].Value).Trim();
            cboxGUnit.Text = Convert.ToString(dgvCGManage[4, dgvCGManage.CurrentCell.RowIndex].Value).Trim();
            txtCKNum.Text = Convert.ToString(dgvCGManage[5, dgvCGManage.CurrentCell.RowIndex].Value).Trim();
            txtPALNum.Text = Convert.ToString(dgvCGManage[6, dgvCGManage.CurrentCell.RowIndex].Value).Trim();
            txtCGPeople.Text = Convert.ToString(dgvCGManage[8, dgvCGManage.CurrentCell.RowIndex].Value).Trim();
            txtCGRemark.Text = Convert.ToString(dgvCGManage[9, dgvCGManage.CurrentCell.RowIndex].Value).Trim();
        }

        private void cboxGID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxGID.Text == "System.Data.DataRowView")
            {
            }
            else
            {
                SQLiteDataReader sqlread = datacon.getread("select GoodsName,StoreName,GoodsUnit,GoodsNum from tb_GoodsInfo"
                    + " where GoodsID=" + Convert.ToInt32(cboxGID.Text.Trim()) + "");
                if (sqlread.Read())
                {
                    txtSName.Text = sqlread["StoreName"].ToString().Trim();
                    txtGName.Text = sqlread["GoodsName"].ToString().Trim();
                    cboxGUnit.Text = sqlread["GoodsUnit"].ToString().Trim();
                    M_int_GNum = Convert.ToInt32(sqlread["GoodsNum"].ToString().Trim());
                }
                sqlread.Close();
            }
        }

        private void txtCKNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtPALNum.Text = Convert.ToString(Convert.ToInt32(txtCKNum.Text.Trim()) - M_int_GNum).Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmCKManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}