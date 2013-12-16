using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS.LookandSum
{
    public partial class frmBGLook : Form
    {
        public frmBGLook()
        {
            InitializeComponent();
        }

        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        private void frmBGLook_Load(object sender, EventArgs e)
        {
            dgvBGInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select BGID as 借货编号,GoodsName as 货物名称,StoreName as 仓库名称,"
                + "GoodsSpec as 货物规格,GoodsNum as 借出数量,BGDate as 借货日期,HandlePeople as 经手人,"
                + "BGPeople as 借货人,BGUnit as 借货单位,BGRemark as 备注 from tb_BorrowGoods", "tb_BorrowGoods");
            dgvBGInfo.DataSource = myds.Tables[0];
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLKWord.Text.Trim() == "")
                {
                    frmBGLook_Load(sender, e);
                }
                else
                {
                    if (cboxLCondition.Text.Trim() == "借货编号")
                    {
                        DataSet myds = datacon.getds("select BGID as 借货编号,GoodsName as 货物名称,StoreName as 仓库名称,"
                            + "GoodsSpec as 货物规格,GoodsNum as 借出数量,BGDate as 借货日期,HandlePeople as 经手人,"
                            + "BGPeople as 借货人,BGUnit as 借货单位,BGRemark as 备注 from tb_BorrowGoods where BGID = " 
                            + txtLKWord.Text.Trim() + "", "tb_BorrowGoods");
                        dgvBGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "借货日期")
                    {
                        string P_str_dtime = txtLKWord.Text.Trim();
                        DataSet myds = datacon.getds("select BGID as 借货编号,GoodsName as 货物名称,StoreName as 仓库名称,"
                            + "GoodsSpec as 货物规格,GoodsNum as 借出数量,BGDate as 借货日期,HandlePeople as 经手人,"
                            + "BGPeople as 借货人,BGUnit as 借货单位,BGRemark as 备注 from tb_BorrowGoods"
                            + " where year(BGDate)=" + P_str_dtime.Substring(0, 4) + " and month(BGDate)="
                            + P_str_dtime.Substring(5, P_str_dtime.Length - 6) + "", "tb_BorrowGoods");
                        dgvBGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "仓库名称")
                    {
                        DataSet myds = datacon.getds("select BGID as 借货编号,GoodsName as 货物名称,StoreName as 仓库名称,"
                            + "GoodsSpec as 货物规格,GoodsNum as 借出数量,BGDate as 借货日期,HandlePeople as 经手人,"
                            + "BGPeople as 借货人,BGUnit as 借货单位,BGRemark as 备注 from tb_BorrowGoods where StoreName like '%" 
                            + txtLKWord.Text.Trim() + "%'", "tb_BorrowGoods");
                        dgvBGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "货物名称")
                    {
                        DataSet myds = datacon.getds("select BGID as 借货编号,GoodsName as 货物名称,StoreName as 仓库名称,"
                            + "GoodsSpec as 货物规格,GoodsNum as 借出数量,BGDate as 借货日期,HandlePeople as 经手人,"
                            + "BGPeople as 借货人,BGUnit as 借货单位,BGRemark as 备注 from tb_BorrowGoods where GoodsName like '%"
                            + txtLKWord.Text.Trim() + "%'", "tb_BorrowGoods");
                        dgvBGInfo.DataSource = myds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboxLCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxLCondition.Text.Trim() == "借货日期")
            {
                label2.Text = "查询年月份";
            }
            else
            {
                label2.Text = "查询关键字";
            }
        }

        private void frmBGLook_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}