using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace SMS.BaseClass
{
	class DataOperate
	{
		DataCon datacon = new DataCon();//声明DataCon类的一个对象，以调用其方法

		#region  绑定ComboBox控件
		/// <summary>
		/// 对ComboBox控件进行数据绑定
		/// </summary>
		/// <param name="M_str_sqlstr">SQL语句</param>
		/// <param name="M_str_table">表名</param>
		/// <param name="M_str_tbMember">数据表中字段名</param>
		/// <param name="cbox">ComboBox控件ID</param>
		public void cboxBind(string M_str_sqlstr, string M_str_table, string M_str_tbMember, ComboBox cbox)
		{
			DataSet myds = datacon.getds(M_str_sqlstr, M_str_table);
			cbox.DataSource = myds.Tables[M_str_table];
			cbox.DisplayMember = M_str_tbMember;
		}
		#endregion

		#region  绘制饼图
		/// <summary>
		/// 根据货物所占百分比画饼图
		/// </summary>
		/// <param name="objgraphics">Graphics类对象</param>
		/// <param name="M_str_sqlstr">SQL语句</param>
		/// <param name="M_str_table">表名</param>
		/// <param name="M_str_Num">数据表中货物数</param>
		/// <param name="M_str_tbGName">数据表中货物名称</param>
		/// <param name="M_str_title">饼图标题</param>
		public void drawPic(Graphics objgraphics,string M_str_sqlstr, string M_str_table, string M_str_Num, string M_str_tbGName, string M_str_title)
		{
			DataSet myds = datacon.getds(M_str_sqlstr, M_str_table);
			float M_flt_total = 0.0f, M_flt_tmp;
			int M_int_iloop;
			for (M_int_iloop = 0; M_int_iloop < myds.Tables[0].Rows.Count; M_int_iloop++)
			{
				M_flt_tmp = Convert.ToSingle(myds.Tables[0].Rows[M_int_iloop][M_str_Num]);
				M_flt_total += M_flt_tmp;
			}
			Font fontlegend = new Font("verdana", 9), fonttitle = new Font("verdana", 10, FontStyle.Bold);//设置字体
			int M_int_width = 275;//白色背景宽
			const int Mc_int_bufferspace = 15;
			int M_int_legendheight = fontlegend.Height * (myds.Tables[0].Rows.Count + 1) + Mc_int_bufferspace;
			int M_int_titleheight = fonttitle.Height + Mc_int_bufferspace;
			int M_int_height = M_int_width + M_int_legendheight + M_int_titleheight + Mc_int_bufferspace;//白色背景高
			int M_int_pieheight = M_int_width;
			Rectangle pierect = new Rectangle(0, M_int_titleheight, M_int_width, M_int_pieheight);
			//加上各种随机色
			Bitmap objbitmap = new Bitmap(M_int_width, M_int_height);//创建一个bitmap实例
			objgraphics = Graphics.FromImage(objbitmap);
			ArrayList colors = new ArrayList();
			Random rnd = new Random();
			for (M_int_iloop = 0; M_int_iloop < myds.Tables[0].Rows.Count; M_int_iloop++)
				colors.Add(new SolidBrush(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255))));
			objgraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, M_int_width, M_int_height);//画一个白色背景
			objgraphics.FillRectangle(new SolidBrush(Color.LightYellow), pierect);//画一个亮黄色背景
			//以下为画饼图(有几行row画几个)
			float M_flt_currentdegree = 0.0f;
			for (M_int_iloop = 0; M_int_iloop < myds.Tables[0].Rows.Count; M_int_iloop++)
			{
				objgraphics.FillPie((SolidBrush)colors[M_int_iloop], pierect, M_flt_currentdegree,
				                    Convert.ToSingle(myds.Tables[0].Rows[M_int_iloop][M_str_Num]) / M_flt_total * 360);
				M_flt_currentdegree += Convert.ToSingle(myds.Tables[0].Rows[M_int_iloop][M_str_Num]) / M_flt_total * 360;
			}
			//以下为生成主标题
			SolidBrush blackbrush = new SolidBrush(Color.Black);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			objgraphics.DrawString(M_str_title, fonttitle, blackbrush, new Rectangle(0, 0, M_int_width, M_int_titleheight), stringFormat);
			objgraphics.DrawRectangle(new Pen(Color.Black, 2), 0, M_int_height - M_int_legendheight, M_int_width, M_int_legendheight);
			for (M_int_iloop = 0; M_int_iloop < myds.Tables[0].Rows.Count; M_int_iloop++)
			{
				objgraphics.FillRectangle((SolidBrush)colors[M_int_iloop], 5, M_int_height - M_int_legendheight + fontlegend.Height * M_int_iloop + 5, 10, 10);
				objgraphics.DrawString(((String)myds.Tables[0].Rows[M_int_iloop][M_str_tbGName]) + " —— "
				                       + Convert.ToString(Convert.ToSingle(myds.Tables[0].Rows[M_int_iloop][M_str_Num]) * 100 / M_flt_total) + "%", fontlegend, blackbrush,
				                       20, M_int_height - M_int_legendheight + fontlegend.Height * M_int_iloop + 1);
			}
			objgraphics.DrawString("总货物数是：" + Convert.ToString(M_flt_total), fontlegend, blackbrush, 5, M_int_height - fontlegend.Height);
			string P_str_imagePath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
			                                                                                                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
			P_str_imagePath += @"\Image\image\" + DateTime.Now.ToString("yyyyMMddhhmss") + ".jpg";
			objbitmap.Save(P_str_imagePath, ImageFormat.Jpeg);
			objgraphics.Dispose();
			objbitmap.Dispose();
		}
		#endregion

		#region  文件压缩
		/// <summary>
		/// 文件压缩
		/// </summary>
		/// <param name="M_str_DFile">压缩前文件及路径</param>
		/// <param name="M_str_CFile">压缩后文件及路径</param>
		public void compressFile(string M_str_DFile, string M_str_CFile)
		{
			if (!File.Exists(M_str_DFile)) throw new FileNotFoundException();
			using (FileStream sourceStream = new FileStream(M_str_DFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
			{
				byte[] buffer = new byte[sourceStream.Length];
				int checkCounter = sourceStream.Read(buffer, 0, buffer.Length);
				if (checkCounter != buffer.Length) throw new ApplicationException();
				using (FileStream destinationStream = new FileStream(M_str_CFile, FileMode.OpenOrCreate, FileAccess.Write))
				{
					using (GZipStream compressedStream = new GZipStream(destinationStream, CompressionMode.Compress, true))
					{
						compressedStream.Write(buffer, 0, buffer.Length);
					}
				}
			}
		}
		#endregion

		#region  验证文本框输入为数字
		/// <summary>
		/// 验证文本框输入为数字
		/// </summary>
		/// <param name="M_str_num">输入字符</param>
		/// <returns>返回一个bool类型的值</returns>
		public bool validateNum(string M_str_num)
		{
			return Regex.IsMatch(M_str_num, "^[0-9]*$");
		}
		#endregion

		#region  验证文本框输入为电话号码
		/// <summary>
		/// 验证文本框输入为电话号码
		/// </summary>
		/// <param name="M_str_phone">输入字符串</param>
		/// <returns>返回一个bool类型的值</returns>
		public bool validatePhone(string M_str_phone)
		{
			return Regex.IsMatch(M_str_phone, @"0\d{9,11}") ||  Regex.IsMatch(M_str_phone, @"0\d{2,3}-\d{7,8}") || Regex.IsMatch(M_str_phone, @"[1][358]\d{9}");
		}
		#endregion

		#region  验证文本框输入为传真号码
		/// <summary>
		/// 验证文本框输入为传真号码
		/// </summary>
		/// <param name="M_str_fax">输入字符串</param>
		/// <returns>返回一个bool类型的值</returns>
		public bool validateFax(string M_str_fax)
		{
			return Regex.IsMatch(M_str_fax, @"86-\d{2,3}-\d{7,8}");
		}
		#endregion

		#region  用户登录
		/// <summary>
		/// 用户登录
		/// </summary>
		/// <param name="P_str_UserName">用户名</param>
		/// <param name="P_str_UserPwd">用户密码</param>
		/// <returns>返回一个int类型的值</returns>
		public int UserLogin(string P_str_UserName, string P_str_UserPwd)
		{
			SQLiteConnection  sqlcon = datacon.getcon();
			SQLiteCommand sqlcom = new SQLiteCommand("select * from tb_User where UserName=@UserName and UserPwd=@UserPwd", sqlcon);
			sqlcom.Parameters.Add("@UserName", DbType.AnsiString, 20).Value = P_str_UserName;
			sqlcom.Parameters.Add("@UserPwd", DbType.AnsiString, 20).Value = P_str_UserPwd;
			try
			{
				SQLiteDataAdapter cmd = new SQLiteDataAdapter(sqlcom);
				DataSet myds = new DataSet();
				cmd.Fill(myds, "test");
				if(myds.Tables.Count==1 && myds.Tables[0].Rows.Count==1){
					return 100;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
			return -100;
		}
		#endregion

		#region  货物入库
		/// <summary>
		/// 货物入库
		/// </summary>
		/// <param name="P_int_GoodsID">货物编号</param>
		/// <param name="P_str_GoodsName">货物名称</param>
		/// <param name="P_str_PrName">供应商名称</param>
		/// <param name="P_str_StoreName">仓库名称</param>
		/// <param name="P_str_GoodsSpec">货物规格</param>
		/// <param name="P_str_GoodsUnit">计量单位</param>
		/// <param name="P_int_GoodsNum">进货数量</param>
		/// <param name="P_dml_GoodsPrice">货物单价</param>
		/// <param name="P_str_HPeople">经手人</param>
		/// <param name="P_str_Remark">备注</param>
		/// <returns>返回一个int类型的值</returns>
		public int InsertGoods(int P_int_GoodsID,string P_str_GoodsName,string P_str_PrName,string P_str_StoreName,
		                       string P_str_GoodsSpec,string P_str_GoodsUnit,int P_int_GoodsNum,decimal P_dml_GoodsPrice,string P_str_HPeople,string P_str_Remark)
		{
			SQLiteConnection sqlcon = datacon.getcon();
			SQLiteCommand sqlcom = new SQLiteCommand("proc_insertInStore", sqlcon);
			sqlcom.CommandType = CommandType.StoredProcedure;
			sqlcom.Parameters.Add("@GoodsID", DbType.Int32).Value = P_int_GoodsID;
			sqlcom.Parameters.Add("@GoodsName", DbType.AnsiString, 50).Value = P_str_GoodsName;
			sqlcom.Parameters.Add("@PrName", DbType.AnsiString, 100).Value = P_str_PrName;
			sqlcom.Parameters.Add("@StoreName", DbType.AnsiString, 100).Value = P_str_StoreName;
			sqlcom.Parameters.Add("@GoodsSpec", DbType.AnsiString, 50).Value = P_str_GoodsSpec;
			sqlcom.Parameters.Add("@GoodsUnit", DbType.AnsiString, 8).Value = P_str_GoodsUnit;
			sqlcom.Parameters.Add("@GoodsNum", DbType.Int32).Value = P_int_GoodsNum;
			sqlcom.Parameters.Add("@GoodsPrice", DbType.Decimal).Value = P_dml_GoodsPrice;
			sqlcom.Parameters.Add("@HandlePeople", DbType.AnsiString, 20).Value = P_str_HPeople;
			sqlcom.Parameters.Add("@ISRemark", DbType.AnsiString, 1000).Value = P_str_Remark;
			SQLiteParameter returnValue = sqlcom.Parameters.Add("returnValue", DbType.Int32, 4);
			returnValue.Direction = ParameterDirection.ReturnValue;
			sqlcon.Open();
			try
			{
				sqlcom.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlcom.Dispose();
				sqlcon.Close();
				sqlcon.Dispose();
			}
			int P_int_returnValue = (int)returnValue.Value;
			return P_int_returnValue;
		}
		#endregion

		#region  添加供应商信息
		/// <summary>
		/// 添加供应商信息
		/// </summary>
		/// <param name="P_str_PrName">供应商名称</param>
		/// <param name="P_str_PrPeople">负责人</param>
		/// <param name="P_str_PrPhone">供应商联系电话</param>
		/// <param name="P_str_PrFax">供应商传真号码</param>
		/// <param name="P_int_PrRemark">备注</param>
		/// <returns>返回一个int类型的值</returns>
		public int InsertProvider(string P_str_PrName, string P_str_PrPeople, string P_str_PrPhone, string P_str_PrFax, string P_int_PrRemark)
		{
			SQLiteConnection sqlcon = datacon.getcon();
			SQLiteCommand sqlcom = new SQLiteCommand("select * from tb_Provider where PrName=@PrName", sqlcon);
			sqlcom.Parameters.Add("@PrName", DbType.AnsiString, 100).Value = P_str_PrName;
			
			SQLiteDataAdapter cmd = new SQLiteDataAdapter(sqlcom);
			try {
				DataSet myds = new DataSet();
				cmd.Fill(myds, "test");
				if(myds.Tables.Count==1 && myds.Tables[0].Rows.Count==1){
					return 100;
				}

			} catch (Exception ex) {
				
				MessageBox.Show(ex.Message);
			}
			sqlcom = new SQLiteCommand(" insert into tb_Provider(PrName,PrPeople,PrPhone,PrFax,PrRemark) values(@PrName,@PrPeople,@PrPhone,@PrFax,@PrRemark)", sqlcon);
			sqlcom.Parameters.Add("@PrName", DbType.AnsiString, 100).Value = P_str_PrName;

			sqlcom.Parameters.Add("@PrPeople", DbType.AnsiString, 20).Value = P_str_PrPeople;
			sqlcom.Parameters.Add("@PrPhone", DbType.AnsiString, 20).Value = P_str_PrPhone;
			sqlcom.Parameters.Add("@PrFax", DbType.AnsiString, 20).Value = P_str_PrFax;
			sqlcom.Parameters.Add("@PrRemark", DbType.AnsiString, 1000).Value = P_int_PrRemark;
			int value=0;
			try
			{
							sqlcon.Open();
				value=sqlcom.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlcom.Dispose();
				sqlcon.Close();
				sqlcon.Dispose();
			}
			return value;
		}
		#endregion

		#region  添加仓库信息
		/// <summary>
		/// 添加仓库信息
		/// </summary>
		/// <param name="P_str_StoreName">仓库名称</param>
		/// <param name="P_str_StorePeople">仓库负责人</param>
		/// <param name="P_str_StorePhone">仓库电话</param>
		/// <param name="P_str_StoreUnit">仓库所属单位</param>
		/// <param name="P_int_StoreRemark">备注</param>
		/// <returns>返回一个int类型的值</returns>
		public int InsertStorage(string P_str_StoreName, string P_str_StorePeople, string P_str_StorePhone, string P_str_StoreUnit, string P_int_StoreRemark)
		{
			SQLiteConnection sqlcon = datacon.getcon();
			SQLiteCommand sqlcom = new SQLiteCommand("select * from tb_Storage where StoreName=@StoreName", sqlcon);
			sqlcom.Parameters.Add("@StoreName", DbType.AnsiString, 100).Value = P_str_StoreName;

			SQLiteDataAdapter cmd = new SQLiteDataAdapter(sqlcom);
			try {
				DataSet myds = new DataSet();
				cmd.Fill(myds, "test");
				if(myds.Tables.Count==1 && myds.Tables[0].Rows.Count==1){
					return 100;
				}

			} catch (Exception ex) {
				
				MessageBox.Show(ex.Message);
			}
			sqlcom = new SQLiteCommand("insert into tb_Storage(StoreName,StorePeople,StorePhone,StoreUnit,StoreRemark) values (@StoreName,@StorePeople,@StorePhone,@StoreUnit,@StoreRemark)", sqlcon);
			sqlcom.Parameters.Add("@StoreName", DbType.AnsiString, 100).Value = P_str_StoreName;
			sqlcom.Parameters.Add("@StorePeople", DbType.AnsiString, 20).Value = P_str_StorePeople;
			sqlcom.Parameters.Add("@StorePhone", DbType.AnsiString, 20).Value = P_str_StorePhone;
			sqlcom.Parameters.Add("@StoreUnit", DbType.AnsiString, 100).Value = P_str_StoreUnit;
			sqlcom.Parameters.Add("@StoreRemark", DbType.AnsiString, 1000).Value = P_int_StoreRemark;
			int value=0;
			try
			{
				sqlcon.Open();

				value=sqlcom.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlcom.Dispose();
				sqlcon.Close();
				sqlcon.Dispose();
			}
			return value;
		}
		#endregion

		#region  添加新用户
		/// <summary>
		/// 添加新用户
		/// </summary>
		/// <param name="P_str_UserName">用户名</param>
		/// <param name="P_str_UserPwd">用户密码</param>
		/// <param name="P_str_UserRight">用户权限</param>
		/// <returns>返回一个int类型的值</returns>
		public int InsertUser(string P_str_UserName, string P_str_UserPwd, string P_str_UserRight)
		{
			SQLiteConnection sqlcon = datacon.getcon();
			SQLiteCommand sqlcom = new SQLiteCommand("select * from tb_User where UserName=@UserName",sqlcon);
			sqlcom.Parameters.Add("@UserName", DbType.AnsiString, 20).Value = P_str_UserName;
			SQLiteDataAdapter cmd = new SQLiteDataAdapter(sqlcom);
			try {
				DataSet myds = new DataSet();
				cmd.Fill(myds, "test");
				if(myds.Tables.Count==1 && myds.Tables[0].Rows.Count==1){
					return 100;
				}

			} catch (Exception ex) {
				
				MessageBox.Show(ex.Message);
			}
			sqlcom = new SQLiteCommand("insert into tb_User(UserName,UserPwd,UserRight)     values(@UserName,@UserPwd,@UserRight)",sqlcon);
			sqlcom.Parameters.Add("@UserName", DbType.AnsiString, 20).Value = P_str_UserName;
			sqlcom.Parameters.Add("@UserPwd", DbType.AnsiString, 20).Value = P_str_UserPwd;
			sqlcom.Parameters.Add("@UserRight", DbType.AnsiString, 10).Value = P_str_UserRight;
			int value=0;
			try
			{
				sqlcon.Open();
				value=sqlcom.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlcom.Dispose();
				sqlcon.Close();
				sqlcon.Dispose();
			}
			return value;
		}
		#endregion

		#region  盘点货物
		/// <summary>
		/// 盘点货物
		/// </summary>
		/// <param name="P_int_ISID">货物入库编号</param>
		/// <param name="P_str_SName">仓库名称</param>
		/// <param name="P_str_GName">货物名称</param>
		/// <param name="P_str_GUnit">计量单位</param>
		/// <param name="P_int_CKNum">盘点数量</param>
		/// <param name="P_int_PALNum">盈亏数量</param>
		/// <param name="P_str_CPeople">盘点人</param>
		/// <param name="P_str_Remark">备注</param>
		/// <returns>返回一个int类型的值</returns>
		public int InsertCheck(int P_int_GoodsID, string P_str_SName, string P_str_GName,
		                       string P_str_GUnit, int P_int_CKNum, int P_int_PALNum, string P_str_CPeople, string P_str_Remark)
		{
			SQLiteConnection sqlcon = datacon.getcon();
			SQLiteCommand sqlcom = new SQLiteCommand("proc_insertCheck", sqlcon);
			sqlcom.CommandType = CommandType.StoredProcedure;
			sqlcom.Parameters.Add("@GoodsID", DbType.Int32).Value = P_int_GoodsID;
			sqlcom.Parameters.Add("@StoreName", DbType.AnsiString, 100).Value = P_str_SName;
			sqlcom.Parameters.Add("@GoodsName", DbType.AnsiString, 50).Value = P_str_GName;
			sqlcom.Parameters.Add("@GoodsUnit", DbType.AnsiString, 8).Value = P_str_GUnit;
			sqlcom.Parameters.Add("@CheckNum", DbType.Int32).Value = P_int_CKNum;
			sqlcom.Parameters.Add("@PALNum", DbType.Int32).Value = P_int_PALNum;
			sqlcom.Parameters.Add("@CheckPeople", DbType.AnsiString, 20).Value = P_str_CPeople;
			sqlcom.Parameters.Add("@CheckRemark", DbType.AnsiString, 1000).Value = P_str_Remark;
			SQLiteParameter returnValue = sqlcom.Parameters.Add("returnValue", DbType.Int32, 4);
			returnValue.Direction = ParameterDirection.ReturnValue;
			sqlcon.Open();
			try
			{
				sqlcom.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlcom.Dispose();
				sqlcon.Close();
				sqlcon.Dispose();
			}
			int P_int_returnValue = (int)returnValue.Value;
			return P_int_returnValue;
		}
		#endregion

		#region  修改用户信息
		/// <summary>
		/// 修改用户信息
		/// </summary>
		/// <param name="P_int_UID">用户编号</param>
		/// <param name="P_str_UserPwd">用户密码</param>
		/// <param name="P_str_UserRight">用户权限</param>
		/// <returns>返回一个int类型的值</returns>
		public void updateUser(int P_int_UID,string P_str_UserPwd, string P_str_UserRight)
		{
			SQLiteConnection sqlcon = datacon.getcon();
			SQLiteCommand sqlcom = new SQLiteCommand("proc_updateUser", sqlcon);
			sqlcom.CommandType = CommandType.StoredProcedure;
			sqlcom.Parameters.Add("@UserID", DbType.Int32).Value = P_int_UID;
			sqlcom.Parameters.Add("@UserPwd", DbType.AnsiString, 20).Value = P_str_UserPwd;
			sqlcom.Parameters.Add("@UserRight", DbType.AnsiString, 10).Value = P_str_UserRight;
			sqlcon.Open();
			try
			{
				sqlcom.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlcom.Dispose();
				sqlcon.Close();
				sqlcon.Dispose();
			}
		}
		#endregion
	}
}
