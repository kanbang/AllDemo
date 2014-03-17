using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;

namespace HelloCad.Model
{
	class EleReinDataModel
	{
		public string Name { get; set; }

		public string Type { get; set; }

		public int ColorIndex { get; set; }

		public Polyline Polyline { get; set; }

		public DBText DbText { get; set; }
	}
}
