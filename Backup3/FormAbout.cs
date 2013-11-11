using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DrawTools
{
	/// <summary>
	/// About dialog
	/// </summary>
	public class FormAbout : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Button OK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormAbout()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormAbout));
            this.lblText = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblText.Location = new System.Drawing.Point(33, 24);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(207, 59);
            this.lblText.TabIndex = 0;
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OK
            // 
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OK.Location = new System.Drawing.Point(97, 107);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(86, 25);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // FormAbout
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(274, 153);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.lblText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About DrawTools";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void OK_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FormAbout_Load(object sender, System.EventArgs e)
        {
            this.Text = "About " + Application.ProductName;

            lblText.Text = "Program: " + Application.ProductName + "\n" +
                "Version: " + Application.ProductVersion;
        
        }
	}
}
