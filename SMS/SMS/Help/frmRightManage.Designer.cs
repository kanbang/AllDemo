namespace SMS.Help
{
    partial class frmRightManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRightManage));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxURight = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxUName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSure = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboxURight);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboxUName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "权限设置";
            // 
            // cboxURight
            // 
            this.cboxURight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxURight.FormattingEnabled = true;
            this.cboxURight.Items.AddRange(new object[] {
            "超级管理员",
            "普通用户"});
            this.cboxURight.Location = new System.Drawing.Point(97, 62);
            this.cboxURight.Name = "cboxURight";
            this.cboxURight.Size = new System.Drawing.Size(121, 20);
            this.cboxURight.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "权限";
            // 
            // cboxUName
            // 
            this.cboxUName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxUName.FormattingEnabled = true;
            this.cboxUName.Location = new System.Drawing.Point(97, 22);
            this.cboxUName.MaxDropDownItems = 100;
            this.cboxUName.Name = "cboxUName";
            this.cboxUName.Size = new System.Drawing.Size(121, 20);
            this.cboxUName.TabIndex = 0;
            this.cboxUName.SelectedIndexChanged += new System.EventHandler(this.cboxUName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnSure);
            this.groupBox2.Location = new System.Drawing.Point(12, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 47);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(207, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSure
            // 
            this.btnSure.Image = ((System.Drawing.Image)(resources.GetObject("btnSure.Image")));
            this.btnSure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSure.Location = new System.Drawing.Point(140, 16);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(57, 23);
            this.btnSure.TabIndex = 2;
            this.btnSure.Text = "确定";
            this.btnSure.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // frmRightManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 161);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRightManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "权限设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRightManage_FormClosed);
            this.Load += new System.EventHandler(this.frmRightManage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboxURight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxUName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSure;
    }
}