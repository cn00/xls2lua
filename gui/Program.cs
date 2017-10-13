using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GameManager.ui;
using GameManager.tools;
using GameManager.config;
using System.Diagnostics;
using System.Runtime.InteropServices;
using GameManager.functions;

namespace GameManager
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		/// 




		public enum E_MODE_TYPE
		{
			MODE_TYPE_CONSOLE,
			MODE_TYPE_WINFORM
		}

		[DllImport("kernel32.dll")]
		static extern bool AttachConsole(int dwProcessId);
		private const int ATTACH_PARENT_PROCESS = -1;
        public static E_MODE_TYPE PROGRAM_TYPE;
        //  使确认点击的函数只会调用一次
        private static bool _isOnlyOne = true; 

		public delegate void LogCallBack(string sMsg);
        //[DllImport("versionDiff.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int generateVersion(string newVersionFile);
        //[DllImport("versionDiff.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int regLogCallBack(LogCallBack callBack);

		[STAThread]
		static void Main(string[] args)
		{
			// 初始化
			initalize();

			// 表示有参数
			if (args.Length > 0)
			{
				switch (args[0])
				{
					// 表转换模式
					case "-convert":
						modeTableConvert();
						break;
					default:
						modeNormal();
						break;
				}
			}
			else
			{
				modeNormal();
			}
			
		}

		static void initalize()
		{
			ConfigObjects.loadAllConfig();
			// 注册C++的消息回调函数
			LogCallBack callBack = new LogCallBack(Log.info);
			// regLogCallBack(callBack);
		}

		// 正常模式
		static void modeNormal()
		{
			PROGRAM_TYPE = E_MODE_TYPE.MODE_TYPE_WINFORM;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            TableConverter.refreshTableTree();


            if (Program._isOnlyOne)
            {
                MainWindow.getInstance().DetermineClick();
                Program._isOnlyOne = false;
            }

			Application.Run(MainWindow.getInstance());
		}

		// TableConvert模式
		static void modeTableConvert()
		{
			PROGRAM_TYPE = E_MODE_TYPE.MODE_TYPE_CONSOLE;
			// redirect console output to parent process;
            // must be before any calls to Console.WriteLine()
            AttachConsole(ATTACH_PARENT_PROCESS);
			// TableConverter.startConvert();
		}
	}
}
