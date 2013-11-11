using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GdiPlusTest
{
	[ToolboxBitmap(typeof(Panel))]
	public class PanelEx : Panel
	{
		private Color _borderColor = Color.FromArgb(121, 121, 121);
		private int _radius = 0;

		private const int WM_ERASEBKGND = 0x0014;
		private const int WM_PAINT = 0xF;

		public PanelEx ()
			: base()
		{
		}

		[DefaultValue(typeof(Color), "121, 121, 121"), Description("控件边框颜色")]
		public Color BorderColor
		{
			get { return _borderColor; }
			set
			{
				_borderColor = value;
				base.Invalidate();
			}
		}

		[DefaultValue(typeof(int), "0"), Description("圆角弧度大小")]
		public int Radius
		{
			get { return _radius; }
			set
			{
				_radius = value;
				base.Invalidate();
			}
		}

		protected override void WndProc (ref Message m)
		{
			try {
				base.WndProc(ref m);
				if (m.Msg == WM_PAINT) {
					using (Graphics g = Graphics.FromHwnd(this.Handle)) {
						Rectangle r = new Rectangle();
						r.Width = this.Width;
						r.Height = this.Height;
						DrawBorder(g, r, this.Radius);
					}
				}
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			//base.OnMouseWheel(e);
		}

		private void DrawBorder (Graphics g, Rectangle rect, int radius)
		{
			rect.Width -= 1;
			rect.Height -= 1;

			GraphicsPath path = new GraphicsPath();
			if (radius > 0) {
				path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
				path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
				path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
				path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);

			} else {
				path.AddRectangle(rect);
			}
			using (Pen pen = new Pen(this.BorderColor)) {
				g.DrawPath(pen, path);
			}
		}
	}
}
