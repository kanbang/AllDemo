namespace SMS.GoodsManage
{
    partial class frmISManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmISManage));
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtISGName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxPName = new System.Windows.Forms.ComboBox();
            this.txtISGID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtISGNum = new System.Windows.Forms.TextBox();
            this.cboxSName = new System.Windows.Forms.ComboBox();
            this.txtISRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGIPrice = new System.Windows.Forms.TextBox();
            this.labGPrice = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxGUnit = new System.Windows.Forms.ComboBox();
            this.txtHPeople = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGSPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGSpec = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.dgvISManage = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvISManage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(34, 80);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 11;
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
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "入库";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(34, 117);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "退出";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "供应商名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "仓库名称";
            // 
            // txtISGName
            // 
            this.txtISGName.Location = new System.Drawing.Point(286, 23);
            this.txtISGName.Name = "txtISGName";
            this.txtISGName.Size = new System.Drawing.Size(100, 21);
            this.txtISGName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "货物名称";
            // 
            // cboxPName
            // 
            this.cboxPName.FormattingEnabled = true;
            this.cboxPName.Location = new System.Drawing.Point(286, 51);
            this.cboxPName.Name = "cboxPName";
            this.cboxPName.Size = new System.Drawing.Size(100, 20);
            this.cboxPName.TabIndex = 3;
            // 
            // txtISGID
            // 
            this.txtISGID.Location = new System.Drawing.Point(95, 23);
            this.txtISGID.Name = "txtISGID";
            this.txtISGID.Size = new System.Drawing.Size(100, 21);
            this.txtISGID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "货物编号";
            // 
            // txtISGNum
            // 
            this.txtISGNum.Location = new System.Drawing.Point(95, 107);
            this.txtISGNum.Name = "txtISGNum";
            this.txtISGNum.Size = new System.Drawing.Size(100, 21);
            this.txtISGNum.TabIndex = 6;
            // 
            // cboxSName
            // 
            this.cboxSName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSName.FormattingEnabled = true;
            this.cboxSName.Location = new System.Drawing.Point(95, 51);
            this.cboxSName.MaxDropDownItems = 10;
            this.cboxSName.Name = "cboxSName";
            this.cboxSName.Size = new System.Drawing.Size(100, 20);
            this.cboxSName.TabIndex = 2;
            // 
            // txtISRemark
            // 
            this.txtISRemark.Location = new System.Drawing.Point(95, 163);
            this.txtISRemark.Multiline = true;
            this.txtISRemark.Name = "txtISRemark";
            this.txtISRemark.Size = new System.Drawing.Size(291, 68);
            this.txtISRemark.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "备注";
            // 
            // txtGIPrice
            // 
            this.txtGIPrice.Location = new System.Drawing.Point(286, 107);
            this.txtGIPrice.Name = "txtGIPrice";
            this.txtGIPrice.Size = new System.Drawing.Size(100, 21);
            this.txtGIPrice.TabIndex = 7;
            this.txtGIPrice.TextChanged += new System.EventHandler(this.txtGIPrice_TextChanged);
            // 
            // labGPrice
            // 
            this.labGPrice.AutoSize = true;
            this.labGPrice.Location = new System.Drawing.Point(218, 110);
            this.labGPrice.Name = "labGPrice";
            this.labGPrice.Size = new System.Drawing.Size(53, 12);
            this.labGPrice.TabIndex = 14;
            this.labGPrice.Text = "货物单价";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboxGUnit);
            this.groupBox1.Controls.Add(this.txtHPeople);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboxPName);
            this.groupBox1.Controls.Add(this.cboxSName);
            this.groupBox1.Controls.Add(this.txtISRemark);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtGIPrice);
            this.groupBox1.Controls.Add(this.labGPrice);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGSPrice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtGSpec);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtISGNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtISGName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtISGID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 237);
            this.groupBox1.TabIndex = 14;
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
            this.cboxGUnit.Location = new System.Drawing.Point(286, 79);
            this.cboxGUnit.MaxDropDownItems = 100;
            this.cboxGUnit.Name = "cboxGUnit";
            this.cboxGUnit.Size = new System.Drawing.Size(100, 20);
            this.cboxGUnit.TabIndex = 5;
            // 
            // txtHPeople
            // 
            this.txtHPeople.Location = new System.Drawing.Point(286, 135);
            this.txtHPeople.Name = "txtHPeople";
            this.txtHPeople.Size = new System.Drawing.Size(100, 21);
            this.txtHPeople.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(224, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "经手人";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "进货总金额";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "入库数量";
            // 
            // txtGSPrice
            // 
            this.txtGSPrice.Location = new System.Drawing.Point(95, 135);
            this.txtGSPrice.Name = "txtGSPrice";
            this.txtGSPrice.ReadOnly = true;
            this.txtGSPrice.Size = new System.Drawing.Size(100, 21);
            this.txtGSPrice.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "计量单位";
            // 
            // txtGSpec
            // 
            this.txtGSpec.Location = new System.Drawing.Point(95, 79);
            this.txtGSpec.Name = "txtGSpec";
            this.txtGSpec.Size = new System.Drawing.Size(100, 21);
            this.txtGSpec.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "货物规格";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(441, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 237);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(12, 387);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(565, 17);
            this.hScrollBar1.TabIndex = 17;
            // 
            // dgvISManage
            // 
            this.dgvISManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvISManage.Location = new System.Drawing.Point(12, 255);
            this.dgvISManage.Name = "dgvISManage";
            this.dgvISManage.ReadOnly = true;
            this.dgvISManage.RowTemplate.Height = 23;
            this.dgvISManage.Size = new System.Drawing.Size(565, 149);
            this.dgvISManage.TabIndex = 15;
            this.dgvISManage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvISManage_CellClick);
            // 
            // frmISManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 416);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.dgvISManage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmISManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "货物入库管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmISManage_FormClosed);
            this.Load += new System.EventHandler(this.frmISManage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvISManage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtISGName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxPName;
        private System.Windows.Forms.TextBox txtISGID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtISGNum;
        private System.Windows.Forms.ComboBox cboxSName;
        private System.Windows.Forms.TextBox txtISRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGIPrice;
        private System.Windows.Forms.Label labGPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGSPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGSpec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.DataGridView dgvISManage;
        private System.Windows.Forms.TextBox txtHPeople;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboxGUnit;
    }
}