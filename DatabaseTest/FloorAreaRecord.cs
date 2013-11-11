using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CITEC.GCPSU.Data
{
	public class FloorAreaRecord
	{
		#region Field
		private string _areaName = string.Empty;
		private int _areaParentID = 0;
		private int _areaLevel = 0;
		private int _id = 0;

		#endregion

		#region Property

		public string AreaName
		{
			get { return _areaName; }
			set { _areaName = value; }
		}
		public int AreaParentID
		{
			get { return _areaParentID; }
			set { _areaParentID = value; }
		}

		public int AreaLevel
		{
			get { return _areaLevel; }
			set { _areaLevel = value; }
		}

		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}

		#endregion

		#region Constructor

		public FloorAreaRecord ()
			: base()
		{
			_areaName = string.Empty;
			_areaParentID = 0;
			_areaLevel = 0;
			_id = 0;
		}
		#endregion
	}
}
