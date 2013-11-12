using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;

namespace GZipStreamTest
{
	public class GZipCompress
	{
		/// <summary>
		/// 对目标文件夹进行压缩，将压缩结果保存为指定文件
		/// </summary>
		/// <param name="dirPath">目标文件夹</param>
		/// <param name="fileName">压缩文件</param>
		public static void Compress(string dirPath, string fileName)
		{
			ArrayList list = new ArrayList();
			foreach (string f in Directory.GetFiles(dirPath)) {
				byte[] destBuffer = File.ReadAllBytes(f);
				SerializeFileInfo sfi = new SerializeFileInfo(f, destBuffer);
				list.Add(sfi);
			}
			IFormatter formatter = new BinaryFormatter();
			using (Stream s = new MemoryStream()) {
				formatter.Serialize(s, list);
				s.Position = 0;
				CreateCompressFile(s, fileName);
			}
		}

		/// <summary>
		/// 对目标压缩文件解压缩，将内容解压缩到指定文件夹
		/// </summary>
		/// <param name="fileName">压缩文件</param>
		/// <param name="dirPath">解压缩目录</param>
		public static void DeCompress(string fileName, string dirPath)
		{
			using (Stream source = File.OpenRead(fileName)) {
				using (Stream destination = new MemoryStream()) {
					using (GZipStream input = new GZipStream(source, CompressionMode.Decompress, true)) {
						byte[] bytes = new byte[4096];
						int n;
						while ((n = input.Read(bytes, 0, bytes.Length)) != 0) {
							destination.Write(bytes, 0, n);
						}
					}
					destination.Flush();
					destination.Position = 0;
					DeSerializeFiles(destination, dirPath);
				}
			}
		}

		private static void DeSerializeFiles(Stream s, string dirPath)
		{
			BinaryFormatter b = new BinaryFormatter();
			ArrayList list = (ArrayList)b.Deserialize(s);

			foreach (SerializeFileInfo f in list) {
				string newName = dirPath + Path.GetFileName(f.FileName);
				using (FileStream fs = new FileStream(newName, FileMode.Create, FileAccess.Write)) {
					fs.Write(f.FileBuffer, 0, f.FileBuffer.Length);
					fs.Close();
				}
			}
		}

		private static void CreateCompressFile(Stream source, string destinationName)
		{
			using (Stream destination = new FileStream(destinationName, FileMode.Create, FileAccess.Write)) {
				using (GZipStream output = new GZipStream(destination, CompressionMode.Compress)) {
					byte[] bytes = new byte[4096];
					int n;
					while ((n = source.Read(bytes, 0, bytes.Length)) != 0) {
						output.Write(bytes, 0, n);
					}
				}
			}
		}

		[Serializable]
		class SerializeFileInfo
		{
			public SerializeFileInfo(string name, byte[] buffer)
			{
				fileName = name;
				fileBuffer = buffer;
			}

			string fileName;
			public string FileName
			{
				get
				{
					return fileName;
				}
			}

			byte[] fileBuffer;
			public byte[] FileBuffer
			{
				get
				{
					return fileBuffer;
				}
			}
		}
	}
}
