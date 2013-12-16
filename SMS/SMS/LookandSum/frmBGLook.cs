using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS.LookandSum
{
    public partial class frmBGLook : Form
    {
        public frmBGLook()
        {
            InitializeComponent();
        }

        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        private void frmBGLook_Load(object sender, EventArgs e)
        {
            dgvBGInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select BGID as ������,GoodsName as ��������,StoreName as �ֿ�����,"
                + "GoodsSpec as ������,GoodsNum as �������,BGDate as �������,HandlePeople as ������,"
                + "BGPeople as �����,BGUnit as �����λ,BGRemark as ��ע from tb_BorrowGoods", "tb_BorrowGoods");
            dgvBGInfo.DataSource = myds.Tables[0];
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLKWord.Text.Trim() == "")
                {
                    frmBGLook_Load(sender, e);
                }
                else
                {
                    if (cboxLCondition.Text.Trim() == "������")
                    {
                        DataSet myds = datacon.getds("select BGID as ������,GoodsName as ��������,StoreName as �ֿ�����,"
                            + "GoodsSpec as ������,GoodsNum as �������,BGDate as �������,HandlePeople as ������,"
                            + "BGPeople as �����,BGUnit as �����λ,BGRemark as ��ע from tb_BorrowGoods where BGID = " 
                            + txtLKWord.Text.Trim() + "", "tb_BorrowGoods");
                        dgvBGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "�������")
                    {
                        string P_str_dtime = txtLKWord.Text.Trim();
                        DataSet myds = datacon.getds("select BGID as ������,GoodsName as ��������,StoreName as �ֿ�����,"
                            + "GoodsSpec as ������,GoodsNum as �������,BGDate as �������,HandlePeople as ������,"
                            + "BGPeople as �����,BGUnit as �����λ,BGRemark as ��ע from tb_BorrowGoods"
                            + " where year(BGDate)=" + P_str_dtime.Substring(0, 4) + " and month(BGDate)="
                            + P_str_dtime.Substring(5, P_str_dtime.Length - 6) + "", "tb_BorrowGoods");
                        dgvBGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "�ֿ�����")
                    {
                        DataSet myds = datacon.getds("select BGID as ������,GoodsName as ��������,StoreName as �ֿ�����,"
                            + "GoodsSpec as ������,GoodsNum as �������,BGDate as �������,HandlePeople as ������,"
                            + "BGPeople as �����,BGUnit as �����λ,BGRemark as ��ע from tb_BorrowGoods where StoreName like '%" 
                            + txtLKWord.Text.Trim() + "%'", "tb_BorrowGoods");
                        dgvBGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "��������")
                    {
                        DataSet myds = datacon.getds("select BGID as ������,GoodsName as ��������,StoreName as �ֿ�����,"
                            + "GoodsSpec as ������,GoodsNum as �������,BGDate as �������,HandlePeople as ������,"
                            + "BGPeople as �����,BGUnit as �����λ,BGRemark as ��ע from tb_BorrowGoods where GoodsName like '%"
                            + txtLKWord.Text.Trim() + "%'", "tb_BorrowGoods");
                        dgvBGInfo.DataSource = myds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboxLCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxLCondition.Text.Trim() == "�������")
            {
                label2.Text = "��ѯ���·�";
            }
            else
            {
                label2.Text = "��ѯ�ؼ���";
            }
        }

        private void frmBGLook_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}