namespace SMS.LookandSum
{
    partial class frmIOSMSum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIOSMSum));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboxMonth = new System.Windows.Forms.ComboBox();
            this.cboxSType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxYear = new System.Windows.Forms.ComboBox();
            this.cboxStore = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSum = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.picbox = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboxMonth);
            this.groupBox2.Controls.Add(this.cboxSType);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboxYear);
            this.groupBox2.Controls.Add(this.cboxStore);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnSum);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(281, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 399);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计操作";
            // 
            // cboxMonth
            // 
            this.cboxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMonth.FormattingEnabled = true;
            this.cboxMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboxMonth.Location = new System.Drawing.Point(18, 207);
            this.cboxMonth.Name = "cboxMonth";
            this.cboxMonth.Size = new System.Drawing.Size(110, 20);
            this.cboxMonth.TabIndex = 3;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "月份：";
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
            this.cboxYear.Location = new System.Drawing.Point(18, 152);
            this.cboxYear.Name = "cboxYear";
            this.cboxYear.Size = new System.Drawing.Size(110, 20);
            this.cboxYear.TabIndex = 2;
            // 
            // cboxStore
            // 
            this.cboxStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxStore.FormattingEnabled = true;
            this.cboxStore.Location = new System.Drawing.Point(18, 100);
            this.cboxStore.Name = "cboxStore";
            this.cboxStore.Size = new System.Drawing.Size(110, 20);
            this.cboxStore.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "年份：";
            // 
            // btnSum
            // 
            this.btnSum.Image = ((System.Drawing.Image)(resources.GetObject("btnSum.Image")));
            this.btnSum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSum.Location = new System.Drawing.Point(31, 249);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(79, 25);
            this.btnSum.TabIndex = 4;
            this.btnSum.Text = "统计";
            this.btnSum.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(31, 290);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 25);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "仓库设置：";
            // 
            // picbox
            // 
            this.picbox.Location = new System.Drawing.Point(2, 10);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(275, 382);
            this.picbox.TabIndex = 7;
            this.picbox.TabStop = false;
            // 
            // frmIOSMSum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 402);
            this.Controls.Add(this.picbox);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmIOSMSum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "出入库货物月统计";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmIOSMSum_FormClosed);
            this.Load += new System.EventHandler(this.frmIOSMSum_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboxSType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxStore;
        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picbox;
    }
}