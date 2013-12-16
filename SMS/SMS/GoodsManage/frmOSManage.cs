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
    public partial class frmOSManage : Form
    {
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        public frmOSManage()
        {
            InitializeComponent();
        }
        
        private void frmOSManage_Load(object sender, EventArgs e)
        {
            dgvOSManage.Controls.Add(hScrollBar1);
            doperate.cboxBind("select distinct StoreName from tb_InStore", "tb_InStore", "StoreName", cboxSName);
            DataSet myds = datacon.getds("select OSID as 出库编号,StoreName as 仓库名称,GoodsName as 货物名称,"
                + "GoodsSpec as 规格,GoodsUnit as 计量单位,GoodsNum as 出库数量,GoodsPrice as 价格,GoodsAPrice as 总金额,"
                + "OSDate as 出库日期,PGProvider as 提货单位,PGPeople as 提货人,"
                + "HandlePeople as 经手人,OSRemark as 备注 from tb_OutStore", "tb_OutStore");
            dgvOSManage.DataSource = myds.Tables["tb_OutStore"];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteDataReader sqlread = datacon.getread("select GoodsNum from tb_GoodsInfo"
                    + " where StoreName='" + cboxSName.Text.Trim() + "' and GoodsName='"
                    + cboxGName.Text.Trim() + "' and GoodsSpec='" + cboxGSpec.Text.Trim() + "'");
                if (sqlread.Read())
                {
                    if (Convert.ToInt32(txtOSGNum.Text.Trim()) > Convert.ToInt32(sqlread["GoodsNum"].ToString().Trim()))
                    {
                        MessageBox.Show("仓库中没有足够的货物！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        datacon.getcom("insert into tb_OutStore(StoreName,GoodsName,GoodsSpec,GoodsUnit,"
                            + "GoodsNum,GoodsPrice,PGProvider,PGPeople,HandlePeople,OSRemark)"
                            + " values('" + cboxSName.Text.Trim() + "','" + cboxGName.Text.Trim()
                            + "','" + cboxGSpec.Text.Trim() + "','" + cboxGUnit.Text.Trim() + "',"
                            + txtOSGNum.Text.Trim() + "," + txtGOPrice.Text.Trim() + ",'"
                            + txtOSUnit.Text.Trim() + "','" + txtOSPeople.Text.Trim() + "','"
                            + txtHPeople.Text.Trim() + "','" + txtOSRemark.Text.Trim() + "')");
                        MessageBox.Show("货物出库成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmOSManage_Load(sender, e);
                    }
                }
                sqlread.Close();
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
                datacon.getcom("delete from tb_OutStore where OSID="
                    + Convert.ToString(dgvOSManage[0, dgvOSManage.CurrentCell.RowIndex].Value).Trim() + "");
                MessageBox.Show("货物删除成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmOSManage_Load(sender, e);
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

        private void dgvOSManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboxSName.Text = Convert.ToString(dgvOSManage[1, dgvOSManage.CurrentCell.RowIndex].Value).Trim();
            cboxGName.Text = Convert.ToString(dgvOSManage[2, dgvOSManage.CurrentCell.RowIndex].Value).Trim();
            cboxGSpec.Text = Convert.ToString(dgvOSManage[3, dgvOSManage.CurrentCell.RowIndex].Value).Trim();
            cboxGUnit.Text = Convert.ToString(dgvOSManage[4, dgvOSManage.CurrentCell.RowIndex].Value).Trim();
            txtOSGNum.Text = Convert.ToString(dgvOSManage[5, dgvOSManage.CurrentCell.RowIndex].Value).Trim();
            txtGOPrice.Text = Convert.ToString(dgvOSManage[6, dgvOSManage.CurrentCell.RowIndex].Value).Trim();
            txtGSPrice.Text = Convert.ToString(dgvOSManage[7, dgvOSManage.CurrentCell.RowIndex].Value).Trim();
            txtOSUnit.Text = Convert.ToString(dgvOSManage[9, dgvOSManage.CurrentCell.RowIndex].Value).Trim();
            txtOSPeople.Text = Convert.ToString(dgvOSManage[10, dgvOSManage.CurrentCell.RowIndex].Value).Trim();
            txtHPeople.Text = Convert.ToString(dgvOSManage[11, dgvOSManage.CurrentCell.RowIndex].Value).Trim();
            txtOSRemark.Text = Convert.ToString(dgvOSManage[12, dgvOSManage.CurrentCell.RowIndex].Value).Trim();
        }

        private void cboxSName_SelectedIndexChanged(object sender, EventArgs e)
        {
            doperate.cboxBind("select distinct GoodsName from tb_InStore where StoreName='" 
                + cboxSName.Text.Trim() + "'", "tb_InStore", "GoodsName", cboxGName);
        }

        private void cboxGName_SelectedIndexChanged(object sender, EventArgs e)
        {
            doperate.cboxBind("select distinct GoodsSpec from tb_InStore where StoreName='"
                + cboxSName.Text.Trim() + "' and GoodsName='" + cboxGName.Text.Trim() 
                + "'", "tb_InStore", "GoodsSpec", cboxGSpec);
            SQLiteDataReader sqlread = datacon.getread("select GoodsUnit,GoodsOutPrice from tb_GoodsInfo"
                + " where StoreName='" + cboxSName.Text.Trim()
                + "' and GoodsName='" + cboxGName.Text.Trim() + "'");
            if (sqlread.Read())
            {
                cboxGUnit.Text = sqlread["GoodsUnit"].ToString().Trim();
                txtGOPrice.Text = sqlread["GoodsOutPrice"].ToString().Trim();
            }
            sqlread.Close();
        }

        private void txtOSGNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtGSPrice.Text = Convert.ToString(Convert.ToDecimal(txtGOPrice.Text.Trim())* Convert.ToInt32(txtOSGNum.Text.Trim())).Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmOSManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}