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


		}

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
	}

}
