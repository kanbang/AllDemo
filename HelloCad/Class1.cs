using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System.IO;
using System.Windows.Media;

namespace ClassLibrary1
{
	public class Class1
	{
		[CommandMethod("HelloWorld")]
		public void HelloWorld()
		{
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
			ed.WriteMessage("Hello World 测试");
		}

		[CommandMethod("ReadAllModel")]
		public void ReadAllModel()
		{
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
		}

		[CommandMethod("GetLayerPro")]
		public static void GetLayerPro()
		{
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
			//得到当前文档图形数据库        
			Database db = HostApplicationServices.WorkingDatabase;
			using (Transaction trans = db.TransactionManager.StartTransaction()) {
				//获取数据库的图层表对象                
				LayerTable lt = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
				//循环遍历每个图层                 
				foreach (ObjectId layerId in lt) {
					LayerTableRecord ltr = (LayerTableRecord)trans.GetObject(layerId, OpenMode.ForRead);
					if (ltr != null) {
						Autodesk.AutoCAD.Colors.Color layerColor = ltr.Color;
						ed.WriteMessage("\n图层名称为：" + ltr.Name);

						ed.WriteMessage("\n图层颜色为：" + layerColor.ToString());
					}
				}
				trans.Commit();
			}
		}


		[CommandMethod("GetEntitiesFromLayer")]
		public static void GetEntitiesFromLayer()
		{
			Database db = HostApplicationServices.WorkingDatabase;
			List<DBText> dbTextList = new List<DBText>();
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
			using (Transaction trans = db.TransactionManager.StartTransaction()) {
				LayerTable lt = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
				Dictionary<int, Dictionary<int, List<DBText>>> allText = new Dictionary<int, Dictionary<int, List<DBText>>>();
				Dictionary<int, Dictionary<int, List<Circle>>> allCircle = new Dictionary<int, Dictionary<int, List<Circle>>>();
				BlockTableRecord ltr = (BlockTableRecord)trans.GetObject(db.CurrentSpaceId, OpenMode.ForRead);
				foreach (ObjectId objId in ltr) {
					Entity ent = (Entity)trans.GetObject(objId, OpenMode.ForRead);
					if (ent.GetType().Name == "DBText") {
						AddText(allText, ent);
					} else if (ent.GetType().Name == "Circle") {
						AddCircle(allCircle, ent);
					}
				}
				StringBuilder builder = new StringBuilder();

				BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
				BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
				foreach (var x in allText) {
					foreach (var y in x.Value) {
						foreach (var text in y.Value) {
							var circle = GetClosestCircle(allCircle, x.Key, y.Key, text, trans, btr);
							if (circle != null) {
								builder.AppendLine(string.Format("文字：{0}", text.TextString));
								builder.AppendLine(string.Format("圆点:{0},{1},FaceStyleId:{2}", circle.Center.X, circle.Center.Y, circle.FaceStyleId));
								var newText = new DBText();
								newText.Position = circle.Center;
								newText.TextString = text.TextString;
								newText.Height = text.Height;
								dbTextList.Add(newText);
								btr.AppendEntity(newText);
								try {
									trans.AddNewlyCreatedDBObject(newText, true);

								} catch (System.Exception ex) {
									throw ex;
								}
							} else {
								builder.AppendLine(string.Format("文字：{0}", text.TextString));
								builder.AppendLine("圆点:没有啊");
							}
						}
					}
				}
				string path = @"C:\acadacad.text";
				if (File.Exists(path)) {
					File.Delete(path);
				}
				StreamWriter rw = File.CreateText(path);
				rw.WriteLine(builder.ToString());
				rw.Flush();
				rw.Close();
				ed.WriteMessage("搞定 收工");
				trans.Commit();
			}
		}

