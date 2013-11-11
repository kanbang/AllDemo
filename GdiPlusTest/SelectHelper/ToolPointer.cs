using System;

using System.Drawing;
using System.Windows.Forms;

namespace GdiPlusTest
{
	/// <summary>
	/// Pointer tool
	/// </summary>
	public class ToolPointer : Tool
	{
		private SelectionMode selectMode = SelectionMode.None;

		// Object which is currently resized:
		private DrawObject resizedObject;
		private int resizedObjectHandle;

		// Keep state about last and current point (used to move and resize objects)
		private Point lastPoint = new Point(0, 0);
		private Point startPoint = new Point(0, 0);

		public ToolPointer()
		{
		}

		/// <summary>
		/// Left mouse button is pressed
		/// </summary>
		/// <param name="DrawRegion"></param>
		/// <param name="e"></param>
		public override void OnMouseDown(DrawRegion drawRegion, MouseEventArgs e)
		{
			selectMode = SelectionMode.None;
			Point point = new Point(e.X, e.Y);


			// Test for move (cursor is on the object)
			if (selectMode == SelectionMode.None) {
				int n1 = drawRegion.GraphicsList.Count;
				DrawObject o = null;

				for (int i = 0; i < n1; i++) {
					if (drawRegion.GraphicsList[i].HitTest(point) == 0) {
						o = drawRegion.GraphicsList[i];
						break;
					}
				}

				if (o != null) {
					selectMode = SelectionMode.Move;
					o.Selected = true;
				}
			}

			// Net selection
			if (selectMode == SelectionMode.None) {
				selectMode = SelectionMode.NetSelection;
				drawRegion.DrawNetRectangle = true;
			}

			lastPoint.X = e.X;
			lastPoint.Y = e.Y;
			startPoint.X = e.X;
			startPoint.Y = e.Y;

			drawRegion.Capture = true;


			drawRegion.NetRectangle = DrawRectangle.GetNormalizedRectangle(startPoint, lastPoint);

			drawRegion.Refresh();
		}


		/// <summary>
		/// Mouse is moved.
		/// None button is pressed, ot left button is pressed.
		/// </summary>
		/// <param name="DrawRegion"></param>
		/// <param name="e"></param>
		public override void OnMouseMove(DrawRegion drawRegion, MouseEventArgs e)
		{
			Point point = new Point(e.X, e.Y);
			drawRegion.DrawNetRectangle = true;
			lastPoint.X = e.X;
			lastPoint.Y = e.Y;
			drawRegion.IsNormal = lastPoint.X > startPoint.X;
			drawRegion.NetRectangle = DrawRectangle.GetNormalizedRectangle(startPoint, lastPoint);
			drawRegion.Refresh();
			return;


			// set cursor when mouse button is not pressed
			if (e.Button == MouseButtons.None) {
				Cursor cursor = null;

				for (int i = 0; i < drawRegion.GraphicsList.Count; i++) {
					int n = drawRegion.GraphicsList[i].HitTest(point);

					if (n > 0) {
						cursor = drawRegion.GraphicsList[i].GetHandleCursor(n);
					}
					if (n == 0 || drawRegion.GraphicsList[i].Selected) {
						drawRegion.GraphicsList[i].SetHighlight();
					} else {
						drawRegion.GraphicsList[i].CancelHighlight();
					}
				}

				if (cursor == null)
					cursor = Cursors.Default;

				drawRegion.Cursor = cursor;
				drawRegion.Refresh();
				return;
			}

			if (e.Button != MouseButtons.Left)
				return;

			/// Left button is pressed

			// Find difference between previous and current position
			int dx = e.X - lastPoint.X;
			int dy = e.Y - lastPoint.Y;

			lastPoint.X = e.X;
			lastPoint.Y = e.Y;

			if (selectMode == SelectionMode.NetSelection) {
				drawRegion.NetRectangle = DrawRectangle.GetNormalizedRectangle(startPoint, lastPoint);
				drawRegion.Refresh();
				return;
			}

		}

		/// <summary>
		/// Right mouse button is released
		/// </summary>
		/// <param name="DrawRegion"></param>
		/// <param name="e"></param>
		public override void OnMouseUp(DrawRegion drawRegion, MouseEventArgs e)
		{
			if (selectMode == SelectionMode.NetSelection) {
				// Group selection
				drawRegion.GraphicsList.SelectInRectangle(drawRegion.NetRectangle);

				selectMode = SelectionMode.None;
				drawRegion.DrawNetRectangle = false;
			}

			if (resizedObject != null) {
				// after resizing
				resizedObject.Normalize();
				resizedObject = null;
			}

			drawRegion.Capture = false;
			drawRegion.Refresh();
		}
	}
}
