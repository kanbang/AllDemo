using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CITEC.GCPSU.Data;

namespace DatabaseTest
{
	class Program
	{
		static void Main (string[] args)
		{
			var floorArea = new FloorAreaRecord() { ID = 1, AreaLevel = 2, AreaParentID = 3, AreaName = "测试" };
			new SqlTester().SQLAddFloorAreaRecord(floorArea);
			floorArea.AreaName = "ceshi2";
			new SqlTester().SQLChangeFloorAreaRecord(floorArea);
			new SqlTester().SQLDeleteFloorAreaRecord(floorArea);
		}
	}
}
