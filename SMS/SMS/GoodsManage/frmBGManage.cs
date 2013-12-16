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
    public partial class frmBGManage : Form
    {
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        public frmBGManage()
        {
            InitializeComponent();
        }
        
        private void frmBGManage_Load(object sender, EventArgs e)
        {
            dgvBGManage.Controls.Add(hScrollBar1);
            doperate.cboxBind("select StoreName from tb_Storage", "tb_Storage", "StoreName", cboxSName);
            DataSet myds = datacon.getds("select BGID as 借货编号,GoodsName as 货物名称,StoreName as 仓库名称,"
                + "GoodsSpec as 货物规格,GoodsNum as 借出数量,BGDate as 借货日期,HandlePeople as 经手人,"
                + "BGPeople as 借货人,BGUnit as 借货单位,BGRemark as 备注 from tb_BorrowGoods", "tb_BorrowGoods");
            dgvBGManage.DataSource = myds.Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!doperate.validateNum(txtBGNum.Text.Trim()))
                {
                    errorPrBGNum.SetError(txtBGNum, "输入必须为数字！");
                }
                else
                {
                    errorPrBGNum.Clear();
                    SQLiteDataReader sqlread = datacon.getread("select GoodsName StoreName,GoodsNum from tb_GoodsInfo"
                        + " where StoreName='" + cboxSName.Text.Trim() + "' and GoodsName='" 
                        + cboxGName.Text.Trim() + "' and GoodsSpec='" + cboxGSpec.Text.Trim() + "'");
                    if (sqlread.Read())
                    {
                        if (Convert.ToInt32(sqlread["GoodsNum"].ToString().Trim()) <= 1)
                        {
                            MessageBox.Show("该货物库存已经不足！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (Convert.ToInt32(txtBGNum.Text.Trim()) >= Convert.ToInt32(sqlread["GoodsNum"].ToString().Trim()))
                            {
                                MessageBox.Show("没有足够的货物供您借取！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtBGNum.Text = "";
                                txtBGNum.Focus();
                            }
                            else
                            {
                                datacon.getcom("insert into tb_BorrowGoods(StoreName,GoodsName,GoodsSpec,"
                                    + "GoodsNum,HandlePeople,BGPeople,BGUnit,BGRemark)"
                                    + " values('" + cboxSName.Text.Trim() + "','" + cboxGName.Text.Trim()
                                    + "','" + cboxGSpec.Text.Trim() + "','" + txtBGNum.Text.Trim() + "','"
                                    + txtHPeople.Text.Trim() + "','" + txtBGPeople.Text.Trim() + "','"
                                    + txtBGDepart.Text.Trim() + "','" + txtBGRemark.Text.Trim() + "')");
                                MessageBox.Show("借货成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmBGManage_Load(sender, e);
                            }
                        }
                    }
                    sqlread.Close();
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
                datacon.getcom("delete from tb_BorrowGoods where BGID="
                    + Convert.ToString(dgvBGManage[0, dgvBGManage.CurrentCell.RowIndex].Value).Trim() + "");
                MessageBox.Show("借货资料删除成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmBGManage_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRGManage_Click(object sender, EventArgs e)
        {
            GoodsManage.frmRGManage GMfrgm = new frmRGManage();
            this.Hide();
            GMfrgm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboxSName_SelectedIndexChanged(object sender, EventArgs e)
        {
            doperate.cboxBind("select distinct GoodsName from tb_GoodsInfo where StoreName='"
                + cboxSName.Text.Trim() + "'", "tb_GoodsInfo", "GoodsName", cboxGName);
        }

        private void cboxGName_SelectedIndexChanged(object sender, EventArgs e)
        {
            doperate.cboxBind("select distinct GoodsSpec from tb_GoodsInfo where StoreName='" + cboxSName.Text.Trim()
                + "' and GoodsName='" + cboxGName.Text.Trim() + "'", "tb_GoodsInfo", "GoodsSpec", cboxGSpec);
        }

        private void dgvBGManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboxSName.Text = Convert.ToString(dgvBGManage[2, dgvBGManage.CurrentCell.RowIndex].Value).Trim();
            cboxGName.Text = Convert.ToString(dgvBGManage[1, dgvBGManage.CurrentCell.RowIndex].Value).Trim();
            cboxGSpec.Text = Convert.ToString(dgvBGManage[3, dgvBGManage.CurrentCell.RowIndex].Value).Trim();
            txtBGNum.Text = Convert.ToString(dgvBGManage[4, dgvBGManage.CurrentCell.RowIndex].Value).Trim();
            txtHPeople.Text = Convert.ToString(dgvBGManage[6, dgvBGManage.CurrentCell.RowIndex].Value).Trim();
            txtBGPeople.Text = Convert.ToString(dgvBGManage[7, dgvBGManage.CurrentCell.RowIndex].Value).Trim();
            txtBGDepart.Text = Convert.ToString(dgvBGManage[8, dgvBGManage.CurrentCell.RowIndex].Value).Trim();
            txtBGRemark.Text = Convert.ToString(dgvBGManage[9, dgvBGManage.CurrentCell.RowIndex].Value).Trim();
        }

        private void frmBGManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}