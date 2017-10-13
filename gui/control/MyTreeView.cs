using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameManager.control
{
    public partial class MyTreeView : TreeView
    {
        public MyTreeView()
        {
            InitializeComponent();
        }
 
        protected override void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
        {
            base.OnNodeMouseDoubleClick(e);
            if (e.Node.IsExpanded)
            {
                e.Node.Collapse();
            }
            else
            {
                e.Node.Expand();
            }
        }
 
        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            base.OnAfterCheck(e);
            if (e.Action != TreeViewAction.Unknown)
            {
                SetChildNodes(e.Node, e.Node.Checked);
                SetParentNodes(e.Node, e.Node.Checked);
            }
        }
 
 
 
        private void SetParentNodes(TreeNode CurNode, bool Checked)
        {
            if (CurNode.Parent != null)
            {
                if (Checked)
                {
                    CurNode.Parent.Checked = Checked;
                    SetParentNodes(CurNode.Parent, Checked);
                }
                else
                {
                    bool ParFlag = false;
                    foreach (TreeNode tmp in CurNode.Parent.Nodes)
                    {
                        if (tmp.Checked)
                        {
                            ParFlag = true;
                            break;
                        }
                    }
                    CurNode.Parent.Checked = ParFlag;
                    SetParentNodes(CurNode.Parent, ParFlag);
                }
            }
        }
 
        private void SetChildNodes(TreeNode CurNode, bool Checked)
        {
            if (CurNode.Nodes != null)
            {
                foreach (TreeNode tmpNode in CurNode.Nodes)
                {
                    tmpNode.Checked = Checked;
                    SetChildNodes(tmpNode, Checked);
                }
            }
        }
 
 
 
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x203)
            {
                m.Result = IntPtr.Zero;
            }
            else
            {
                base.WndProc(ref m);
            }
        }



    }
}
