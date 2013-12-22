using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
//Download by http://www.codefans.net
namespace SMS
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			tsslUser.Text = "�����û�Ȩ�ޣ�" + frmLogin.M_str_right.ToString().Trim();
			tsslDate.Text = DateTime.Today.ToLongDateString();
			tsslTime.Text = "��¼ϵͳʱ�䣺" + DateTime.Now.ToShortTimeString();
			if(frmLogin.M_str_right=="��ͨ�û�"){
				������ToolStripMenuItem.Enabled = false;
				�������ToolStripMenuItem.Enabled = false;
				�������ToolStripMenuItem.Enabled = false;
				�̵����ToolStripMenuItem.Enabled = false;
				����������ToolStripMenuItem.Enabled = false;
				���ﵵ������ToolStripMenuItem.Enabled = false;
				�ֿ�����ToolStripMenuItem.Enabled = false;
				Ȩ������ToolStripMenuItem.Enabled = false;
				�û�����ToolStripMenuItem.Enabled = false;
				btnIS.Enabled = false;
				btnOS.Enabled = false;
				btnBR.Enabled = false;
				btnCM.Enabled = false;
				btnPI.Enabled = false;
				btnGI.Enabled = false;
				btnSI.Enabled = false;
				btnRI.Enabled = false;
				btnUM.Enabled = false;
			}
		}

		private void btnIS_Click(object sender, EventArgs e)
		{
			GoodsManage.frmISManage GMfism = new SMS.GoodsManage.frmISManage();
			GMfism.ShowDialog();
		}

		private void btnOS_Click(object sender, EventArgs e)
		{
			GoodsManage.frmOSManage GMfosm = new SMS.GoodsManage.frmOSManage();
			GMfosm.ShowDialog();
		}

		private void btnBR_Click(object sender, EventArgs e)
		{
			GoodsManage.frmBGManage GMfbgm = new SMS.GoodsManage.frmBGManage();
			GMfbgm.ShowDialog();
		}

		private void btnCM_Click(object sender, EventArgs e)
		{
			SMS.GoodsManage.frmCKManage GMfckm = new SMS.GoodsManage.frmCKManage();
			GMfckm.ShowDialog();
		}

		private void btnPI_Click(object sender, EventArgs e)
		{
			BasicInfo.frmPrInfo BIfpi = new SMS.BasicInfo.frmPrInfo();
			BIfpi.ShowDialog();
		}

		private void btnGI_Click(object sender, EventArgs e)
		{
			BasicInfo.frmGoodsInfo BIfgi = new SMS.BasicInfo.frmGoodsInfo();
			BIfgi.ShowDialog();
		}

		private void btnSI_Click(object sender, EventArgs e)
		{
			BasicInfo.frmStoreInfo BIfsi = new SMS.BasicInfo.frmStoreInfo();
			BIfsi.ShowDialog();
		}

		private void btnSL_Click(object sender, EventArgs e)
		{
			LookandSum.frmGILook LSfgil = new SMS.LookandSum.frmGILook();
			LSfgil.ShowDialog();
		}

		private void btnISL_Click(object sender, EventArgs e)
		{
			LookandSum.frmISLook LSfisl = new SMS.LookandSum.frmISLook();
			LSfisl.ShowDialog();
		}

		private void btnOSL_Click(object sender, EventArgs e)
		{
			LookandSum.frmOSLook LSfosl = new SMS.LookandSum.frmOSLook();
			LSfosl.ShowDialog();
		}

		private void btnIOYS_Click(object sender, EventArgs e)
		{
			LookandSum.frmIOSYSum LSfiosys = new SMS.LookandSum.frmIOSYSum();
			LSfiosys.ShowDialog();
		}

		private void btnIOMS_Click(object sender, EventArgs e)
		{
			LookandSum.frmIOSMSum LSfiosms = new SMS.LookandSum.frmIOSMSum();
			LSfiosms.ShowDialog();
		}

		private void btnGOL_Click(object sender, EventArgs e)
		{
			LookandSum.frmBGLook LSfbgl = new SMS.LookandSum.frmBGLook();
			LSfbgl.ShowDialog();
		}

		private void btnGIL_Click(object sender, EventArgs e)
		{
			LookandSum.frmRGLook LSfrgl = new SMS.LookandSum.frmRGLook();
			LSfrgl.ShowDialog();
		}

		private void btnWG_Click(object sender, EventArgs e)
		{
			LookandSum.frmWGLook LSfwgl = new SMS.LookandSum.frmWGLook();
			LSfwgl.ShowDialog();
		}

		private void btnDS_Click(object sender, EventArgs e)
		{
			SysManage.frmDataStore SMfds = new SMS.SysManage.frmDataStore();
			SMfds.ShowDialog();
		}

		private void btnDR_Click(object sender, EventArgs e)
		{
			SysManage.frmDataRevert SMfdr = new SMS.SysManage.frmDataRevert();
			SMfdr.ShowDialog();
		}

		private void btnDC_Click(object sender, EventArgs e)
		{
			SysManage.frmDataCut SMfdc = new SMS.SysManage.frmDataCut();
			SMfdc.ShowDialog();
		}

		private void btnEP_Click(object sender, EventArgs e)
		{
			Help.frmEditPwd HPfep = new SMS.Help.frmEditPwd();
			HPfep.ShowDialog();
		}

		private void btnRI_Click(object sender, EventArgs e)
		{
			Help.frmRightManage HPfrm = new SMS.Help.frmRightManage();
			HPfrm.ShowDialog();
		}

		private void btnUM_Click(object sender, EventArgs e)
		{
			Help.frmUserManage HPfum = new SMS.Help.frmUserManage();
			HPfum.ShowDialog();
		}

		private void btnAU_Click(object sender, EventArgs e)
		{
			Help.frmAboutUs HPfau = new SMS.Help.frmAboutUs();
			HPfau.ShowDialog();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (MessageBox.Show("�����Ҫ�˳���ϵͳ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
			{
				Application.Exit();
			}
			else
			{
				frmMain fmain = new frmMain();
				fmain.Show();
			}
		}

		private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnIS_Click(sender, e);
		}

		private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnOS_Click(sender,e);
		}

		private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnBR_Click(sender, e);
		}

		private void �̵����ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnCM_Click(sender, e);
		}

		private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnPI_Click(sender, e);
		}

		private void ���ﵵ������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnGI_Click(sender, e);
		}

		private void �ֿ�����ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnSI_Click(sender, e);
		}

		private void ����ѯToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnSL_Click(sender, e);
		}

		private void ����ѯToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnISL_Click(sender, e);
		}

		private void �����ѯToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnOSL_Click(sender, e);
		}

		private void ����������ͳ��ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnIOYS_Click(sender, e);
		}

		private void ����������ͳ��ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnIOMS_Click(sender, e);
		}

		private void ��������ѯToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnGOL_Click(sender, e);
		}

		private void ����黹��ѯToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnGIL_Click(sender, e);
		}

		private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnWG_Click(sender, e);
		}

		private void ���ݱ���ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnDS_Click(sender, e);
		}

		private void ���ݻָ�ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnDR_Click(sender, e);
		}

		private void ����ѹ��ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnDC_Click(sender, e);
		}

		private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnEP_Click(sender, e);
		}

		private void Ȩ������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnRI_Click(sender, e);
		}

		private void �û�����ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnUM_Click(sender, e);
		}

		private void ���ڱ�ϵͳToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnAU_Click(sender, e);
		}

		private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 0;
		}

		private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 1;
		}

		private void ��ѯͳ��ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 2;
		}

		private void ϵͳά��ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 3;
		}

		private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 4;
		}

		private void ���µ�¼ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmLogin flogin = new frmLogin();
			flogin.Show();
			this.Dispose();
		}

		private void �˳�ϵͳToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnExit_Click(sender, e);
		}
	}
}