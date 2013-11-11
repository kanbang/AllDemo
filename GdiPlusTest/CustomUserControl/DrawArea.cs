using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace DrawTools
{
	/// <summary>
	/// Working area.
	/// Handles mouse input and draws graphics objects.
	/// </summary>
	public class DrawArea : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region Constructor, Dispose

		public DrawArea()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// DrawArea
			// 
			this.Name = "DrawArea";
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseUp);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawArea_Paint);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseMove);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseDown);

		}
		#endregion

		#region Enumerations

		public enum DrawToolType
		{
			Pointer,
			Rectangle,
			Ellipse,
			Line,
			Polygon,
			NumberOfDrawTools
		};

		#endregion

		#region Members

		private GraphicsList graphicsList;    // list of draw objects
		// (instances of DrawObject-derived classes)

		private DrawToolType activeTool;      // active drawing tool
		private Tool[] tools;                 // array of tools

		// group selection rectangle
		private Rectangle netRectangle;
		private bool drawNetRectangle = false;

		// Information about owner form

		#endregion

		#region Properties


		/// <summary>
		/// Group selection rectangle. Used for drawing.
		/// </summary>
		public Rectangle NetRectangle
		{
			get
			{
				return netRectangle;
			}
			set
			{
				netRectangle = value;
			}
		}

		/// <summary>
		/// Flas is set to true if group selection rectangle should be drawn.
		/// </summary>
		public bool DrawNetRectangle
		{
			get
			{
				return drawNetRectangle;
			}
			set
			{
				drawNetRectangle = value;
			}
		}

		/// <summary>
		/// Active drawing tool.
		/// </summary>
		public DrawToolType ActiveTool
		{
			get
			{
				return activeTool;
			}
			set
			{
				activeTool = value;
			}
		}

		/// <summary>
		/// List of graphics objects.
		/// </summary>
		public GraphicsList GraphicsList
		{
			get
			{
				return graphicsList;
			}
			set
			{
				graphicsList = value;
			}
		}

		#endregion


		#region Other Functions

		/// <summary>
		/// Initialization
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="docManager"></param>
		public void Initialize()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint |
				ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

			// set default tool
			activeTool = DrawToolType.Pointer;

			// create list of graphic objects
			graphicsList = new GraphicsList();

			// create array of drawing tools
			tools = new Tool[(int)DrawToolType.NumberOfDrawTools];
			tools[(int)DrawToolType.Pointer] = new ToolPointer();
		}


		/// <summary>
		///  Draw group selection rectangle
		/// </summary>
		/// <param name="g"></param>
		public void DrawNetSelection(Graphics g)
		{
			if (!DrawNetRectangle)
				return;

			ControlPaint.DrawFocusRectangle(g, NetRectangle, Color.Black, Color.Transparent);
		}

		/// <summary>
		/// Right-click handler
		/// </summary>
		/// <param name="e"></param>
		private void OnContextMenu(MouseEventArgs e)
		{
			// Change current selection if necessary

			Point point = new Point(e.X, e.Y);

			int n = GraphicsList.Count;
			DrawObject o = null;

			for (int i = 0; i < n; i++) {
				if (GraphicsList[i].HitTest(point) == 0) {
					o = GraphicsList[i];
					break;
				}
			}

			if (o != null) {
				if (!o.Selected)
					GraphicsList.UnselectAll();

				// Select clicked object
				o.Selected = true;
			} else {
				GraphicsList.UnselectAll();
			}

			Refresh();
		}

		#endregion
	}
}
