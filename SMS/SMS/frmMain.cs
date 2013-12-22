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
			tsslUser.Text = "操作用户权限：" + frmLogin.M_str_right.ToString().Trim();
			tsslDate.Text = DateTime.Today.ToLongDateString();
			tsslTime.Text = "登录系统时间：" + DateTime.Now.ToShortTimeString();
			if(frmLogin.M_str_right=="普通用户"){
				入库管理ToolStripMenuItem.Enabled = false;
				出库管理ToolStripMenuItem.Enabled = false;
				借货还货ToolStripMenuItem.Enabled = false;
				盘点管理ToolStripMenuItem.Enabled = false;
				供货商设置ToolStripMenuItem.Enabled = false;
				货物档案设置ToolStripMenuItem.Enabled = false;
				仓库设置ToolStripMenuItem.Enabled = false;
				权限设置ToolStripMenuItem.Enabled = false;
				用户管理ToolStripMenuItem.Enabled = false;
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
			if (MessageBox.Show("您真的要退出本系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
			{
				Application.Exit();
			}
			else
			{
				frmMain fmain = new frmMain();
				fmain.Show();
			}
		}

		private void 入库管理ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnIS_Click(sender, e);
		}

		private void 出库管理ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnOS_Click(sender,e);
		}

		private void 借货还货ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnBR_Click(sender, e);
		}

		private void 盘点管理ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnCM_Click(sender, e);
		}

		private void 供货商设置ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnPI_Click(sender, e);
		}

		private void 货物档案设置ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnGI_Click(sender, e);
		}

		private void 仓库设置ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnSI_Click(sender, e);
		}

		private void 库存查询ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnSL_Click(sender, e);
		}

		private void 入库查询ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnISL_Click(sender, e);
		}

		private void 出库查询ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnOSL_Click(sender, e);
		}

		private void 出入库货物年统计ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnIOYS_Click(sender, e);
		}

		private void 出入库货物月统计ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnIOMS_Click(sender, e);
		}

		private void 货物借出查询ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnGOL_Click(sender, e);
		}

		private void 货物归还查询ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnGIL_Click(sender, e);
		}

		private void 警戒货物ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnWG_Click(sender, e);
		}

		private void 数据备份ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnDS_Click(sender, e);
		}

		private void 数据恢复ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnDR_Click(sender, e);
		}

		private void 数据压缩ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnDC_Click(sender, e);
		}

		private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnEP_Click(sender, e);
		}

		private void 权限设置ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnRI_Click(sender, e);
		}

		private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnUM_Click(sender, e);
		}

		private void 关于本系统ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnAU_Click(sender, e);
		}

		private void 货物管理ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 0;
		}

		private void 基本档案ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 1;
		}

		private void 查询统计ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 2;
		}

		private void 系统维护ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 3;
		}

		private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 4;
		}

		private void 重新登录ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmLogin flogin = new frmLogin();
			flogin.Show();
			this.Dispose();
		}

		private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btnExit_Click(sender, e);
		}
	}
}