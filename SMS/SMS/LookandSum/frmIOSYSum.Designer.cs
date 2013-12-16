namespace SMS.LookandSum
{
    partial class frmIOSYSum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIOSYSum));
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSum = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxStore = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboxYear = new System.Windows.Forms.ComboBox();
            this.cboxSType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picbox = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "仓库设置：";
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(34, 231);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 25);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退出";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSum
            // 
            this.btnSum.Image = ((System.Drawing.Image)(resources.GetObject("btnSum.Image")));
            this.btnSum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSum.Location = new System.Drawing.Point(34, 194);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(76, 25);
            this.btnSum.TabIndex = 3;
            this.btnSum.Text = "统计";
            this.btnSum.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "统计年份：";
            // 
            // cboxStore
            // 
            this.cboxStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxStore.FormattingEnabled = true;
            this.cboxStore.Location = new System.Drawing.Point(18, 148);
            this.cboxStore.Name = "cboxStore";
            this.cboxStore.Size = new System.Drawing.Size(110, 20);
            this.cboxStore.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboxYear);
            this.groupBox2.Controls.Add(this.cboxSType);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboxStore);
            this.groupBox2.Controls.Add(this.btnSum);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(285, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 399);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计操作";
            // 
            // cboxYear
            // 
            this.cboxYear.FormattingEnabled = true;
            this.cboxYear.Items.AddRange(new object[] {
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010"});
            this.cboxYear.Location = new System.Drawing.Point(18, 96);
            this.cboxYear.Name = "cboxYear";
            this.cboxYear.Size = new System.Drawing.Size(110, 20);
            this.cboxYear.TabIndex = 7;
            // 
            // cboxSType
            // 
            this.cboxSType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSType.FormattingEnabled = true;
            this.cboxSType.Items.AddRange(new object[] {
            "入库货物统计",
            "出库货物统计"});
            this.cboxSType.Location = new System.Drawing.Point(18, 49);
            this.cboxSType.Name = "cboxSType";
            this.cboxSType.Size = new System.Drawing.Size(110, 20);
            this.cboxSType.TabIndex = 0;
            this.cboxSType.SelectedIndexChanged += new System.EventHandler(this.cboxSType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "统计类型：";
            // 
            // picbox
            // 
            this.picbox.Location = new System.Drawing.Point(5, 10);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(275, 382);
            this.picbox.TabIndex = 8;
            this.picbox.TabStop = false;
            // 
            // frmIOSYSum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 402);
            this.Controls.Add(this.picbox);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmIOSYSum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "出入库货物年统计";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmIOSDSum_FormClosed);
            this.Load += new System.EventHandler(this.frmIOSDSum_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxStore;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxSType;
        private System.Windows.Forms.ComboBox cboxYear;
        private System.Windows.Forms.PictureBox picbox;


    }
}