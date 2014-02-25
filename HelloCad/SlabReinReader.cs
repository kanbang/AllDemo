using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Geometry;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace HelloCad
{
	public class SlabReinReader
	{
		[CommandMethod("GetReinForSlabFromLayer")]
		public static void GetReinForSlabFromLayer()
		{
			Database db = HostApplicationServices.WorkingDatabase;
			List<DBText> dbTextList = new List<DBText>();
			Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			List<Polyline> reins = GetAllRein(db, ed);
			PromptPointResult pointResult = ed.GetPoint("指定插入点");
			StringBuilder builder = new StringBuilder();

			if (pointResult.Status == PromptStatus.OK) {
				builder.AppendLine(pointResult.Value.ToString());
			}
			object acad = Autodesk.AutoCAD.ApplicationServices.Application.AcadApplication;
			acad.GetType().InvokeMember("ZoomExtents", BindingFlags.InvokeMethod, null, acad, null);
			FillReinInfos(db, ed, reins, builder);

			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "文本文件|*.txt";
			saveFileDialog.RestoreDirectory = true;
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				string fName = saveFileDialog.FileName;

				File.WriteAllText(fName, builder.ToString());
			}
		}

		private static void FillReinInfos(Database db, Editor ed, List<Polyline> reins, StringBuilder builder)
		{
			foreach (Polyline item in reins) {
				List<Point3d> points = new List<Point3d>();

				if (item.NumberOfVertices == 4) {
					points.Add(item.GetPoint3dAt(0));
					points.Add(item.GetPoint3dAt(1));
					points.Add(item.GetPoint3dAt(2));
					points.Add(item.GetPoint3dAt(3));

				} else {
					continue;
				}
				List<string> reinInfos = GetReinInfos(db, ed, points);
				string reinInfo = string.Format("{0};{1}", points[1].ToString(), points[2].ToString());
				foreach (var dbtxt in reinInfos) {
					reinInfo = string.Format("{0};{1}", reinInfo, dbtxt);
				}
				builder.AppendLine(reinInfo);
			}
		}

		private static List<string> GetReinInfos(Database db, Editor ed, List<Point3d> points)
		{
			List<string> reinInfos = new List<string>();

			Vector3d vector = points[2] - points[3];
			Point3d endPoint = points[2] + vector;
			Point3d startPoint = points[0] - vector;
			double minX = startPoint.X;
			double minY = startPoint.Y;
			double maxX = endPoint.X;
			double maxY = endPoint.Y;
			if (startPoint.X > endPoint.X) {
				minX = endPoint.X;
				maxX = startPoint.X;
			}
			if (startPoint.Y > endPoint.Y) {
				minY = endPoint.Y;
				maxY = startPoint.Y;
			}

			PromptSelectionResult result = ed.SelectCrossingWindow(startPoint, endPoint);
			if (result.Status == PromptStatus.OK) {
				SelectionSet sst = result.Value;
				using (Transaction trans = db.TransactionManager.StartTransaction()) {
					ObjectId[] oids = sst.GetObjectIds();
					vector = points[2] - points[1];
					BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
					BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead) as BlockTableRecord;
					DBText reinInfo = null;
					double distance = -1;
					FillReinInfos(points, reinInfos, vector, trans, oids, ref reinInfo, ref distance);
					if (reinInfo != null) {
						reinInfos.Add(reinInfo.TextString);
					} else {
						reinInfos.Add(string.Empty);
					}
				}
			}
			return reinInfos;
		}

		private static void FillReinInfos(List<Point3d> points, List<string> reinInfos, Vector3d vector, Transaction trans, ObjectId[] oids, ref DBText reinInfo, ref double distance)
		{
			double left = 0;
			double right = 0;
			DBText leftText = null;
			DBText rightText = null;
			for (int i = 0; i < oids.Length; i++) {
				Entity ent = (Entity)trans.GetObject(oids[i], OpenMode.ForRead);
				double value = 0;
				if (ent is DBText) {
					DBText txt = (DBText)ent;
					int dia = 0;
					string textString = txt.TextString;
					if ((textString.Contains("@") && ((textString.StartsWith("%") || int.TryParse(textString.Substring(1, 1), out dia))))) {
						SetReinInfo(points, ref reinInfo, ref distance, txt);
					} else if (double.TryParse(textString, out value)) {
						SetLeftOrRightDim(ref vector, ref leftText, ref rightText, txt);
					}
				}
			}
			if (leftText != null && rightText != null) {
				if ((leftText.Position.X < rightText.Position.X) || (leftText.Position.Y < rightText.Position.Y)) {
					double.TryParse(leftText.TextString, out left);
					double.TryParse(rightText.TextString, out right);

				} else {
					double.TryParse(leftText.TextString, out right);
					double.TryParse(rightText.TextString, out left);

				}
			} else if (leftText != null) {
				double.TryParse(leftText.TextString, out left);
				//if (left * 2 <= (points[1] - points[2]).Length) {
				//    right = left;
				//}
				Extents3d extents = leftText.GeometricExtents;
				Point3d center = new Point3d((extents.MinPoint.X + extents.MaxPoint.X) / 2, (extents.MinPoint.Y + extents.MaxPoint.Y)/2, 0);
				Vector3d vecLeft = center - points[1];
				Vector3d vecRight = center - points[2];
				if (vecLeft.Length > vecRight.Length ||(points[1].X > points[2].X) || (points[1].Y > points[2].Y)) {
					right = left;
					left = 0;
				}
			}
			reinInfos.Add(left.ToString());
			reinInfos.Add(right.ToString());
		}

		private static void SetLeftOrRightDim(ref Vector3d vector, ref DBText leftText, ref DBText rightText, DBText txt)
		{
			double angle = Math.Abs(vector.GetAngleTo(new Vector3d(1, 0, 0)) - txt.Rotation);
			if (angle < 0.01 || Math.Abs(angle - Math.PI) < 0.01 || Math.Abs(angle - Math.PI * 2) < 0.01) {
				if (leftText == null) {
					leftText = txt;
				} else {
					rightText = txt;
				}

			}
		}

		private static void SetReinInfo(List<Point3d> points, ref DBText reinInfo, ref double distance, DBText txt)
		{
			if (reinInfo == null) {
				reinInfo = txt;
			} else {
				if (distance == -1) {
					distance = (GetPedal(reinInfo.Position, points[1], points[2]) - reinInfo.Position).LengthSqrd;
				}
				double distance2 = (GetPedal(txt.Position, points[1], points[2]) - txt.Position).LengthSqrd;
				if (distance2 < distance) {
					distance = distance2;
					reinInfo = txt;
				}
			}
		}

		private static List<Polyline> GetAllRein(Database db, Editor ed)
		{
			List<Polyline> allRein = new List<Polyline>();

			PromptEntityResult entityResult = ed.GetEntity("选择一个钢筋");
			if (entityResult.Status != PromptStatus.OK) {
				return allRein;
			}
			ObjectId selectedID = entityResult.ObjectId;

			using (Transaction trans = db.TransactionManager.StartTransaction()) {
				LayerTable lt = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
				Entity selectedEnt = (Entity)trans.GetObject(selectedID, OpenMode.ForRead);
				if (selectedEnt == null) {
					return allRein;
				}
				ObjectId[] oids = GetObjectIdsAtLayer(selectedEnt.Layer);
				if (oids == null) {
					return allRein;
				}
				for (int i = 0; i < oids.Length; i++) {
					Entity ent = (Entity)trans.GetObject(oids[i], OpenMode.ForRead);
					if (ent is Polyline) {
						allRein.Add((Polyline)ent);
					}
				}
			}
			return allRein;
		}

		/// <summary>
		/// 取得图层下的所有对象id
		/// </summary>
		/// <param name="name">图层名称</param>
		/// <returns>id集合</returns>
		public static ObjectId[] GetObjectIdsAtLayer(string name)
		{
			ObjectIdCollection ids = new ObjectIdCollection();

			PromptSelectionResult ProSset = null;
			TypedValue[] filList = new TypedValue[1] { new TypedValue((int)DxfCode.LayerName, name) };
			SelectionFilter sfilter = new SelectionFilter(filList);
			Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ProSset = ed.SelectAll(sfilter);
			if (ProSset.Status == PromptStatus.OK) {

				SelectionSet sst = ProSset.Value;

				return sst.GetObjectIds();

			}

			return null;
		}
		public static Point3d GetPedal(Point3d point, Point3d startPoint, Point3d endPoint)
		{
			double a, b, c, A, B, C;
			a = endPoint.X - startPoint.X;
			b = endPoint.Y - startPoint.Y;
			c = endPoint.Z - startPoint.Z;

			A = a * point.X + b * point.Y + c * point.Z;
			B = b * startPoint.X - a * startPoint.Y;
			C = c * startPoint.X - a * startPoint.Z;
			double x, y, z;
			if (Math.Abs(a) > 1e-3) {
				x = (A * a + B * b + C * c) / (a * a + b * b + c * c);
				y = (b * x - B) / a;
				z = (c * x - C) / a;
			} else {
				double D, temp;
				D = c * startPoint.Y - b * startPoint.Z;
				temp = b * b + c * c;
				x = (A * b + D * c) / temp;
				y = (A * c - D * b) / temp;
				z = (B + a * y) / b;
			}

			return new Point3d(x, y, z);
		}

	}
}