		[CommandMethod("GetReinForSlabFromLayer")]
		public static void GetReinForSlabFromLayer()
		{
			Database db = HostApplicationServices.WorkingDatabase;
			List<DBText> dbTextList = new List<DBText>();
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

			PromptEntityResult entityResult = ed.GetEntity("选择一个钢筋");
			if (entityResult.Status != PromptStatus.OK) {
				return;
			}
			ObjectId selectedID = entityResult.ObjectId;

			using (Transaction trans = db.TransactionManager.StartTransaction()) {
				LayerTable lt = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
				Entity selectedEnt = (Entity)trans.GetObject(selectedID, OpenMode.ForRead);
				if (selectedEnt == null) {
					return;
				}
				ObjectId[] oids = GetObjectIdsAtLayer(selectedEnt.Layer);
				if (oids == null) {
					return;
				}
				List<Polyline> allRein = new List<Polyline>();
				for (int i = 0; i < oids.Length; i++) {
					Entity ent = (Entity)trans.GetObject(oids[i], OpenMode.ForRead);
					if (ent.GetType().Name == "Polyline") {
						allRein.Add((Polyline)ent);
					}
				}

				//StringBuilder builder = new StringBuilder();

				//BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
				//BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
				//foreach (var x in allText) {
				//    foreach (var y in x.Value) {
				//        foreach (var text in y.Value) {
				//            var circle = GetClosestCircle(allCircle, x.Key, y.Key, text, trans, btr);
				//            if (circle != null) {
				//                builder.AppendLine(string.Format("文字：{0}", text.TextString));
				//                builder.AppendLine(string.Format("圆点:{0},{1},FaceStyleId:{2}", circle.Center.X, circle.Center.Y, circle.FaceStyleId));
				//                var newText = new DBText();
				//                newText.Position = circle.Center;
				//                newText.TextString = text.TextString;
				//                newText.Height = text.Height;
				//                dbTextList.Add(newText);
				//                btr.AppendEntity(newText);
				//                try {
				//                    trans.AddNewlyCreatedDBObject(newText, true);

				//                } catch (System.Exception ex) {
				//                    throw ex;
				//                }
				//            } else {
				//                builder.AppendLine(string.Format("文字：{0}", text.TextString));
				//                builder.AppendLine("圆点:没有啊");
				//            }
				//        }
				//    }
				//}
				//string path = @"C:\acadacad.text";
				//if (File.Exists(path)) {
				//    File.Delete(path);
				//}
				//StreamWriter rw = File.CreateText(path);
				//rw.WriteLine(builder.ToString());
				//rw.Flush();
				//rw.Close();
				ed.WriteMessage("搞定 收工");
				trans.Commit();
			}
		}

		#region "取得图层下的所有对象id"
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

		private static void AddCircle(Dictionary<int, Dictionary<int, List<Circle>>> allCircle, Entity ent)
		{
			var circle = (Circle)ent;
			var x = (int)circle.Center.X / 400;
			var y = (int)circle.Center.Y / 1000;
			if (!allCircle.ContainsKey(x)) {
				allCircle[x] = new Dictionary<int, List<Circle>>();
			}
			if (!allCircle[x].ContainsKey(y)) {
				allCircle[x][y] = new List<Circle>();
			}

			allCircle[x][y].Add(circle);
		}

		private static void AddText(Dictionary<int, Dictionary<int, List<DBText>>> allText, Entity ent)
		{
			var text = (DBText)ent;
			var x = (int)text.Position.X / 400;
			var y = (int)text.Position.Y / 10000;
			if (!allText.ContainsKey(x)) {
				allText[x] = new Dictionary<int, List<DBText>>();
			}
			if (!allText[x].ContainsKey(y)) {
				allText[x][y] = new List<DBText>();
			}
			allText[x][y].Add(text);
		}

		private static Circle GetClosestCircle(Dictionary<int, Dictionary<int, List<Circle>>> allCircle, int xValue, int yValue, DBText text, Transaction trans, BlockTableRecord btr)
		{
			var distinctdistict = double.MaxValue;
			Circle circle = null;
			if (allCircle.ContainsKey(xValue)) {
				if (allCircle[xValue].ContainsKey(yValue)) {
					SetCircle(allCircle, xValue, yValue, text, ref distinctdistict, ref circle, trans, btr);
				}
				if (allCircle[xValue].ContainsKey(yValue - 1)) {
					SetCircle(allCircle, xValue, yValue - 1, text, ref distinctdistict, ref circle, trans, btr);
				}
				if (allCircle[xValue].ContainsKey(yValue + 1)) {
					SetCircle(allCircle, xValue, yValue + 1, text, ref distinctdistict, ref circle, trans, btr);
				}
			}
			if (allCircle.ContainsKey(xValue - 1)) {
				if (allCircle[xValue - 1].ContainsKey(yValue)) {
					SetCircle(allCircle, xValue - 1, yValue, text, ref distinctdistict, ref circle, trans, btr);
				}
				if (allCircle[xValue - 1].ContainsKey(yValue - 1)) {
					SetCircle(allCircle, xValue - 1, yValue - 1, text, ref distinctdistict, ref circle, trans, btr);
				}
				if (allCircle[xValue - 1].ContainsKey(yValue + 1)) {
					SetCircle(allCircle, xValue - 1, yValue + 1, text, ref distinctdistict, ref circle, trans, btr);
				}

			}
			if (allCircle.ContainsKey(xValue + 1)) {
				if (allCircle[xValue + 1].ContainsKey(yValue)) {
					SetCircle(allCircle, xValue + 1, yValue, text, ref distinctdistict, ref circle, trans, btr);
				}
				if (allCircle[xValue + 1].ContainsKey(yValue - 1)) {
					SetCircle(allCircle, xValue + 1, yValue - 1, text, ref distinctdistict, ref circle, trans, btr);
				}
				if (allCircle[xValue + 1].ContainsKey(yValue + 1)) {
					SetCircle(allCircle, xValue + 1, yValue + 1, text, ref distinctdistict, ref circle, trans, btr);
				}
			}
			return circle;
		}

