using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameManager.functions;
using XlsToLua;
using GameManager.config;
using GameManager.tools;

namespace GameManager.ui
{

	public partial class MainWindow : Form
	{
        private static MainWindow instance = null;
        public static RecordClick recordClick = new RecordClick();

		public static MainWindow getInstance()
		{
			if (instance == null)
			{
				instance = new MainWindow();
			}
			return instance;
		}

		public MainWindow()
		{
			InitializeComponent();
			m_winConsole.HideSelection = false;
		}

		public void writeLine(string strInfo) 
		{
			m_winConsole.AppendText(DateTime.Now + " ");
			m_winConsole.AppendText(strInfo + "\n");
		}

        
		public void refreshTreeView(TreeNode node)
		{
			m_treeView.CheckBoxes = true;
			m_treeView.Nodes.Clear();
			m_treeView.Nodes.Add(node);
		}

		// 按钮：表转换
		private void m_btnConvert_Click(object sender, EventArgs e)
		{
            bool isEmptyTable = true;            //是否为空表
            TreeNode nodes = m_treeView.Nodes[0];//头
            Log.info("开始转换！");
            int number = -1;                     //表示第几个需要转
			foreach (TreeNode node in nodes.Nodes)
			{
				number++;
				if (node.Checked)
				{
                    
					TableConverter.startConvert(node.Text,node.Nodes[1].Checked, node.Nodes[0].Checked, number);
					isEmptyTable = false;
				}
			}
            if (isEmptyTable)
                Log.info("请选择需要转换的表！");
            else
                Log.info("转换完成！");
		}

		// 按钮：表路径设置
		private void m_btnSetDirectory_Click(object sender, EventArgs e)
		{
			DirectorySetting.getInstance().ShowDialog();
		}

		//  按钮：刷新表
		private void m_btnRefresh_Click(object sender, EventArgs e)
		{
			TableConverter.refreshTableTree();
		}

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            TreeNode nodes = m_treeView.Nodes[0];//头
            if (nodes.Checked)
            {
                recordClick.writeRecordClick(nodes.Text , 0,  true);
                int nLevel = 0;
                foreach (TreeNode nodeMiddle in nodes.Nodes)
                {
                    nLevel++;
                    if (nodeMiddle.Checked)
                    {
                        recordClick.writeRecordClick(nodeMiddle.Text, nLevel, true);
                        foreach (TreeNode node in nodeMiddle.Nodes)
                        {
                            if (node.Checked)
                            {
                                recordClick.writeRecordClick(node.Text, nLevel, false);
                            }
                        }
                    }
                }
            }else
            {
                recordClick.ClearXML();
            }


        }


        public void DetermineClick()
        {
            TreeNode nodes = m_treeView.Nodes[0];//头

            nodes.Checked = recordClick.readRecordClick(nodes.Text);
            if (!nodes.Checked)
            {
                return;
            }
            foreach (TreeNode node in nodes.Nodes)
            {
                if (recordClick.readRecordClick(node.Text))
                {
                    node.Checked = true;
                    foreach (TreeNode _node in node.Nodes)
                    {
                        if( recordClick.readRecordClick(_node.Text , node.Text , true) )
                        {
                            _node.Checked = true;
                        }
                    }
                }
            }

        }



	}
}