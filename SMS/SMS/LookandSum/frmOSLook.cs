using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.LookandSum
{
    public partial class frmOSLook : Form
    {
        public frmOSLook()
        {
            InitializeComponent();
        }

        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        private void frmOSLook_Load(object sender, EventArgs e)
        {
            dgvOSInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select OSID as 出库编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                + "GoodsSpec as 规格,GoodsUnit as 计量单位,GoodsNum as 出库数量,GoodsPrice as 价格,GoodsAPrice as 总金额,"
                + "OSDate as 出库日期,PGProvider as 提货单位,PGPeople as 提货人,"
                + "HandlePeople as 经手人,OSRemark as 备注 from tb_OutStore", "tb_OutStore");
            dgvOSInfo.DataSource = myds.Tables[0];
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLKWord.Text.Trim() == "")
                {
                    frmOSLook_Load(sender, e);
                }
                else
                {
                    if (cboxLCondition.Text.Trim() == "出库编号")
                    {
                        DataSet myds = datacon.getds("select OSID as 出库编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                            + "GoodsSpec as 规格,GoodsUnit as 计量单位,GoodsNum as 出库数量,GoodsPrice as 价格,GoodsAPrice as 总金额,"
                            + "OSDate as 出库日期,PGProvider as 提货单位,PGPeople as 提货人,"
                            + "HandlePeople as 经手人,OSRemark as 备注 from tb_OutStore where OSID = " + txtLKWord.Text.Trim() + "", "tb_OutStore");
                        dgvOSInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "出库日期")
                    {
                        string P_str_dtime = txtLKWord.Text.Trim();
                        DataSet myds = datacon.getds("select OSID as 出库编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                            + "GoodsSpec as 规格,GoodsUnit as 计量单位,GoodsNum as 出库数量,GoodsPrice as 价格,GoodsAPrice as 总金额,"
                            + "OSDate as 出库日期,PGProvider as 提货单位,PGPeople as 提货人,"
                            + "HandlePeople as 经手人,OSRemark as 备注 from tb_OutStore where year(OSDate)=" + P_str_dtime.Substring(0, 4)
                            + " and month(OSDate)=" + P_str_dtime.Substring(5, P_str_dtime.Length - 6) + "", "tb_OutStore");
                        dgvOSInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "仓库名称")
                    {
                        DataSet myds = datacon.getds("select OSID as 出库编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                            + "GoodsSpec as 规格,GoodsUnit as 计量单位,GoodsNum as 出库数量,GoodsPrice as 价格,GoodsAPrice as 总金额,"
                            + "OSDate as 出库日期,PGProvider as 提货单位,PGPeople as 提货人,"
                            + "HandlePeople as 经手人,OSRemark as 备注 from tb_OutStore where StoreName like '%" 
                            + txtLKWord.Text.Trim() + "%'", "tb_OutStore");
                        dgvOSInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "货物名称")
                    {
                        DataSet myds = datacon.getds("select OSID as 出库编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                            + "GoodsSpec as 规格,GoodsUnit as 计量单位,GoodsNum as 出库数量,GoodsPrice as 价格,GoodsAPrice as 总金额,"
                            + "OSDate as 出库日期,PGProvider as 提货单位,PGPeople as 提货人,"
                            + "HandlePeople as 经手人,OSRemark as 备注 from tb_OutStore where GoodsName like '%"
                            + txtLKWord.Text.Trim() + "%'", "tb_OutStore");
                        dgvOSInfo.DataSource = myds.Tables[0];
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
            if (cboxLCondition.Text.Trim() == "出库日期")
            {
                label2.Text = "查询年月份";
            }
            else
            {
                label2.Text = "查询关键字";
            }
        }

        private void frmOSLook_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}