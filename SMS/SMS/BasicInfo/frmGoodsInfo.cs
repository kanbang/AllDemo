using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.BasicInfo
{
    public partial class frmGoodsInfo : Form
    {
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        public frmGoodsInfo()
        {
            InitializeComponent();
        }

        private void frmGoodsInfo_Load(object sender, EventArgs e)
        {
            dgvGInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select GoodsID as 货物编号,GoodsName as 货物名称,"
                + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,"
                + "GoodsNum as 货物数量,GoodsInPrice as 进货价格,GoodsOutPrice as 出货价格,"
                + "GoodsLeast as 最低存储,GoodsMost as 最高存储,Editer as 修改人,EditDate as 修改日期 from tb_GoodsInfo", "tb_GoodsInfo");
            dgvGInfo.DataSource = myds.Tables["tb_GoodsInfo"];
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!doperate.validateNum(txtGOPrice.Text.Trim()))
                {
                    errorPrMoney.SetError(txtGOPrice, "输入必须为数字");
                }
                else
                {
                    errorPrMoney.Clear();
                    datacon.getcom("update tb_GoodsInfo set GoodsOutPrice=" + txtGOPrice.Text.Trim()
                        + ",GoodsLeast='" + txtLNum.Text.Trim() + "',GoodsMost='" + txtMNum.Text.Trim()
                        + "',Editer='" + SMS.frmLogin.M_str_name + "',EditDate='"
                        + DateTime.Now.ToShortDateString() + "'where GoodsID="
                        + Convert.ToString(dgvGInfo[0, dgvGInfo.CurrentCell.RowIndex].Value).Trim() + "");
                    MessageBox.Show("货物档案修改成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmGoodsInfo_Load(sender, e);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                datacon.getcom("delete from tb_GoodsInfo where GoodsID="
                    + Convert.ToString(dgvGInfo[0, dgvGInfo.CurrentCell.RowIndex].Value).Trim() 
                    + " and StoreName='" + Convert.ToString(dgvGInfo[2, dgvGInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                MessageBox.Show("货物删除成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmGoodsInfo_Load(sender, e);
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

        private void dgvGInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGName.Text = Convert.ToString(dgvGInfo[1, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            txtGSpec.Text = Convert.ToString(dgvGInfo[3, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            cboxGUnit.Text = Convert.ToString(dgvGInfo[4, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            txtGNum.Text = Convert.ToString(dgvGInfo[5, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            txtGIPrice.Text = Convert.ToString(dgvGInfo[6, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            txtGOPrice.Text = Convert.ToString(dgvGInfo[7, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            txtLNum.Text = Convert.ToString(dgvGInfo[8, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            txtMNum.Text  = Convert.ToString(dgvGInfo[9, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
        }

        private void frmGoodsInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}