using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GdiPlusTest
{
	[ToolboxBitmap(typeof(Panel))]
	public class PanelExNoWheel : Panel
	{
		public PanelExNoWheel()
			: base()
		{
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			//base.OnMouseWheel(e);
		}

	}
}
