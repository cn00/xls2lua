using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameManager.ui;
using GameManager.functions;
using GameManager.config;
using System.IO;
using System.Windows.Forms;
using XlsToLua;
using System.Data;
using GameManager.functions.io;
using System.Data.OleDb;

namespace GameManager.tools
{
    class TableConverter
    {
        public static List<FileInfo> m_lstTableInfo = new List<FileInfo>();

        public static void loadFile()
        {

            string strPath = ConfigObjects.directories.共用表输入路径;
            DirectoryInfo TheFolder = new DirectoryInfo(strPath);
            IEnumerable<string> files = new List<string>();
            files = System.IO.Directory.EnumerateFiles(strPath, "", System.IO.SearchOption.TopDirectoryOnly);
            m_lstTableInfo.Clear();

            try
            {
                foreach(FileInfo file in TheFolder.GetFiles("*.xls"))
                {
                    m_lstTableInfo.Add(file);
                }
            }
            catch(System.Exception ex)
            {
                strPath = "";
                Log.info("目录错误：" + ex.Message);
            }
        }

        public static void startConvert(string cilckName, bool isClientNeed, bool isServerNeed, int number)
        {

            var outDir = new DirectoryInfo(ConfigObjects.directories.客户端表输出路径);
            if(!outDir.Exists)
            {
                outDir.Create();
            }
            Log.info("客户端输出目录：" + outDir.FullName);

            outDir = new DirectoryInfo(ConfigObjects.directories.服务器表输出路径);
            if(!outDir.Exists)
            {
                outDir.Create();
            }
            Log.info("服务器输出目录：" + outDir.FullName);

            // 开始转换
            foreach(FileInfo info in m_lstTableInfo)
            {
                if(cilckName != "" && cilckName == info.Name)
                {
                    string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
                         + "Data Source=" + info.FullName
                         + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    OleDbConnection conn = new OleDbConnection(strConn);
                    conn.Open();

                    DataTable tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    for(int i = 0; i < 1/*tables.Rows.Count*/; i += 2)
                    {
                        DataRow drow = tables.Rows[i];
                        string sheetname = drow["TABLE_NAME"].ToString();
                        Log.info("开始转换表【" + sheetname + "】...");

                        DataTable ds = new DataTable();
                        string strcom = "select * from [" + sheetname + "]";
                        OleDbDataAdapter odda = new OleDbDataAdapter(strcom, conn);
                        odda.Fill(ds);

                        // 输出客户端
                        if(isClientNeed)
                        {
                            if(LuaWriter.writeLua(sheetname.Replace("$", ""), ds, ConfigObjects.directories.客户端表输出路径))
                            {
                            }
                            else
                            {
                                Log.info("【" + sheetname + "】表转换失败");
                            }
                        }

                        // 输出服务器
                        if(isServerNeed)
                        {
                            if(JsonWriter.writeJson(sheetname.Replace("$", ""), ds, ConfigObjects.directories.服务器表输出路径))
                            {
                            }
                            else
                            {
                                Log.info("【" + sheetname + "】表转换失败");
                            }
                        }
                    }
                }
            }
        }

        public static void refreshTableTree()
        {
            TableConverter.loadFile();
            TreeNode RootNode = new TreeNode("表结构");
            RootNode.Nodes.Clear();
            RootNode.Expand();

            foreach(FileInfo info in m_lstTableInfo)
            {
                TreeNode node = new TreeNode(info.Name);
                node.Nodes.Add("服务器");
                node.Nodes.Add("客户端");
                RootNode.Nodes.Add(node);
            }

            if(RootNode.Nodes.Count == 0)
            {
                RootNode.Nodes.Add("(空)");
            }
            MainWindow.getInstance().refreshTreeView(RootNode);
        }
    }
}