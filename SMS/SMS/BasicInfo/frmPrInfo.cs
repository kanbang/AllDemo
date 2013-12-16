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
    public partial class frmPrInfo : Form
    {
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        public frmPrInfo()
        {
            InitializeComponent();
        }

        private void frmPrInfo_Load(object sender, EventArgs e)
        {
            dgvPInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select PrID as 供应商编号,PrName as 供应商名称,PrPeople as 负责人,"
                + "PrPhone as 电话,PrFax as 传真,PrRemark as 备注,Editer as 修改人,EditDate as 修改日期 from tb_Provider", "tb_Provider");
            dgvPInfo.DataSource=myds.Tables["tb_Provider"];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!doperate.validatePhone(txtPPhone.Text.Trim()))
                {
                    errorPrPhone.SetError(txtPPhone, "电话号码格式不正确");
                }
                else if (!doperate.validateFax(txtPFax.Text.Trim()))
                {
                    errorPrFax.SetError(txtPFax, "传真号码输入格式不正确");
                }
                else
                {
                    errorPrFax.Clear();
                    errorPrPhone.Clear();
                    if (txtPName.Text == "")
                    {
                        MessageBox.Show("供应商名称不能为空！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int P_int_returnValue = doperate.InsertProvider(txtPName.Text.Trim(),
                            txtPLeader.Text.Trim(),txtPPhone.Text.Trim(),txtPFax.Text.Trim(),txtPRemark.Text.Trim());
                        if (P_int_returnValue == 100)
                        {
                            MessageBox.Show("该供应商已经存在！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("供应商信息添加成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmPrInfo_Load(sender, e);
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
                if (!doperate.validatePhone(txtPPhone.Text.Trim()))
                {
                    errorPrPhone.SetError(txtPPhone, "电话号码格式不正确");
                }
                else if (!doperate.validateFax(txtPFax.Text.Trim()))
                {
                    errorPrFax.SetError(txtPFax, "传真号码输入格式不正确");
                }
                else
                {
                    errorPrFax.Clear();
                    errorPrPhone.Clear();
                    datacon.getcom("update tb_Provider set PrPeople='" + txtPLeader.Text.Trim() + "',PrPhone='"
                        + txtPPhone.Text.Trim() + "',PrFax='" + txtPFax.Text.Trim()
                        + "',PrRemark='" + txtPRemark.Text.Trim() + "',Editer='"
                        + SMS.frmLogin.M_str_name + "',EditDate='" + DateTime.Now.ToShortDateString()
                        + "'where PrID=" + Convert.ToString(dgvPInfo[0, dgvPInfo.CurrentCell.RowIndex].Value).Trim() + "");
                    MessageBox.Show("供应商档案修改成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPrInfo_Load(sender, e);
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
                datacon.getcom("delete from tb_Provider where PrID="
                    + Convert.ToString(dgvPInfo[0, dgvPInfo.CurrentCell.RowIndex].Value).Trim() + "");
                MessageBox.Show("成功删除供应商！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmPrInfo_Load(sender, e);
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

        private void dgvPInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPName.Text = Convert.ToString(dgvPInfo[1, dgvPInfo.CurrentCell.RowIndex].Value).Trim();
            txtPLeader.Text = Convert.ToString(dgvPInfo[2, dgvPInfo.CurrentCell.RowIndex].Value).Trim();
            txtPPhone.Text = Convert.ToString(dgvPInfo[3, dgvPInfo.CurrentCell.RowIndex].Value).Trim();
            txtPFax.Text = Convert.ToString(dgvPInfo[4, dgvPInfo.CurrentCell.RowIndex].Value).Trim();
            txtPRemark.Text = Convert.ToString(dgvPInfo[5, dgvPInfo.CurrentCell.RowIndex].Value).Trim();
        }

        private void frmPrInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}