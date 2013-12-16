using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.LookandSum
{
    public partial class frmISLook : Form
    {
        public frmISLook()
        {
            InitializeComponent();
        }

        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        private void frmISLook_Load(object sender, EventArgs e)
        {
            dgvISInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select ISID as 入库编号,GoodsID as 货物编号,GoodsName as 货物名称,"
                + "PrName as 供应商名称,StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,"
                + "GoodsNum as 入库数量,GoodsPrice as 进货价格,GoodsAPrice as 总金额,ISDate as 入库日期,"
                + "HandlePeople as 经手人,ISRemark as 备注 from tb_InStore", "tb_InStore");
            dgvISInfo.DataSource = myds.Tables[0];
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLKWord.Text.Trim() == "")
                {
                    frmISLook_Load(sender, e);
                }
                else
                {
                    if (cboxLCondition.Text.Trim() == "入库编号")
                    {
                        DataSet myds = datacon.getds("select ISID as 入库编号,GoodsID as 货物编号,GoodsName as 货物名称,PrName as 供应商名称,"
                            + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,GoodsNum as 入库数量,"
                            + "GoodsPrice as 进货价格,GoodsAPrice as 总金额,ISDate as 入库日期,HandlePeople as 经手人,"
                            + "ISRemark as 备注 from tb_InStore where ISID = " + txtLKWord.Text.Trim() + "", "tb_InStore");
                        dgvISInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "货物编号")
                    {
                        DataSet myds = datacon.getds("select ISID as 入库编号,GoodsID as 货物编号,GoodsName as 货物名称,PrName as 供应商名称,"
                            + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,GoodsNum as 入库数量,"
                            + "GoodsPrice as 进货价格,GoodsAPrice as 总金额,ISDate as 入库日期,HandlePeople as 经手人,"
                            + "ISRemark as 备注 from tb_InStore where GoodsID = " + txtLKWord.Text.Trim() + "", "tb_InStore");
                        dgvISInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "入库日期")
                    {
                        string P_str_dtime = txtLKWord.Text.Trim();
                        DataSet myds = datacon.getds("select ISID as 入库编号,GoodsID as 货物编号,GoodsName as 货物名称,PrName as 供应商名称,"
                            + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,GoodsNum as 入库数量,"
                            + "GoodsPrice as 进货价格,GoodsAPrice as 总金额,ISDate as 入库日期,HandlePeople as 经手人,"
                            + "ISRemark as 备注 from tb_InStore where year(ISDate)=" + P_str_dtime.Substring(0, 4)
                            + " and month(ISDate)=" + P_str_dtime.Substring(5, P_str_dtime.Length - 6) + "", "tb_InStore");
                        dgvISInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "仓库名称")
                    {
                        DataSet myds = datacon.getds("select ISID as 入库编号,GoodsID as 货物编号,GoodsName as 货物名称,PrName as 供应商名称,"
                            + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,GoodsNum as 入库数量,"
                            + "GoodsPrice as 进货价格,GoodsAPrice as 总金额,ISDate as 入库日期,HandlePeople as 经手人,"
                            + "ISRemark as 备注 from tb_InStore where StoreName like '%" + txtLKWord.Text.Trim() + "%'", "tb_InStore");
                        dgvISInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "货物名称")
                    {
                        DataSet myds = datacon.getds("select ISID as 入库编号,GoodsID as 货物编号,GoodsName as 货物名称,PrName as 供应商名称,"
                            + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,GoodsNum as 入库数量,"
                            + "GoodsPrice as 进货价格,GoodsAPrice as 总金额,ISDate as 入库日期,HandlePeople as 经手人,"
                            + "ISRemark as 备注 from tb_InStore where GoodsName like '%" + txtLKWord.Text.Trim() + "%'", "tb_InStore");
                        dgvISInfo.DataSource = myds.Tables[0];
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

        private void cboxLCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxLCondition.Text.Trim() == "入库日期")
            {
                label2.Text = "查询年月份";
            }
            else
            {
                label2.Text = "查询关键字";
            }
        }

        private void frmISLook_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}