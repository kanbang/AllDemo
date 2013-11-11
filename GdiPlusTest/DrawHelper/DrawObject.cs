using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace GdiPlusTest
{
	/// <summary>
	/// Base class for all draw objects
	/// </summary>
	public abstract class DrawObject
	{
		#region Members

		private bool _selected;
		protected bool _isHighlight;
		protected Color _normalColor = Color.Black;
		protected Color _highlightColor = Color.Red;
		private int penWidth;
		#endregion

		#region Properties

		/// <summary>
		/// Selection flag
		/// </summary>
		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
			}
		}
		protected Color DrawColor
		{
			get
			{
				return _isHighlight || _selected ? _highlightColor : _normalColor;
			}
		}

		public Color NormalColor
		{
			get { return _normalColor; }
			set { _normalColor = value; }
		}
		public Color HighlightColor
		{
			get { return _highlightColor; }
			set { _highlightColor = value; }
		}

		/// <summary>
		/// Pen width
		/// </summary>
		public int PenWidth
		{
			get
			{
				return penWidth;
			}
			set
			{
				penWidth = value;
			}
		}

		public void Highlight()
		{

		}
		/// <summary>
		/// Number of handles
		/// </summary>
		public virtual int HandleCount
		{
			get
			{
				return 0;
			}
		}
		#endregion

		#region Virtual Functions

		/// <summary>
		/// Draw object
		/// </summary>
		/// <param name="g"></param>
		public virtual void Draw(Graphics g)
		{
		}

		/// <summary>
		/// Get handle point by 1-based number
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns></returns>
		public virtual Point GetHandle(int handleNumber)
		{
			return new Point(0, 0);
		}

		/// <summary>
		/// Get handle rectangle by 1-based number
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns></returns>
		public virtual Rectangle GetHandleRectangle(int handleNumber)
		{
			Point point = GetHandle(handleNumber);

			return new Rectangle(point.X - 3, point.Y - 3, 7, 7);
		}

		/// <summary>
		/// Draw tracker for selected object
		/// </summary>
		/// <param name="g"></param>
		public virtual void DrawTracker(Graphics g)
		{
			if (!Selected)
				return;

			SolidBrush brush = new SolidBrush(Color.Black);

			for (int i = 1; i <= HandleCount; i++) {
				g.FillRectangle(brush, GetHandleRectangle(i));
			}

			brush.Dispose();
		}

		/// <summary>
		/// Hit test.
		/// Return value: -1 - no hit
		///                0 - hit anywhere
		///                > 1 - handle number
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		public virtual int HitTest(Point point)
		{
			return -1;
		}


		/// <summary>
		/// Test whether point is inside of the object
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		protected virtual bool PointInObject(Point point)
		{
			return false;
		}


		/// <summary>
		/// Get curesor for the handle
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns></returns>
		public virtual Cursor GetHandleCursor(int handleNumber)
		{
			return Cursors.Default;
		}

		/// <summary>
		/// Test whether object intersects with rectangle
		/// </summary>
		/// <param name="rectangle"></param>
		/// <returns></returns>
		public virtual bool IntersectsWith(Rectangle rectangle)
		{
			return false;
		}

		/// <summary>
		/// Move object
		/// </summary>
		/// <param name="deltaX"></param>
		/// <param name="deltaY"></param>
		public virtual void Move(int deltaX, int deltaY)
		{
		}

		/// <summary>
		/// Move handle to the point
		/// </summary>
		/// <param name="point"></param>
		/// <param name="handleNumber"></param>
		public virtual void MoveHandleTo(Point point, int handleNumber)
		{
		}

		/// <summary>
		/// Dump (for debugging)
		/// </summary>
		public virtual void Dump()
		{
			Trace.WriteLine("");
			Trace.WriteLine(this.GetType().Name);
			Trace.WriteLine("Selected = " + _selected.ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// Normalize object.
		/// Call this function in the end of object resizing.
		/// </summary>
		public virtual void Normalize()
		{
		}


		#endregion

		#region Other functions

		/// <summary>
		/// Initialization
		/// </summary>
		protected void Initialize()
		{
		}
		public void SetHighlight()
		{
			_isHighlight = true;
		}
		public void CancelHighlight()
		{
			_isHighlight = false;
		}
		#endregion
	}
}
