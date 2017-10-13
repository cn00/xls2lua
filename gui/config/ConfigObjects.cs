using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;

namespace GameManager.config
{
	class ConfigObjects
	{
		private const String XML_CONFIG = "Config.xml";
		public static XmlDocument xml = new XmlDocument();
		public static Directories directories = new Directories();


		public static void loadAllConfig()
		{
			try
			{
				// 加载XML文档
				xml.Load(XML_CONFIG);
			}
			catch (System.IO.FileNotFoundException ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

            loadDirectories();

            
		}

		public static void loadDirectories()
		{
			// 读取Directories配置
			XmlNode node_Directories = xml.DocumentElement.SelectSingleNode("Directories");
			Type type = directories.GetType();
			PropertyInfo[] props = type.GetProperties();
			for (int i = 0; i < props.Length && i < node_Directories.ChildNodes.Count; ++i)
			{
				props[i].SetValue(directories, node_Directories.ChildNodes[i].InnerText, null);
			}
		}


		public static void saveDirectories()
		{
			// 保存Directories配置
			XmlNode node_Directories = xml.DocumentElement.SelectSingleNode("Directories");
			Type type = directories.GetType();
			PropertyInfo[] props = type.GetProperties();
			for (int i = 0; i < props.Length; ++i)
			{
				if (node_Directories.ChildNodes[i] == null)
				{
					XmlNode node = xml.CreateNode(XmlNodeType.Text, props[i].Name, "Directories");
					node_Directories.AppendChild(node);
				}
				node_Directories.ChildNodes[i].InnerText = props[i].GetValue(directories, null).ToString();
			}

			xml.Save(XML_CONFIG);
		}

		public static void loadServerURLs()
		{
			// 读取ServerURLs配置
			XmlNode node_Directories = xml.DocumentElement.SelectSingleNode("ServerURLs");
			Type type = directories.GetType();
			PropertyInfo[] props = type.GetProperties();
			for (int i = 0; i < props.Length && i < node_Directories.ChildNodes.Count; ++i)
			{
				props[i].SetValue(directories, node_Directories.ChildNodes[i].InnerText, null);
			}
		}

		public static void saveServerURLs()
		{
			// 保存ServerURLs配置
			XmlNode node_Directories = xml.DocumentElement.SelectSingleNode("ServerURLs");
			Type type = directories.GetType();
			PropertyInfo[] props = type.GetProperties();
			for (int i = 0; i < props.Length && i < node_Directories.ChildNodes.Count; ++i)
			{
				node_Directories.ChildNodes[i].InnerText = props[i].GetValue(directories, null).ToString();
			}

			xml.Save(XML_CONFIG);
		}

	}
}