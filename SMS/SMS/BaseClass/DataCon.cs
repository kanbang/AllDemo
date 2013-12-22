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

		#region  �������ݿ�����
		/// <summary>
		/// �������ݿ�����.
		/// </summary>
		/// <returns>����SQLiteConnection����</returns>
		public SQLiteConnection getcon()
		{
			if(!File.Exists(M_str_sqlcon)){
				SQLiteConnection.CreateFile(M_str_sqlcon);
			}
			SQLiteConnection connection = new SQLiteConnection("Data Source=" + M_str_sqlcon);
			return connection;
		}
		#endregion

		#region  ִ��SqlCommand����
		/// <summary>
		/// ִ��SqlCommand
		/// </summary>
		/// <param name="M_str_sqlstr">SQL���</param>
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

		#region  ����DataSet����
		/// <summary>
		/// ����һ��DataSet����
		/// </summary>
		/// <param name="M_str_sqlstr">SQL���</param>
		/// <param name="M_str_table">����</param>
		/// <returns>����DataSet����</returns>
		public DataSet getds(string M_str_sqlstr, string M_str_table)
		{
			SQLiteConnection sqlcon = this.getcon();
			SQLiteDataAdapter cmd = new SQLiteDataAdapter(M_str_sqlstr, sqlcon);
			DataSet myds = new DataSet();
			cmd.Fill(myds, M_str_table);
			return myds;
		}
		#endregion

		#region  ����SQLiteDataReader����
		/// <summary>
		/// ����һ��SQLiteDataReader����
		/// </summary>
		/// <param name="M_str_sqlstr">SQL���</param>
		/// <returns>����SQLiteDataReader����</returns>
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
