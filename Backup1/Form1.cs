using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using System.Diagnostics;
using System.Security;
using DocToolkit;
using System.Runtime.Serialization;

/// DrawTools sample application.
/// Written by Alex Farber
/// alexf2062@yahoo.com
/// 
/// Drawing of graphics shapes (line, rectangle,
/// ellipse, polygon) on the window client area
/// using mouse.
/// Program works like MFC sample DRAWCLI
/// and uses some design decisions from this sample.
/// 
/// Dependencies: DocToolkit Library.



namespace DrawTools
{
	/// <summary>
	/// Main application form
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuFileNew;
        private System.Windows.Forms.MenuItem menuFileOpen;
        private System.Windows.Forms.MenuItem menuFileSave;
        private System.Windows.Forms.MenuItem menuFileSaveAs;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuFileRecentFiles;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuFileExit;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuHelpAbout;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbNew;
        private System.Windows.Forms.ToolBarButton tbOpen;
        private System.Windows.Forms.ToolBarButton tbSave;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton tbAbout;
        private DrawTools.DrawArea drawArea;
        private System.Windows.Forms.ToolBarButton tbPointer;
        private System.Windows.Forms.ToolBarButton tbRectangle;
        private System.Windows.Forms.ToolBarButton tbEllipse;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuDrawPointer;
        private System.Windows.Forms.MenuItem menuDrawRectangle;
        private System.Windows.Forms.MenuItem menuDrawEllipse;
        private System.Windows.Forms.ToolBarButton tbLine;
        private System.Windows.Forms.MenuItem menuDrawLine;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuEditSelectAll;
        private System.Windows.Forms.MenuItem menuEditUnselectAll;
        private System.Windows.Forms.MenuItem menuEditDelete;
        private System.Windows.Forms.MenuItem menuEditDeleteAll;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuEditMoveToFront;
        private System.Windows.Forms.MenuItem menuEditMoveToBack;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuEditProperties;
        private System.Windows.Forms.ToolBarButton tbPolygon;
        private System.Windows.Forms.MenuItem menuDrawPolygon;
        private System.ComponentModel.IContainer components;

        #region Constructor, Dispose

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            persistState = new PersistWindowState(registryPath, this);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

