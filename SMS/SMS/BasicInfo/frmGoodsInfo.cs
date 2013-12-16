using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.BasicInfo
{
    public partial class frmGoodsInfo : Form
    {
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        public frmGoodsInfo()
        {
            InitializeComponent();
        }

        private void frmGoodsInfo_Load(object sender, EventArgs e)
        {
            dgvGInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select GoodsID as ������,GoodsName as ��������,"
                + "StoreName as �ֿ�����,GoodsSpec as ������,GoodsUnit as ������λ,"
                + "GoodsNum as ��������,GoodsInPrice as �����۸�,GoodsOutPrice as �����۸�,"
                + "GoodsLeast as ��ʹ洢,GoodsMost as ��ߴ洢,Editer as �޸���,EditDate as �޸����� from tb_GoodsInfo", "tb_GoodsInfo");
            dgvGInfo.DataSource = myds.Tables["tb_GoodsInfo"];
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!doperate.validateNum(txtGOPrice.Text.Trim()))
                {
                    errorPrMoney.SetError(txtGOPrice, "�������Ϊ����");
                }
                else
                {
                    errorPrMoney.Clear();
                    datacon.getcom("update tb_GoodsInfo set GoodsOutPrice=" + txtGOPrice.Text.Trim()
                        + ",GoodsLeast='" + txtLNum.Text.Trim() + "',GoodsMost='" + txtMNum.Text.Trim()
                        + "',Editer='" + SMS.frmLogin.M_str_name + "',EditDate='"
                        + DateTime.Now.ToShortDateString() + "'where GoodsID="
                        + Convert.ToString(dgvGInfo[0, dgvGInfo.CurrentCell.RowIndex].Value).Trim() + "");
                    MessageBox.Show("���ﵵ���޸ĳɹ���", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmGoodsInfo_Load(sender, e);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                datacon.getcom("delete from tb_GoodsInfo where GoodsID="
                    + Convert.ToString(dgvGInfo[0, dgvGInfo.CurrentCell.RowIndex].Value).Trim() 
                    + " and StoreName='" + Convert.ToString(dgvGInfo[2, dgvGInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                MessageBox.Show("����ɾ���ɹ���", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmGoodsInfo_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGName.Text = Convert.ToString(dgvGInfo[1, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            txtGSpec.Text = Convert.ToString(dgvGInfo[3, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            cboxGUnit.Text = Convert.ToString(dgvGInfo[4, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            txtGNum.Text = Convert.ToString(dgvGInfo[5, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            txtGIPrice.Text = Convert.ToString(dgvGInfo[6, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            txtGOPrice.Text = Convert.ToString(dgvGInfo[7, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            txtLNum.Text = Convert.ToString(dgvGInfo[8, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
            txtMNum.Text  = Convert.ToString(dgvGInfo[9, dgvGInfo.CurrentCell.RowIndex].Value).Trim();
        }

        private void frmGoodsInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}