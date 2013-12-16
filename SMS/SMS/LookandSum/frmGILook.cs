using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.LookandSum
{
    public partial class frmGILook : Form
    {
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        public frmGILook()
        {
            InitializeComponent();
        }

        private void frmGILook_Load(object sender, EventArgs e)
        {
            dgvGInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select GoodsID as ������,GoodsName as ��������,"
                + "StoreName as �ֿ�����,GoodsSpec as ������,GoodsUnit as ������λ,"
                + "GoodsNum as ��������,GoodsInPrice as �����۸�,GoodsOutPrice as �����۸�,"
                + "GoodsLeast as ��ʹ洢,GoodsMost as ��ߴ洢,Editer as �޸���,EditDate as �޸����� from tb_GoodsInfo", "tb_GoodsInfo");
            dgvGInfo.DataSource = myds.Tables[0];
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLKWord.Text.Trim() == "")
                {
                    frmGILook_Load(sender, e);
                }
                else
                {
                    if (cboxLCondition.Text.Trim() == "������")
                    {
                        DataSet myds = datacon.getds("select GoodsID as ������,GoodsName as ��������,"
                            + "StoreName as �ֿ�����,GoodsSpec as ������,GoodsUnit as ������λ,"
                            + "GoodsNum as ��������,GoodsInPrice as �����۸�,GoodsOutPrice as �����۸�,"
                            + "GoodsLeast as ��ʹ洢,GoodsMost as ��ߴ洢,Editer as �޸���,EditDate as �޸�����"
                            + " from tb_GoodsInfo where GoodsID = " + txtLKWord.Text.Trim() + "", "tb_GoodsInfo");
                        dgvGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "��������")
                    {
                        DataSet myds = datacon.getds("select GoodsID as ������,GoodsName as ��������,"
                            + "StoreName as �ֿ�����,GoodsSpec as ������,GoodsUnit as ������λ,"
                            + "GoodsNum as ��������,GoodsInPrice as �����۸�,GoodsOutPrice as �����۸�,"
                            + "GoodsLeast as ��ʹ洢,GoodsMost as ��ߴ洢,Editer as �޸���,EditDate as �޸�����"
                            + " from tb_GoodsInfo where GoodsName like '%" + txtLKWord.Text.Trim() + "%'", "tb_GoodsInfo");
                        dgvGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "�ֿ�����")
                    {
                        DataSet myds = datacon.getds("select GoodsID as ������,GoodsName as ��������,"
                            + "StoreName as �ֿ�����,GoodsSpec as ������,GoodsUnit as ������λ,"
                            + "GoodsNum as ��������,GoodsInPrice as �����۸�,GoodsOutPrice as �����۸�,"
                            + "GoodsLeast as ��ʹ洢,GoodsMost as ��ߴ洢,Editer as �޸���,EditDate as �޸�����"
                            + " from tb_GoodsInfo where StoreName like '%" + txtLKWord.Text.Trim() + "%'", "tb_GoodsInfo");
                        dgvGInfo.DataSource = myds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGILook_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}