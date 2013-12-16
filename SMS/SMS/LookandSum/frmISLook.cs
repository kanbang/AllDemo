using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.LookandSum
{
    public partial class frmISLook : Form
    {
        public frmISLook()
        {
            InitializeComponent();
        }

        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        private void frmISLook_Load(object sender, EventArgs e)
        {
            dgvISInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select ISID as �����,GoodsID as ������,GoodsName as ��������,"
                + "PrName as ��Ӧ������,StoreName as �ֿ�����,GoodsSpec as ������,GoodsUnit as ������λ,"
                + "GoodsNum as �������,GoodsPrice as �����۸�,GoodsAPrice as �ܽ��,ISDate as �������,"
                + "HandlePeople as ������,ISRemark as ��ע from tb_InStore", "tb_InStore");
            dgvISInfo.DataSource = myds.Tables[0];
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLKWord.Text.Trim() == "")
                {
                    frmISLook_Load(sender, e);
                }
                else
                {
                    if (cboxLCondition.Text.Trim() == "�����")
                    {
                        DataSet myds = datacon.getds("select ISID as �����,GoodsID as ������,GoodsName as ��������,PrName as ��Ӧ������,"
                            + "StoreName as �ֿ�����,GoodsSpec as ������,GoodsUnit as ������λ,GoodsNum as �������,"
                            + "GoodsPrice as �����۸�,GoodsAPrice as �ܽ��,ISDate as �������,HandlePeople as ������,"
                            + "ISRemark as ��ע from tb_InStore where ISID = " + txtLKWord.Text.Trim() + "", "tb_InStore");
                        dgvISInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "������")
                    {
                        DataSet myds = datacon.getds("select ISID as �����,GoodsID as ������,GoodsName as ��������,PrName as ��Ӧ������,"
                            + "StoreName as �ֿ�����,GoodsSpec as ������,GoodsUnit as ������λ,GoodsNum as �������,"
                            + "GoodsPrice as �����۸�,GoodsAPrice as �ܽ��,ISDate as �������,HandlePeople as ������,"
                            + "ISRemark as ��ע from tb_InStore where GoodsID = " + txtLKWord.Text.Trim() + "", "tb_InStore");
                        dgvISInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "�������")
                    {
                        string P_str_dtime = txtLKWord.Text.Trim();
                        DataSet myds = datacon.getds("select ISID as �����,GoodsID as ������,GoodsName as ��������,PrName as ��Ӧ������,"
                            + "StoreName as �ֿ�����,GoodsSpec as ������,GoodsUnit as ������λ,GoodsNum as �������,"
                            + "GoodsPrice as �����۸�,GoodsAPrice as �ܽ��,ISDate as �������,HandlePeople as ������,"
                            + "ISRemark as ��ע from tb_InStore where year(ISDate)=" + P_str_dtime.Substring(0, 4)
                            + " and month(ISDate)=" + P_str_dtime.Substring(5, P_str_dtime.Length - 6) + "", "tb_InStore");
                        dgvISInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "�ֿ�����")
                    {
                        DataSet myds = datacon.getds("select ISID as �����,GoodsID as ������,GoodsName as ��������,PrName as ��Ӧ������,"
                            + "StoreName as �ֿ�����,GoodsSpec as ������,GoodsUnit as ������λ,GoodsNum as �������,"
                            + "GoodsPrice as �����۸�,GoodsAPrice as �ܽ��,ISDate as �������,HandlePeople as ������,"
                            + "ISRemark as ��ע from tb_InStore where StoreName like '%" + txtLKWord.Text.Trim() + "%'", "tb_InStore");
                        dgvISInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "��������")
                    {
                        DataSet myds = datacon.getds("select ISID as �����,GoodsID as ������,GoodsName as ��������,PrName as ��Ӧ������,"
                            + "StoreName as �ֿ�����,GoodsSpec as ������,GoodsUnit as ������λ,GoodsNum as �������,"
                            + "GoodsPrice as �����۸�,GoodsAPrice as �ܽ��,ISDate as �������,HandlePeople as ������,"
                            + "ISRemark as ��ע from tb_InStore where GoodsName like '%" + txtLKWord.Text.Trim() + "%'", "tb_InStore");
                        dgvISInfo.DataSource = myds.Tables[0];
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

        private void frmISLook_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}