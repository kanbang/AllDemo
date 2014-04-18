using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using Warrentech.Velo.BimDataModel;

namespace GdiPlusTest
{
	public partial class Form1 : Form
	{
		private bool initial = true, startDraw;
		List<Point> pList = new List<Point>();
		byte i = 0;
		public Form1()
		{
			InitializeComponent();
			AddFileToAutoCAD();
			#region 其他

			comboBox3 = new LineWidthPicker();
			button1 = new ColorPicker();
			button1.Click += new EventHandler(button11_Click);
			lineWidthPicker3.DataSource = new List<int> { 0, 5, 9, 13, 15, 18, 20, 25, 30, 35, 40, 50, 53, 60, 70, 80, 90, 100, 106, 120, 140, 158, 200, 211 };
			this.MouseWheel += new MouseEventHandler(panel31_MouseWheel);
			panel4.MouseWheel += new MouseEventHandler(panel4_MouseWheel);
			panel3.MouseWheel += new MouseEventHandler(panel3_MouseWheel);
			this.Click += new EventHandler(Form1_Click);
			groupBox1.Click += new EventHandler(groupBox1_Click);

			dataGridView.Rows.Add();
			dataGridView.Rows[0].Cells[0].Value = "框架柱";
			dataGridView.Rows.Add();
			dataGridView.Rows[1].Cells[0].Value = "框支柱";

			dataGridView.Rows[0].Cells[1].Value = "KZ";
			dataGridView.Rows[1].Cells[1].Value = "KZZ";

			dataGridView2.Rows.Add();
			dataGridView2.Rows[0].Cells[0].Value = "框架柱";
			dataGridView2.Rows.Add();
			dataGridView2.Rows[1].Cells[0].Value = "框支柱";

			dataGridView2.Rows[0].Cells[1].Value = "KZ";
			dataGridView2.Rows[1].Cells[1].Value = "KZZ";
			#endregion

			#region 测试DataGridView事件
			Init();
			#endregion
		}

		#region 其他

		void groupBox1_Click(object sender, EventArgs e)
		{
			this.Focus();
			checkBox1.Focus();
		}

		void Form1_Click(object sender, EventArgs e)
		{
			//Debug.WriteLine("this.Click ");
		}

		void panel4_MouseWheel(object sender, MouseEventArgs e)
		{
			//checkBox1.Focus();
			//Debug.WriteLine("panel4_MouseWheel ");

		}

		void panel3_MouseWheel(object sender, MouseEventArgs e)
		{
			//checkBox1.Focus();
			//Debug.WriteLine("panel3_MouseWheel ");

		}

		void panel31_MouseWheel(object sender, MouseEventArgs e)
		{
			panel3.AutoScrollPosition = new Point(0, panel3.VerticalScroll.Value - e.Delta / 10);
			//Debug.WriteLine("this.MouseWheel ");

		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}
		private void button11_Click(object sender, EventArgs e)
		{
			ArrayList ColorList = new ArrayList();
			Type colorType = typeof(System.Drawing.Color);
			PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
										  BindingFlags.DeclaredOnly | BindingFlags.Public);
			foreach (PropertyInfo c in propInfoList) {
				this.comboBox1.Items.Add(c.Name);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}

		void label1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void AddNewObject(DrawRegion drawRegion, DrawObject drawLine)
		{
			drawRegion.GraphicsList.UnselectAll();

			drawRegion.GraphicsList.Add(drawLine);

			drawRegion.Capture = true;
			drawRegion.Refresh();
		}

		private void panel1_Paint_1(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.Clear(label1.BackColor);
			Font font = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style, this.Font.Unit, i++);
			g.DrawString("大于hь/4中的最", font, new SolidBrush(Color.Red), new PointF(0, 0));
			textBox1.Text = i.ToString();
		}

		private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			Graphics g = e.Graphics;
			Rectangle rect = e.Bounds;
			if (e.Index >= 0) {
				string n = ((ComboBox)sender).Items[e.Index].ToString();
				Font f = new Font("Arial", 9, FontStyle.Regular);
				Color c = Color.FromName(n);
				Brush b = new SolidBrush(c);
				g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
				g.FillRectangle(b, rect.X + 10, rect.Y + 5,
								rect.Width - 10, rect.Height - 10);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
		}
		#region 获得CAD字体文件
		public static void AddFileToAutoCAD()
		{
			string autocad2012RegistryPath = "SOFTWARE\\Autodesk\\AutoCAD\\R18.2\\ACAD-A001:804";
			string autocad2010RegistryPath = "SOFTWARE\\Autodesk\\AutoCAD\\R18.0\\ACAD-8001:804";
			string autocad2008RegistryPath = "SOFTWARE\\Autodesk\\AutoCAD\\R17.1\\ACAD-6001:804";
			List<string> list = new List<string>();
			FillFontList(autocad2012RegistryPath, list);
			FillFontList(autocad2010RegistryPath, list);
			FillFontList(autocad2008RegistryPath, list);
		}

		static void FillFontList(string autocadRegistryPath, List<string> list)
		{
			try {
				var gpRegRoot = Registry.LocalMachine.OpenSubKey(autocadRegistryPath, RegistryKeyPermissionCheck.ReadSubTree);
				if (gpRegRoot != null) {
					string autoCADPath = gpRegRoot.GetValue("Location").ToString();
					if (gpRegRoot != null) {
						autoCADPath = autoCADPath + "\\Fonts";
						DirectoryInfo dictionaryArrayCAD = new DirectoryInfo(autoCADPath);

						if (dictionaryArrayCAD.Exists == false) {
							return;
						}
						FileInfo[] Files = dictionaryArrayCAD.GetFiles();

						foreach (FileInfo inf in Files) {
							list.Add(inf.Name);
						}

					}
				}
			} catch (System.Exception ex) {

			}
		}



		#endregion
		float fontScaleY = 0;
		private bool _hasLine;
		private void panel2_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(panel2.BackColor);
			int height = 81;
			float dpiX = e.Graphics.DpiX;

			float offset = GetPixelByMM(2.5);

			float tagFirstCenterX = pictureBox1.Location.X + 36;
			float tagSecondCenterX = pictureBox1.Location.X + 194;
			float tagFirstCenterY = pictureBox1.Location.Y - offset - height;
			Pen pen = new Pen(Color.Green, GetPixelByMM(0.3));
			float xOffset = GetPixelByMM(1.0);
			e.Graphics.DrawLine(pen, tagFirstCenterX - xOffset, tagFirstCenterY, tagSecondCenterX + xOffset, tagFirstCenterY);
			float yOffset = GetPixelByMM(1.0);
			e.Graphics.DrawLine(pen, tagFirstCenterX, tagFirstCenterY - yOffset, tagFirstCenterX, tagFirstCenterY + height);
			e.Graphics.DrawLine(pen, tagSecondCenterX, tagFirstCenterY - yOffset, tagSecondCenterX, tagFirstCenterY + height);

