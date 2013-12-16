using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS.LookandSum
{
    public partial class frmIOSYSum : Form
    {
        SMS.BaseClass.DataCon datacon = new SMS.BaseClass.DataCon();
        SMS.BaseClass.DataOperate doperate = new SMS.BaseClass.DataOperate();
        public frmIOSYSum()
        {
            InitializeComponent();
        }
        
        private void frmIOSDSum_Load(object sender, EventArgs e)
        {
            doperate.cboxBind("select distinct StoreName from tb_InStore", "tb_InStore", "StoreName", cboxStore);
        }
        private void btnSum_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Enabled = true;
            Graphics objgraphics = this.CreateGraphics();
            string P_str_imagePath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            P_str_imagePath += @"\Image\image\" + DateTime.Now.ToString("yyyyMMddhhmss") + ".jpg";
            try
            {
                if (cboxSType.Text.Trim()=="入库货物统计")
                {
                    doperate.drawPic(objgraphics, "select GoodsID,GoodsName,StoreName,sum(GoodsNum) as GSNum,ISDate from tb_InStore "
                        + "where StoreName='" + cboxStore.Text.Trim() + "' and year(ISDate)='" + cboxYear.Text.Trim()
                        + "'group by GoodsID,GoodsName,StoreName,ISDate", "tb_InStore", "GSNum", "GoodsName", "入库货物年统计");
                }
                else if (cboxSType.Text.Trim() == "出库货物统计")
                {
                    doperate.drawPic(objgraphics, "select GoodsName,StoreName,sum(GoodsNum) as GSNum,OSDate from tb_OutStore "
                        + "where StoreName='" + cboxStore.Text.Trim() + "' and year(OSDate)='" + cboxYear.Text.Trim()
                        + "'group by GoodsName,StoreName,OSDate", "tb_OutStore", "GSNum", "GoodsName", "出库货物年统计");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                System.Drawing.Image myImage = Image.FromFile(P_str_imagePath);
                picbox.Image = myImage;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboxSType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxSType.Text.Trim() == "入库货物统计")
            {
                frmIOSDSum_Load(sender, e);
            }
            else if (cboxSType.Text.Trim() == "出库货物统计")
            {
                doperate.cboxBind("select distinct StoreName from tb_OutStore", "tb_OutStore", "StoreName", cboxStore);
            }
        }

        private void frmIOSDSum_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}