namespace GameManager.ui
{
	partial class MainWindow
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_btnConvert = new System.Windows.Forms.ToolStripButton();
            this.m_btnPath = new System.Windows.Forms.ToolStripButton();
            this.m_btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.m_winConsole = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_treeView = new GameManager.control.MyTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(494, 467);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnConvert,
            this.m_btnPath,
            this.m_btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(494, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Click += new System.EventHandler(this.m_btnConvert_Click);
            // 
            // m_btnConvert
            // 
            this.m_btnConvert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_btnConvert.Image = ((System.Drawing.Image)(resources.GetObject("m_btnConvert.Image")));
            this.m_btnConvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnConvert.Name = "m_btnConvert";
            this.m_btnConvert.Size = new System.Drawing.Size(36, 22);
            this.m_btnConvert.Text = "转换";
            this.m_btnConvert.Click += new System.EventHandler(this.m_btnConvert_Click);
            // 
            // m_btnPath
            // 
            this.m_btnPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_btnPath.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPath.Image")));
            this.m_btnPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnPath.Name = "m_btnPath";
            this.m_btnPath.Size = new System.Drawing.Size(36, 22);
            this.m_btnPath.Text = "路径";
            this.m_btnPath.Click += new System.EventHandler(this.m_btnSetDirectory_Click);
            // 
            // m_btnRefresh
            // 
            this.m_btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("m_btnRefresh.Image")));
            this.m_btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnRefresh.Name = "m_btnRefresh";
            this.m_btnRefresh.Size = new System.Drawing.Size(36, 22);
            this.m_btnRefresh.Text = "刷新";
            this.m_btnRefresh.Click += new System.EventHandler(this.m_btnRefresh_Click);
            // 
            // m_winConsole
            // 
            this.m_winConsole.BackColor = System.Drawing.Color.White;
            this.m_winConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_winConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_winConsole.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.m_winConsole.Location = new System.Drawing.Point(0, 0);
            this.m_winConsole.Name = "m_winConsole";
            this.m_winConsole.ReadOnly = true;
            this.m_winConsole.Size = new System.Drawing.Size(494, 140);
            this.m_winConsole.TabIndex = 0;
            this.m_winConsole.Text = "";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.m_treeView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_winConsole);
            this.splitContainer2.Size = new System.Drawing.Size(494, 438);
            this.splitContainer2.SplitterDistance = 294;
            this.splitContainer2.TabIndex = 2;
            // 
            // m_treeView
            // 
            this.m_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_treeView.Location = new System.Drawing.Point(0, 0);
            this.m_treeView.Name = "m_treeView";
            this.m_treeView.Size = new System.Drawing.Size(494, 294);
            this.m_treeView.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 467);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "转表工具";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton m_btnConvert;
        private System.Windows.Forms.ToolStripButton m_btnPath;
        private System.Windows.Forms.ToolStripButton m_btnRefresh;
        private control.MyTreeView m_treeView;
        private System.Windows.Forms.RichTextBox m_winConsole;
        private System.Windows.Forms.SplitContainer splitContainer2;

	}
}