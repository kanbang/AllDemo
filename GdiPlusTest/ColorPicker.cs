using System.Windows.Forms;
using System.Drawing;
using System;
using GdiPlusTest.Properties;
using System.Drawing.Drawing2D;

namespace GdiPlusTest
{
	public class ColorPicker : Button
	{
		int _plotScale = 100;
		private Color _color = Color.White;
		private const int WM_PAINT = 0xF;

		public Color Color
		{
			get { return _color; }
			set
			{
				_color = value;
				this.Refresh();
			}
		}

		public ColorPicker()
			: base()
		{
		}

		protected override void OnClick(EventArgs e)
		{

			ColorDialog dialog = new ColorDialog();

			if (dialog.ShowDialog() == DialogResult.OK) {
				Color = dialog.Color;
			}

		}
		protected override void OnPaint(PaintEventArgs pevent)
		{
			Graphics graphic = pevent.Graphics;
			graphic.Clear(this.Parent.BackColor);

			Rectangle rect = new Rectangle();
			rect.Width = this.Width;
			rect.Height = this.Height;
			rect.Width -= 1;
			rect.Height -= 1;
			GraphicsPath path = new GraphicsPath();
			int radius = 10;
			path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
			path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
			path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
			path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
			path.CloseAllFigures();
			Brush back = new LinearGradientBrush(rect, Color.FromArgb(242, 242, 242), Color.FromArgb(207, 207, 207), LinearGradientMode.Vertical);
			graphic.FillPath(back, path);

			graphic.DrawPath(new Pen(BackColor), path);

			back = new SolidBrush(_color);
			graphic.FillRectangle(back, rect.X + 5, (this.Height - 15) / 2, 15, 15);
			graphic.DrawString(_color.Name, this.Font, Brushes.Black, rect.X + 25, (this.Height - this.Font.Height) / 2);
			back.Dispose();

		}


	}
}
