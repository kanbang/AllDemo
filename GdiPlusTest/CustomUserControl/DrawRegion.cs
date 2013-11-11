using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GdiPlusTest
{
	public partial class DrawRegion : UserControl
	{
		private GraphicsList graphicsList = new GraphicsList();    // list of draw objects
		// group selection rectangle
		private Rectangle netRectangle;
		private bool drawNetRectangle = false;
		private ToolPointer _toolPointer = new ToolPointer();
		//todo 临时测试颜色所用，设置后删除
		private static Color _highlight = Color.YellowGreen;

		public static Color Highlight
		{
			get { return _highlight; }
			set { _highlight = value; }
		}
		public GraphicsList GraphicsList
		{
			get { return graphicsList; }
			set { graphicsList = value; }
		}
		public Rectangle NetRectangle
		{
			get { return netRectangle; }
			set { netRectangle = value; }
		}

		public bool DrawNetRectangle
		{
			get { return drawNetRectangle; }
			set { drawNetRectangle = value; }
		}


		public DrawRegion()
		{
			InitializeComponent();
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseUp);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawArea_Paint);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseMove);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseDown);
			this.KeyPress += new KeyPressEventHandler(DrawRegion_KeyPress);
		}

		void DrawRegion_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (int)Keys.Escape) {
				graphicsList.UnselectAll();
				Refresh();
			} else if (e.KeyChar == (int)Keys.Delete) {
				graphicsList.DeleteSelection();
				Refresh();
			}
		}
		#region Event Handlers

		/// <summary>
		/// Draw graphic objects and 
		/// group selection rectangle (optionally)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DrawArea_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			SolidBrush brush = new SolidBrush(this.BackColor);
			e.Graphics.FillRectangle(brush,
				this.ClientRectangle);

			if (graphicsList != null) {
				graphicsList.Draw(e.Graphics);
			}
			DrawNetSelection(e.Graphics);

			brush.Dispose();
		}
		/// <summary>
		///  Draw group selection rectangle
		/// </summary>
		/// <param name="g"></param>
		public void DrawNetSelection(Graphics g)
		{
			if (!DrawNetRectangle)
				return;
			if (IsNormal) {
				ControlPaint.DrawBorder(g, NetRectangle, Color.White, ButtonBorderStyle.Solid);
			} else {
				ControlPaint.DrawBorder(g, NetRectangle, Color.White, ButtonBorderStyle.Dashed);
			}
		}

		/// <summary>
		/// Mouse down.
		/// Left button down event is passed to active tool.
		/// Right button down event is handled in this class.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DrawArea_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) {
				_toolPointer.OnMouseDown(this, e);
			} else if (e.Button == MouseButtons.Right) {
				ColorDialog dialog = new ColorDialog();
				if (dialog.ShowDialog() == DialogResult.OK) {
					Highlight = dialog.Color;
				}
			}
		}

		/// <summary>
		/// Mouse move.
		/// Moving without button pressed or with left button pressed
		/// is passed to active tool.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DrawArea_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left || e.Button == MouseButtons.None) {

				_toolPointer.OnMouseMove(this, e);
			}
		}

		/// <summary>
		/// Mouse up event.
		/// Left button up event is passed to active tool.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DrawArea_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) {

				_toolPointer.OnMouseUp(this, e);
			}
		}

		#endregion


		public bool IsNormal { get; set; }
	}
}
