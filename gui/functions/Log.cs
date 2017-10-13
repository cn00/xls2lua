using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameManager.ui;

namespace GameManager.functions
{
	class Log
	{
		public static List<Object> abs = new List<Object>();
		public static void info(string strInfo) 
		{
			switch (Program.PROGRAM_TYPE)
			{
				case Program.E_MODE_TYPE.MODE_TYPE_CONSOLE:
					Console.WriteLine(strInfo);
					break;
				case Program.E_MODE_TYPE.MODE_TYPE_WINFORM:
					MainWindow.getInstance().writeLine(strInfo);
					break;
			}
		}
	}
}
