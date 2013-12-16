namespace SMS.BasicInfo
{
    partial class frmGoodsInfo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoodsInfo));
            this.label3 = new System.Windows.Forms.Label();
            this.txtGSpec = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.txtGNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvGInfo = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxGUnit = new System.Windows.Forms.ComboBox();
            this.txtMNum = new System.Windows.Forms.TextBox();
            this.Lab = new System.Windows.Forms.Label();
            this.txtLNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGOPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGIPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorPrMoney = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorPrMoney)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "计量单位";
            // 
            // txtGSpec
            // 
            this.txtGSpec.Location = new System.Drawing.Point(291, 29);
            this.txtGSpec.Name = "txtGSpec";
            this.txtGSpec.ReadOnly = true;
            this.txtGSpec.Size = new System.Drawing.Size(100, 21);
            this.txtGSpec.TabIndex = 1;
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(34, 86);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "删除";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(34, 43);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "修改";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(12, 386);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(565, 17);
            this.hScrollBar1.TabIndex = 5;
            // 
            // txtGNum
            // 
            this.txtGNum.Location = new System.Drawing.Point(291, 67);
            this.txtGNum.Name = "txtGNum";
            this.txtGNum.ReadOnly = true;
            this.txtGNum.Size = new System.Drawing.Size(100, 21);
            this.txtGNum.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "库存数量";
            // 
            // dgvGInfo
            // 
            this.dgvGInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGInfo.Location = new System.Drawing.Point(12, 202);
            this.dgvGInfo.Name = "dgvGInfo";
            this.dgvGInfo.ReadOnly = true;
            this.dgvGInfo.RowTemplate.Height = 23;
            this.dgvGInfo.Size = new System.Drawing.Size(565, 201);
            this.dgvGInfo.TabIndex = 3;
            this.dgvGInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGInfo_CellClick);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(34, 129);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "货物规格";
            // 
            // txtGName
            // 
            this.txtGName.Location = new System.Drawing.Point(100, 29);
            this.txtGName.Name = "txtGName";
            this.txtGName.ReadOnly = true;
            this.txtGName.Size = new System.Drawing.Size(100, 21);
            this.txtGName.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboxGUnit);
            this.groupBox1.Controls.Add(this.txtMNum);
            this.groupBox1.Controls.Add(this.Lab);
            this.groupBox1.Controls.Add(this.txtLNum);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGOPrice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtGIPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtGSpec);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtGName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 185);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // cboxGUnit
            // 
            this.cboxGUnit.FormattingEnabled = true;
            this.cboxGUnit.Items.AddRange(new object[] {
            "个",
            "件",
            "瓶",
            "斤",
            "两",
            "公斤",
            "千克",
            "吨",
            "米",
            "台",
            "部",
            "辆"});
            this.cboxGUnit.Location = new System.Drawing.Point(100, 67);
            this.cboxGUnit.MaxDropDownItems = 100;
            this.cboxGUnit.Name = "cboxGUnit";
            this.cboxGUnit.Size = new System.Drawing.Size(100, 20);
            this.cboxGUnit.TabIndex = 2;
            // 
            // txtMNum
            // 
            this.txtMNum.Location = new System.Drawing.Point(291, 143);
            this.txtMNum.Name = "txtMNum";
            this.txtMNum.Size = new System.Drawing.Size(100, 21);
            this.txtMNum.TabIndex = 5;
            // 
            // Lab
            // 
            this.Lab.AutoSize = true;
            this.Lab.Location = new System.Drawing.Point(208, 146);
            this.Lab.Name = "Lab";
            this.Lab.Size = new System.Drawing.Size(77, 12);
            this.Lab.TabIndex = 14;
            this.Lab.Text = "警戒顶线库存";
            // 
            // txtLNum
            // 
            this.txtLNum.Location = new System.Drawing.Point(100, 143);
            this.txtLNum.Name = "txtLNum";
            this.txtLNum.Size = new System.Drawing.Size(100, 21);
            this.txtLNum.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "警戒底线库存";
            // 
            // txtGOPrice
            // 
            this.txtGOPrice.Location = new System.Drawing.Point(291, 105);
            this.txtGOPrice.Name = "txtGOPrice";
            this.txtGOPrice.Size = new System.Drawing.Size(100, 21);
            this.txtGOPrice.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "销售价格";
            // 
            // txtGIPrice
            // 
            this.txtGIPrice.Location = new System.Drawing.Point(100, 105);
            this.txtGIPrice.Name = "txtGIPrice";
            this.txtGIPrice.ReadOnly = true;
            this.txtGIPrice.Size = new System.Drawing.Size(100, 21);
            this.txtGIPrice.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "进货价格";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "货物名称";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Location = new System.Drawing.Point(441, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 185);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // errorPrMoney
            // 
            this.errorPrMoney.ContainerControl = this;
            // 
            // frmGoodsInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 416);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.dgvGInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGoodsInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "货物档案设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGoodsInfo_FormClosed);
            this.Load += new System.EventHandler(this.frmGoodsInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorPrMoney)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGSpec;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.TextBox txtGNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvGInfo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMNum;
        private System.Windows.Forms.Label Lab;
        private System.Windows.Forms.TextBox txtLNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGOPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGIPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxGUnit;
        private System.Windows.Forms.ErrorProvider errorPrMoney;
    }
}