namespace SMS.GoodsManage
{
    partial class frmOSManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOSManage));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOSGNum = new System.Windows.Forms.TextBox();
            this.cboxGUnit = new System.Windows.Forms.ComboBox();
            this.txtOSPeople = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOSUnit = new System.Windows.Forms.TextBox();
            this.cboxGSpec = new System.Windows.Forms.ComboBox();
            this.txtHPeople = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboxGName = new System.Windows.Forms.ComboBox();
            this.cboxSName = new System.Windows.Forms.ComboBox();
            this.txtOSRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGOPrice = new System.Windows.Forms.TextBox();
            this.labGPrice = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGSPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.dgvOSManage = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOSManage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOSGNum);
            this.groupBox1.Controls.Add(this.cboxGUnit);
            this.groupBox1.Controls.Add(this.txtOSPeople);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtOSUnit);
            this.groupBox1.Controls.Add(this.cboxGSpec);
            this.groupBox1.Controls.Add(this.txtHPeople);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboxGName);
            this.groupBox1.Controls.Add(this.cboxSName);
            this.groupBox1.Controls.Add(this.txtOSRemark);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtGOPrice);
            this.groupBox1.Controls.Add(this.labGPrice);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGSPrice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 237);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // txtOSGNum
            // 
            this.txtOSGNum.Location = new System.Drawing.Point(95, 81);
            this.txtOSGNum.Name = "txtOSGNum";
            this.txtOSGNum.Size = new System.Drawing.Size(100, 21);
            this.txtOSGNum.TabIndex = 4;
            this.txtOSGNum.TextChanged += new System.EventHandler(this.txtOSGNum_TextChanged);
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
            this.cboxGUnit.Location = new System.Drawing.Point(286, 52);
            this.cboxGUnit.MaxDropDownItems = 100;
            this.cboxGUnit.Name = "cboxGUnit";
            this.cboxGUnit.Size = new System.Drawing.Size(100, 20);
            this.cboxGUnit.TabIndex = 3;
            // 
            // txtOSPeople
            // 
            this.txtOSPeople.Location = new System.Drawing.Point(286, 110);
            this.txtOSPeople.Name = "txtOSPeople";
            this.txtOSPeople.Size = new System.Drawing.Size(100, 21);
            this.txtOSPeople.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "提货人";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "提货单位";
            // 
            // txtOSUnit
            // 
            this.txtOSUnit.Location = new System.Drawing.Point(95, 141);
            this.txtOSUnit.Name = "txtOSUnit";
            this.txtOSUnit.Size = new System.Drawing.Size(100, 21);
            this.txtOSUnit.TabIndex = 6;
            // 
            // cboxGSpec
            // 
            this.cboxGSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxGSpec.FormattingEnabled = true;
            this.cboxGSpec.Location = new System.Drawing.Point(95, 54);
            this.cboxGSpec.Name = "cboxGSpec";
            this.cboxGSpec.Size = new System.Drawing.Size(100, 20);
            this.cboxGSpec.TabIndex = 2;
            // 
            // txtHPeople
            // 
            this.txtHPeople.Location = new System.Drawing.Point(286, 139);
            this.txtHPeople.Name = "txtHPeople";
            this.txtHPeople.Size = new System.Drawing.Size(100, 21);
            this.txtHPeople.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(223, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "经手人";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "出货总金额";
            // 
            // cboxGName
            // 
            this.cboxGName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxGName.FormattingEnabled = true;
            this.cboxGName.Location = new System.Drawing.Point(286, 23);
            this.cboxGName.Name = "cboxGName";
            this.cboxGName.Size = new System.Drawing.Size(100, 20);
            this.cboxGName.TabIndex = 1;
            this.cboxGName.SelectedIndexChanged += new System.EventHandler(this.cboxGName_SelectedIndexChanged);
            // 
            // cboxSName
            // 
            this.cboxSName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSName.FormattingEnabled = true;
            this.cboxSName.Location = new System.Drawing.Point(95, 23);
            this.cboxSName.Name = "cboxSName";
            this.cboxSName.Size = new System.Drawing.Size(100, 20);
            this.cboxSName.TabIndex = 0;
            this.cboxSName.SelectedIndexChanged += new System.EventHandler(this.cboxSName_SelectedIndexChanged);
            // 
            // txtOSRemark
            // 
            this.txtOSRemark.Location = new System.Drawing.Point(95, 171);
            this.txtOSRemark.Multiline = true;
            this.txtOSRemark.Name = "txtOSRemark";
            this.txtOSRemark.Size = new System.Drawing.Size(291, 48);
            this.txtOSRemark.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "备注";
            // 
            // txtGOPrice
            // 
            this.txtGOPrice.Location = new System.Drawing.Point(286, 81);
            this.txtGOPrice.Name = "txtGOPrice";
            this.txtGOPrice.ReadOnly = true;
            this.txtGOPrice.Size = new System.Drawing.Size(100, 21);
            this.txtGOPrice.TabIndex = 15;
            // 
            // labGPrice
            // 
            this.labGPrice.AutoSize = true;
            this.labGPrice.Location = new System.Drawing.Point(217, 84);
            this.labGPrice.Name = "labGPrice";
            this.labGPrice.Size = new System.Drawing.Size(53, 12);
            this.labGPrice.TabIndex = 14;
            this.labGPrice.Text = "货物单价";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "出库数量";
            // 
            // txtGSPrice
            // 
            this.txtGSPrice.Location = new System.Drawing.Point(95, 114);
            this.txtGSPrice.Name = "txtGSPrice";
            this.txtGSPrice.ReadOnly = true;
            this.txtGSPrice.Size = new System.Drawing.Size(100, 21);
            this.txtGSPrice.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "计量单位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "货物规格";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "货物名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓库名称";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(441, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 237);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(34, 117);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "退出";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(34, 80);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 10;
            this.btnDel.Text = "删除";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(34, 43);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "出库";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(12, 387);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(565, 17);
            this.hScrollBar1.TabIndex = 21;
            // 
            // dgvOSManage
            // 
            this.dgvOSManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOSManage.Location = new System.Drawing.Point(12, 255);
            this.dgvOSManage.Name = "dgvOSManage";
            this.dgvOSManage.ReadOnly = true;
            this.dgvOSManage.RowTemplate.Height = 23;
            this.dgvOSManage.Size = new System.Drawing.Size(565, 149);
            this.dgvOSManage.TabIndex = 19;
            this.dgvOSManage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOSManage_CellClick);
            // 
            // frmOSManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 416);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.dgvOSManage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOSManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "货物出库管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOSManage_FormClosed);
            this.Load += new System.EventHandler(this.frmOSManage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOSManage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHPeople;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboxGName;
        private System.Windows.Forms.ComboBox cboxSName;
        private System.Windows.Forms.TextBox txtOSRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGOPrice;
        private System.Windows.Forms.Label labGPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGSPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.DataGridView dgvOSManage;
        private System.Windows.Forms.ComboBox cboxGSpec;
        private System.Windows.Forms.TextBox txtOSPeople;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOSUnit;
        private System.Windows.Forms.ComboBox cboxGUnit;
        private System.Windows.Forms.TextBox txtOSGNum;
    }
}