		private static void SetCircle(Dictionary<int, Dictionary<int, List<Circle>>> allCircle, int xValue, int yValue, DBText text, ref double distinct, ref Circle circle, Transaction trans, BlockTableRecord btr)
		{
			var circles = allCircle[xValue][yValue];
			foreach (var item in circles) {
				//var newText = new DBText();
				//newText.Position = item.Center;
				//newText.TextString = text.TextString;
				//newText.Height = text.Height;

				//btr.AppendEntity(newText);
				//try {
				//    trans.AddNewlyCreatedDBObject(newText, true);

				//} catch (System.Exception ex) {
				//    throw ex;
				//}
				var length = GetDistinct(text.Position, item.Center);
				if (length < distinct) {
					distinct = length;
					circle = item;
				}
			}

		}

		private static double GetDistinct(Point3d start, Point3d end)
		{
			return Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2);
		}

		[CommandMethod("Addselectchang")]
		public void AddDocEvent()
		{
			Document acDoc = Application.DocumentManager.MdiActiveDocument;
			acDoc.ImpliedSelectionChanged += new EventHandler(doc_ImpliedSelectionChanged);
		}

		[CommandMethod("Removeselectchang")]
		public void RemoveDocEvent()
		{
			// Get the current document
			Document acDoc = Application.DocumentManager.MdiActiveDocument;
			acDoc.ImpliedSelectionChanged -= new EventHandler(doc_ImpliedSelectionChanged);
		}


		public void doc_ImpliedSelectionChanged(object sender, EventArgs e)
		{
			var ed = Application.DocumentManager.MdiActiveDocument.Editor;

			PromptSelectionResult pkf = ed.SelectImplied();
			if (pkf.Status != PromptStatus.OK) {
				return;
			}

			ObjectId[] objIds = pkf.Value.GetObjectIds();
			String oids = "";

			foreach (ObjectId objId in objIds) {
				oids += "\n " + objId.ToString();
			}

		}

