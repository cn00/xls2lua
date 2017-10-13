using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameManager.config;

namespace GameManager.functions
{
	class FileManager
	{
		public enum E_FILE_TYPE
		{
			FILE_TYPE_SERVER_IN = 0,
			FILE_TYPE_CLIENT_IN = 1,
			FILE_TYPE_COMMON_IN = 2,
			FILE_TYPE_SERVER_OUT = 3,
			FILE_TYPE_CLIENT_OUT = 4
		}
		public static List<FileInfo> m_lstServerInTableInfo = new List<FileInfo>();
		public static List<FileInfo> m_lstClientInTableInfo = new List<FileInfo>();
		public static List<FileInfo> m_lstCommonInTableInfo = new List<FileInfo>();
		public static List<FileInfo> m_lstServerOutTableInfo = new List<FileInfo>();
		public static List<FileInfo> m_lstClientOutTableInfo = new List<FileInfo>();

		public static void refresh()
		{
			setFileInfo(ConfigObjects.directories.服务器表输入路径, "xls", E_FILE_TYPE.FILE_TYPE_SERVER_IN);
			setFileInfo(ConfigObjects.directories.客户端表输入路径, "xls", E_FILE_TYPE.FILE_TYPE_CLIENT_IN);
			setFileInfo(ConfigObjects.directories.共用表输入路径, "xls", E_FILE_TYPE.FILE_TYPE_COMMON_IN);
			setFileInfo(ConfigObjects.directories.服务器表输出路径, "xls", E_FILE_TYPE.FILE_TYPE_SERVER_OUT);
			setFileInfo(ConfigObjects.directories.客户端表输出路径, "lua", E_FILE_TYPE.FILE_TYPE_CLIENT_OUT);
		}

		public static void setFileInfo(String strPath, string strFileType, E_FILE_TYPE eType)
		{
			if (strPath == null || strPath == "")
			{
				return;
			}

            //  DirectoryInfo获取的文件夹下的所有子目录
			DirectoryInfo TheFolder = new DirectoryInfo(strPath);
			List<FileInfo> fileInfo;
			switch (eType)
			{
				case E_FILE_TYPE.FILE_TYPE_SERVER_IN:
					fileInfo = m_lstServerInTableInfo;
					break;
				case E_FILE_TYPE.FILE_TYPE_CLIENT_IN:
					fileInfo = m_lstClientInTableInfo;
					break;
				case E_FILE_TYPE.FILE_TYPE_COMMON_IN:
					fileInfo = m_lstCommonInTableInfo;
					break;
				case E_FILE_TYPE.FILE_TYPE_SERVER_OUT:
					fileInfo = m_lstServerOutTableInfo;
					break;
				case E_FILE_TYPE.FILE_TYPE_CLIENT_OUT:
					fileInfo = m_lstClientOutTableInfo;
					break;
				default:
					fileInfo = null;
					break;
			}

			if (fileInfo == null)
			{
				return;
			}

			IEnumerable<string> files = new List<string>();
			files = System.IO.Directory.EnumerateFiles(strPath, "", System.IO.SearchOption.TopDirectoryOnly);
			fileInfo.Clear();

			try
			{
				foreach (FileInfo file in TheFolder.GetFiles("*." + strFileType))
				{
					fileInfo.Add(file);
				}
			}
			catch (System.Exception ex)
			{
				strPath = "";
				Log.info("目录错误：" + ex.Message);
			}
			
		}

		public static List<FileInfo> getFileList(E_FILE_TYPE eType)
		{
			switch (eType)
			{
				case E_FILE_TYPE.FILE_TYPE_SERVER_IN:
					return m_lstServerInTableInfo;
				case E_FILE_TYPE.FILE_TYPE_CLIENT_IN:
					return m_lstClientInTableInfo;
				case E_FILE_TYPE.FILE_TYPE_COMMON_IN:
					return m_lstCommonInTableInfo;
				case E_FILE_TYPE.FILE_TYPE_SERVER_OUT:
					return m_lstServerOutTableInfo;
				case E_FILE_TYPE.FILE_TYPE_CLIENT_OUT:
					return m_lstClientOutTableInfo;
				default:
					return null;
			}
		}
	}
}
