namespace SMS.LookandSum
{
    partial class frmRGLook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRGLook));
            this.btnLook = new System.Windows.Forms.Button();
            this.txtLKWord = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.dgvRGInfo = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxLCondition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRGInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // txtLKWord
            // 
            this.txtLKWord.Location = new System.Drawing.Point(142, 54);
            this.txtLKWord.Name = "txtLKWord";
            this.txtLKWord.Size = new System.Drawing.Size(147, 21);
            this.txtLKWord.TabIndex = 1;
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
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(9, 306);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(412, 17);
            this.hScrollBar1.TabIndex = 7;
            // 
            // dgvRGInfo
            // 
            this.dgvRGInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRGInfo.Location = new System.Drawing.Point(9, 98);
            this.dgvRGInfo.Name = "dgvRGInfo";
            this.dgvRGInfo.ReadOnly = true;
            this.dgvRGInfo.RowTemplate.Height = 23;
            this.dgvRGInfo.Size = new System.Drawing.Size(412, 225);
            this.dgvRGInfo.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnLook);
            this.groupBox2.Location = new System.Drawing.Point(345, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(80, 85);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLKWord);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboxLCondition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 85);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 57);
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
            "还货编号",
            "借货编号",
            "仓库名称",
            "货物名称",
            "还货日期"});
            this.cboxLCondition.Location = new System.Drawing.Point(142, 25);
            this.cboxLCondition.Name = "cboxLCondition";
            this.cboxLCondition.Size = new System.Drawing.Size(147, 20);
            this.cboxLCondition.TabIndex = 0;
            this.cboxLCondition.SelectedIndexChanged += new System.EventHandler(this.cboxLCondition_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择查询条件";
            // 
            // frmRGLook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 331);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.dgvRGInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRGLook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "货物归还查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRGLook_FormClosed);
            this.Load += new System.EventHandler(this.frmRGLook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRGInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLook;
        private System.Windows.Forms.TextBox txtLKWord;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.DataGridView dgvRGInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxLCondition;
        private System.Windows.Forms.Label label1;
    }
}