		[CommandMethod("SetAllText")]
		public static void SetAllText()
		{
			Database db = HostApplicationServices.WorkingDatabase;
			List<DBText> dbTextList = new List<DBText>();
			Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
			using (Transaction trans = db.TransactionManager.StartTransaction()) {
				LayerTable lt = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
				List<DBText> allText = new List<DBText>();
				List<Circle> allCircle = new List<Circle>();
				BlockTableRecord ltr = (BlockTableRecord)trans.GetObject(db.CurrentSpaceId, OpenMode.ForRead);
				foreach (ObjectId objId in ltr) {
					Entity ent = (Entity)trans.GetObject(objId, OpenMode.ForRead);
					if (ent.GetType().Name == "DBText") {
						var text = (DBText)ent;
						if (text.TextString.Contains("A") || text.TextString.Contains("B") || text.TextString.Contains("C") || text.TextString.Contains("K") || text.TextString.Contains("L") || text.TextString.Contains("P") || text.TextString.Contains("T")) {
							allText.Add(text);
						}
					} else if (ent.GetType().Name == "Circle") {
						allCircle.Add((Circle)ent);
					}
				}
				StringBuilder builder = new StringBuilder();

				BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
				BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

				foreach (var text in allText) {
					Circle circle = GetClosedCircle(allCircle, text);
					if (circle != null) {
						int lineCount = 0;
						int polylineCount = 0;
						int circleCount = 0;
						int hatchCount = 0;
						int arcCount = 0;
						string textString = "";
						var selectionResult = ed.SelectWindow(circle.GeometricExtents.MinPoint, circle.GeometricExtents.MaxPoint).Value;
						if (selectionResult != null) {
							var ids = selectionResult.GetObjectIds();
							foreach (var id in ids) {
								var entity = trans.GetObject(id, OpenMode.ForWrite);
								if (entity.GetType().Name == "Line") {
									lineCount++;
								} else if (entity.GetType().Name == "Circle") {
									circleCount++;
								} else if (entity.GetType().Name == "DBText") {
									var dbText = (DBText)entity;
									textString += "," + dbText.TextString;
								} else if (entity.GetType().Name == "Hatch") {
									hatchCount++;
								} else if (entity.GetType().Name == "Polyline") {
									polylineCount++;
								} else if (entity.GetType().Name == "Arc") {
									arcCount++;
								} else {
									var name = entity.GetType().Name;
								}

							}
						}
						var type = "无图例";
						if (lineCount == 8 && circleCount == 4) {
							type = "地下室抗拔桩";
						} else if (circleCount == 10 && hatchCount == 5) {
							type = "地下室柱下桩";
						} else if (circleCount == 7 && hatchCount == 7) {
							type = "抗拔桩试桩TP2";
						} else if (lineCount == 49 && circleCount == 7) {
							type = "抗拔桩反力桩AP2";
						} else if (circleCount == 1 && hatchCount == 1) {
							type = "A型桩试桩TP1";
						} else if (circleCount == 1 && hatchCount == 4) {
							type = "主楼抗压桩B型";
						}
						builder.AppendLine(string.Format("{0},{1},{2},{3}", text.TextString, circle.Center.X / 304.8, circle.Center.Y / 304.8, type));
						//builder.AppendLine(string.Format("lineCount:{0},circleCount:{1},hatchCount:{2},textString:{3},polylineCount:{4},arcCount:{5}", lineCount, circleCount, hatchCount, textString, polylineCount, arcCount));

						//var newText = new DBText();
						//newText.Position = circle.Center;
						//newText.TextString = text.TextString;
						//newText.Height = text.Height;
						//dbTextList.Add(newText);
						//btr.AppendEntity(newText);
						//try {
						//    trans.AddNewlyCreatedDBObject(newText, true);

						//} catch (System.Exception ex) {
						//    throw ex;
						//}
					} else {
						builder.AppendLine(string.Format("文字：{0}", text.TextString));
						builder.AppendLine("圆点:没有啊");
					}
				}
				string path = @"C:\acadacad.text";
				if (File.Exists(path)) {
					File.Delete(path);
				}
				StreamWriter rw = File.CreateText(path);
				rw.WriteLine(builder.ToString());
				rw.Flush();
				rw.Close();
				ed.WriteMessage("搞定 收工");
				trans.Commit();
			}
		}

		private static Circle GetClosedCircle(List<Circle> allCircle, DBText text)
		{
			var distinct = double.MaxValue;
			Circle circle = null;
			foreach (var item in allCircle) {
				var length = GetDistinct(text.Position, item.Center);
				if (length < distinct) {
					circle = item;
					distinct = length;
				}
			}
			return circle;
		}

		//#region 提取一个图层上的各类元素
		//[CommandMethod("BlockInLayerCAD")]
		//public void BlockInLayerCAD ()
		//{
		//    //PromptStringOptions pStringOption = new PromptStringOptions("\n 输入一个图层名");
		//    //PromptResult layerName = pDocument.Editor.GetString(pStringOption);
		//    Database pDatabase = HostApplicationServices.WorkingDatabase;

