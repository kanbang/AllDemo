using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.LookandSum
{
    public partial class frmRGLook : Form
    {
        public frmRGLook()
        {
            InitializeComponent();
        }

        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        private void frmRGLook_Load(object sender, EventArgs e)
        {
            dgvRGInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select RGID as 还货编号,BGID as 借货编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                + "RGNum as 归还数量,NRGNum as 未归还数量,RGDate as 还货日期,HandlePeople as 经手人,RGPeople as 还货人,RGRemark as 备注,"
                + "Editer as 修改人,EditDate as 修改日期 from tb_ReturnGoods", "tb_ReturnGoods");
            dgvRGInfo.DataSource = myds.Tables[0];
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLKWord.Text.Trim() == "")
                {
                    frmRGLook_Load(sender, e);
                }
                else
                {
                    if (cboxLCondition.Text.Trim() == "还货编号")
                    {
                        DataSet myds = datacon.getds("select RGID as 还货编号,BGID as 借货编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                            + "RGNum as 归还数量,NRGNum as 未归还数量,RGDate as 还货日期,HandlePeople as 经手人,RGPeople as 还货人,RGRemark as 备注,"
                            + "Editer as 修改人,EditDate as 修改日期 from tb_ReturnGoods where RGID = " + txtLKWord.Text.Trim() + "", "tb_ReturnGoods");
                        dgvRGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "借货编号")
                    {
                        DataSet myds = datacon.getds("select RGID as 还货编号,BGID as 借货编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                            + "RGNum as 归还数量,NRGNum as 未归还数量,RGDate as 还货日期,HandlePeople as 经手人,RGPeople as 还货人,RGRemark as 备注,"
                            + "Editer as 修改人,EditDate as 修改日期 from tb_ReturnGoods where BGID = " + txtLKWord.Text.Trim() + "", "tb_ReturnGoods");
                        dgvRGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "还货日期")
                    {
                        string P_str_dtime=txtLKWord.Text.Trim();
                        DataSet myds = datacon.getds("select RGID as 还货编号,BGID as 借货编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                            + "RGNum as 归还数量,NRGNum as 未归还数量,RGDate as 还货日期,HandlePeople as 经手人,RGPeople as 还货人,RGRemark as 备注,"
                            + "Editer as 修改人,EditDate as 修改日期 from tb_ReturnGoods where year(RGDate)=" + P_str_dtime.Substring(0, 4) 
                            + " and month(RGDate)=" + P_str_dtime.Substring(5, P_str_dtime.Length - 6) + "", "tb_ReturnGoods");
                        dgvRGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "仓库名称")
                    {
                        DataSet myds = datacon.getds("select RGID as 还货编号,BGID as 借货编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                            + "RGNum as 归还数量,NRGNum as 未归还数量,RGDate as 还货日期,HandlePeople as 经手人,RGPeople as 还货人,RGRemark as 备注,"
                            + "Editer as 修改人,EditDate as 修改日期 from tb_ReturnGoods where StoreName like '%" + txtLKWord.Text.Trim() + "%'", "tb_ReturnGoods");
                        dgvRGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "货物名称")
                    {
                        DataSet myds = datacon.getds("select RGID as 还货编号,BGID as 借货编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                            + "RGNum as 归还数量,NRGNum as 未归还数量,RGDate as 还货日期,HandlePeople as 经手人,RGPeople as 还货人,RGRemark as 备注,"
                            + "Editer as 修改人,EditDate as 修改日期 from tb_ReturnGoods where GoodsName like '%" + txtLKWord.Text.Trim() + "%'", "tb_ReturnGoods");
                        dgvRGInfo.DataSource = myds.Tables[0];
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
            if (cboxLCondition.Text.Trim() == "还货日期")
            {
                label2.Text = "查询年月份";
            }
            else
            {
                label2.Text = "查询关键字";
            }
        }

        private void frmRGLook_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}