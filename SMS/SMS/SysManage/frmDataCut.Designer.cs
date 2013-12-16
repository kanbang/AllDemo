namespace SMS.SysManage
{
    partial class frmDataCut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataCut));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFCut = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnSel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDCPath = new System.Windows.Forms.TextBox();
            this.btnDCut = new System.Windows.Forms.Button();
            this.fbDialogPath = new System.Windows.Forms.FolderBrowserDialog();
            this.ofDialogFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFCut);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnDCut);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据压缩";
            // 
            // btnFCut
            // 
            this.btnFCut.Enabled = false;
            this.btnFCut.Location = new System.Drawing.Point(109, 110);
            this.btnFCut.Name = "btnFCut";
            this.btnFCut.Size = new System.Drawing.Size(75, 23);
            this.btnFCut.TabIndex = 4;
            this.btnFCut.Text = "文件压缩";
            this.btnFCut.UseVisualStyleBackColor = true;
            this.btnFCut.Click += new System.EventHandler(this.btnFCut_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(193, 110);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSFile);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFile);
            this.groupBox2.Controls.Add(this.btnSel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDCPath);
            this.groupBox2.Location = new System.Drawing.Point(6, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 91);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnSFile
            // 
            this.btnSFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSFile.Image")));
            this.btnSFile.Location = new System.Drawing.Point(235, 20);
            this.btnSFile.Name = "btnSFile";
            this.btnSFile.Size = new System.Drawing.Size(44, 21);
            this.btnSFile.TabIndex = 4;
            this.btnSFile.UseVisualStyleBackColor = true;
            this.btnSFile.Click += new System.EventHandler(this.btnSFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "要压缩的文件";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(91, 20);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(137, 21);
            this.txtFile.TabIndex = 2;
            // 
            // btnSel
            // 
            this.btnSel.Image = ((System.Drawing.Image)(resources.GetObject("btnSel.Image")));
            this.btnSel.Location = new System.Drawing.Point(235, 56);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(44, 21);
            this.btnSel.TabIndex = 1;
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "压缩后文件";
            // 
            // txtDCPath
            // 
            this.txtDCPath.Location = new System.Drawing.Point(91, 56);
            this.txtDCPath.Name = "txtDCPath";
            this.txtDCPath.ReadOnly = true;
            this.txtDCPath.Size = new System.Drawing.Size(137, 21);
            this.txtDCPath.TabIndex = 0;
            this.txtDCPath.TextChanged += new System.EventHandler(this.txtDCPath_TextChanged);
            // 
            // btnDCut
            // 
            this.btnDCut.Location = new System.Drawing.Point(25, 110);
            this.btnDCut.Name = "btnDCut";
            this.btnDCut.Size = new System.Drawing.Size(75, 23);
            this.btnDCut.TabIndex = 2;
            this.btnDCut.Text = "数据压缩";
            this.btnDCut.UseVisualStyleBackColor = true;
            this.btnDCut.Click += new System.EventHandler(this.btnDCut_Click);
            // 
            // fbDialogPath
            // 
            this.fbDialogPath.SelectedPath = "D:\\";
            // 
            // frmDataCut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 156);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmDataCut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据压缩";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDataCut_FormClosed);
            this.Load += new System.EventHandler(this.frmDataCut_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDCPath;
        private System.Windows.Forms.Button btnDCut;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.FolderBrowserDialog fbDialogPath;
        private System.Windows.Forms.Button btnSFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.OpenFileDialog ofDialogFile;
        private System.Windows.Forms.Button btnFCut;
    }
}