namespace SMS.GoodsManage
{
    partial class frmRGManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRGManage));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGSpec = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGName = new System.Windows.Forms.TextBox();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.txtRGNum = new System.Windows.Forms.TextBox();
            this.cboxBGID = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRGRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHPeople = new System.Windows.Forms.TextBox();
            this.labHPeople = new System.Windows.Forms.Label();
            this.txtRGPeople = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNRGNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.dgvRGManage = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRGManage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(34, 151);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(34, 115);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 7;
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
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "还货";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGSpec);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGName);
            this.groupBox1.Controls.Add(this.txtSName);
            this.groupBox1.Controls.Add(this.txtRGNum);
            this.groupBox1.Controls.Add(this.cboxBGID);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtRGRemark);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtHPeople);
            this.groupBox1.Controls.Add(this.labHPeople);
            this.groupBox1.Controls.Add(this.txtRGPeople);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNRGNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 237);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // txtGSpec
            // 
            this.txtGSpec.Location = new System.Drawing.Point(289, 63);
            this.txtGSpec.Name = "txtGSpec";
            this.txtGSpec.ReadOnly = true;
            this.txtGSpec.Size = new System.Drawing.Size(100, 21);
            this.txtGSpec.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "货物规格";
            // 
            // txtGName
            // 
            this.txtGName.Location = new System.Drawing.Point(98, 63);
            this.txtGName.Name = "txtGName";
            this.txtGName.ReadOnly = true;
            this.txtGName.Size = new System.Drawing.Size(100, 21);
            this.txtGName.TabIndex = 23;
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(289, 26);
            this.txtSName.Name = "txtSName";
            this.txtSName.ReadOnly = true;
            this.txtSName.Size = new System.Drawing.Size(100, 21);
            this.txtSName.TabIndex = 22;
            // 
            // txtRGNum
            // 
            this.txtRGNum.Location = new System.Drawing.Point(98, 100);
            this.txtRGNum.Name = "txtRGNum";
            this.txtRGNum.Size = new System.Drawing.Size(100, 21);
            this.txtRGNum.TabIndex = 1;
            this.txtRGNum.TextChanged += new System.EventHandler(this.txtRGNum_TextChanged);
            // 
            // cboxBGID
            // 
            this.cboxBGID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxBGID.FormattingEnabled = true;
            this.cboxBGID.Location = new System.Drawing.Point(98, 26);
            this.cboxBGID.Name = "cboxBGID";
            this.cboxBGID.Size = new System.Drawing.Size(100, 20);
            this.cboxBGID.TabIndex = 0;
            this.cboxBGID.SelectedIndexChanged += new System.EventHandler(this.cboxBGID_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "借货编号";
            // 
            // txtRGRemark
            // 
            this.txtRGRemark.Location = new System.Drawing.Point(98, 174);
            this.txtRGRemark.Multiline = true;
            this.txtRGRemark.Name = "txtRGRemark";
            this.txtRGRemark.Size = new System.Drawing.Size(291, 55);
            this.txtRGRemark.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "备注";
            // 
            // txtHPeople
            // 
            this.txtHPeople.Location = new System.Drawing.Point(289, 137);
            this.txtHPeople.Name = "txtHPeople";
            this.txtHPeople.Size = new System.Drawing.Size(100, 21);
            this.txtHPeople.TabIndex = 3;
            // 
            // labHPeople
            // 
            this.labHPeople.AutoSize = true;
            this.labHPeople.Location = new System.Drawing.Point(229, 140);
            this.labHPeople.Name = "labHPeople";
            this.labHPeople.Size = new System.Drawing.Size(41, 12);
            this.labHPeople.TabIndex = 14;
            this.labHPeople.Text = "经手人";
            // 
            // txtRGPeople
            // 
            this.txtRGPeople.Location = new System.Drawing.Point(98, 137);
            this.txtRGPeople.Name = "txtRGPeople";
            this.txtRGPeople.Size = new System.Drawing.Size(100, 21);
            this.txtRGPeople.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "还货人";
            // 
            // txtNRGNum
            // 
            this.txtNRGNum.Location = new System.Drawing.Point(289, 100);
            this.txtNRGNum.Name = "txtNRGNum";
            this.txtNRGNum.ReadOnly = true;
            this.txtNRGNum.Size = new System.Drawing.Size(100, 21);
            this.txtNRGNum.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "未归还数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "本次归还数量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "货物名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓库名称";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(12, 387);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(565, 17);
            this.hScrollBar1.TabIndex = 13;
            // 
            // dgvRGManage
            // 
            this.dgvRGManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRGManage.Location = new System.Drawing.Point(12, 255);
            this.dgvRGManage.Name = "dgvRGManage";
            this.dgvRGManage.ReadOnly = true;
            this.dgvRGManage.RowTemplate.Height = 23;
            this.dgvRGManage.Size = new System.Drawing.Size(565, 149);
            this.dgvRGManage.TabIndex = 11;
            this.dgvRGManage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRGManage_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(441, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 237);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(34, 79);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "修改";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmRGManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 416);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.dgvRGManage);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRGManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "还货管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRGManage_FormClosed);
            this.Load += new System.EventHandler(this.frmRGManage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRGManage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRGRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHPeople;
        private System.Windows.Forms.Label labHPeople;
        private System.Windows.Forms.TextBox txtRGPeople;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNRGNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.DataGridView dgvRGManage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cboxBGID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRGNum;
        private System.Windows.Forms.TextBox txtGName;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.TextBox txtGSpec;
        private System.Windows.Forms.Label label5;
    }
}