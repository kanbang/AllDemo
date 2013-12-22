using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.SQLite;

namespace SMS.BaseClass
{
	class DataCon
	{
		string M_str_sqlcon = "sms.db";

		#region  建立数据库连接
		/// <summary>
		/// 建立数据库连接.
		/// </summary>
		/// <returns>返回SQLiteConnection对象</returns>
		public SQLiteConnection getcon()
		{
			if(!File.Exists(M_str_sqlcon)){
				SQLiteConnection.CreateFile(M_str_sqlcon);
			}
			SQLiteConnection connection = new SQLiteConnection("Data Source=" + M_str_sqlcon);
			return connection;
		}
		#endregion

		#region  执行SqlCommand命令
		/// <summary>
		/// 执行SqlCommand
		/// </summary>
		/// <param name="M_str_sqlstr">SQL语句</param>
		public void getcom(string M_str_sqlstr)
		{
			using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + M_str_sqlcon))			{
				connection.Open();
				using (SQLiteCommand command = new SQLiteCommand(connection)){
					command.CommandText = M_str_sqlstr;
					command.ExecuteNonQuery();
				}

			}
		}
		#endregion

		#region  创建DataSet对象
		/// <summary>
		/// 创建一个DataSet对象
		/// </summary>
		/// <param name="M_str_sqlstr">SQL语句</param>
		/// <param name="M_str_table">表名</param>
		/// <returns>返回DataSet对象</returns>
		public DataSet getds(string M_str_sqlstr, string M_str_table)
		{
			SQLiteConnection sqlcon = this.getcon();
			SQLiteDataAdapter cmd = new SQLiteDataAdapter(M_str_sqlstr, sqlcon);
			DataSet myds = new DataSet();
			cmd.Fill(myds, M_str_table);
			return myds;
		}
		#endregion

		#region  创建SQLiteDataReader对象
		/// <summary>
		/// 创建一个SQLiteDataReader对象
		/// </summary>
		/// <param name="M_str_sqlstr">SQL语句</param>
		/// <returns>返回SQLiteDataReader对象</returns>
		public SQLiteDataReader getread(string M_str_sqlstr)
		{
			SQLiteConnection sqlcon = this.getcon();
			SQLiteCommand sqlcom = new SQLiteCommand(M_str_sqlstr, sqlcon);
			sqlcon.Open();
			SQLiteDataReader  sqlread=sqlcom.ExecuteReader(CommandBehavior.CloseConnection);
			return sqlread;
		}
		#endregion
	}
}
