using System;
using System.Drawing;
using System.Windows.Forms;

namespace GdiPlusTest
{
	public class LineWidthPicker : ComboBox
	{
		private double _width = 0.3;//单位为毫米

		public double Width
		{
			get { return _width; }
			set
			{
				_width = value;
				this.Refresh();
			}
		}

		public LineWidthPicker()
			: base()
		{
			this.DrawMode = DrawMode.OwnerDrawFixed;
			this.DropDownStyle = ComboBoxStyle.DropDownList;
		}
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			string n = this.Items[this.SelectedIndex].ToString();
			_width = Convert.ToInt32(n) / 100.0;
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			base.OnDrawItem(e);
			Graphics g = e.Graphics;
			Rectangle rect = e.Bounds;
			if (e.Index >= 0) {
				if (e.State == (DrawItemState.Selected | DrawItemState.Focus | DrawItemState.NoAccelerator | DrawItemState.NoFocusRect)) {
					//当绘制项没有键盘加速键和焦点可视化提示时
					e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), rect);//用指定的颜色填充自定义矩形的内部
				} else {
					//当绘制项有键盘加速键或者焦点可视化提示时
					e.Graphics.FillRectangle(new SolidBrush(Color.White), rect);//用指定的颜色填充自定义矩形的内部
				}

				string n = this.Items[e.Index].ToString();
				int height = Convert.ToInt32(n);
				g.DrawString(string.Format("{0} mm", (height / 100.0).ToString("0.00")), this.Font, Brushes.Black, rect.X + 40, rect.Y + 2);

				float recHeight = (float)Convert.ToDouble(height / 20.0);
				if (recHeight == 0) {
					recHeight = 0.1F;
				}
				Brush b = new SolidBrush(Color.Black);
				g.FillRectangle(b, rect.X + 5, rect.Y + (rect.Height - recHeight) / 2, 30, recHeight);
				e.DrawFocusRectangle();//在指定的边界范围内绘制聚焦框

			}
		}

	}
}

