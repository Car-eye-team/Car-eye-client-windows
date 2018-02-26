namespace CarEyeClient
{
	partial class FrmMain
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
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.dockMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.mnuSysSet = new System.Windows.Forms.ToolStripMenuItem();
			this.statusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// dockMain
			// 
			this.dockMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dockMain.DefaultFloatWindowSize = new System.Drawing.Size(800, 600);
			this.dockMain.Location = new System.Drawing.Point(0, 0);
			this.dockMain.Name = "dockMain";
			this.dockMain.Size = new System.Drawing.Size(963, 657);
			this.dockMain.TabIndex = 0;
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
			this.statusBar.Location = new System.Drawing.Point(0, 659);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(963, 23);
			this.statusBar.TabIndex = 6;
			this.statusBar.Text = "statusStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSysSet});
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(69, 21);
			this.toolStripDropDownButton1.Text = "系统菜单";
			// 
			// mnuSysSet
			// 
			this.mnuSysSet.Name = "mnuSysSet";
			this.mnuSysSet.Size = new System.Drawing.Size(152, 22);
			this.mnuSysSet.Text = "系统设置";
			this.mnuSysSet.Click += new System.EventHandler(this.mnuSysSet_Click);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.ClientSize = new System.Drawing.Size(963, 682);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.dockMain);
			this.IsMdiContainer = true;
			this.Name = "FrmMain";
			this.Text = "车辆监控系统";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private WeifenLuo.WinFormsUI.Docking.DockPanel dockMain;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem mnuSysSet;
	}
}
