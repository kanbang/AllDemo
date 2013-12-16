namespace SMS.Help
{
    partial class frmEditPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPwd));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFUNPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUNPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUOPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSure = new System.Windows.Forms.Button();
            this.errorPrPwd = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorPrPwd)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFUNPwd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUNPwd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUOPwd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtFUNPwd
            // 
            this.txtFUNPwd.Location = new System.Drawing.Point(130, 98);
            this.txtFUNPwd.Name = "txtFUNPwd";
            this.txtFUNPwd.PasswordChar = '*';
            this.txtFUNPwd.Size = new System.Drawing.Size(100, 21);
            this.txtFUNPwd.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "确认新密码";
            // 
            // txtUNPwd
            // 
            this.txtUNPwd.Location = new System.Drawing.Point(130, 71);
            this.txtUNPwd.Name = "txtUNPwd";
            this.txtUNPwd.PasswordChar = '*';
            this.txtUNPwd.Size = new System.Drawing.Size(100, 21);
            this.txtUNPwd.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "新密码";
            // 
            // txtUOPwd
            // 
            this.txtUOPwd.Location = new System.Drawing.Point(130, 44);
            this.txtUOPwd.Name = "txtUOPwd";
            this.txtUOPwd.PasswordChar = '*';
            this.txtUOPwd.Size = new System.Drawing.Size(100, 21);
            this.txtUOPwd.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "旧密码";
            // 
            // txtUName
            // 
            this.txtUName.Location = new System.Drawing.Point(130, 17);
            this.txtUName.Name = "txtUName";
            this.txtUName.ReadOnly = true;
            this.txtUName.Size = new System.Drawing.Size(100, 21);
            this.txtUName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnSure);
            this.groupBox2.Location = new System.Drawing.Point(2, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 34);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(235, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(58, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退出";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSure
            // 
            this.btnSure.Image = ((System.Drawing.Image)(resources.GetObject("btnSure.Image")));
            this.btnSure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSure.Location = new System.Drawing.Point(168, 10);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(58, 23);
            this.btnSure.TabIndex = 3;
            this.btnSure.Text = "确定";
            this.btnSure.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // errorPrPwd
            // 
            this.errorPrPwd.ContainerControl = this;
            // 
            // frmEditPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 166);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEditPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEditPwd_FormClosed);
            this.Load += new System.EventHandler(this.frmEditPwd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorPrPwd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFUNPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUNPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUOPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ErrorProvider errorPrPwd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSure;
    }
}