		//    List<string> layerNames = new List<string>();
		//    using (Transaction tran = pDatabase.TransactionManager.StartTransaction()) {
		//        #region 获取图层名字
		//        LayerTable pLayerTable = tran.GetObject(pDatabase.LayerTableId, OpenMode.ForRead) as LayerTable;
		//        foreach (ObjectId pObjectId in pLayerTable) {
		//            LayerTableRecord pLayerTableRecord = tran.GetObject(pObjectId, OpenMode.ForRead) as LayerTableRecord;
		//            layerNames.Add(pLayerTableRecord.Name);
		//        }
		//        #endregion
		//        string layerName = string.Empty;
		//        string typeResult = string.Empty;
		//        FrmLayer frm = new FrmLayer(layerNames);
		//        frm.ShowDialog();
		//        if (frm.DialogResult == Autodesk.AutoCAD.LayerManager.LayerFilter.DialogResult.OK) {
		//            layerName = frm.selectLayer;
		//            typeResult = frm.blockType;
		//        } else {
		//            return;
		//        }
		//        TypedValue[] pTypedValue = new TypedValue[] { new TypedValue((int)DxfCode.LayerName, layerName) };
		//        SelectionFilter pSelectFilter = new SelectionFilter(pTypedValue);
		//        PromptSelectionResult pSelectionResult = pDocument.Editor.SelectAll(pSelectFilter);
		//        SelectionSet pSelectionSet = pSelectionResult.Value;
		//        StreamWriter txt = new StreamWriter(Stream.Null, Encoding.UTF8);
		//        if (typeResult != "全部") {
		//            if (File.Exists("C:\\cad\\cadMessage.txt")) {
		//                File.Delete("C:\\cad\\cadMessage.txt");
		//            }
		//            txt = File.AppendText("C:\\cad\\cadMessage.txt");
		//        }
		//        Point3d startPoint = new Point3d();
		//        Point3d endPoint = new Point3d();
		//        if (typeResult != "全部") {
		//            PromptPointOptions txtPoint = new PromptPointOptions("\n 选择两个点作为文字取值范围");
		//            txtPoint.Message = "\n 选择第一个点：";
		//            PromptPointResult txtStartPoint = pDocument.Editor.GetPoint(txtPoint);
		//            startPoint = txtStartPoint.Value;
		//            txtPoint.Message = "\n 选择第二个点：";
		//            PromptPointResult txtEndPoint = pDocument.Editor.GetPoint(txtPoint);
		//            endPoint = txtEndPoint.Value;
		//            Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(startPoint.X.ToString() + "," + startPoint.Y.ToString() + ";" + endPoint.X.ToString() + "," + endPoint.Y.ToString());
		//        }
		//        foreach (ObjectId selectedId in pSelectionSet.GetObjectIds()) {
		//            Entity pEntity = tran.GetObject(selectedId, OpenMode.ForRead) as Entity;
		//            switch (typeResult) {
		//                case "全部":
		//                    pEntity.ColorIndex = 4;
		//                    break;
		//                case "文字":
		//                    if ((pEntity as MText) != null) {
		//                        MText mText = pEntity as MText;
		//                        if (mText.Location.X > startPoint.X && mText.Location.Y < startPoint.Y && mText.Location.X < endPoint.X && mText.Location.Y > endPoint.Y) {
		//                            txt.WriteLine((pEntity as MText).Contents.ToString());
		//                        }
		//                    }
		//                    if ((pEntity as DBText) != null) {
		//                        DBText pDBText = pEntity as DBText;
		//                        //txtList.Add(pDBText);//这个留着后面测试分析用
		//                        if (pDBText.Position.X > startPoint.X && pDBText.Position.X < endPoint.X) {
		//                            if (pDBText.Position.Y < startPoint.Y && pDBText.Position.Y > endPoint.Y) {
		//                                txt.WriteLine((pEntity as DBText).TextString.ToString());
		//                                pDocument.Editor.WriteMessage(pDBText.TextString + "\n");
		//                                txtList.Add(pDBText);//这个留着后面测试分析用
		//                            }
		//                        }
		//                    }
		//                    break;
		//                case "多段线":
		//                    if ((pEntity as Polyline) != null) {
		//                        Polyline pPolyline = pEntity as Polyline;
		//                        txt.WriteLine("起点：" + pPolyline.StartPoint.X.ToString() + "," + pPolyline.StartPoint.Y.ToString());
		//                        txt.WriteLine("终点：" + pPolyline.EndPoint.X.ToString() + "," + pPolyline.EndPoint.Y.ToString());
		//                    }
		//                    break;
		//                case "直线":
		//                    if ((pEntity as Line) != null) {
		//                        Line pLine = pEntity as Line;
		//                        txt.WriteLine("起点:" + pLine.StartPoint.X.ToString() + "," + pLine.StartPoint.Y.ToString());
		//                        txt.WriteLine("终点:" + pLine.EndPoint.X.ToString() + "," + pLine.EndPoint.Y.ToString());
		//                    }
		//                    break;
		//                case "圆":
		//                    if ((pEntity as Circle) != null) {
		//                        Circle pCircle = pEntity as Circle;
		//                        txt.WriteLine("圆心：(" + pCircle.Center.X.ToString() + "," + pCircle.Center.Y.ToString() + "),半径：" + pCircle.Radius.ToString());
		//                    }
		//                    break;
		//                default:
		//                    break;
		//            }
		//        }
		//        tran.Commit();
		//        txt.Flush();
		//        txt.Close();
		//    }

		//}
		#endregion

	}
}