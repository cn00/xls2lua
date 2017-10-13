using System;
using System.Data;
using System.Globalization;
using System.IO;
using XlsToLua;
using System.Data;
using System.Data.OleDb;

namespace Convert
{
    class Program
    {
        private static void Main(string[] args)
        {
            string inPath = "";
            string outPath = "";
            if(args.Length < 2)
            {
                Console.Write("usage:\n\t Convert.exe [excel_输入目录] [lua_输出目录]\n输入后按 Enter 继续：\n");
                string s = Console.ReadLine();
                inPath = s.Split(' ')[0];
                outPath = s.Split(' ')[1];
            }
            else
            {
                inPath = args[0];
                outPath = args[1];
            }

            if(inPath != null && inPath != "")
            {
                if(outPath == null || outPath == "")
                    outPath = "out";

                long lastWriteTime = 0;
                long newWriteTime = 0;

                var outDir = new DirectoryInfo(outPath);
                if(!outDir.Exists)
                {
                    outDir.Create();
                }

                if(new FileInfo(inPath + @"\lastWriteTime").Exists && args.Length == 2)
                {
                    StreamReader reader = new StreamReader(inPath + @"\lastWriteTime");
                    if(reader != null)
                    {
                        string s = reader.ReadLine();
                        reader.Close();
                        //lastWriteTime = DateTime.ParseExact(s, "yyyy_MM_dd-HH_mm_ss", CultureInfo.InvariantCulture);
                        if(!long.TryParse(s, out lastWriteTime))
                        {
                            lastWriteTime = 0;
                        }
                    }
                }
                Console.WriteLine("上次转换时间：" + DateTime.FromFileTimeUtc(lastWriteTime));

                DirectoryInfo info = new DirectoryInfo(inPath);
                int errno = 0;
                foreach(FileInfo info2 in info.GetFiles("*.xls"))
                {
                    char[] separator = new char[] { '.' };
                    if(info2.LastWriteTime.ToFileTimeUtc() <= lastWriteTime)
                    {
                        Console.WriteLine(info2.LastWriteTime.ToString("yyyy_MM_dd-HH_mm_ss") + " 无需更新【" + info2.Name + "】");
                    }
                    else
                    {
                        if(info2.LastWriteTime.ToFileTimeUtc() > newWriteTime)
                        {
                            newWriteTime = info2.LastWriteTime.ToFileTimeUtc();
                        }
                        Console.WriteLine(info2.LastWriteTime.ToString("yyyy_MM_dd-HH_mm_ss") + " 开始转换【" + info2.Name + "】... ");

                        try
                        {
                            //Provider=Microsoft.Jet.OLEDB.4.0;这个是指办公软件
                            //Data Source=" + filepath + ";这是excel位置
                            //Extended Properties='Excel 8.0;IMEX=1'";这个是Excel的版本
                            //[Sheet1$]指的是Excel表中第一个工作薄

                            //string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" 
                            //    + "data source=" + info2.FullName 
                            //    + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
                            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
                                 + "Data Source=" + info2.FullName 
                                 + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                            OleDbConnection conn = new OleDbConnection(strConn);
                            conn.Open();

                            DataTable tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            for(int i = 0; i < 1/*tables.Rows.Count*/; i += 2)
                            {
                                DataRow drow = tables.Rows[i];
                                string sheetname = drow["TABLE_NAME"].ToString();
                                Console.Write("  " + sheetname);

                                DataTable ds = new DataTable();
                                string strcom = "select * from [" + sheetname + "]";
                                OleDbDataAdapter odda = new OleDbDataAdapter(strcom, conn);
                                odda.Fill(ds);

                                if(LuaWriter.writeLua(sheetname.Replace("$", ""), ds, outPath))
                                {
                                    Console.Write(" 成功\n");
                                }
                                else
                                {
                                    Console.Write(" 失败!!!!!!!!!\n");
                                    ++errno;
                                }
                            }
                            conn.Close();
                        }
                        catch(OleDbException e)
                        {
                            Console.Error.Write("错误信息：" + e.Message);
                        }
                    }
                } // for
                StreamWriter writer = new StreamWriter(inPath + @"\lastWriteTime", false);
                writer.Write(
                    newWriteTime
                //newWriteTime.ToString("yyyy_MM_dd-HH_mm_ss")
                );
                writer.Close();
                if(errno > 0)
                {
                    Console.WriteLine("转表 {0} 个错误，按 Enter 退出", errno);
                    Console.ReadLine();
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
