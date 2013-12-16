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
    public partial class frmRGManage : Form
    {
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        public frmRGManage()
        {
            InitializeComponent();
        }
        
        private void frmRGManage_Load(object sender, EventArgs e)
        {
            dgvRGManage.Controls.Add(hScrollBar1);
            doperate.cboxBind("select BGID from tb_BorrowGoods", "tb_BorrowGoods", "BGID", cboxBGID);
            DataSet myds = datacon.getds("select RGID as 还货编号,BGID as 借货编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                + "GoodsSpec as 货物规格, RGNum as 归还数量,NRGNum as 未归还数量,RGDate as 还货日期,HandlePeople as 经手人,"
                + "RGPeople as 还货人,RGRemark as 备注,Editer as 修改人,EditDate as 修改日期 from tb_ReturnGoods", "tb_ReturnGoods");
            dgvRGManage.DataSource = myds.Tables["tb_ReturnGoods"];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteDataReader sqlread = datacon.getread("select GoodsNum from tb_BorrowGoods"
                    + " where BGID=" + Convert.ToInt32(cboxBGID.Text.Trim()) + "");
                if (sqlread.Read())
                {
                    if (Convert.ToInt32(txtRGNum.Text.Trim()) > Convert.ToInt32(sqlread["GoodsNum"].ToString().Trim()))
                    {
                        MessageBox.Show("您借的货物数目为" + Convert.ToInt32(sqlread["GoodsNum"].ToString().Trim())
                            + "，请重新填写还货的数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRGNum.Text = "";
                        txtRGNum.Focus();
                    }
                    else
                    {
                        datacon.getcom("insert into tb_ReturnGoods(BGID,StoreName,GoodsName,GoodsSpec,RGNum,"
                            + "NRGNum,HandlePeople,RGPeople,RGRemark) values(" + cboxBGID.Text.Trim() + ",'" + txtSName.Text.Trim()
                            + "','" + txtGName.Text.Trim() + "','" + txtGSpec.Text.Trim() + "'," + txtRGNum.Text.Trim() + ","
                            + txtNRGNum.Text.Trim() + ",'" + txtHPeople.Text.Trim() + "','"
                            + txtRGPeople.Text.Trim() + "','" + txtRGRemark.Text.Trim() + "')");
                        MessageBox.Show("还货成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmRGManage_Load(sender, e);
                    }
                }
                sqlread.Close();
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
                datacon.getcom("update tb_ReturnGoods set HandlePeople='" + txtHPeople.Text.Trim() + "',RGPeople='"
                    + txtRGPeople.Text.Trim() + "',RGRemark='" + txtRGRemark.Text.Trim()
                    + "',Editer='" + SMS.frmLogin.M_str_name + "',EditDate='"
                    + DateTime.Now.ToShortDateString() + "'where RGID="
                    + Convert.ToString(dgvRGManage[0, dgvRGManage.CurrentCell.RowIndex].Value).Trim() + "");
                MessageBox.Show("还货档案资料修改成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmRGManage_Load(sender, e);
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
                datacon.getcom("delete from tb_ReturnGoods where RGID="
                    + Convert.ToString(dgvRGManage[0, dgvRGManage.CurrentCell.RowIndex].Value).Trim() + "");
                MessageBox.Show("还货档案资料删除成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmRGManage_Load(sender, e);
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

        private void cboxBGID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxBGID.Text == "System.Data.DataRowView")
            {
            }
            else
            {
                SQLiteDataReader sqlreadNum = datacon.getread("select sum(RGNum) as Num from tb_ReturnGoods"
                    + " where BGID=" + Convert.ToInt32(cboxBGID.Text.Trim()) + "");
                if (sqlreadNum.Read())
                {
                    if (sqlreadNum["Num"].ToString().Trim() == "")
                    {
                        MessageBox.Show("您没有还过该货物。");
                    }
                    else
                    {
                        MessageBox.Show("已归还数量为" + sqlreadNum["Num"].ToString().Trim() + "。");
                    }
                }
                sqlreadNum.Close();
                SQLiteDataReader sqlread = datacon.getread("select StoreName,GoodsName,GoodsSpec from tb_BorrowGoods"
                    + " where BGID=" + Convert.ToInt32(cboxBGID.Text.Trim()) + "");
                if (sqlread.Read())
                {
                    txtSName.Text = sqlread["StoreName"].ToString().Trim();
                    txtGName.Text = sqlread["GoodsName"].ToString().Trim();
                    txtGSpec.Text = sqlread["GoodsSpec"].ToString().Trim();
                }
                sqlread.Close();
            }
        }

        private void dgvRGManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboxBGID.Text = Convert.ToString(dgvRGManage[1, dgvRGManage.CurrentCell.RowIndex].Value).Trim();
            txtSName.Text = Convert.ToString(dgvRGManage[2, dgvRGManage.CurrentCell.RowIndex].Value).Trim();
            txtGName.Text = Convert.ToString(dgvRGManage[3, dgvRGManage.CurrentCell.RowIndex].Value).Trim();
            txtRGNum.Text = Convert.ToString(dgvRGManage[5, dgvRGManage.CurrentCell.RowIndex].Value).Trim();
            txtNRGNum.Text = Convert.ToString(dgvRGManage[6, dgvRGManage.CurrentCell.RowIndex].Value).Trim();
            txtRGPeople.Text = Convert.ToString(dgvRGManage[9, dgvRGManage.CurrentCell.RowIndex].Value).Trim();
            txtHPeople.Text = Convert.ToString(dgvRGManage[8, dgvRGManage.CurrentCell.RowIndex].Value).Trim();
            txtRGRemark.Text = Convert.ToString(dgvRGManage[10, dgvRGManage.CurrentCell.RowIndex].Value).Trim();
        }

        private void txtRGNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SQLiteDataReader sqlread = datacon.getread("select GoodsNum from tb_BorrowGoods"
                    + " where BGID=" + Convert.ToInt32(cboxBGID.Text.Trim()) + "");
                if (sqlread.Read())
                {
                    txtNRGNum.Text = Convert.ToString(Convert.ToInt32(sqlread["GoodsNum"].ToString().Trim()) - Convert.ToInt32(txtRGNum.Text.Trim())).Trim();
                }
                sqlread.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmRGManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}