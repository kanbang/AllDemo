using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS.BasicInfo
{
    public partial class frmStoreInfo : Form
    {
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        public frmStoreInfo()
        {
            InitializeComponent();
        }

        private void frmStoreInfo_Load(object sender, EventArgs e)
        {
            dgvSInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select StoreID as 仓库编号,StoreName as 仓库名称,StorePeople as 负责人,"
                + "StorePhone as 电话,StoreUnit as 所属单位,StoreDate as 建库日期,StoreRemark as 备注,"
                + "Editer as 修改人,EditDate as 修改日期 from tb_Storage", "tb_Storage");
            dgvSInfo.DataSource=myds.Tables["tb_Storage"];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!doperate.validatePhone(txtSPhone.Text.Trim()))
                {
                    errorPrPhone.SetError(txtSPhone, "电话号码输入格式不正确");
                }
                else
                {
                    errorPrPhone.Clear();
                    if (txtSName.Text == "")
                    {
                        MessageBox.Show("仓库名称不能为空！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int P_int_returnValue = doperate.InsertStorage(txtSName.Text.Trim(),
                            txtSLeader.Text.Trim(), txtSPhone.Text.Trim(), txtSDepart.Text.Trim(), txtSRemark.Text.Trim());
                        if (P_int_returnValue == 100)
                        {
                            MessageBox.Show("该仓库已经存在！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("仓库信息添加成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmStoreInfo_Load(sender, e);
                        }
                    }
                }
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
                if (!doperate.validatePhone(txtSPhone.Text.Trim()))
                {
                    errorPrPhone.SetError(txtSPhone, "电话号码输入格式不正确");
                }
                else
                {
                    errorPrPhone.Clear();
                    datacon.getcom("update tb_Storage set StorePeople='" + txtSLeader.Text.Trim() + "',StorePhone='"
                        + txtSPhone.Text.Trim() + "',StoreUnit='" + txtSDepart.Text.Trim()
                        + "',StoreRemark='" + txtSRemark.Text.Trim() + "',Editer='"
                        + SMS.frmLogin.M_str_name + "',EditDate='" + DateTime.Now.ToShortDateString()
                        + "'where StoreID=" + Convert.ToString(dgvSInfo[0, dgvSInfo.CurrentCell.RowIndex].Value).Trim() + "");
                    MessageBox.Show("仓库档案修改成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmStoreInfo_Load(sender, e);
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
                datacon.getcom("delete from tb_Storage where StoreID="
                    + Convert.ToString(dgvSInfo[0, dgvSInfo.CurrentCell.RowIndex].Value).Trim() + "");
                MessageBox.Show("成功删除仓库！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmStoreInfo_Load(sender, e);
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

        private void dgvSInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSName.Text = Convert.ToString(dgvSInfo[1, dgvSInfo.CurrentCell.RowIndex].Value).Trim();
            txtSLeader.Text = Convert.ToString(dgvSInfo[2, dgvSInfo.CurrentCell.RowIndex].Value).Trim();
            txtSPhone.Text = Convert.ToString(dgvSInfo[3, dgvSInfo.CurrentCell.RowIndex].Value).Trim();
            txtSDepart.Text = Convert.ToString(dgvSInfo[4, dgvSInfo.CurrentCell.RowIndex].Value).Trim();
            txtSRemark.Text = Convert.ToString(dgvSInfo[6, dgvSInfo.CurrentCell.RowIndex].Value).Trim();
        }

        private void frmStoreInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}