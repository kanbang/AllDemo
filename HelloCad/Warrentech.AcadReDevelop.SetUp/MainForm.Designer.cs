namespace Warrentech.AcadReDevelop.SetUp
{
	partial class MainForm
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent ()
		{
			this.groupBoxVersion = new System.Windows.Forms.GroupBox();
			this.btnUnLoad = new System.Windows.Forms.Button();
			this.btnSetUp = new System.Windows.Forms.Button();
			this.chcTenEN = new System.Windows.Forms.CheckBox();
			this.chcTenCN = new System.Windows.Forms.CheckBox();
			this.chcNineEN = new System.Windows.Forms.CheckBox();
			this.chcNineCN = new System.Windows.Forms.CheckBox();
			this.chcEightEN = new System.Windows.Forms.CheckBox();
			this.chcEightCN = new System.Windows.Forms.CheckBox();
			this.chcSevenEN = new System.Windows.Forms.CheckBox();
			this.chcSevenCN = new System.Windows.Forms.CheckBox();
			this.chcSixEN = new System.Windows.Forms.CheckBox();
			this.chcSixCN = new System.Windows.Forms.CheckBox();
			this.groupBoxVersion.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxVersion
			// 
			this.groupBoxVersion.Controls.Add(this.btnUnLoad);
			this.groupBoxVersion.Controls.Add(this.btnSetUp);
			this.groupBoxVersion.Controls.Add(this.chcTenEN);
			this.groupBoxVersion.Controls.Add(this.chcTenCN);
			this.groupBoxVersion.Controls.Add(this.chcNineEN);
			this.groupBoxVersion.Controls.Add(this.chcNineCN);
			this.groupBoxVersion.Controls.Add(this.chcEightEN);
			this.groupBoxVersion.Controls.Add(this.chcEightCN);
			this.groupBoxVersion.Controls.Add(this.chcSevenEN);
			this.groupBoxVersion.Controls.Add(this.chcSevenCN);
			this.groupBoxVersion.Controls.Add(this.chcSixEN);
			this.groupBoxVersion.Controls.Add(this.chcSixCN);
			this.groupBoxVersion.Location = new System.Drawing.Point(12, 12);
			this.groupBoxVersion.Name = "groupBoxVersion";
			this.groupBoxVersion.Size = new System.Drawing.Size(268, 254);
			this.groupBoxVersion.TabIndex = 0;
			this.groupBoxVersion.TabStop = false;
			this.groupBoxVersion.Text = "选择AutoCAD的版本";
			// 
			// btnUnLoad
			// 
			this.btnUnLoad.Location = new System.Drawing.Point(132, 214);
			this.btnUnLoad.Name = "btnUnLoad";
			this.btnUnLoad.Size = new System.Drawing.Size(59, 34);
			this.btnUnLoad.TabIndex = 11;
			this.btnUnLoad.Text = "卸载";
			this.btnUnLoad.UseVisualStyleBackColor = true;
			this.btnUnLoad.Click += new System.EventHandler(this.btnUnLoad_Click);
			// 
			// btnSetUp
			// 
			this.btnSetUp.Location = new System.Drawing.Point(25, 214);
			this.btnSetUp.Name = "btnSetUp";
			this.btnSetUp.Size = new System.Drawing.Size(51, 34);
			this.btnSetUp.TabIndex = 10;
			this.btnSetUp.Text = "安装";
			this.btnSetUp.UseVisualStyleBackColor = true;
			this.btnSetUp.Click += new System.EventHandler(this.btnSetUp_Click);
			// 
			// chcTenEN
			// 
			this.chcTenEN.AutoSize = true;
			this.chcTenEN.Location = new System.Drawing.Point(132, 192);
			this.chcTenEN.Name = "chcTenEN";
			this.chcTenEN.Size = new System.Drawing.Size(72, 16);
			this.chcTenEN.TabIndex = 9;
			this.chcTenEN.Text = "2010英文";
			this.chcTenEN.UseVisualStyleBackColor = true;
			// 
			// chcTenCN
			// 
			this.chcTenCN.AutoSize = true;
			this.chcTenCN.Location = new System.Drawing.Point(25, 192);
			this.chcTenCN.Name = "chcTenCN";
			this.chcTenCN.Size = new System.Drawing.Size(84, 16);
			this.chcTenCN.TabIndex = 8;
			this.chcTenCN.Text = "2010中文版";
			this.chcTenCN.UseVisualStyleBackColor = true;
			// 
			// chcNineEN
			// 
			this.chcNineEN.AutoSize = true;
			this.chcNineEN.Location = new System.Drawing.Point(132, 152);
			this.chcNineEN.Name = "chcNineEN";
			this.chcNineEN.Size = new System.Drawing.Size(72, 16);
			this.chcNineEN.TabIndex = 7;
			this.chcNineEN.Text = "2009英文";
			this.chcNineEN.UseVisualStyleBackColor = true;
			// 
			// chcNineCN
			// 
			this.chcNineCN.AutoSize = true;
			this.chcNineCN.Location = new System.Drawing.Point(25, 152);
			this.chcNineCN.Name = "chcNineCN";
			this.chcNineCN.Size = new System.Drawing.Size(84, 16);
			this.chcNineCN.TabIndex = 6;
			this.chcNineCN.Text = "2009中文版";
			this.chcNineCN.UseVisualStyleBackColor = true;
			// 
			// chcEightEN
			// 
			this.chcEightEN.AutoSize = true;
			this.chcEightEN.Location = new System.Drawing.Point(132, 112);
			this.chcEightEN.Name = "chcEightEN";
			this.chcEightEN.Size = new System.Drawing.Size(72, 16);
			this.chcEightEN.TabIndex = 5;
			this.chcEightEN.Text = "2008英文";
			this.chcEightEN.UseVisualStyleBackColor = true;
			// 
			// chcEightCN
			// 
			this.chcEightCN.AutoSize = true;
			this.chcEightCN.Location = new System.Drawing.Point(25, 112);
			this.chcEightCN.Name = "chcEightCN";
			this.chcEightCN.Size = new System.Drawing.Size(84, 16);
			this.chcEightCN.TabIndex = 4;
			this.chcEightCN.Text = "2008中文版";
			this.chcEightCN.UseVisualStyleBackColor = true;
			// 
			// chcSevenEN
			// 
			this.chcSevenEN.AutoSize = true;
			this.chcSevenEN.Location = new System.Drawing.Point(132, 72);
			this.chcSevenEN.Name = "chcSevenEN";
			this.chcSevenEN.Size = new System.Drawing.Size(72, 16);
			this.chcSevenEN.TabIndex = 3;
			this.chcSevenEN.Text = "2007英文";
			this.chcSevenEN.UseVisualStyleBackColor = true;
			// 
			// chcSevenCN
			// 
			this.chcSevenCN.AutoSize = true;
			this.chcSevenCN.Location = new System.Drawing.Point(25, 72);
			this.chcSevenCN.Name = "chcSevenCN";
			this.chcSevenCN.Size = new System.Drawing.Size(84, 16);
			this.chcSevenCN.TabIndex = 2;
			this.chcSevenCN.Text = "2007中文版";
			this.chcSevenCN.UseVisualStyleBackColor = true;
			// 
			// chcSixEN
			// 
			this.chcSixEN.AutoSize = true;
			this.chcSixEN.Location = new System.Drawing.Point(132, 32);
			this.chcSixEN.Name = "chcSixEN";
			this.chcSixEN.Size = new System.Drawing.Size(72, 16);
			this.chcSixEN.TabIndex = 1;
			this.chcSixEN.Text = "2006英文";
			this.chcSixEN.UseVisualStyleBackColor = true;
			// 
			// chcSixCN
			// 
			this.chcSixCN.AutoSize = true;
			this.chcSixCN.Location = new System.Drawing.Point(25, 32);
			this.chcSixCN.Name = "chcSixCN";
			this.chcSixCN.Size = new System.Drawing.Size(84, 16);
			this.chcSixCN.TabIndex = 0;
			this.chcSixCN.Text = "2006中文版";
			this.chcSixCN.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 274);
			this.Controls.Add(this.groupBoxVersion);
			this.Name = "MainForm";
			this.Text = "W.插件程序-AutoCAD";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.groupBoxVersion.ResumeLayout(false);
			this.groupBoxVersion.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxVersion;
		private System.Windows.Forms.Button btnSetUp;
		private System.Windows.Forms.CheckBox chcTenEN;
		private System.Windows.Forms.CheckBox chcTenCN;
		private System.Windows.Forms.CheckBox chcNineEN;
		private System.Windows.Forms.CheckBox chcNineCN;
		private System.Windows.Forms.CheckBox chcEightEN;
		private System.Windows.Forms.CheckBox chcEightCN;
		private System.Windows.Forms.CheckBox chcSevenEN;
		private System.Windows.Forms.CheckBox chcSevenCN;
		private System.Windows.Forms.CheckBox chcSixEN;
		private System.Windows.Forms.CheckBox chcSixCN;
		private System.Windows.Forms.Button btnUnLoad;
	}
}

