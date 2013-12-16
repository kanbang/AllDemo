using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS.LookandSum
{
    public partial class frmRGLook : Form
    {
        public frmRGLook()
        {
            InitializeComponent();
        }

        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        private void frmRGLook_Load(object sender, EventArgs e)
        {
            dgvRGInfo.Controls.Add(hScrollBar1);
            DataSet myds = datacon.getds("select RGID as �������,BGID as ������,StoreName as �ֿ�����,GoodsName as ��������,"
                + "RGNum as �黹����,NRGNum as δ�黹����,RGDate as ��������,HandlePeople as ������,RGPeople as ������,RGRemark as ��ע,"
                + "Editer as �޸���,EditDate as �޸����� from tb_ReturnGoods", "tb_ReturnGoods");
            dgvRGInfo.DataSource = myds.Tables[0];
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLKWord.Text.Trim() == "")
                {
                    frmRGLook_Load(sender, e);
                }
                else
                {
                    if (cboxLCondition.Text.Trim() == "�������")
                    {
                        DataSet myds = datacon.getds("select RGID as �������,BGID as ������,StoreName as �ֿ�����,GoodsName as ��������,"
                            + "RGNum as �黹����,NRGNum as δ�黹����,RGDate as ��������,HandlePeople as ������,RGPeople as ������,RGRemark as ��ע,"
                            + "Editer as �޸���,EditDate as �޸����� from tb_ReturnGoods where RGID = " + txtLKWord.Text.Trim() + "", "tb_ReturnGoods");
                        dgvRGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "������")
                    {
                        DataSet myds = datacon.getds("select RGID as �������,BGID as ������,StoreName as �ֿ�����,GoodsName as ��������,"
                            + "RGNum as �黹����,NRGNum as δ�黹����,RGDate as ��������,HandlePeople as ������,RGPeople as ������,RGRemark as ��ע,"
                            + "Editer as �޸���,EditDate as �޸����� from tb_ReturnGoods where BGID = " + txtLKWord.Text.Trim() + "", "tb_ReturnGoods");
                        dgvRGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "��������")
                    {
                        string P_str_dtime=txtLKWord.Text.Trim();
                        DataSet myds = datacon.getds("select RGID as �������,BGID as ������,StoreName as �ֿ�����,GoodsName as ��������,"
                            + "RGNum as �黹����,NRGNum as δ�黹����,RGDate as ��������,HandlePeople as ������,RGPeople as ������,RGRemark as ��ע,"
                            + "Editer as �޸���,EditDate as �޸����� from tb_ReturnGoods where year(RGDate)=" + P_str_dtime.Substring(0, 4) 
                            + " and month(RGDate)=" + P_str_dtime.Substring(5, P_str_dtime.Length - 6) + "", "tb_ReturnGoods");
                        dgvRGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "�ֿ�����")
                    {
                        DataSet myds = datacon.getds("select RGID as �������,BGID as ������,StoreName as �ֿ�����,GoodsName as ��������,"
                            + "RGNum as �黹����,NRGNum as δ�黹����,RGDate as ��������,HandlePeople as ������,RGPeople as ������,RGRemark as ��ע,"
                            + "Editer as �޸���,EditDate as �޸����� from tb_ReturnGoods where StoreName like '%" + txtLKWord.Text.Trim() + "%'", "tb_ReturnGoods");
                        dgvRGInfo.DataSource = myds.Tables[0];
                    }
                    if (cboxLCondition.Text.Trim() == "��������")
                    {
                        DataSet myds = datacon.getds("select RGID as �������,BGID as ������,StoreName as �ֿ�����,GoodsName as ��������,"
                            + "RGNum as �黹����,NRGNum as δ�黹����,RGDate as ��������,HandlePeople as ������,RGPeople as ������,RGRemark as ��ע,"
                            + "Editer as �޸���,EditDate as �޸����� from tb_ReturnGoods where GoodsName like '%" + txtLKWord.Text.Trim() + "%'", "tb_ReturnGoods");
                        dgvRGInfo.DataSource = myds.Tables[0];
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

        private void frmRGLook_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}