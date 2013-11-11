using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;
using System.Data;
using System.Text;

namespace SqliteTest
{
	class Program
	{
		static void Main(string[] args)
		{
			TestConnect();
		}

		private static void TestConnect()
		{
			SQLiteConnection cnn = new SQLiteConnection(@"Data Source=E:\360data\重要数据\桌面\混凝土模型-YJK\导入YJK\施工图\dtlmodel.ydb;UTF8Encoding=True;");
			cnn.Open();
			DbCommand comm = cnn.CreateCommand();
			comm.CommandText = "SELECT * FROM tblProjectPara where id=2";
			comm.CommandType = CommandType.Text;
			StringBuilder builder = new StringBuilder();
			using (IDataReader reader = comm.ExecuteReader()) {
				while (reader.Read()) {
					builder.AppendLine(reader["ParaVal"].ToString());
				}
			}
			cnn.Close();
		}
	}
}
