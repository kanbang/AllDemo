using System;
using System.Windows.Forms;
using System.Drawing;

namespace DrawTools
{
	/// <summary>
	/// Ellipse graphic object
	/// </summary>
	public class DrawEllipse : DrawTools.DrawRectangle
	{
		public DrawEllipse()
		{
            SetRectangle(0, 0, 1, 1);
            Initialize();
		}

        public DrawEllipse(int x, int y, int width, int height)
        {
            Rectangle = new Rectangle(x, y, width, height);
            Initialize();
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, PenWidth);

            g.DrawEllipse(pen, DrawRectangle.GetNormalizedRectangle(Rectangle));

            pen.Dispose();
        }


	}
}