			pen = new Pen(Color.Green, GetPixelByMM(0.5));
			float tagLength = GetPixelByMM(2);
			float tagOffset = (float)(tagLength * Math.Sqrt(2) / 4);
			e.Graphics.DrawLine(pen, tagFirstCenterX - tagOffset, tagFirstCenterY + tagOffset, tagFirstCenterX + tagOffset, tagFirstCenterY - tagOffset);
			e.Graphics.DrawLine(pen, tagSecondCenterX - tagOffset, tagFirstCenterY + tagOffset, tagSecondCenterX + tagOffset, tagFirstCenterY - tagOffset);

			float fontHeight = (float)(GetPixelByMM(3) / 1.5 + 12);
			float fontWidth = (float)0.7 * fontHeight;
			//e.Graphics.ScaleTransform(0.7f,1);
			//e.Graphics.ResetTransform();
			float fontY = tagFirstCenterY - fontHeight - 2;

			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

			GraphicsPath path = new GraphicsPath();
			StringFormat strformat = new StringFormat();
			strformat.Alignment = StringAlignment.Center;
			strformat.LineAlignment = StringAlignment.Center;
			path.AddString("200", this.Font.FontFamily, (int)this.Font.Style, fontHeight, new PointF(0, fontY), StringFormat.GenericDefault);
			Matrix m = new Matrix();
			m.Scale(0.7f + fontScaleY, 1f);   //压扁
			path.Transform(m);
			RectangleF rec = path.GetBounds();
			m = new Matrix();
			float fontX = (float)(pictureBox1.Location.X + 115 - rec.Width * 0.5);

			m.Translate(fontX - path.GetBounds().Left, 0);
			path.Flatten(m, 1.0F);

			e.Graphics.FillPath(new SolidBrush(Color.White), path);
			fontScaleY += (float)0.1;

