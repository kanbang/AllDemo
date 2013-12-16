using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
namespace SMS.LookandSum
{
    public partial class frmWGLook : Form
    {
        public frmWGLook()
        {
            InitializeComponent();
        }

        private int G_int_Lnum;
        private int G_int_Mnum;
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        private void frmWGLook_Load(object sender, EventArgs e)
        {
            dgvWGInfo.Controls.Add(hScrollBar1);
            SQLiteDataReader sqlread = datacon.getread("select GoodsLeast,GoodsMost from tb_GoodsInfo");
            if (sqlread.Read())
            {
                G_int_Lnum = Convert.ToInt32(sqlread["GoodsLeast"].ToString().Trim());
                G_int_Mnum = Convert.ToInt32(sqlread["GoodsMost"].ToString().Trim());
            }
            sqlread.Close();
            DataSet myds = datacon.getds("select GoodsID as 货物编号,GoodsName as 货物名称,"
                + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,"
                + "GoodsNum as 货物数量,GoodsInPrice as 进货价格,GoodsOutPrice as 出货价格,"
                + "GoodsLeast as 库存下线,GoodsMost as 库存上线,Editer as 修改人,EditDate as 修改日期 from tb_GoodsInfo"
                + " where GoodsNum<=" + G_int_Lnum + " or GoodsNum>=" + G_int_Mnum + "", "tb_GoodsInfo");
            dgvWGInfo.DataSource = myds.Tables[0];
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLKWord.Text.Trim() == "")
                {
                    frmWGLook_Load(sender, e);
                }
                else
                {
                    SQLiteDataReader sqlread = datacon.getread("select GoodsLeast,GoodsMost from tb_GoodsInfo "
                        + "where GoodsName like '%" + txtLKWord.Text.Trim() + "%'");
                    if (sqlread.Read())
                    {
                        if (cboxLCondition.Text.Trim() == "库存下线")
                        {
                            DataSet myds = datacon.getds("select GoodsID as 货物编号,GoodsName as 货物名称,"
                                + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,"
                                + "GoodsNum as 货物数量,GoodsInPrice as 进货价格,GoodsOutPrice as 出货价格,"
                                + "GoodsLeast as 库存下线,GoodsMost as 库存上线,Editer as 修改人,EditDate as 修改日期"
                                + " from tb_GoodsInfo where GoodsName like '%" + txtLKWord.Text.Trim()
                                + "%' and GoodsNum<=" + Convert.ToInt32(sqlread["GoodsLeast"].ToString().Trim()) + "", "tb_GoodsInfo");
                            dgvWGInfo.DataSource = myds.Tables[0];
                        }
                        else
                        {
                            DataSet myds = datacon.getds("select GoodsID as 货物编号,GoodsName as 货物名称,"
                                + "StoreName as 仓库名称,GoodsSpec as 货物规格,GoodsUnit as 计量单位,"
                                + "GoodsNum as 货物数量,GoodsInPrice as 进货价格,GoodsOutPrice as 出货价格,"
                                + "GoodsLeast as 库存下线,GoodsMost as 库存上线,Editer as 修改人,EditDate as 修改日期"
                                + " from tb_GoodsInfo where GoodsName like '%" + txtLKWord.Text.Trim()
                                + "%' and GoodsNum>=" + Convert.ToInt32(sqlread["GoodsMost"].ToString().Trim()) + "", "tb_GoodsInfo");
                            dgvWGInfo.DataSource = myds.Tables[0];
                        }
                    }
                    sqlread.Close();
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

        private void frmWGLook_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}