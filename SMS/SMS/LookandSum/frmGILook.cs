using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.LookandSum
{
    public partial class frmGILook : Form
    {
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        public frmGILook()
        {
            InitializeComponent();
        }

        private void frmGILook_Load(object sender, EventArgs e)
        {
            dgvGInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select GoodsID as 货物编号,GoodsName as 货物名称,"
                + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,"
                + "GoodsNum as 货物数量,GoodsInPrice as 进货价格,GoodsOutPrice as 出货价格,"
                + "GoodsLeast as 最低存储,GoodsMost as 最高存储,Editer as 修改人,EditDate as 修改日期 from tb_GoodsInfo", "tb_GoodsInfo");
            dgvGInfo.DataSource = myds.Tables[0];
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLKWord.Text.Trim() == "")
                {
                    frmGILook_Load(sender, e);
                }
                else
                {
                    if (cboxLCondition.Text.Trim() == "货物编号")
                    {
                        DataSet myds = datacon.getds("select GoodsID as 货物编号,GoodsName as 货物名称,"
                            + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,"
                            + "GoodsNum as 货物数量,GoodsInPrice as 进货价格,GoodsOutPrice as 出货价格,"
                            + "GoodsLeast as 最低存储,GoodsMost as 最高存储,Editer as 修改人,EditDate as 修改日期"
                            + " from tb_GoodsInfo where GoodsID = " + txtLKWord.Text.Trim() + "", "tb_GoodsInfo");
                        dgvGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "货物名称")
                    {
                        DataSet myds = datacon.getds("select GoodsID as 货物编号,GoodsName as 货物名称,"
                            + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,"
                            + "GoodsNum as 货物数量,GoodsInPrice as 进货价格,GoodsOutPrice as 出货价格,"
                            + "GoodsLeast as 最低存储,GoodsMost as 最高存储,Editer as 修改人,EditDate as 修改日期"
                            + " from tb_GoodsInfo where GoodsName like '%" + txtLKWord.Text.Trim() + "%'", "tb_GoodsInfo");
                        dgvGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "仓库名称")
                    {
                        DataSet myds = datacon.getds("select GoodsID as 货物编号,GoodsName as 货物名称,"
                            + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,"
                            + "GoodsNum as 货物数量,GoodsInPrice as 进货价格,GoodsOutPrice as 出货价格,"
                            + "GoodsLeast as 最低存储,GoodsMost as 最高存储,Editer as 修改人,EditDate as 修改日期"
                            + " from tb_GoodsInfo where StoreName like '%" + txtLKWord.Text.Trim() + "%'", "tb_GoodsInfo");
                        dgvGInfo.DataSource = myds.Tables[0];
                    }
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

        private void frmGILook_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}