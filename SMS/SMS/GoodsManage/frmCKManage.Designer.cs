namespace SMS.GoodsManage
{
    partial class frmCKManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCKManage));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGName = new System.Windows.Forms.TextBox();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.cboxGID = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboxGUnit = new System.Windows.Forms.ComboBox();
            this.txtCGRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPALNum = new System.Windows.Forms.TextBox();
            this.labNO = new System.Windows.Forms.Label();
            this.txtCGPeople = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCKNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvCGManage = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.errorPrRNum = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCGManage)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorPrRNum)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGName);
            this.groupBox1.Controls.Add(this.txtSName);
            this.groupBox1.Controls.Add(this.cboxGID);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboxGUnit);
            this.groupBox1.Controls.Add(this.txtCGRemark);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPALNum);
            this.groupBox1.Controls.Add(this.labNO);
            this.groupBox1.Controls.Add(this.txtCGPeople);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCKNum);
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
            // txtGName
            // 
            this.txtGName.Location = new System.Drawing.Point(95, 66);
            this.txtGName.Name = "txtGName";
            this.txtGName.ReadOnly = true;
            this.txtGName.Size = new System.Drawing.Size(100, 21);
            this.txtGName.TabIndex = 24;
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(286, 28);
            this.txtSName.Name = "txtSName";
            this.txtSName.ReadOnly = true;
            this.txtSName.Size = new System.Drawing.Size(100, 21);
            this.txtSName.TabIndex = 23;
            // 
            // cboxGID
            // 
            this.cboxGID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxGID.FormattingEnabled = true;
            this.cboxGID.Location = new System.Drawing.Point(95, 28);
            this.cboxGID.Name = "cboxGID";
            this.cboxGID.Size = new System.Drawing.Size(100, 20);
            this.cboxGID.TabIndex = 22;
            this.cboxGID.SelectedIndexChanged += new System.EventHandler(this.cboxGID_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(216, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "仓库名称";
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
            this.cboxGUnit.Location = new System.Drawing.Point(286, 66);
            this.cboxGUnit.MaxDropDownItems = 100;
            this.cboxGUnit.Name = "cboxGUnit";
            this.cboxGUnit.Size = new System.Drawing.Size(100, 20);
            this.cboxGUnit.TabIndex = 2;
            // 
            // txtCGRemark
            // 
            this.txtCGRemark.Location = new System.Drawing.Point(95, 169);
            this.txtCGRemark.Multiline = true;
            this.txtCGRemark.Name = "txtCGRemark";
            this.txtCGRemark.Size = new System.Drawing.Size(291, 55);
            this.txtCGRemark.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "备注";
            // 
            // txtPALNum
            // 
            this.txtPALNum.Location = new System.Drawing.Point(286, 104);
            this.txtPALNum.Name = "txtPALNum";
            this.txtPALNum.ReadOnly = true;
            this.txtPALNum.Size = new System.Drawing.Size(100, 21);
            this.txtPALNum.TabIndex = 6;
            // 
            // labNO
            // 
            this.labNO.AutoSize = true;
            this.labNO.Location = new System.Drawing.Point(216, 107);
            this.labNO.Name = "labNO";
            this.labNO.Size = new System.Drawing.Size(53, 12);
            this.labNO.TabIndex = 14;
            this.labNO.Text = "盈亏数量";
            // 
            // txtCGPeople
            // 
            this.txtCGPeople.Location = new System.Drawing.Point(95, 142);
            this.txtCGPeople.Name = "txtCGPeople";
            this.txtCGPeople.Size = new System.Drawing.Size(223, 21);
            this.txtCGPeople.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "盘点人";
            // 
            // txtCKNum
            // 
            this.txtCKNum.Location = new System.Drawing.Point(95, 104);
            this.txtCKNum.Name = "txtCKNum";
            this.txtCKNum.Size = new System.Drawing.Size(100, 21);
            this.txtCKNum.TabIndex = 3;
            this.txtCKNum.TextChanged += new System.EventHandler(this.txtCKNum_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "盘点数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "计量单位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "货物编号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "盘点货物";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(12, 387);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(565, 17);
            this.hScrollBar1.TabIndex = 13;
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(34, 113);
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
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "盘点";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvCGManage
            // 
            this.dgvCGManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCGManage.Location = new System.Drawing.Point(12, 255);
            this.dgvCGManage.Name = "dgvCGManage";
            this.dgvCGManage.ReadOnly = true;
            this.dgvCGManage.RowTemplate.Height = 23;
            this.dgvCGManage.Size = new System.Drawing.Size(565, 149);
            this.dgvCGManage.TabIndex = 11;
            this.dgvCGManage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCGManage_CellClick);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(34, 148);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "退出";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.btnEdit.Location = new System.Drawing.Point(34, 78);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "修改";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // errorPrRNum
            // 
            this.errorPrRNum.ContainerControl = this;
            // 
            // frmCKManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 416);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.dgvCGManage);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCKManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "盘点管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCKManage_FormClosed);
            this.Load += new System.EventHandler(this.frmCKManage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCGManage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorPrRNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCGRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPALNum;
        private System.Windows.Forms.Label labNO;
        private System.Windows.Forms.TextBox txtCGPeople;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCKNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvCGManage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cboxGUnit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboxGID;
        private System.Windows.Forms.TextBox txtGName;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.ErrorProvider errorPrRNum;
    }
}