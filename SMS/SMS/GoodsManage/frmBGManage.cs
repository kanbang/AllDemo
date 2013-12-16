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
            DataSet myds = datacon.getds("select BGID as ������,GoodsName as ��������,StoreName as �ֿ�����,"
                + "GoodsSpec as ������,GoodsNum as �������,BGDate as �������,HandlePeople as ������,"
                + "BGPeople as �����,BGUnit as �����λ,BGRemark as ��ע from tb_BorrowGoods", "tb_BorrowGoods");
            dgvBGManage.DataSource = myds.Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!doperate.validateNum(txtBGNum.Text.Trim()))
                {
                    errorPrBGNum.SetError(txtBGNum, "�������Ϊ���֣�");
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
                            MessageBox.Show("�û������Ѿ����㣡", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (Convert.ToInt32(txtBGNum.Text.Trim()) >= Convert.ToInt32(sqlread["GoodsNum"].ToString().Trim()))
                            {
                                MessageBox.Show("û���㹻�Ļ��﹩����ȡ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                MessageBox.Show("����ɹ���", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmBGManage_Load(sender, e);
                            }
                        }
                    }
                    sqlread.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                datacon.getcom("delete from tb_BorrowGoods where BGID="
                    + Convert.ToString(dgvBGManage[0, dgvBGManage.CurrentCell.RowIndex].Value).Trim() + "");
                MessageBox.Show("�������ɾ���ɹ���", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmBGManage_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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