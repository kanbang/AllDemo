using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

namespace DrawTools
{
	/// <summary>
	/// Properties dialog for graphic object.
	/// Shows properties for one or more graphic objects.
	/// 
	/// Special value "Undefined" is used when number of objects
	/// have different property values.
	/// 
	/// Input/output: GraphicsProperties class.
	/// 
	/// </summary>
	public class PropertiesDialog : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Label lblPenWidth;
        private System.Windows.Forms.ComboBox cmbPenWidth;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PropertiesDialog()
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.lblPenWidth = new System.Windows.Forms.Label();
            this.cmbPenWidth = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(40, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 28);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(193, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(33, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Color";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(33, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pen Width";
            // 
            // lblColor
            // 
            this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblColor.Location = new System.Drawing.Point(113, 21);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(74, 21);
            this.lblColor.TabIndex = 4;
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectColor.Location = new System.Drawing.Point(240, 21);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(27, 28);
            this.btnSelectColor.TabIndex = 5;
            this.btnSelectColor.Text = "...";
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // lblPenWidth
            // 
            this.lblPenWidth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPenWidth.Location = new System.Drawing.Point(113, 69);
            this.lblPenWidth.Name = "lblPenWidth";
            this.lblPenWidth.Size = new System.Drawing.Size(74, 21);
            this.lblPenWidth.TabIndex = 6;
            this.lblPenWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPenWidth
            // 
            this.cmbPenWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPenWidth.Location = new System.Drawing.Point(207, 69);
            this.cmbPenWidth.Name = "cmbPenWidth";
            this.cmbPenWidth.Size = new System.Drawing.Size(86, 21);
            this.cmbPenWidth.TabIndex = 7;
            this.cmbPenWidth.SelectedIndexChanged += new System.EventHandler(this.cmbPenWidth_SelectedIndexChanged);
            // 
            // PropertiesDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(308, 172);
            this.Controls.Add(this.cmbPenWidth);
            this.Controls.Add(this.lblPenWidth);
            this.Controls.Add(this.btnSelectColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PropertiesDialog";
            this.ShowInTaskbar = false;
            this.Text = "Properties";
            this.Load += new System.EventHandler(this.PropertiesDialog_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private GraphicsProperties properties;
        private const string undefined = "??";
        private const int maxWidth = 5;

        public GraphicsProperties Properties
        {
            get
            {
                return properties;
            }
            set
            {
                properties = value;
            }
        }

        private void PropertiesDialog_Load(object sender, System.EventArgs e)
        {
            InitControls();
            SetColor();
            SetPenWidth();
        }

        private void InitControls()
        {
            for ( int i = 1; i <= maxWidth; i++ )
            {
                cmbPenWidth.Items.Add(i.ToString(CultureInfo.InvariantCulture));
            }
        }

        private void SetColor()
        {
            if ( ! properties.ColorDefined )
                lblColor.Text = undefined;
            else
                lblColor.BackColor = properties.Color;
        }

        private void SetPenWidth()
        {
            int penWidth = properties.PenWidth;

            if ( penWidth < 1 )
                penWidth = 1;

            if ( penWidth > maxWidth )
                penWidth = maxWidth;

            if ( ! properties.PenWidthDefined )
                lblPenWidth.Text = undefined;
            else
            {
                lblPenWidth.Text = penWidth.ToString(CultureInfo.InvariantCulture);
                cmbPenWidth.SelectedIndex = penWidth - 1;
            }
        }

        private void ReadValues()
        {
            if ( cmbPenWidth.Text != undefined )
            {
                properties.PenWidthDefined = true;
                properties.PenWidth = cmbPenWidth.SelectedIndex + 1;
            }

            if ( lblColor.Text.Length == 0 )
            {
                properties.ColorDefined = true;
                properties.Color = lblColor.BackColor;
            }
        }

        private void cmbPenWidth_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int width = cmbPenWidth.SelectedIndex + 1;
            lblPenWidth.Text = width.ToString(CultureInfo.InvariantCulture);
        }

        private void btnSelectColor_Click(object sender, System.EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = lblColor.BackColor;

            if ( dlg.ShowDialog(this) == DialogResult.OK )
            {
                lblColor.BackColor = dlg.Color;
                lblColor.Text = "";
            }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            ReadValues();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }



	}
}
