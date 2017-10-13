using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameManager.config;
using GameManager.tools;

namespace GameManager.ui
{
	public partial class DirectorySetting : Form
	{
		private static DirectorySetting instance = null;
		public static DirectorySetting getInstance()
		{
			if (instance == null)
			{
				instance = new DirectorySetting();
			}

			return instance;
		}

		public DirectorySetting()
		{
			InitializeComponent();
			m_propDirectories.SelectedObject = ConfigObjects.directories;
		}

		// 点击OK
		private void OK_Click(object sender, EventArgs e)
		{
			// 保存设置
			ConfigObjects.saveDirectories();
			TableConverter.refreshTableTree();
			instance.Hide();
		}

		// 点击取消
		private void Cancel_Click(object sender, EventArgs e)
		{
			// 恢复原样
			ConfigObjects.loadDirectories();
			TableConverter.refreshTableTree();
			instance.Hide();
		}
	}
}