			//e.Graphics.DrawString("200", new Font(this.Font.FontFamily, this.Font.Size + fontSize), new SolidBrush(Color.White), new PointF(fontX, fontY));
		}
		private float GetPixelByMM(double mm)
		{
			return (float)Convert.ToDouble(Convert.ToDouble(mm) * 2);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			panel2.Refresh();
		}

		private void pictureBox2_Paint(object sender, PaintEventArgs e)
		{
			if (!_hasLine) {
				SolidBrush brush = new SolidBrush(Color.FromArgb(200, Color.Gray));
				e.Graphics.FillRectangle(brush, new RectangleF(0, 0, pictureBox2.Width, pictureBox2.Height));
				brush.Dispose();
			}
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			_hasLine = true;
			pictureBox2.Refresh();
			pictureBox3.Refresh();
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			_hasLine = false;
			pictureBox2.Refresh();
			pictureBox3.Refresh();
		}

		private void pictureBox3_Paint(object sender, PaintEventArgs e)
		{
			if (_hasLine) {
				SolidBrush brush = new SolidBrush(Color.FromArgb(200, Color.Gray));
				e.Graphics.FillRectangle(brush, new RectangleF(0, 0, pictureBox3.Width, pictureBox3.Height));
				brush.Dispose();
			}
		}

		private void comboBox4_DropDownClosed(object sender, EventArgs e)
		{
			//checkBox1.Focus();
		}

		private void comboBox4_MouseLeave(object sender, EventArgs e)
		{
			checkBox1.Focus();

		}

		private void panel4_Click(object sender, EventArgs e)
		{
			checkBox1.Focus();
		}

		private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
		}

		private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
			dataGridView.BeginEdit(true);

			Rectangle rec = dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
			Rectangle newRec = dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

		}

		private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.WriteLine(MethodBase.GetCurrentMethod().Name);

		}

		private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.WriteLine(MethodBase.GetCurrentMethod().Name);

		}

		private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			//Debug.WriteLine(MethodBase.GetCurrentMethod().Name);

		}

		Point point = new Point();
		//fixed bug 5288

		//fixed topic 5288
		private void dataGridView_Click(object sender, EventArgs e)
		{
			AddToNewParent(tabPage4);
		}

		private void panel6_Click(object sender, EventArgs e)
		{

		}

		private void tabPage4_Click(object sender, EventArgs e)
		{

		}

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
		}
		/// <summary>
		/// windows消息窗体 屏蔽鼠标操作
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref Message m)
		{
			//Debug.WriteLine(string.Format("m.HWnd {0}; m.LParam {1};m.Msg {2};,m.Result {3};m.WParam {4}", m.HWnd, m.LParam, m.Msg, m.Result, m.WParam));

			if (m.Msg == 0x201 || m.Msg == 0x202 || m.Msg == 0x203 || m.Msg == 0x204 || m.Msg == 0x205 || m.Msg == 0x206 || m.Msg == 0x207 || m.Msg == 0x208 || m.Msg == 0x209 || m.Msg == 0x210) {
				Point point = new Point(m.LParam.ToInt32());
				//换算成相对本窗体的位置

				//判断是否在panel内
				if (!tabPage4.RectangleToScreen(dataGridView.DisplayRectangle).Contains(point)) {
					AddToNewParent(panel6);

				}
			}
			base.WndProc(ref m);

		}

		private void AddToNewParent(Control panel)
		{
			if (dataGridView.Parent != panel) {
				dataGridView.Location = panel.PointToClient(dataGridView.Parent.PointToScreen(dataGridView.Location));
				dataGridView.Parent.Controls.Remove(dataGridView);
				panel.Controls.Add(dataGridView);
				dataGridView.BringToFront();

			}
		}

		private void textBox3_KeyDown(object sender, KeyEventArgs e)
		{
			List<Keys> allowKeys = new List<Keys>();
			allowKeys.Add(Keys.D2);
			allowKeys.Add(Keys.D4);
			allowKeys.Add(Keys.D6);
			allowKeys.Add(Keys.D8);
			allowKeys.Add(Keys.NumPad2);
			allowKeys.Add(Keys.NumPad4);
			allowKeys.Add(Keys.NumPad6);
			allowKeys.Add(Keys.NumPad8);
			allowKeys.Add(Keys.Left);
			allowKeys.Add(Keys.Right);
			allowKeys.Add(Keys.Up);
			allowKeys.Add(Keys.Down);
			allowKeys.Add(Keys.Delete);
			allowKeys.Add(Keys.Back);
			allowKeys.Add(Keys.Home);
			allowKeys.Add(Keys.End);
			allowKeys.Add(Keys.Insert);
			if (!e.Shift) {
				if (allowKeys.Contains(e.KeyCode)) {
					return;
				}

				if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0) {
					if (textBox3.Text.Length > 0 && textBox3.SelectionStart > 0) {
						return;
					}

				}
			}

			e.SuppressKeyPress = true;
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void textBox2_KeyUp(object sender, KeyEventArgs e)
		{

		}

		private void panel9_Paint(object sender, PaintEventArgs e)
		{
			List<List<PointF>> stirrupBarPoints = new List<List<PointF>>();

			stirrupBarPoints.Add(new List<PointF> { new PointF(10, 10), new PointF(10, 20), new PointF(10, 30), new PointF(30, 30), new PointF(30, 20), new PointF(30, 10) });
			//stirrupBarPoints.Add(new List<PointF> { new PointF(10, 20), new PointF(10, 25), new PointF(35, 25), new PointF(40, 25), new PointF(40, 20), new PointF(35, 20) });

			List<GraphicsPath> pathList = new List<GraphicsPath>();
			GraphicsPath path = new GraphicsPath();
			foreach (List<PointF> list in stirrupBarPoints) {
				if (list.Count == 0) {
					continue;
				}
				GraphicsPath childPath = GetRepresentPoints(list);
				pathList.Add(childPath);
				path.AddPath(childPath, false);
			}
			RectangleF rec = path.GetBounds();
			Matrix mScale = new Matrix();

			//mScale.Translate(0 - rec.Left, 0 - rec.Top);//移到 0,0点
			path.Flatten(mScale, 1.0f);

			PointF pointBS = new PointF(100, 200);
			PointF pointBE = new PointF(200, 200);
			PointF pointTS = new PointF(100, 100);
			PointF pointTE = new PointF(120, 100);

			PointF pointTS2 = new PointF(180, 100);
			PointF pointTE2 = new PointF(200, 100);

			PointF pointOS = new PointF(80, 150);
			PointF pointOE = new PointF(210, 150);
			path.StartFigure();
			path.AddLine(pointBS, pointBE);

			path.StartFigure();
			path.AddLine(pointTS, pointTE);

			path.StartFigure();
			path.AddCurve(new PointF[] { pointBS, pointOS, pointTS });

			path.StartFigure();
			path.AddLine(pointTS2, pointTE2);

			path.StartFigure();
			path.AddCurve(new PointF[] { pointBE, pointOE, pointTE2 });

			e.Graphics.Clear(panel9.BackColor);
			e.Graphics.DrawPath(new Pen(Brushes.Red), path);
		}
		float scale = 0.1f;
		private GraphicsPath GetRepresentPoints(List<PointF> list)
		{
			int offset = 5;
			GraphicsPath path = new GraphicsPath();
			path.AddPolygon(list.ToArray());
			Matrix mScale = new Matrix();
			mScale.Scale(scale, scale); //进行缩放，比例
			path.Transform(mScale);
			return path;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			panel9.Refresh();
			panel10.Refresh();
			scale += 0.1f;
		}


		private void panel10_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(panel9.BackColor);

			List<List<PointF>> stirrupBarPoints = new List<List<PointF>>();

			stirrupBarPoints.Add(new List<PointF> { new PointF(10, 10), new PointF(10, 20), new PointF(10, 30), new PointF(30, 30), new PointF(30, 20), new PointF(30, 10) });
			stirrupBarPoints.Add(new List<PointF> { new PointF(10, 20), new PointF(10, 25), new PointF(35, 25), new PointF(40, 25), new PointF(40, 20), new PointF(35, 20) });

			foreach (List<PointF> list in stirrupBarPoints) {
				if (list.Count == 0) {
					continue;
				}
				Matrix mScale = new Matrix();
				mScale.Scale(scale, scale); //进行缩放，比例
				PointF[] array = list.ToArray();
				mScale.TransformPoints(array);
				//e.Graphics.DrawPolygon(new Pen(Brushes.Red), array);
				GraphicsPath path = new GraphicsPath();
				path.AddPolygon(array);
				e.Graphics.DrawPath(new Pen(Brushes.Red), path);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{

		}

		private void button6_MouseClick(object sender, MouseEventArgs e)
		{

		}

		private void label3_DoubleClick(object sender, EventArgs e)
		{
			Debug.WriteLine(MethodBase.GetCurrentMethod().Name);

		}

		private void label3_MouseClick(object sender, MouseEventArgs e)
		{
			Debug.WriteLine(MethodBase.GetCurrentMethod().Name);

		}

		private void label3_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
		}

		private void panel11_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(Color.Black);
			List<Point3D> soruce = new List<Point3D>();
			soruce.Add(new Point3D(214.667145, 181.538437, 0));
			soruce.Add(new Point3D(191.806778, 270.600739, 0));
			soruce.Add(new Point3D(300.448883, 298.486816, 0));
			soruce.Add(new Point3D(319.0396, 226.058746, 0));
			soruce.Add(new Point3D(358.449615, 162.5112, 0));
			soruce.Add(new Point3D(263.128265, 103.396194, 0));

			BoundingBox boxSource = GraphicTools.GetRectanglePoint(soruce, true);
			Point3D centerSource = boxSource.MinPt + (boxSource.MaxPt - boxSource.MinPt) / 2;

			List<Point3D> list = new List<Point3D>();
			list.Add(new Point3D(251.407073974609, 141.631622314453, 0));
			list.Add(new Point3D(175.881851196289, 197.970703125, 0));
			list.Add(new Point3D(242.947723388672, 287.875701904297, 0));
			list.Add(new Point3D(302.884399414063, 243.165130615234, 0));
			list.Add(new Point3D(374.374542236328, 221.242523193359, 0));
			list.Add(new Point3D(341.490631103516, 114.007308959961, 0));
			BoundingBox boxlist = GraphicTools.GetRectanglePoint(list, true);
			Point3D centerlist = boxlist.MinPt + (boxlist.MaxPt - boxlist.MinPt) / 2;
			Matrix3D _matrix = new Matrix3D();
			_matrix.Rotate(new Quaternion(new Vector3D(0, 0, 1), angel));

			PointF[] drawSource = new PointF[6];
			for (int i = 0; i < soruce.Count; i++) {
				drawSource[i] = new PointF((float)soruce[i].X, (float)soruce[i].Y);
			}
			PointF[] drawList = new PointF[6];
			PointF[] drawListRotate = new PointF[6];
			List<Point3D> rotate = new List<Point3D>();

			for (int i = 0; i < list.Count; i++) {
				Point3D point = _matrix.Transform(list[i]);
				rotate.Add(point);
				drawList[i] = new PointF((float)list[i].X, (float)list[i].Y);
			}
			BoundingBox boxRotate = GraphicTools.GetRectanglePoint(rotate, true);
			Point3D centerRotate = boxRotate.MinPt + (boxRotate.MaxPt - boxRotate.MinPt) / 2;
			_matrix = new Matrix3D();
			_matrix.Translate(centerSource - centerRotate);
			for (int i = 0; i < rotate.Count; i++) {
				Point3D point = _matrix.Transform(rotate[i]);
				drawListRotate[i] = new PointF((float)point.X, (float)point.Y);
			}

			e.Graphics.DrawPolygon(new Pen(Color.Red), drawSource);

			e.Graphics.DrawPolygon(new Pen(Color.Green), drawList);
			e.Graphics.DrawPolygon(new Pen(Color.Blue), drawListRotate);

		}
		double angel = 0.0;
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			angel = Convert.ToDouble(numericUpDown1.Value);
			//angel =  - (75.604189995795200);
			panel11.Refresh();
		}
		#endregion
		#region 测试DataGridView 事件
		private void Init()
		{
			dataGridView3.Rows.Add();
			#region 生成所有的事件
			//EventInfo[] evts = dataGridView3.GetType().GetEvents(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			//StringBuilder eventBuilder = new StringBuilder();
			//StringBuilder builder = new StringBuilder();
			//foreach (var evt in evts) {
			//    eventBuilder.AppendLine(string.Format("dataGridView3.{0}+=On{0}Handler;", evt.Name));
			//    string eventTypeName = evt.EventHandlerType.Name;
			//    eventTypeName = eventTypeName.Replace("EventHandler", "EventArgs");
			//    builder.AppendLine(string.Format("void On{0}Handler(object sender, {1} e)", evt.Name, eventTypeName));
			//    builder.AppendLine("{");
			//    builder.AppendLine(string.Format("Debug.WriteLine('On{0}Handler');",evt.Name));
			//    builder.AppendLine("}");

			//}

			//Clipboard.SetText(builder.ToString());
			//Clipboard.SetText(eventBuilder.ToString());

			#endregion
			dataGridView3.AllowUserToAddRowsChanged += OnAllowUserToAddRowsChangedHandler;
			dataGridView3.AllowUserToDeleteRowsChanged += OnAllowUserToDeleteRowsChangedHandler;
			dataGridView3.AllowUserToOrderColumnsChanged += OnAllowUserToOrderColumnsChangedHandler;
			dataGridView3.AllowUserToResizeColumnsChanged += OnAllowUserToResizeColumnsChangedHandler;
			dataGridView3.AllowUserToResizeRowsChanged += OnAllowUserToResizeRowsChangedHandler;
			dataGridView3.AlternatingRowsDefaultCellStyleChanged += OnAlternatingRowsDefaultCellStyleChangedHandler;
			dataGridView3.AutoGenerateColumnsChanged += OnAutoGenerateColumnsChangedHandler;
			dataGridView3.AutoSizeColumnsModeChanged += OnAutoSizeColumnsModeChangedHandler;
			dataGridView3.AutoSizeRowsModeChanged += OnAutoSizeRowsModeChangedHandler;
			dataGridView3.BackColorChanged += OnBackColorChangedHandler;
			dataGridView3.BackgroundColorChanged += OnBackgroundColorChangedHandler;
			dataGridView3.BackgroundImageChanged += OnBackgroundImageChangedHandler;
			dataGridView3.BackgroundImageLayoutChanged += OnBackgroundImageLayoutChangedHandler;
			dataGridView3.BorderStyleChanged += OnBorderStyleChangedHandler;
			dataGridView3.CellBorderStyleChanged += OnCellBorderStyleChangedHandler;
			dataGridView3.ColumnHeadersBorderStyleChanged += OnColumnHeadersBorderStyleChangedHandler;
			dataGridView3.ColumnHeadersDefaultCellStyleChanged += OnColumnHeadersDefaultCellStyleChangedHandler;
			dataGridView3.ColumnHeadersHeightChanged += OnColumnHeadersHeightChangedHandler;
			dataGridView3.ColumnHeadersHeightSizeModeChanged += OnColumnHeadersHeightSizeModeChangedHandler;
			dataGridView3.DataMemberChanged += OnDataMemberChangedHandler;
			dataGridView3.DataSourceChanged += OnDataSourceChangedHandler;
			dataGridView3.DefaultCellStyleChanged += OnDefaultCellStyleChangedHandler;
			dataGridView3.EditModeChanged += OnEditModeChangedHandler;
			dataGridView3.ForeColorChanged += OnForeColorChangedHandler;
			dataGridView3.FontChanged += OnFontChangedHandler;
			dataGridView3.GridColorChanged += OnGridColorChangedHandler;
			dataGridView3.MultiSelectChanged += OnMultiSelectChangedHandler;
			dataGridView3.PaddingChanged += OnPaddingChangedHandler;
			dataGridView3.ReadOnlyChanged += OnReadOnlyChangedHandler;
			dataGridView3.RowHeadersBorderStyleChanged += OnRowHeadersBorderStyleChangedHandler;
			dataGridView3.RowHeadersDefaultCellStyleChanged += OnRowHeadersDefaultCellStyleChangedHandler;
			dataGridView3.RowHeadersWidthChanged += OnRowHeadersWidthChangedHandler;
			dataGridView3.RowHeadersWidthSizeModeChanged += OnRowHeadersWidthSizeModeChangedHandler;
			dataGridView3.RowsDefaultCellStyleChanged += OnRowsDefaultCellStyleChangedHandler;
			dataGridView3.TextChanged += OnTextChangedHandler;
			dataGridView3.AutoSizeColumnModeChanged += OnAutoSizeColumnModeChangedHandler;
			dataGridView3.CancelRowEdit += OnCancelRowEditHandler;
			dataGridView3.CellBeginEdit += OnCellBeginEditHandler;
			dataGridView3.CellClick += OnCellClickHandler;
			dataGridView3.CellContentClick += OnCellContentClickHandler;
			dataGridView3.CellContentDoubleClick += OnCellContentDoubleClickHandler;
			dataGridView3.CellContextMenuStripChanged += OnCellContextMenuStripChangedHandler;
			dataGridView3.CellContextMenuStripNeeded += OnCellContextMenuStripNeededHandler;
			dataGridView3.CellDoubleClick += OnCellDoubleClickHandler;
			dataGridView3.CellEndEdit += OnCellEndEditHandler;
			dataGridView3.CellEnter += OnCellEnterHandler;
			dataGridView3.CellErrorTextChanged += OnCellErrorTextChangedHandler;
			dataGridView3.CellErrorTextNeeded += OnCellErrorTextNeededHandler;
			dataGridView3.CellFormatting += OnCellFormattingHandler;
			dataGridView3.CellLeave += OnCellLeaveHandler;
			dataGridView3.CellMouseClick += OnCellMouseClickHandler;
			dataGridView3.CellMouseDoubleClick += OnCellMouseDoubleClickHandler;
			dataGridView3.CellMouseDown += OnCellMouseDownHandler;
			dataGridView3.CellMouseEnter += OnCellMouseEnterHandler;
			dataGridView3.CellMouseLeave += OnCellMouseLeaveHandler;
			dataGridView3.CellMouseMove += OnCellMouseMoveHandler;
			dataGridView3.CellMouseUp += OnCellMouseUpHandler;
			dataGridView3.CellPainting += OnCellPaintingHandler;
			dataGridView3.CellParsing += OnCellParsingHandler;
			dataGridView3.CellStateChanged += OnCellStateChangedHandler;
			dataGridView3.CellStyleChanged += OnCellStyleChangedHandler;
			dataGridView3.CellStyleContentChanged += OnCellStyleContentChangedHandler;
			dataGridView3.CellToolTipTextChanged += OnCellToolTipTextChangedHandler;
			dataGridView3.CellToolTipTextNeeded += OnCellToolTipTextNeededHandler;
			dataGridView3.CellValidated += OnCellValidatedHandler;
			dataGridView3.CellValidating += OnCellValidatingHandler;
			dataGridView3.CellValueChanged += OnCellValueChangedHandler;
			dataGridView3.CellValueNeeded += OnCellValueNeededHandler;
			dataGridView3.CellValuePushed += OnCellValuePushedHandler;
			dataGridView3.ColumnAdded += OnColumnAddedHandler;
			dataGridView3.ColumnContextMenuStripChanged += OnColumnContextMenuStripChangedHandler;
			dataGridView3.ColumnDataPropertyNameChanged += OnColumnDataPropertyNameChangedHandler;
			dataGridView3.ColumnDefaultCellStyleChanged += OnColumnDefaultCellStyleChangedHandler;
			dataGridView3.ColumnDisplayIndexChanged += OnColumnDisplayIndexChangedHandler;
			dataGridView3.ColumnDividerDoubleClick += OnColumnDividerDoubleClickHandler;
			dataGridView3.ColumnDividerWidthChanged += OnColumnDividerWidthChangedHandler;
			dataGridView3.ColumnHeaderMouseClick += OnColumnHeaderMouseClickHandler;
			dataGridView3.ColumnHeaderMouseDoubleClick += OnColumnHeaderMouseDoubleClickHandler;
			dataGridView3.ColumnHeaderCellChanged += OnColumnHeaderCellChangedHandler;
			dataGridView3.ColumnMinimumWidthChanged += OnColumnMinimumWidthChangedHandler;
			dataGridView3.ColumnNameChanged += OnColumnNameChangedHandler;
			dataGridView3.ColumnRemoved += OnColumnRemovedHandler;
			dataGridView3.ColumnSortModeChanged += OnColumnSortModeChangedHandler;
			dataGridView3.ColumnStateChanged += OnColumnStateChangedHandler;
			dataGridView3.ColumnToolTipTextChanged += OnColumnToolTipTextChangedHandler;
			dataGridView3.ColumnWidthChanged += OnColumnWidthChangedHandler;
			dataGridView3.CurrentCellChanged += OnCurrentCellChangedHandler;
			dataGridView3.CurrentCellDirtyStateChanged += OnCurrentCellDirtyStateChangedHandler;
			dataGridView3.DataBindingComplete += OnDataBindingCompleteHandler;
			dataGridView3.DataError += OnDataErrorHandler;
			dataGridView3.DefaultValuesNeeded += OnDefaultValuesNeededHandler;
			dataGridView3.EditingControlShowing += OnEditingControlShowingHandler;
			dataGridView3.NewRowNeeded += OnNewRowNeededHandler;
			dataGridView3.RowContextMenuStripChanged += OnRowContextMenuStripChangedHandler;
			dataGridView3.RowContextMenuStripNeeded += OnRowContextMenuStripNeededHandler;
			dataGridView3.RowDefaultCellStyleChanged += OnRowDefaultCellStyleChangedHandler;
			dataGridView3.RowDirtyStateNeeded += OnRowDirtyStateNeededHandler;
			dataGridView3.RowDividerDoubleClick += OnRowDividerDoubleClickHandler;
			dataGridView3.RowDividerHeightChanged += OnRowDividerHeightChangedHandler;
			dataGridView3.RowEnter += OnRowEnterHandler;
			dataGridView3.RowErrorTextChanged += OnRowErrorTextChangedHandler;
			dataGridView3.RowErrorTextNeeded += OnRowErrorTextNeededHandler;
			dataGridView3.RowHeaderMouseClick += OnRowHeaderMouseClickHandler;
			dataGridView3.RowHeaderMouseDoubleClick += OnRowHeaderMouseDoubleClickHandler;
			dataGridView3.RowHeaderCellChanged += OnRowHeaderCellChangedHandler;
			dataGridView3.RowHeightChanged += OnRowHeightChangedHandler;
			dataGridView3.RowHeightInfoNeeded += OnRowHeightInfoNeededHandler;
			dataGridView3.RowHeightInfoPushed += OnRowHeightInfoPushedHandler;
			dataGridView3.RowLeave += OnRowLeaveHandler;
			dataGridView3.RowMinimumHeightChanged += OnRowMinimumHeightChangedHandler;
			dataGridView3.RowPostPaint += OnRowPostPaintHandler;
			dataGridView3.RowPrePaint += OnRowPrePaintHandler;
			dataGridView3.RowsAdded += OnRowsAddedHandler;
			dataGridView3.RowsRemoved += OnRowsRemovedHandler;
			dataGridView3.RowStateChanged += OnRowStateChangedHandler;
			dataGridView3.RowUnshared += OnRowUnsharedHandler;
			dataGridView3.RowValidated += OnRowValidatedHandler;
			dataGridView3.RowValidating += OnRowValidatingHandler;
			dataGridView3.Scroll += OnScrollHandler;
			dataGridView3.SelectionChanged += OnSelectionChangedHandler;
			dataGridView3.SortCompare += OnSortCompareHandler;
			dataGridView3.Sorted += OnSortedHandler;
			dataGridView3.StyleChanged += OnStyleChangedHandler;
			dataGridView3.UserAddedRow += OnUserAddedRowHandler;
			dataGridView3.UserDeletedRow += OnUserDeletedRowHandler;
			dataGridView3.UserDeletingRow += OnUserDeletingRowHandler;
			dataGridView3.AutoSizeChanged += OnAutoSizeChangedHandler;
			dataGridView3.BindingContextChanged += OnBindingContextChangedHandler;
			dataGridView3.CausesValidationChanged += OnCausesValidationChangedHandler;
			dataGridView3.ClientSizeChanged += OnClientSizeChangedHandler;
			dataGridView3.ContextMenuChanged += OnContextMenuChangedHandler;
			dataGridView3.ContextMenuStripChanged += OnContextMenuStripChangedHandler;
			dataGridView3.CursorChanged += OnCursorChangedHandler;
			dataGridView3.DockChanged += OnDockChangedHandler;
			dataGridView3.EnabledChanged += OnEnabledChangedHandler;
			dataGridView3.LocationChanged += OnLocationChangedHandler;
			dataGridView3.MarginChanged += OnMarginChangedHandler;
			dataGridView3.RegionChanged += OnRegionChangedHandler;
			dataGridView3.RightToLeftChanged += OnRightToLeftChangedHandler;
			dataGridView3.SizeChanged += OnSizeChangedHandler;
			dataGridView3.TabIndexChanged += OnTabIndexChangedHandler;
			dataGridView3.TabStopChanged += OnTabStopChangedHandler;
			dataGridView3.VisibleChanged += OnVisibleChangedHandler;
			dataGridView3.Click += OnClickHandler;
			dataGridView3.ControlAdded += OnControlAddedHandler;
			dataGridView3.ControlRemoved += OnControlRemovedHandler;
			dataGridView3.DragDrop += OnDragDropHandler;
			dataGridView3.DragEnter += OnDragEnterHandler;
			dataGridView3.DragOver += OnDragOverHandler;
			dataGridView3.DragLeave += OnDragLeaveHandler;
			dataGridView3.GiveFeedback += OnGiveFeedbackHandler;
			dataGridView3.HandleCreated += OnHandleCreatedHandler;
			dataGridView3.HandleDestroyed += OnHandleDestroyedHandler;
			dataGridView3.HelpRequested += OnHelpRequestedHandler;
			dataGridView3.Invalidated += OnInvalidatedHandler;
			dataGridView3.Paint += OnPaintHandler;
			dataGridView3.QueryContinueDrag += OnQueryContinueDragHandler;
			dataGridView3.QueryAccessibilityHelp += OnQueryAccessibilityHelpHandler;
			dataGridView3.DoubleClick += OnDoubleClickHandler;
			dataGridView3.Enter += OnEnterHandler;
			dataGridView3.GotFocus += OnGotFocusHandler;
			dataGridView3.KeyDown += OnKeyDownHandler;
			dataGridView3.KeyPress += OnKeyPressHandler;
			dataGridView3.KeyUp += OnKeyUpHandler;
			dataGridView3.Layout += OnLayoutHandler;
			dataGridView3.Leave += OnLeaveHandler;
			dataGridView3.LostFocus += OnLostFocusHandler;
			dataGridView3.MouseClick += OnMouseClickHandler;
			dataGridView3.MouseDoubleClick += OnMouseDoubleClickHandler;
			dataGridView3.MouseCaptureChanged += OnMouseCaptureChangedHandler;
			dataGridView3.MouseDown += OnMouseDownHandler;
			dataGridView3.MouseEnter += OnMouseEnterHandler;
			dataGridView3.MouseLeave += OnMouseLeaveHandler;
			dataGridView3.MouseHover += OnMouseHoverHandler;
			dataGridView3.MouseMove += OnMouseMoveHandler;
			dataGridView3.MouseUp += OnMouseUpHandler;
			dataGridView3.MouseWheel += OnMouseWheelHandler;
			dataGridView3.Move += OnMoveHandler;
			dataGridView3.PreviewKeyDown += OnPreviewKeyDownHandler;
			dataGridView3.Resize += OnResizeHandler;
			dataGridView3.ChangeUICues += OnChangeUICuesHandler;
			dataGridView3.SystemColorsChanged += OnSystemColorsChangedHandler;
			dataGridView3.Validating += OnValidatingHandler;
			dataGridView3.Validated += OnValidatedHandler;
			dataGridView3.ParentChanged += OnParentChangedHandler;
			dataGridView3.ImeModeChanged += OnImeModeChangedHandler;
			dataGridView3.Disposed += OnDisposedHandler;
		}
		void OnAllowUserToAddRowsChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnAllowUserToAddRowsChangedHandler");
		}
		void OnAllowUserToDeleteRowsChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnAllowUserToDeleteRowsChangedHandler");
		}
		void OnAllowUserToOrderColumnsChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnAllowUserToOrderColumnsChangedHandler");
		}
		void OnAllowUserToResizeColumnsChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnAllowUserToResizeColumnsChangedHandler");
		}
		void OnAllowUserToResizeRowsChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnAllowUserToResizeRowsChangedHandler");
		}
		void OnAlternatingRowsDefaultCellStyleChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnAlternatingRowsDefaultCellStyleChangedHandler");
		}
		void OnAutoGenerateColumnsChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnAutoGenerateColumnsChangedHandler");
		}
		void OnAutoSizeColumnsModeChangedHandler(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnAutoSizeColumnsModeChangedHandler");
		}
		void OnAutoSizeRowsModeChangedHandler(object sender, DataGridViewAutoSizeModeEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnAutoSizeRowsModeChangedHandler");
		}
		void OnBackColorChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnBackColorChangedHandler");
		}
		void OnBackgroundColorChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnBackgroundColorChangedHandler");
		}
		void OnBackgroundImageChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnBackgroundImageChangedHandler");
		}
		void OnBackgroundImageLayoutChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnBackgroundImageLayoutChangedHandler");
		}
		void OnBorderStyleChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnBorderStyleChangedHandler");
		}
		void OnCellBorderStyleChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellBorderStyleChangedHandler");
		}
		void OnColumnHeadersBorderStyleChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnHeadersBorderStyleChangedHandler");
		}
		void OnColumnHeadersDefaultCellStyleChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnHeadersDefaultCellStyleChangedHandler");
		}
		void OnColumnHeadersHeightChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnHeadersHeightChangedHandler");
		}
		void OnColumnHeadersHeightSizeModeChangedHandler(object sender, DataGridViewAutoSizeModeEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnHeadersHeightSizeModeChangedHandler");
		}
		void OnDataMemberChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDataMemberChangedHandler");
		}
		void OnDataSourceChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDataSourceChangedHandler");
		}
		void OnDefaultCellStyleChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDefaultCellStyleChangedHandler");
		}
		void OnEditModeChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnEditModeChangedHandler");
		}
		void OnForeColorChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnForeColorChangedHandler");
		}
		void OnFontChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnFontChangedHandler");
		}
		void OnGridColorChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnGridColorChangedHandler");
		}
		void OnMultiSelectChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnMultiSelectChangedHandler");
		}
		void OnPaddingChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnPaddingChangedHandler");
		}
		void OnReadOnlyChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnReadOnlyChangedHandler");
		}
		void OnRowHeadersBorderStyleChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowHeadersBorderStyleChangedHandler");
		}
		void OnRowHeadersDefaultCellStyleChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowHeadersDefaultCellStyleChangedHandler");
		}
		void OnRowHeadersWidthChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowHeadersWidthChangedHandler");
		}
		void OnRowHeadersWidthSizeModeChangedHandler(object sender, DataGridViewAutoSizeModeEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowHeadersWidthSizeModeChangedHandler");
		}
		void OnRowsDefaultCellStyleChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowsDefaultCellStyleChangedHandler");
		}
		void OnTextChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnTextChangedHandler");
		}
		void OnAutoSizeColumnModeChangedHandler(object sender, DataGridViewAutoSizeColumnModeEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnAutoSizeColumnModeChangedHandler");
		}
		void OnCancelRowEditHandler(object sender, QuestionEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCancelRowEditHandler");
		}
		void OnCellBeginEditHandler(object sender, DataGridViewCellCancelEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellBeginEditHandler");
		}
		void OnCellClickHandler(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.WriteLine(DateTime.Now + "OnCellClickHandler");
		}
		void OnCellContentClickHandler(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.WriteLine(DateTime.Now + "OnCellContentClickHandler");
		}
		void OnCellContentDoubleClickHandler(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.WriteLine(DateTime.Now + "OnCellContentDoubleClickHandler");
		}
		void OnCellContextMenuStripChangedHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellContextMenuStripChangedHandler");
		}
		void OnCellContextMenuStripNeededHandler(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellContextMenuStripNeededHandler");
		}
		void OnCellDoubleClickHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellDoubleClickHandler");
		}
		void OnCellEndEditHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellEndEditHandler");
		}
		void OnCellEnterHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellEnterHandler");
		}
		void OnCellErrorTextChangedHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellErrorTextChangedHandler");
		}
		void OnCellErrorTextNeededHandler(object sender, DataGridViewCellErrorTextNeededEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellErrorTextNeededHandler");
		}
		void OnCellFormattingHandler(object sender, DataGridViewCellFormattingEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellFormattingHandler");
		}
		void OnCellLeaveHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellLeaveHandler");
		}
		void OnCellMouseClickHandler(object sender, DataGridViewCellMouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellMouseClickHandler");
		}
		void OnCellMouseDoubleClickHandler(object sender, DataGridViewCellMouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellMouseDoubleClickHandler");
		}
		void OnCellMouseDownHandler(object sender, DataGridViewCellMouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellMouseDownHandler");
		}
		void OnCellMouseEnterHandler(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.WriteLine(DateTime.Now + "OnCellMouseEnterHandler");
		}
		void OnCellMouseLeaveHandler(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.WriteLine(DateTime.Now + "OnCellMouseLeaveHandler");
		}
		void OnCellMouseMoveHandler(object sender, DataGridViewCellMouseEventArgs e)
		{
			//Debug.WriteLine(DateTime.Now + "OnCellMouseMoveHandler");
		}
		void OnCellMouseUpHandler(object sender, DataGridViewCellMouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellMouseUpHandler");
		}
		void OnCellPaintingHandler(object sender, DataGridViewCellPaintingEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellPaintingHandler");
		}
		void OnCellParsingHandler(object sender, DataGridViewCellParsingEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellParsingHandler");
		}
		void OnCellStateChangedHandler(object sender, DataGridViewCellStateChangedEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellStateChangedHandler");
		}
		void OnCellStyleChangedHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellStyleChangedHandler");
		}
		void OnCellStyleContentChangedHandler(object sender, DataGridViewCellStyleContentChangedEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellStyleContentChangedHandler");
		}
		void OnCellToolTipTextChangedHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellToolTipTextChangedHandler");
		}
		void OnCellToolTipTextNeededHandler(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellToolTipTextNeededHandler");
		}
		void OnCellValidatedHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellValidatedHandler");
		}
		void OnCellValidatingHandler(object sender, DataGridViewCellValidatingEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellValidatingHandler");
		}
		void OnCellValueChangedHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellValueChangedHandler");
		}
		void OnCellValueNeededHandler(object sender, DataGridViewCellValueEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellValueNeededHandler");
		}
		void OnCellValuePushedHandler(object sender, DataGridViewCellValueEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCellValuePushedHandler");
		}
		void OnColumnAddedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnAddedHandler");
		}
		void OnColumnContextMenuStripChangedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnContextMenuStripChangedHandler");
		}
		void OnColumnDataPropertyNameChangedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnDataPropertyNameChangedHandler");
		}
		void OnColumnDefaultCellStyleChangedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnDefaultCellStyleChangedHandler");
		}
		void OnColumnDisplayIndexChangedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnDisplayIndexChangedHandler");
		}
		void OnColumnDividerDoubleClickHandler(object sender, DataGridViewColumnDividerDoubleClickEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnDividerDoubleClickHandler");
		}
		void OnColumnDividerWidthChangedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnDividerWidthChangedHandler");
		}
		void OnColumnHeaderMouseClickHandler(object sender, DataGridViewCellMouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnHeaderMouseClickHandler");
		}
		void OnColumnHeaderMouseDoubleClickHandler(object sender, DataGridViewCellMouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnHeaderMouseDoubleClickHandler");
		}
		void OnColumnHeaderCellChangedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnHeaderCellChangedHandler");
		}
		void OnColumnMinimumWidthChangedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnMinimumWidthChangedHandler");
		}
		void OnColumnNameChangedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnNameChangedHandler");
		}
		void OnColumnRemovedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnRemovedHandler");
		}
		void OnColumnSortModeChangedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnSortModeChangedHandler");
		}
		void OnColumnStateChangedHandler(object sender, DataGridViewColumnStateChangedEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnStateChangedHandler");
		}
		void OnColumnToolTipTextChangedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnToolTipTextChangedHandler");
		}
		void OnColumnWidthChangedHandler(object sender, DataGridViewColumnEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnColumnWidthChangedHandler");
		}
		void OnCurrentCellChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCurrentCellChangedHandler");
		}
		void OnCurrentCellDirtyStateChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCurrentCellDirtyStateChangedHandler");
		}
		void OnDataBindingCompleteHandler(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDataBindingCompleteHandler");
		}
		void OnDataErrorHandler(object sender, DataGridViewDataErrorEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDataErrorHandler");
		}
		void OnDefaultValuesNeededHandler(object sender, DataGridViewRowEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDefaultValuesNeededHandler");
		}
		void OnEditingControlShowingHandler(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnEditingControlShowingHandler");
		}
		void OnNewRowNeededHandler(object sender, DataGridViewRowEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnNewRowNeededHandler");
		}
		void OnRowContextMenuStripChangedHandler(object sender, DataGridViewRowEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowContextMenuStripChangedHandler");
		}
		void OnRowContextMenuStripNeededHandler(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowContextMenuStripNeededHandler");
		}
		void OnRowDefaultCellStyleChangedHandler(object sender, DataGridViewRowEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowDefaultCellStyleChangedHandler");
		}
		void OnRowDirtyStateNeededHandler(object sender, QuestionEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowDirtyStateNeededHandler");
		}
		void OnRowDividerDoubleClickHandler(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowDividerDoubleClickHandler");
		}
		void OnRowDividerHeightChangedHandler(object sender, DataGridViewRowEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowDividerHeightChangedHandler");
		}
		void OnRowEnterHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowEnterHandler");
		}
		void OnRowErrorTextChangedHandler(object sender, DataGridViewRowEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowErrorTextChangedHandler");
		}
		void OnRowErrorTextNeededHandler(object sender, DataGridViewRowErrorTextNeededEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowErrorTextNeededHandler");
		}
		void OnRowHeaderMouseClickHandler(object sender, DataGridViewCellMouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowHeaderMouseClickHandler");
		}
		void OnRowHeaderMouseDoubleClickHandler(object sender, DataGridViewCellMouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowHeaderMouseDoubleClickHandler");
		}
		void OnRowHeaderCellChangedHandler(object sender, DataGridViewRowEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowHeaderCellChangedHandler");
		}
		void OnRowHeightChangedHandler(object sender, DataGridViewRowEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowHeightChangedHandler");
		}
		void OnRowHeightInfoNeededHandler(object sender, DataGridViewRowHeightInfoNeededEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowHeightInfoNeededHandler");
		}
		void OnRowHeightInfoPushedHandler(object sender, DataGridViewRowHeightInfoPushedEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowHeightInfoPushedHandler");
		}
		void OnRowLeaveHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowLeaveHandler");
		}
		void OnRowMinimumHeightChangedHandler(object sender, DataGridViewRowEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowMinimumHeightChangedHandler");
		}
		void OnRowPostPaintHandler(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowPostPaintHandler");
		}
		void OnRowPrePaintHandler(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowPrePaintHandler");
		}
		void OnRowsAddedHandler(object sender, DataGridViewRowsAddedEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowsAddedHandler");
		}
		void OnRowsRemovedHandler(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowsRemovedHandler");
		}
		void OnRowStateChangedHandler(object sender, DataGridViewRowStateChangedEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowStateChangedHandler");
		}
		void OnRowUnsharedHandler(object sender, DataGridViewRowEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowUnsharedHandler");
		}
		void OnRowValidatedHandler(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowValidatedHandler");
		}
		void OnRowValidatingHandler(object sender, DataGridViewCellCancelEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRowValidatingHandler");
		}
		void OnScrollHandler(object sender, ScrollEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnScrollHandler");
		}
		void OnSelectionChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnSelectionChangedHandler");
		}
		void OnSortCompareHandler(object sender, DataGridViewSortCompareEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnSortCompareHandler");
		}
		void OnSortedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnSortedHandler");
		}
		void OnStyleChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnStyleChangedHandler");
		}
		void OnUserAddedRowHandler(object sender, DataGridViewRowEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnUserAddedRowHandler");
		}
		void OnUserDeletedRowHandler(object sender, DataGridViewRowEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnUserDeletedRowHandler");
		}
		void OnUserDeletingRowHandler(object sender, DataGridViewRowCancelEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnUserDeletingRowHandler");
		}
		void OnAutoSizeChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnAutoSizeChangedHandler");
		}
		void OnBindingContextChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnBindingContextChangedHandler");
		}
		void OnCausesValidationChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCausesValidationChangedHandler");
		}
		void OnClientSizeChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnClientSizeChangedHandler");
		}
		void OnContextMenuChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnContextMenuChangedHandler");
		}
		void OnContextMenuStripChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnContextMenuStripChangedHandler");
		}
		void OnCursorChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnCursorChangedHandler");
		}
		void OnDockChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDockChangedHandler");
		}
		void OnEnabledChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnEnabledChangedHandler");
		}
		void OnLocationChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnLocationChangedHandler");
		}
		void OnMarginChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnMarginChangedHandler");
		}
		void OnRegionChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRegionChangedHandler");
		}
		void OnRightToLeftChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnRightToLeftChangedHandler");
		}
		void OnSizeChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnSizeChangedHandler");
		}
		void OnTabIndexChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnTabIndexChangedHandler");
		}
		void OnTabStopChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnTabStopChangedHandler");
		}
		void OnVisibleChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnVisibleChangedHandler");
		}
		void OnClickHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnClickHandler");
		}
		void OnControlAddedHandler(object sender, ControlEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnControlAddedHandler");
		}
		void OnControlRemovedHandler(object sender, ControlEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnControlRemovedHandler");
		}
		void OnDragDropHandler(object sender, DragEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDragDropHandler");
		}
		void OnDragEnterHandler(object sender, DragEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDragEnterHandler");
		}
		void OnDragOverHandler(object sender, DragEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDragOverHandler");
		}
		void OnDragLeaveHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDragLeaveHandler");
		}
		void OnGiveFeedbackHandler(object sender, GiveFeedbackEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnGiveFeedbackHandler");
		}
		void OnHandleCreatedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnHandleCreatedHandler");
		}
		void OnHandleDestroyedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnHandleDestroyedHandler");
		}
		void OnHelpRequestedHandler(object sender, HelpEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnHelpRequestedHandler");
		}
		void OnInvalidatedHandler(object sender, InvalidateEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnInvalidatedHandler");
		}
		void OnPaintHandler(object sender, PaintEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnPaintHandler");
		}
		void OnQueryContinueDragHandler(object sender, QueryContinueDragEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnQueryContinueDragHandler");
		}
		void OnQueryAccessibilityHelpHandler(object sender, QueryAccessibilityHelpEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnQueryAccessibilityHelpHandler");
		}
		void OnDoubleClickHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDoubleClickHandler");
		}
		void OnEnterHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnEnterHandler");
		}
		void OnGotFocusHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnGotFocusHandler");
		}
		void OnKeyDownHandler(object sender, KeyEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnKeyDownHandler");
		}
		void OnKeyPressHandler(object sender, KeyPressEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnKeyPressHandler");
		}
		void OnKeyUpHandler(object sender, KeyEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnKeyUpHandler");
		}
		void OnLayoutHandler(object sender, LayoutEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnLayoutHandler");
		}
		void OnLeaveHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnLeaveHandler");
		}
		void OnLostFocusHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnLostFocusHandler");
		}
		void OnMouseClickHandler(object sender, MouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnMouseClickHandler");
		}
		void OnMouseDoubleClickHandler(object sender, MouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnMouseDoubleClickHandler");
		}
		void OnMouseCaptureChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnMouseCaptureChangedHandler");
		}
		void OnMouseDownHandler(object sender, MouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnMouseDownHandler");
		}
		void OnMouseEnterHandler(object sender, EventArgs e)
		{
			//Debug.WriteLine(DateTime.Now + "OnMouseEnterHandler");
		}
		void OnMouseLeaveHandler(object sender, EventArgs e)
		{
			//Debug.WriteLine(DateTime.Now + "OnMouseLeaveHandler");
		}
		void OnMouseHoverHandler(object sender, EventArgs e)
		{
			//Debug.WriteLine(DateTime.Now + "OnMouseHoverHandler");
		}
		void OnMouseMoveHandler(object sender, MouseEventArgs e)
		{
			//Debug.WriteLine(DateTime.Now + "OnMouseMoveHandler");
		}
		void OnMouseUpHandler(object sender, MouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnMouseUpHandler");
		}
		void OnMouseWheelHandler(object sender, MouseEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnMouseWheelHandler");
		}
		void OnMoveHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnMoveHandler");
		}
		void OnPreviewKeyDownHandler(object sender, PreviewKeyDownEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnPreviewKeyDownHandler");
		}
		void OnResizeHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnResizeHandler");
		}
		void OnChangeUICuesHandler(object sender, UICuesEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnChangeUICuesHandler");
		}
		void OnSystemColorsChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnSystemColorsChangedHandler");
		}
		void OnValidatingHandler(object sender, CancelEventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnValidatingHandler");
		}
		void OnValidatedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnValidatedHandler");
		}
		void OnParentChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnParentChangedHandler");
		}
		void OnImeModeChangedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnImeModeChangedHandler");
		}
		void OnDisposedHandler(object sender, EventArgs e)
		{
			Debug.WriteLine(DateTime.Now + "OnDisposedHandler");
		}
		#endregion
	}

}
