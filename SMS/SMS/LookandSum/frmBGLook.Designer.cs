namespace SMS.LookandSum
{
    partial class frmBGLook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBGLook));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLKWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxLCondition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLook = new System.Windows.Forms.Button();
            this.dgvBGInfo = new System.Windows.Forms.DataGridView();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBGInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLKWord);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboxLCondition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // txtLKWord
            // 
            this.txtLKWord.Location = new System.Drawing.Point(139, 54);
            this.txtLKWord.Name = "txtLKWord";
            this.txtLKWord.Size = new System.Drawing.Size(147, 21);
            this.txtLKWord.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "查询关键字";
            // 
            // cboxLCondition
            // 
            this.cboxLCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxLCondition.FormattingEnabled = true;
            this.cboxLCondition.Items.AddRange(new object[] {
            "借货编号",
            "仓库名称",
            "货物名称",
            "借货日期"});
            this.cboxLCondition.Location = new System.Drawing.Point(139, 25);
            this.cboxLCondition.Name = "cboxLCondition";
            this.cboxLCondition.Size = new System.Drawing.Size(147, 20);
            this.cboxLCondition.TabIndex = 0;
            this.cboxLCondition.SelectedIndexChanged += new System.EventHandler(this.cboxLCondition_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择查询条件";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnLook);
            this.groupBox2.Location = new System.Drawing.Point(345, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(80, 85);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(16, 49);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(47, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLook
            // 
            this.btnLook.Location = new System.Drawing.Point(16, 20);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(47, 23);
            this.btnLook.TabIndex = 2;
            this.btnLook.Text = "查询";
            this.btnLook.UseVisualStyleBackColor = true;
            this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
            // 
            // dgvBGInfo
            // 
            this.dgvBGInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBGInfo.Location = new System.Drawing.Point(9, 97);
            this.dgvBGInfo.Name = "dgvBGInfo";
            this.dgvBGInfo.ReadOnly = true;
            this.dgvBGInfo.RowTemplate.Height = 23;
            this.dgvBGInfo.Size = new System.Drawing.Size(412, 225);
            this.dgvBGInfo.TabIndex = 2;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(9, 305);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(412, 17);
            this.hScrollBar1.TabIndex = 3;
            // 
            // frmBGLook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 331);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.dgvBGInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBGLook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "货物借出查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBGLook_FormClosed);
            this.Load += new System.EventHandler(this.frmBGLook_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBGInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLKWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxLCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLook;
        private System.Windows.Forms.DataGridView dgvBGInfo;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}