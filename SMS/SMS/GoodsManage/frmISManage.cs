using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS.GoodsManage
{
    public partial class frmISManage : Form
    {
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        public frmISManage()
        {
            InitializeComponent();
        }
        
        private void frmISManage_Load(object sender, EventArgs e)
        {
            dgvISManage.Controls.Add(hScrollBar1);
            doperate.cboxBind("select StoreName from tb_Storage", "tb_Storage", "StoreName", cboxSName);
            doperate.cboxBind("select PrName from tb_Provider", "tb_Provider", "PrName", cboxPName);
            DataSet myds = datacon.getds("select ISID as �����,GoodsID as ������,GoodsName as ��������,PrName as ��Ӧ������,"
                + "StoreName as �ֿ�����,GoodsSpec as ������,GoodsUnit as ������λ,GoodsNum as �������,"
                + "GoodsPrice as �����۸�,GoodsAPrice as �ܽ��,ISDate as �������,HandlePeople as ������,"
                + "ISRemark as ��ע from tb_InStore", "tb_InStore");
            dgvISManage.DataSource = myds.Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtISGID.Text == "")
            {
                MessageBox.Show("�����Ų���Ϊ�գ�", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (txtGIPrice.Text == "")
            {
                MessageBox.Show("���ﵥ�۲���Ϊ�գ�", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int P_int_returnValue = doperate.InsertGoods(Convert.ToInt32(txtISGID.Text.Trim()), txtISGName.Text.Trim(),
                    cboxPName.Text.Trim(), cboxSName.Text.Trim(), txtGSpec.Text.Trim(), cboxGUnit.Text.Trim(),
                    Convert.ToInt32(txtISGNum.Text.Trim()), Convert.ToDecimal(txtGIPrice.Text.Trim()), txtHPeople.Text.Trim(), txtISRemark.Text.Trim());
                if (P_int_returnValue == 100)
                {
                    MessageBox.Show("�û�����Ѿ���ռ�ã�", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (P_int_returnValue == 200)
                {
                    MessageBox.Show("��������Ѿ�����Ωһ��ţ�", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("�������ɹ���", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmISManage_Load(sender, e);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                datacon.getcom("delete from tb_InStore where ISID="
                    + Convert.ToString(dgvISManage[0, dgvISManage.CurrentCell.RowIndex].Value).Trim() + "");
                MessageBox.Show("����ɾ���ɹ���", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmISManage_Load(sender, e);
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

        private void dgvISManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtISGID.Text = Convert.ToString(dgvISManage[1,dgvISManage.CurrentCell.RowIndex].Value).Trim();
            txtISGName.Text = Convert.ToString(dgvISManage[2, dgvISManage.CurrentCell.RowIndex].Value).Trim();
            cboxSName.Text = Convert.ToString(dgvISManage[4, dgvISManage.CurrentCell.RowIndex].Value).Trim();
            cboxPName.Text = Convert.ToString(dgvISManage[3, dgvISManage.CurrentCell.RowIndex].Value).Trim();
            txtGSpec.Text = Convert.ToString(dgvISManage[5, dgvISManage.CurrentCell.RowIndex].Value).Trim();
            cboxGUnit.Text = Convert.ToString(dgvISManage[6, dgvISManage.CurrentCell.RowIndex].Value).Trim();
            txtISGNum.Text = Convert.ToString(dgvISManage[7, dgvISManage.CurrentCell.RowIndex].Value).Trim();
            txtGIPrice.Text = Convert.ToString(dgvISManage[8, dgvISManage.CurrentCell.RowIndex].Value).Trim();
            txtGSPrice.Text = Convert.ToString(dgvISManage[9, dgvISManage.CurrentCell.RowIndex].Value).Trim();
            txtHPeople.Text = Convert.ToString(dgvISManage[11, dgvISManage.CurrentCell.RowIndex].Value).Trim();
            txtISRemark.Text = Convert.ToString(dgvISManage[12, dgvISManage.CurrentCell.RowIndex].Value).Trim();
        }

        private void txtGIPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtGSPrice.Text = Convert.ToString(Convert.ToDecimal(txtGIPrice.Text.Trim()) * Convert.ToInt32(txtISGNum.Text.Trim())).Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmISManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}