using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.LookandSum
{
    public partial class frmOSLook : Form
    {
        public frmOSLook()
        {
            InitializeComponent();
        }

        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        private void frmOSLook_Load(object sender, EventArgs e)
        {
            dgvOSInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select OSID as ������,StoreName as �ֿ�����,GoodsName as ��������,"
                + "GoodsSpec as ���,GoodsUnit as ������λ,GoodsNum as ��������,GoodsPrice as �۸�,GoodsAPrice as �ܽ��,"
                + "OSDate as ��������,PGProvider as �����λ,PGPeople as �����,"
                + "HandlePeople as ������,OSRemark as ��ע from tb_OutStore", "tb_OutStore");
            dgvOSInfo.DataSource = myds.Tables[0];
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLKWord.Text.Trim() == "")
                {
                    frmOSLook_Load(sender, e);
                }
                else
                {
                    if (cboxLCondition.Text.Trim() == "������")
                    {
                        DataSet myds = datacon.getds("select OSID as ������,StoreName as �ֿ�����,GoodsName as ��������,"
                            + "GoodsSpec as ���,GoodsUnit as ������λ,GoodsNum as ��������,GoodsPrice as �۸�,GoodsAPrice as �ܽ��,"
                            + "OSDate as ��������,PGProvider as �����λ,PGPeople as �����,"
                            + "HandlePeople as ������,OSRemark as ��ע from tb_OutStore where OSID = " + txtLKWord.Text.Trim() + "", "tb_OutStore");
                        dgvOSInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "��������")
                    {
                        string P_str_dtime = txtLKWord.Text.Trim();
                        DataSet myds = datacon.getds("select OSID as ������,StoreName as �ֿ�����,GoodsName as ��������,"
                            + "GoodsSpec as ���,GoodsUnit as ������λ,GoodsNum as ��������,GoodsPrice as �۸�,GoodsAPrice as �ܽ��,"
                            + "OSDate as ��������,PGProvider as �����λ,PGPeople as �����,"
                            + "HandlePeople as ������,OSRemark as ��ע from tb_OutStore where year(OSDate)=" + P_str_dtime.Substring(0, 4)
                            + " and month(OSDate)=" + P_str_dtime.Substring(5, P_str_dtime.Length - 6) + "", "tb_OutStore");
                        dgvOSInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "�ֿ�����")
                    {
                        DataSet myds = datacon.getds("select OSID as ������,StoreName as �ֿ�����,GoodsName as ��������,"
                            + "GoodsSpec as ���,GoodsUnit as ������λ,GoodsNum as ��������,GoodsPrice as �۸�,GoodsAPrice as �ܽ��,"
                            + "OSDate as ��������,PGProvider as �����λ,PGPeople as �����,"
                            + "HandlePeople as ������,OSRemark as ��ע from tb_OutStore where StoreName like '%" 
                            + txtLKWord.Text.Trim() + "%'", "tb_OutStore");
                        dgvOSInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "��������")
                    {
                        DataSet myds = datacon.getds("select OSID as ������,StoreName as �ֿ�����,GoodsName as ��������,"
                            + "GoodsSpec as ���,GoodsUnit as ������λ,GoodsNum as ��������,GoodsPrice as �۸�,GoodsAPrice as �ܽ��,"
                            + "OSDate as ��������,PGProvider as �����λ,PGPeople as �����,"
                            + "HandlePeople as ������,OSRemark as ��ע from tb_OutStore where GoodsName like '%"
                            + txtLKWord.Text.Trim() + "%'", "tb_OutStore");
                        dgvOSInfo.DataSource = myds.Tables[0];
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
            if (cboxLCondition.Text.Trim() == "��������")
            {
                label2.Text = "��ѯ���·�";
            }
            else
            {
                label2.Text = "��ѯ�ؼ���";
            }
        }

        private void frmOSLook_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}