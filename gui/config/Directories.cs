using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using GameManager.functions;
using System.Drawing.Design;
using System.Reflection;

namespace GameManager.config
{
	public class Directories
	{
		//[CategoryAttribute("表路径"), DescriptionAttribute("服务器表的输入路径"), Editor(typeof(PropertyGridFileSelector), typeof(UITypeEditor))]
		//// 设置服务器表输入路径
		//public string 服务器表输入路径
		//{
		//	get;
		//	set;
		//}
		//[CategoryAttribute("表路径"), DescriptionAttribute("客户端表的输入路径"), Editor(typeof(PropertyGridFileSelector), typeof(UITypeEditor))]
		//// 设置客户端表输入路径
		//public string 客户端表输入路径
		//{
		//	get;
		//	set;
		//}
		[CategoryAttribute("表路径"), DescriptionAttribute("源表的输入路径"), Editor(typeof(PropertyGridFileSelector), typeof(UITypeEditor))]
		// 设置共用表输入路径
		public string 共用表输入路径
		{
			get;
			set;
		}

		[CategoryAttribute("表路径"), DescriptionAttribute("服务器表的输出路径"), Editor(typeof(PropertyGridFileSelector), typeof(UITypeEditor))]
		// 设置服务器表输出路径
		public string 服务器表输出路径
		{
			get;
			set;
		}
		[CategoryAttribute("表路径"), DescriptionAttribute("客户端表的输出路径"), Editor(typeof(PropertyGridFileSelector), typeof(UITypeEditor))]
		// 设置客户端表输出路径
		public string 客户端表输出路径
		{
			get;
			set;
		}

// 		[CategoryAttribute("版本路径"), DescriptionAttribute("客户端版本路径"), Editor(typeof(PropertyGridFileSelector), typeof(UITypeEditor))]
// 		// 设置客户端表输出路径
// 		public string 客户端版本路径
// 		{
// 			get;
// 			set;
// 		}
// 		[CategoryAttribute("版本路径"), DescriptionAttribute("服务器版本路径"), Editor(typeof(PropertyGridFileSelector), typeof(UITypeEditor))]
// 		// 设置客户端表输出路径
// 		public string 服务器版本路径
// 		{
// 			get;
// 			set;
// 		}
// 		[CategoryAttribute("版本路径"), DescriptionAttribute("客户端更新路径"), Editor(typeof(PropertyGridFileSelector), typeof(UITypeEditor))]
// 		// 设置客户端表输出路径
// 		public string 客户端更新路径
// 		{
// 			get;
// 			set;
// 		}
// 		[CategoryAttribute("版本路径"), DescriptionAttribute("服务器更新路径"), Editor(typeof(PropertyGridFileSelector), typeof(UITypeEditor))]
// 		// 设置客户端表输出路径
// 		public string 服务器更新路径
// 		{
// 			get;
// 			set;
// 		}
	}
}