        #endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuFileNew = new System.Windows.Forms.MenuItem();
            this.menuFileOpen = new System.Windows.Forms.MenuItem();
            this.menuFileSave = new System.Windows.Forms.MenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuFileRecentFiles = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuFileExit = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuEditSelectAll = new System.Windows.Forms.MenuItem();
            this.menuEditUnselectAll = new System.Windows.Forms.MenuItem();
            this.menuEditDelete = new System.Windows.Forms.MenuItem();
            this.menuEditDeleteAll = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuEditMoveToFront = new System.Windows.Forms.MenuItem();
            this.menuEditMoveToBack = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuEditProperties = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuDrawPointer = new System.Windows.Forms.MenuItem();
            this.menuDrawRectangle = new System.Windows.Forms.MenuItem();
            this.menuDrawEllipse = new System.Windows.Forms.MenuItem();
            this.menuDrawLine = new System.Windows.Forms.MenuItem();
            this.menuDrawPolygon = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuHelpAbout = new System.Windows.Forms.MenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbNew = new System.Windows.Forms.ToolBarButton();
            this.tbOpen = new System.Windows.Forms.ToolBarButton();
            this.tbSave = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tbPointer = new System.Windows.Forms.ToolBarButton();
            this.tbRectangle = new System.Windows.Forms.ToolBarButton();
            this.tbEllipse = new System.Windows.Forms.ToolBarButton();
            this.tbLine = new System.Windows.Forms.ToolBarButton();
            this.tbPolygon = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.tbAbout = new System.Windows.Forms.ToolBarButton();
            this.drawArea = new DrawTools.DrawArea();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuItem1,
                                                                                      this.menuItem3,
                                                                                      this.menuItem2,
                                                                                      this.menuItem10});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuFileNew,
                                                                                      this.menuFileOpen,
                                                                                      this.menuFileSave,
                                                                                      this.menuFileSaveAs,
                                                                                      this.menuItem6,
                                                                                      this.menuFileRecentFiles,
                                                                                      this.menuItem8,
                                                                                      this.menuFileExit});
            this.menuItem1.Text = "File";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Index = 0;
            this.menuFileNew.Text = "New";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Index = 1;
            this.menuFileOpen.Text = "Open";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Index = 2;
            this.menuFileSave.Text = "Save";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Index = 3;
            this.menuFileSaveAs.Text = "Save As";
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 4;
            this.menuItem6.Text = "-";
            // 
            // menuFileRecentFiles
            // 
            this.menuFileRecentFiles.Index = 5;
            this.menuFileRecentFiles.Text = "Recent Files";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 6;
            this.menuItem8.Text = "-";
            // 
            // menuFileExit
            // 
            this.menuFileExit.Index = 7;
            this.menuFileExit.Text = "Exit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuEditSelectAll,
                                                                                      this.menuEditUnselectAll,
                                                                                      this.menuEditDelete,
                                                                                      this.menuEditDeleteAll,
                                                                                      this.menuItem4,
                                                                                      this.menuEditMoveToFront,
                                                                                      this.menuEditMoveToBack,
                                                                                      this.menuItem5,
                                                                                      this.menuEditProperties});
            this.menuItem3.Text = "Edit";
            // 
            // menuEditSelectAll
            // 
            this.menuEditSelectAll.Index = 0;
            this.menuEditSelectAll.Text = "Select All";
            this.menuEditSelectAll.Click += new System.EventHandler(this.menuEditSelectAll_Click);
            // 
            // menuEditUnselectAll
            // 
            this.menuEditUnselectAll.Index = 1;
            this.menuEditUnselectAll.Text = "Unselect All";
            this.menuEditUnselectAll.Click += new System.EventHandler(this.menuEditUnselectAll_Click);
            // 
            // menuEditDelete
            // 
            this.menuEditDelete.Index = 2;
            this.menuEditDelete.Text = "Delete";
            this.menuEditDelete.Click += new System.EventHandler(this.menuEditDelete_Click);
            // 
            // menuEditDeleteAll
            // 
            this.menuEditDeleteAll.Index = 3;
            this.menuEditDeleteAll.Text = "DeleteAll";
            this.menuEditDeleteAll.Click += new System.EventHandler(this.menuEditDeleteAll_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.Text = "-";
            // 
            // menuEditMoveToFront
            // 
            this.menuEditMoveToFront.Index = 5;
            this.menuEditMoveToFront.Text = "Move to Front";
            this.menuEditMoveToFront.Click += new System.EventHandler(this.menuEditMoveToFront_Click);
            // 
            // menuEditMoveToBack
            // 
            this.menuEditMoveToBack.Index = 6;
            this.menuEditMoveToBack.Text = "Move to Back";
            this.menuEditMoveToBack.Click += new System.EventHandler(this.menuEditMoveToBack_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 7;
            this.menuItem5.Text = "-";
            // 
            // menuEditProperties
            // 
            this.menuEditProperties.Index = 8;
            this.menuEditProperties.Text = "Properties";
            this.menuEditProperties.Click += new System.EventHandler(this.menuEditProperties_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuDrawPointer,
                                                                                      this.menuDrawRectangle,
                                                                                      this.menuDrawEllipse,
                                                                                      this.menuDrawLine,
                                                                                      this.menuDrawPolygon});
            this.menuItem2.Text = "Draw";
            // 
            // menuDrawPointer
            // 
            this.menuDrawPointer.Index = 0;
            this.menuDrawPointer.Text = "Pointer";
            this.menuDrawPointer.Click += new System.EventHandler(this.menuDrawPointer_Click);
            // 
            // menuDrawRectangle
            // 
            this.menuDrawRectangle.Index = 1;
            this.menuDrawRectangle.Text = "Rectangle";
            this.menuDrawRectangle.Click += new System.EventHandler(this.menuDrawRectangle_Click);
            // 
            // menuDrawEllipse
            // 
            this.menuDrawEllipse.Index = 2;
            this.menuDrawEllipse.Text = "Ellipse";
            this.menuDrawEllipse.Click += new System.EventHandler(this.menuDrawEllipse_Click);
            // 
            // menuDrawLine
            // 
            this.menuDrawLine.Index = 3;
            this.menuDrawLine.Text = "Line";
            this.menuDrawLine.Click += new System.EventHandler(this.menuDrawLine_Click);
            // 
            // menuDrawPolygon
            // 
            this.menuDrawPolygon.Index = 4;
            this.menuDrawPolygon.Text = "Pencil";
            this.menuDrawPolygon.Click += new System.EventHandler(this.menuDrawPolygon_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 3;
            this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                       this.menuHelpAbout});
            this.menuItem10.Text = "Help";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Index = 0;
            this.menuHelpAbout.Text = "About";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(23, 22);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Silver;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                        this.tbNew,
                                                                                        this.tbOpen,
                                                                                        this.tbSave,
                                                                                        this.toolBarButton1,
                                                                                        this.tbPointer,
                                                                                        this.tbRectangle,
                                                                                        this.tbEllipse,
                                                                                        this.tbLine,
                                                                                        this.tbPolygon,
                                                                                        this.toolBarButton2,
                                                                                        this.tbAbout});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(426, 34);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbNew
            // 
            this.tbNew.ImageIndex = 0;
            this.tbNew.ToolTipText = "New";
            // 
            // tbOpen
            // 
            this.tbOpen.ImageIndex = 1;
            this.tbOpen.ToolTipText = "Open";
            // 
            // tbSave
            // 
            this.tbSave.ImageIndex = 2;
            this.tbSave.ToolTipText = "Save";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbPointer
            // 
            this.tbPointer.ImageIndex = 4;
            this.tbPointer.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbPointer.ToolTipText = "Pointer";
            // 
            // tbRectangle
            // 
            this.tbRectangle.ImageIndex = 5;
            this.tbRectangle.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbRectangle.ToolTipText = "Recatngle";
            // 
            // tbEllipse
            // 
            this.tbEllipse.ImageIndex = 6;
            this.tbEllipse.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbEllipse.ToolTipText = "Ellipse";
            // 
            // tbLine
            // 
            this.tbLine.ImageIndex = 7;
            this.tbLine.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbLine.ToolTipText = "Line";
            // 
            // tbPolygon
            // 
            this.tbPolygon.ImageIndex = 8;
            this.tbPolygon.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbPolygon.ToolTipText = "Pencil";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbAbout
            // 
            this.tbAbout.ImageIndex = 3;
            this.tbAbout.ToolTipText = "About ...";
            // 
            // drawArea
            // 
            this.drawArea.ActiveTool = DrawTools.DrawArea.DrawToolType.Pointer;
            this.drawArea.DocManager = null;
            this.drawArea.DrawNetRectangle = false;
            this.drawArea.GraphicsList = null;
            this.drawArea.Location = new System.Drawing.Point(20, 73);
            this.drawArea.Name = "drawArea";
            this.drawArea.NetRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.drawArea.Owner = null;
            this.drawArea.Size = new System.Drawing.Size(227, 100);
            this.drawArea.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(426, 245);
            this.Controls.Add(this.drawArea);
            this.Controls.Add(this.toolBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "DrawTools";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }
		#endregion

        #region Main

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
			Application.EnableVisualStyles();
            Application.DoEvents();

            // Check command line
            if( args.Length > 1 ) 
            {
                MessageBox.Show("Incorrect number of arguments. Usage: DrawTools.exe [file]", "DrawTools");
            }


            // Load main form, taking command line into account
            Form1 form = new Form1();

            if ( args.Length == 1 ) 
                form.ArgumentFile = args[0];

            Application.Run(form);
		}

        #endregion

        #region Members

        private DocManager docManager;
        private DragDropManager dragDropManager;
        private MruManager mruManager;
        private PersistWindowState persistState;

        private string argumentFile = "";   // file name from command line

        const string registryPath = "Software\\AlexF\\DrawTools";

        #endregion

        #region Properties

        /// <summary>
        /// File name from the command line
        /// </summary>
        public string ArgumentFile
        {
            get
            {
                return argumentFile;
            }
            set
            {
                argumentFile = value;
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Helper objects (DocManager and others)
            InitializeHelperObjects();

            LoadSettingsFromRegistry();

            // Initialize draw area
            ResizeDrawArea(); 
            drawArea.Initialize(this, docManager);

            // Submit to Idle event to set controls state at idle time
            Application.Idle += new EventHandler(Application_Idle);

            // Open file passed in the command line
            if ( ArgumentFile.Length > 0 )
                OpenDocument(ArgumentFile);
        }

        /// <summary>
        /// Form is closng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ( ! docManager.CloseDocument() )
                e.Cancel = true;

            SaveSettingsToRegistry();
        }

        /// <summary>
        /// Idle processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Idle(object sender, EventArgs e)
        {
            SetStateOfControls();
        }

        /// <summary>
        /// Exit menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// About menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuHelpAbout_Click(object sender, System.EventArgs e)
        {
            CommandAbout();        
        }


        /// <summary>
        /// Resize draw area when form is resized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if ( this.WindowState != FormWindowState.Minimized )
            {
                ResizeDrawArea();
            }
        }

        /// <summary>
        /// Toolbar buttons handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if ( e.Button == tbPointer )
                CommandPointer();
            else if ( e.Button == tbRectangle)
                CommandRectangle();
            else if ( e.Button == tbEllipse)
                CommandEllipse();
            else if ( e.Button == tbLine)
                CommandLine();
            else if ( e.Button == tbPolygon)
                CommandPolygon();
            else if ( e.Button == tbAbout )
                CommandAbout();
            else if ( e.Button == tbSave )
                CommandSave();
            else if ( e.Button == tbOpen )
                CommandOpen();
            else if ( e.Button == tbNew )
                CommandNew();
        }

        #region File Menu

        /// <summary>
        /// File - New menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileNew_Click(object sender, System.EventArgs e)
        {
            CommandNew();        
        }

        /// <summary>
        /// File - Open menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileOpen_Click(object sender, System.EventArgs e)
        {
            CommandOpen();
        }

        /// <summary>
        /// File - Save menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSave_Click(object sender, System.EventArgs e)
        {
            CommandSave();
        }

        /// <summary>
        /// File - Save As menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSaveAs_Click(object sender, System.EventArgs e)
        {
            CommandSaveAs();
        }

        #endregion

        #region Draw menu

        /// <summary>
        /// Pointer Tool menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDrawPointer_Click(object sender, System.EventArgs e)
        {
            CommandPointer();        
        }

        /// <summary>
        /// Rectangle Tool menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDrawRectangle_Click(object sender, System.EventArgs e)
        {
            CommandRectangle();
        }

        /// <summary>
        /// Ellipse Tool menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDrawEllipse_Click(object sender, System.EventArgs e)
        {
            CommandEllipse();
        }

        /// <summary>
        /// Line Tool menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDrawLine_Click(object sender, System.EventArgs e)
        {
            CommandLine();        
        }

        /// <summary>
        /// Polygon Tool menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDrawPolygon_Click(object sender, System.EventArgs e)
        {
            CommandPolygon();        
        }

        #endregion

        #region Edit Menu

        private void menuEditSelectAll_Click(object sender, System.EventArgs e)
        {
            drawArea.GraphicsList.SelectAll();
            drawArea.Refresh();
        }

        private void menuEditUnselectAll_Click(object sender, System.EventArgs e)
        {
            drawArea.GraphicsList.UnselectAll();
            drawArea.Refresh();
        }

        private void menuEditDelete_Click(object sender, System.EventArgs e)
        {
            if ( drawArea.GraphicsList.DeleteSelection() )
            {
                drawArea.SetDirty();
                drawArea.Refresh();
            }
        }

        private void menuEditDeleteAll_Click(object sender, System.EventArgs e)
        {
            if ( drawArea.GraphicsList.Clear() )
            {
                drawArea.SetDirty();
                drawArea.Refresh();
            }
        }

        private void menuEditMoveToFront_Click(object sender, System.EventArgs e)
        {
            if ( drawArea.GraphicsList.MoveSelectionToFront() )
            {
                drawArea.SetDirty();
                drawArea.Refresh();
            }
        }

        private void menuEditMoveToBack_Click(object sender, System.EventArgs e)
        {
            if ( drawArea.GraphicsList.MoveSelectionToBack() )
            {
                drawArea.SetDirty();
                drawArea.Refresh();
            }
        }

        private void menuEditProperties_Click(object sender, System.EventArgs e)
        {
            if ( drawArea.GraphicsList.ShowPropertiesDialog(this) )
            {
                drawArea.SetDirty();
                drawArea.Refresh();
            }
        }

        #endregion

        #endregion

        #region DocManager Event Handlers

        /// <summary>
        /// DocManager reports hat it executed New command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void docManager_ClearEvent(object sender, EventArgs e)
        {
            if ( drawArea.GraphicsList != null )
            {
                drawArea.GraphicsList.Clear();
                drawArea.Refresh();
            }
        }
        
        /// <summary>
        /// DocManager reports that document was changed (loaded from file)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void docManager_DocChangedEvent(object sender, EventArgs e)
        {
            drawArea.Refresh();
        }

        /// <summary>
        /// DocManager reports about successful/unsuccessful Open File operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void docManager_OpenEvent(object sender, OpenFileEventArgs e)
        {
            // Update MRU List
            if ( e.Succeeded )
                mruManager.Add(e.FileName);
            else
                mruManager.Remove(e.FileName);
        }
        
        /// <summary>
        /// Load document from the stream supplied by DocManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void docManager_LoadEvent(object sender, SerializationEventArgs e)
        {
            // DocManager asks to load document from supplied stream
            try
            {
                drawArea.GraphicsList = (GraphicsList)e.Formatter.Deserialize(e.SerializationStream);
            }
            catch ( ArgumentNullException ex )
            {
                HandleLoadException(ex, e);
            }
            catch ( SerializationException ex )
            {
                HandleLoadException(ex, e);
            }
            catch ( SecurityException ex )
            {
                HandleLoadException(ex, e);
            }
        }

        
        /// <summary>
        /// Save document to stream supplied by DocManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void docManager_SaveEvent(object sender, SerializationEventArgs e)
        {
            // DocManager asks to save document to supplied stream
            try
            {
                e.Formatter.Serialize(e.SerializationStream, drawArea.GraphicsList);
            }
            catch ( ArgumentNullException ex )
            {
                HandleSaveException(ex, e);
            }
            catch ( SerializationException ex )
            {
                HandleSaveException(ex, e);
            }
            catch ( SecurityException ex )
            {
                HandleSaveException(ex, e);
            }
        }

        #endregion

        #region DragDropManager Event Handlers

        private void dragDropManager_FileDroppedEvent(object sender, FileDroppedEventArgs e)
        {
            OpenDocument(e.FileArray.GetValue(0).ToString());
        }

        #endregion

        #region MruManager Event Handlers

        private void mruManager_MruOpenEvent(object sender, MruFileOpenEventArgs e)
        {
            OpenDocument(e.FileName);
        }
        #endregion

        #region Other Functions

        /// <summary>
        /// Set Pointer draw tool
        /// </summary>
        private void CommandPointer()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Pointer;
        }

        /// <summary>
        /// Set Rectangle draw tool
        /// </summary>
        private void CommandRectangle()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Rectangle;
        }

        /// <summary>
        /// Set Ellipse draw tool
        /// </summary>
        private void CommandEllipse()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Ellipse;
        }

        /// <summary>
        /// Set Line draw tool
        /// </summary>
        private void CommandLine()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Line;
        }

        /// <summary>
        /// Set Polygon draw tool
        /// </summary>
        private void CommandPolygon()
        {
            drawArea.ActiveTool = DrawArea.DrawToolType.Polygon;
        }

        /// <summary>
        /// Show About dialog
        /// </summary>
        private void CommandAbout()
        {
            FormAbout frm = new FormAbout();
            frm.ShowDialog(this);
        }

        /// <summary>
        /// Set draw area to all form client space except toolbar
        /// </summary>
        private void ResizeDrawArea()
        {
            Rectangle rect = this.ClientRectangle;

            drawArea.Left = rect.Left;
            drawArea.Top = rect.Top + toolBar1.Height;
            drawArea.Width = rect.Width;
            drawArea.Height = rect.Height - toolBar1.Height;
        }

        /// <summary>
        /// Load application settings from the Registry
        /// </summary>
        void LoadSettingsFromRegistry()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath);

                DrawObject.LastUsedColor = Color.FromArgb((int)key.GetValue(
                    "Color", 
                    Color.Black.ToArgb()));

                DrawObject.LastUsedPenWidth = (int)key.GetValue(
                    "Width",
                    1);
            }
            catch (ArgumentNullException ex)
            {
                HandleRegistryException(ex);
            }
            catch (SecurityException ex)
            {
                HandleRegistryException(ex);
            }
            catch (ArgumentException ex)
            {
                HandleRegistryException(ex);
            }
            catch (ObjectDisposedException ex)
            {
                HandleRegistryException(ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                HandleRegistryException(ex);
            }
        }

        /// <summary>
        /// Save application settings to the Registry
        /// </summary>
        void SaveSettingsToRegistry()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath);

                key.SetValue("Color", DrawObject.LastUsedColor.ToArgb());
                key.SetValue("Width", DrawObject.LastUsedPenWidth);
            }
            catch (SecurityException ex)
            {
                HandleRegistryException(ex);
            }
            catch (ArgumentException ex)
            {
                HandleRegistryException(ex);
            }
            catch (ObjectDisposedException ex)
            {
                HandleRegistryException(ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                HandleRegistryException(ex);
            }
        }

        private void HandleRegistryException(Exception ex)
        {
            Trace.WriteLine("Registry operation failed: " + ex.Message);
        }

        /// <summary>
        /// Set state of controls.
        /// Function is called at idle time.
        /// </summary>
        public void SetStateOfControls()
        {
            // Select active tool
            tbPointer.Pushed = (drawArea.ActiveTool == DrawArea.DrawToolType.Pointer);
            tbRectangle.Pushed = (drawArea.ActiveTool == DrawArea.DrawToolType.Rectangle);
            tbEllipse.Pushed  = (drawArea.ActiveTool == DrawArea.DrawToolType.Ellipse);
            tbLine.Pushed = (drawArea.ActiveTool == DrawArea.DrawToolType.Line);
            tbPolygon.Pushed = (drawArea.ActiveTool == DrawArea.DrawToolType.Polygon);

            menuDrawPointer.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Pointer);
            menuDrawRectangle.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Rectangle);
            menuDrawEllipse.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Ellipse);
            menuDrawLine.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Line);
            menuDrawPolygon.Checked = (drawArea.ActiveTool == DrawArea.DrawToolType.Polygon);

            bool objects = ( drawArea.GraphicsList.Count > 0 );
            bool selectedObjects = ( drawArea.GraphicsList.SelectionCount > 0);

            // File operations
            menuFileSave.Enabled = objects;
            menuFileSaveAs.Enabled = objects;
            tbSave.Enabled = objects;

            // Edit operations
            menuEditDelete.Enabled = selectedObjects;
            menuEditDeleteAll.Enabled = objects;
            menuEditSelectAll.Enabled = objects;
            menuEditUnselectAll.Enabled = objects;
            menuEditMoveToFront.Enabled = selectedObjects;
            menuEditMoveToBack.Enabled = selectedObjects;
            menuEditProperties.Enabled = selectedObjects;
        }

        /// <summary>
        /// Open new file
        /// </summary>
        private void CommandNew()
        {
            docManager.NewDocument();
        }

        /// <summary>
        /// Open file
        /// </summary>
        private void CommandOpen()
        {
            docManager.OpenDocument("");
        }

        /// <summary>
        /// Save file
        /// </summary>
        private void CommandSave()
        {
            docManager.SaveDocument(DocManager.SaveType.Save);
        }

        /// <summary>
        /// Save As
        /// </summary>
        private void CommandSaveAs()
        {
            docManager.SaveDocument(DocManager.SaveType.SaveAs);
        }

        /// <summary>
        /// Handle exception from docManager_LoadEvent function
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="fileName"></param>
        private void HandleLoadException(Exception ex, SerializationEventArgs e)
        {
            MessageBox.Show(this, 
                "Open File operation failed. File name: " + e.FileName + "\n" +
                "Reason: " + ex.Message, 
                Application.ProductName);

            e.Error = true;
        }

        /// <summary>
        /// Handle exception from docManager_SaveEvent function
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="fileName"></param>
        private void HandleSaveException(Exception ex, SerializationEventArgs e)
        {
            MessageBox.Show(this, 
                "Save File operation failed. File name: " + e.FileName + "\n" +
                "Reason: " + ex.Message, 
                Application.ProductName);

            e.Error = true;
        }

        /// <summary>
        /// Initialize helper objects from the DocToolkit Library.
        /// 
        /// Called from Form1_Load. Initialized all objects except
        /// PersistWindowState wich must be initialized in the
        /// form constructor.
        /// </summary>
        private void InitializeHelperObjects()
        {
            // DocManager

            DocManagerData data = new DocManagerData();
            data.FormOwner = this;
            data.UpdateTitle = true;
            data.FileDialogFilter = "DrawTools files (*.dtl)|*.dtl|All Files (*.*)|*.*";
            data.NewDocName = "Untitled.dtl";
            data.RegistryPath = registryPath;

            docManager = new DocManager(data);
            docManager.RegisterFileType("dtl", "dtlfile", "DrawTools File");

            docManager.SaveEvent +=new SaveEventHandler(docManager_SaveEvent);
            docManager.LoadEvent +=new LoadEventHandler(docManager_LoadEvent);
            docManager.OpenEvent += new OpenFileEventHandler(docManager_OpenEvent);
            docManager.DocChangedEvent += new EventHandler(docManager_DocChangedEvent);
            docManager.ClearEvent += new EventHandler(docManager_ClearEvent);

            docManager.NewDocument();

            // DragDropManager
            dragDropManager = new DragDropManager(this);
            dragDropManager.FileDroppedEvent += new FileDroppedEventHandler(this.dragDropManager_FileDroppedEvent); 

            // MruManager
            mruManager = new MruManager();
            mruManager.Initialize(
                this,                              // owner form
                menuFileRecentFiles,               // Recent Files menu item
                registryPath);                     // Registry path to keep MRU list

            mruManager.MruOpenEvent += new MruFileOpenEventHandler(mruManager_MruOpenEvent);
        }

        /// <summary>
        /// Open document.
        /// Used to open file passed in command line or dropped into the window
        /// </summary>
        /// <param name="file"></param>
        public void OpenDocument(string file)
        {
            docManager.OpenDocument(file);
        }

        #endregion
    }
}
