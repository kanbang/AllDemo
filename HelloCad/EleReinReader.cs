﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using Acad = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using HelloCad.Model;

namespace HelloCad
{
	public class EleReinReader
	{
		[CommandMethod("ReadGGJTxt")]
		public static void ReadGGJTxt()
		{

			OpenFileDialog file = new OpenFileDialog();
			if (file.ShowDialog() != DialogResult.OK) {
				return;
			}
			string[] allContent = File.ReadAllLines(file.FileName);
			Dictionary<string, List<EleReinDataModel>> list = new Dictionary<string, List<EleReinDataModel>>();
			foreach (var item in allContent) {
				string[] detail = item.Replace(" ", "").Split(';');
				EleReinDataModel model = new EleReinDataModel();
				model.Type = detail[0];
				model.Name = detail[2];
				model.ColorIndex = Convert.ToInt32(model.Type.Split(':')[1]);
				if (model.ColorIndex == 4 || model.ColorIndex == 7) {
					model.Polyline = GetPolyline(detail[6], detail[7], detail[8], detail[9]);
					model.DbText = GetDBText(detail[3], detail[4], detail[5], detail[6]);

				} else {
					model.Polyline = GetPolyline(detail[3], detail[4], detail[5], detail[6]);
				}
				if (!list.ContainsKey(model.Type)) {
					list[model.Type] = new List<EleReinDataModel>();
				}
				list[model.Type].Add(model);
			}

			Dictionary<string, LayerTable> layers = new Dictionary<string, LayerTable>();
			// Get the current document and database获取当前文档和数据库
			Document acDoc = Acad.Application.DocumentManager.MdiActiveDocument;
			Database acCurDb = acDoc.Database;
			// Start a transaction启动事务
			using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction()) {
				foreach (var item in list) {
					// Open the Layer table for read以读打开图层表
					LayerTable acLyrTbl;
					acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId, OpenMode.ForRead) as LayerTable;
					string sLayerName = item.Key;
					if (acLyrTbl.Has(sLayerName) == false) {
						LayerTableRecord acLyrTblRec = new LayerTableRecord();
						acLyrTblRec.Color = Color.FromColorIndex(ColorMethod.ByAci, (short)item.Value[0].ColorIndex);
						acLyrTblRec.Name = sLayerName;
						// Upgrade the Layer table for write以写升级打开图层表
						acLyrTbl.UpgradeOpen();
						// Append the new layer to the Layer table and the transaction
						// 将新图层添加到图层表，并进行事务登记
						acLyrTbl.Add(acLyrTblRec);
						acTrans.AddNewlyCreatedDBObject(acLyrTblRec, true);
					}
					// Open the Block table for read以读打开块表
					BlockTable acBlkTbl;
					acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;
					// Open the Block table record Model space for write以写打开块表记录模型空间
					BlockTableRecord acBlkTblRec;
					acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
					foreach (var model in item.Value) {
						model.Polyline.Layer = sLayerName;
						acBlkTblRec.AppendEntity(model.Polyline);
						acTrans.AddNewlyCreatedDBObject(model.Polyline, true);

						if (model.DbText != null) {
							model.DbText.Layer = sLayerName;
							acBlkTblRec.AppendEntity(model.DbText);
							acTrans.AddNewlyCreatedDBObject(model.DbText, true);

						}
					}
				}

				// Save the changes and dispose of the transaction保存修改并关闭事务
				acTrans.Commit();
			}

		}

		private static DBText GetDBText(string p, string p_2, string p_3, string p_4)
		{
			string txt = string.Format("{0};{1};{2}", p.Remove(0, 5), p_2.Remove(0, 5), p_3.Remove(0, 5));
			Point2d point = GetPoint2d(p_4);
			DBText dbText = new DBText();
			dbText.TextString = txt;
			dbText.Position = new Point3d(point.X, point.Y, 0);
			return dbText;
		}

		private static Polyline GetPolyline(string p, string p_2, string p_3, string p_4)
		{
			Polyline polyline = new Polyline();
			polyline.AddVertexAt(0, GetPoint2d(p), 0, 0, 0);
			polyline.AddVertexAt(1, GetPoint2d(p_2), 0, 0, 0);
			polyline.AddVertexAt(2, GetPoint2d(p_3), 0, 0, 0);
			polyline.AddVertexAt(3, GetPoint2d(p_4), 0, 0, 0);

			return polyline;
		}

		private static Point2d GetPoint2d(string p)
		{
			string[] values = p.Split(',');
			return new Point2d(Convert.ToDouble(values[0].Replace("(", "")), Convert.ToDouble(values[1]));
		}

	}
}
