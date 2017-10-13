using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace GameManager.functions
{
    //读取的文件目录  
	class PropertyGridFileSelector : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
		{
			IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (edSvc != null)
			{
				// 可以打开任何特定的对话框  
				FolderBrowserDialog dialog = new FolderBrowserDialog();
				if (dialog.ShowDialog().Equals(DialogResult.OK))
				{
					return dialog.SelectedPath;
				}
			}

			return value;
		}
	}
}
