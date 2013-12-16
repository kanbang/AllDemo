namespace SMS.GoodsManage
{
    partial class frmBGManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBGManage));
            this.txtHPeople = new System.Windows.Forms.TextBox();
            this.labHPeople = new System.Windows.Forms.Label();
            this.txtBGDepart = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBGNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRGManage = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtBGPeople = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxGName = new System.Windows.Forms.ComboBox();
            this.cboxSName = new System.Windows.Forms.ComboBox();
            this.cboxGSpec = new System.Windows.Forms.ComboBox();
            this.txtBGRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.dgvBGManage = new System.Windows.Forms.DataGridView();
            this.errorPrBGNum = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBGManage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPrBGNum)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHPeople
            // 
            this.txtHPeople.Location = new System.Drawing.Point(286, 99);
            this.txtHPeople.Name = "txtHPeople";
            this.txtHPeople.Size = new System.Drawing.Size(100, 21);
            this.txtHPeople.TabIndex = 5;
            // 
            // labHPeople
            // 
            this.labHPeople.AutoSize = true;
            this.labHPeople.Location = new System.Drawing.Point(226, 102);
            this.labHPeople.Name = "labHPeople";
            this.labHPeople.Size = new System.Drawing.Size(41, 12);
            this.labHPeople.TabIndex = 14;
            this.labHPeople.Text = "经手人";
            // 
            // txtBGDepart
            // 
            this.txtBGDepart.Location = new System.Drawing.Point(95, 134);
            this.txtBGDepart.Name = "txtBGDepart";
            this.txtBGDepart.Size = new System.Drawing.Size(291, 21);
            this.txtBGDepart.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "借货单位";
            // 
            // txtBGNum
            // 
            this.txtBGNum.Location = new System.Drawing.Point(286, 63);
            this.txtBGNum.Name = "txtBGNum";
            this.txtBGNum.Size = new System.Drawing.Size(100, 21);
            this.txtBGNum.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "借出数量";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRGManage);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(441, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 237);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // btnRGManage
            // 
            this.btnRGManage.Image = ((System.Drawing.Image)(resources.GetObject("btnRGManage.Image")));
            this.btnRGManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRGManage.Location = new System.Drawing.Point(34, 119);
            this.btnRGManage.Name = "btnRGManage";
            this.btnRGManage.Size = new System.Drawing.Size(75, 23);
            this.btnRGManage.TabIndex = 10;
            this.btnRGManage.Text = "还货";
            this.btnRGManage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRGManage.UseVisualStyleBackColor = true;
            this.btnRGManage.Click += new System.EventHandler(this.btnRGManage_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(34, 157);
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
            this.btnDel.Location = new System.Drawing.Point(34, 81);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 9;
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
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "借货";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtBGPeople
            // 
            this.txtBGPeople.Location = new System.Drawing.Point(95, 99);
            this.txtBGPeople.Name = "txtBGPeople";
            this.txtBGPeople.Size = new System.Drawing.Size(100, 21);
            this.txtBGPeople.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "借货人";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "仓库名称";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboxGName);
            this.groupBox1.Controls.Add(this.cboxSName);
            this.groupBox1.Controls.Add(this.cboxGSpec);
            this.groupBox1.Controls.Add(this.txtBGRemark);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtHPeople);
            this.groupBox1.Controls.Add(this.labHPeople);
            this.groupBox1.Controls.Add(this.txtBGDepart);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtBGPeople);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBGNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 237);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // cboxGName
            // 
            this.cboxGName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxGName.FormattingEnabled = true;
            this.cboxGName.Location = new System.Drawing.Point(286, 25);
            this.cboxGName.MaxDropDownItems = 100;
            this.cboxGName.Name = "cboxGName";
            this.cboxGName.Size = new System.Drawing.Size(100, 20);
            this.cboxGName.TabIndex = 1;
            this.cboxGName.SelectedIndexChanged += new System.EventHandler(this.cboxGName_SelectedIndexChanged);
            // 
            // cboxSName
            // 
            this.cboxSName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSName.FormattingEnabled = true;
            this.cboxSName.Location = new System.Drawing.Point(95, 25);
            this.cboxSName.MaxDropDownItems = 100;
            this.cboxSName.Name = "cboxSName";
            this.cboxSName.Size = new System.Drawing.Size(100, 20);
            this.cboxSName.TabIndex = 0;
            this.cboxSName.SelectedIndexChanged += new System.EventHandler(this.cboxSName_SelectedIndexChanged);
            // 
            // cboxGSpec
            // 
            this.cboxGSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxGSpec.FormattingEnabled = true;
            this.cboxGSpec.Location = new System.Drawing.Point(95, 63);
            this.cboxGSpec.MaxDropDownItems = 100;
            this.cboxGSpec.Name = "cboxGSpec";
            this.cboxGSpec.Size = new System.Drawing.Size(100, 20);
            this.cboxGSpec.TabIndex = 2;
            // 
            // txtBGRemark
            // 
            this.txtBGRemark.Location = new System.Drawing.Point(95, 166);
            this.txtBGRemark.Multiline = true;
            this.txtBGRemark.Name = "txtBGRemark";
            this.txtBGRemark.Size = new System.Drawing.Size(291, 55);
            this.txtBGRemark.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "备注";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "货物规格";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "货物名称";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(12, 387);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(565, 17);
            this.hScrollBar1.TabIndex = 9;
            // 
            // dgvBGManage
            // 
            this.dgvBGManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBGManage.Location = new System.Drawing.Point(12, 255);
            this.dgvBGManage.Name = "dgvBGManage";
            this.dgvBGManage.ReadOnly = true;
            this.dgvBGManage.RowTemplate.Height = 23;
            this.dgvBGManage.Size = new System.Drawing.Size(565, 149);
            this.dgvBGManage.TabIndex = 7;
            this.dgvBGManage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBGManage_CellClick);
            // 
            // errorPrBGNum
            // 
            this.errorPrBGNum.ContainerControl = this;
            // 
            // frmBGManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 416);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.dgvBGManage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBGManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "借货管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBGManage_FormClosed);
            this.Load += new System.EventHandler(this.frmBGManage_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBGManage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPrBGNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtHPeople;
        private System.Windows.Forms.Label labHPeople;
        private System.Windows.Forms.TextBox txtBGDepart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBGNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtBGPeople;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.DataGridView dgvBGManage;
        private System.Windows.Forms.TextBox txtBGRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboxGSpec;
        private System.Windows.Forms.ComboBox cboxSName;
        private System.Windows.Forms.ComboBox cboxGName;
        private System.Windows.Forms.Button btnRGManage;
        private System.Windows.Forms.ErrorProvider errorPrBGNum;
    }
}