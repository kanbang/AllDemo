using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CITEC.GCPSU.Data;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseTest
{
	class SqlTester
	{
		#region Field
		private const string TableName = "T_FloorArea";
		private const string ColumnAreaID = "AreaID";
		private const string ColumnAreaName = "AreaName";
		private const string ColumnAreaParentID = "AreaParentID";
		private const string ColumnAreaLevel = "AreaLevel";
		private string _selectStatement = string.Empty;
		private string _updateStatement = string.Empty;
		private string _deleteStatement = string.Empty;
		private string _addStatement = string.Empty;
		private string _user = "4dcad";
		private string _password = "DCE#admin#0117";
		private string _dataSource = "127.0.0.1";
		private string _database = "IkeaArch";
		private string _sqlConnectionProjectString = "";

		#endregion


		public SqlTester ()
		{
			_selectStatement = string.Format("select * from {0} order by {1} asc", TableName, ColumnAreaID);
			_updateStatement = string.Format("update {0} set {1}=@{1},{2}=@{2},{3}=@{3} where {4}=@{4}", TableName, ColumnAreaName, ColumnAreaParentID, ColumnAreaLevel, ColumnAreaID);
			_deleteStatement = string.Format("Delete {0} where {1}=@{1}", TableName, ColumnAreaID);
			_addStatement = string.Format("INSERT INTO {0} ( {4}, {1} , {2} ,{3} ) VALUES (@{4} ,@{1} ,@{2} ,@{3} )", TableName, ColumnAreaName, ColumnAreaParentID, ColumnAreaLevel, ColumnAreaID);
			_sqlConnectionProjectString = string.Format("User ID = {0}; Password = {1};Database= {2}; Data Source ={3};Connect Timeout=60", _user, _password, _database, _dataSource);
		}

		public void SQLChangeFloorAreaRecord (FloorAreaRecord record)
		{
			SqlConnection databaseConnection = new SqlConnection(_sqlConnectionProjectString);
			SqlCommand command = new SqlCommand(_updateStatement, databaseConnection);
			command.CommandType = CommandType.Text;
			SetParameters(record, command);
			try {
				databaseConnection.Open();
				int NumRows = command.ExecuteNonQuery();
				if (NumRows == 0) {
					var message = "数据记录为空，请检查！";
				}
			} catch (Exception e) {
				var message = e;
			} finally {
				databaseConnection.Close();
			}
		}

		static void SetParameters (FloorAreaRecord record, SqlCommand command)
		{
			var parameterName = string.Format("@{0}", ColumnAreaID);
			command.Parameters.Add(parameterName, SqlDbType.Int);
			command.Parameters[parameterName].Value = record.ID;

			parameterName = string.Format("@{0}", ColumnAreaName);
			command.Parameters.Add(parameterName, SqlDbType.NVarChar);
			command.Parameters[parameterName].Value = record.AreaName;

			parameterName = string.Format("@{0}", ColumnAreaParentID);
			command.Parameters.Add(parameterName, SqlDbType.Int);
			command.Parameters[parameterName].Value = record.AreaParentID;

			parameterName = string.Format("@{0}", ColumnAreaLevel);
			command.Parameters.Add(parameterName, SqlDbType.Int);
			command.Parameters[parameterName].Value = record.AreaLevel;
		}

		public void SQLDeleteFloorAreaRecord (FloorAreaRecord record)
		{
			SqlConnection databaseConnection = new SqlConnection(_sqlConnectionProjectString);
			SqlCommand command = new SqlCommand(_deleteStatement, databaseConnection);
			command.CommandType = CommandType.Text;
			SetParameters(record, command);
			try {
				databaseConnection.Open();
				int NumRows = command.ExecuteNonQuery();
				//if (NumRows == 0) {
				//    MessageBox.Show("数据删除出错，请检查！");
				//}
			} catch (Exception e) {
				var message = e;
			} finally {
				databaseConnection.Close();
			}
		}

		public void SQLAddFloorAreaRecord (FloorAreaRecord record)
		{
			SqlConnection databaseConnection = new SqlConnection(_sqlConnectionProjectString);
			SqlCommand command = new SqlCommand(_addStatement, databaseConnection);
			command.CommandType = CommandType.Text;
			SetParameters(record, command);
			try {
				databaseConnection.Open();
				int NumRows = command.ExecuteNonQuery();
				if (NumRows == 0) {
					var message = "数据记录为空，请检查！";
				}
			} catch (Exception e) {
				var message = e;
			} finally {
				databaseConnection.Close();
			}
		}


	}
}
