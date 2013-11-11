using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using DocToolkit;

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
        private Form1 owner;
        private DocManager docManager;

        #endregion

        #region Properties

        /// <summary>
        /// Reference to the owner form
        /// </summary>
        public Form1 Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }

        /// <summary>
        /// Reference to DocManager
        /// </summary>
        public DocManager DocManager
        {
            get
            {
                return docManager;
            }
            set
            {
                docManager = value;
            }
        }

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

        #region Event Handlers

        /// <summary>
        /// Draw graphic objects and 
        /// group selection rectangle (optionally)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawArea_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
            e.Graphics.FillRectangle(brush, 
                this.ClientRectangle);

            if ( graphicsList != null )
            {
                graphicsList.Draw(e.Graphics);
            }

            DrawNetSelection(e.Graphics);

            brush.Dispose();
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
            if ( e.Button == MouseButtons.Left )
                tools[(int)activeTool].OnMouseDown(this, e);
            else if ( e.Button == MouseButtons.Right )
                OnContextMenu(e);
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
            if ( e.Button == MouseButtons.Left  ||  e.Button == MouseButtons.None )
                tools[(int)activeTool].OnMouseMove(this, e);
            else
                this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Mouse up event.
        /// Left button up event is passed to active tool.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawArea_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Left )
                tools[(int)activeTool].OnMouseUp(this, e);
        }

        #endregion

        #region Other Functions

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="docManager"></param>
        public void Initialize(Form1 owner, DocManager docManager)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            // Keep reference to owner form
            this.Owner = owner;
            this.DocManager = docManager;

            // set default tool
            activeTool = DrawToolType.Pointer;

            // create list of graphic objects
            graphicsList = new GraphicsList();

            // create array of drawing tools
            tools = new Tool[(int)DrawToolType.NumberOfDrawTools];
            tools[(int)DrawToolType.Pointer] = new ToolPointer();
            tools[(int)DrawToolType.Rectangle] = new ToolRectangle();
            tools[(int)DrawToolType.Ellipse] = new ToolEllipse();
            tools[(int)DrawToolType.Line] = new ToolLine();
            tools[(int)DrawToolType.Polygon] = new ToolPolygon();
        }

        /// <summary>
        /// Set dirty flag (file is changed after last save operation)
        /// </summary>
        public void SetDirty()
        {
            DocManager.Dirty = true;
        }

        /// <summary>
        ///  Draw group selection rectangle
        /// </summary>
        /// <param name="g"></param>
        public void DrawNetSelection(Graphics g)
        {
            if ( ! DrawNetRectangle )
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

            for ( int i = 0; i < n; i++ )
            {
                if ( GraphicsList[i].HitTest(point) == 0 )
                {
                    o = GraphicsList[i];
                    break;
                }
            }

            if ( o != null )
            {
                if ( ! o.Selected )
                    GraphicsList.UnselectAll();

                // Select clicked object
                o.Selected = true;
            }
            else
            {
                GraphicsList.UnselectAll();
            }

            Refresh();

            // Show context menu.
            // Make ugly trick which saves a lot of code.
            // Get menu items from Edit menu in main form and
            // make context menu from them.
            // These menu items are handled in the parent form without
            // any additional efforts.

            MainMenu mainMenu = Owner.Menu;    // Main menu
            MenuItem editItem = mainMenu.MenuItems[1];            // Edit submenu

            // Make array of items for ContextMenu constructor
            // taking them from the Edit submenu
            MenuItem[] items = new MenuItem[editItem.MenuItems.Count];

            for ( int i = 0; i < editItem.MenuItems.Count; i++ )
            {
                items[i] = editItem.MenuItems[i];
            }

            Owner.SetStateOfControls();  // enable/disable menu items

            // Create and show context menu
            ContextMenu menu = new ContextMenu(items);
            menu.Show(this, point);

            // Restore items in the Edit menu (without this line Edit menu
            // is empty after forst right-click)
            editItem.MergeMenu(menu);
        }



        #endregion
	}
}
