namespace CarEyeMap.Demo
{
	partial class FrmDemo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDemo));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.lblCursor = new System.Windows.Forms.ToolStripLabel();
			this.btnPan = new System.Windows.Forms.ToolStripButton();
			this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
			this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
			this.btnDistance = new System.Windows.Forms.ToolStripButton();
			this.btnArea = new System.Windows.Forms.ToolStripButton();
			this.btnMark = new System.Windows.Forms.ToolStripButton();
			this.btnRound = new System.Windows.Forms.ToolStripButton();
			this.btnRect = new System.Windows.Forms.ToolStripButton();
			this.btnPoly = new System.Windows.Forms.ToolStripButton();
			this.btnRoute = new System.Windows.Forms.ToolStripButton();
			this.btnShowRound = new System.Windows.Forms.ToolStripButton();
			this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
			this.btnSearch = new System.Windows.Forms.ToolStripButton();
			this.btnClear = new System.Windows.Forms.ToolStripButton();
			this.btnRefresh = new System.Windows.Forms.ToolStripButton();
			this.demoMap = new CarEyeMap.WebMap();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCursor,
            this.btnPan,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnDistance,
            this.btnArea,
            this.btnMark,
            this.btnRound,
            this.btnRect,
            this.btnPoly,
            this.btnRoute,
            this.btnShowRound,
            this.txtSearch,
            this.btnSearch,
            this.btnClear,
            this.btnRefresh});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1010, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// lblCursor
			// 
			this.lblCursor.AutoSize = false;
			this.lblCursor.Name = "lblCursor";
			this.lblCursor.Size = new System.Drawing.Size(150, 22);
			this.lblCursor.Text = "光标坐标";
			// 
			// btnPan
			// 
			this.btnPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnPan.Image = ((System.Drawing.Image)(resources.GetObject("btnPan.Image")));
			this.btnPan.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPan.Name = "btnPan";
			this.btnPan.Size = new System.Drawing.Size(36, 22);
			this.btnPan.Text = "漫游";
			this.btnPan.ToolTipText = "漫游";
			this.btnPan.Click += new System.EventHandler(this.btnPan_Click);
			// 
			// btnZoomIn
			// 
			this.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
			this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnZoomIn.Name = "btnZoomIn";
			this.btnZoomIn.Size = new System.Drawing.Size(36, 22);
			this.btnZoomIn.Text = "放大";
			this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
			// 
			// btnZoomOut
			// 
			this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
			this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnZoomOut.Name = "btnZoomOut";
			this.btnZoomOut.Size = new System.Drawing.Size(36, 22);
			this.btnZoomOut.Text = "缩小";
			this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
			// 
			// btnDistance
			// 
			this.btnDistance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnDistance.Image = ((System.Drawing.Image)(resources.GetObject("btnDistance.Image")));
			this.btnDistance.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDistance.Name = "btnDistance";
			this.btnDistance.Size = new System.Drawing.Size(36, 22);
			this.btnDistance.Text = "测距";
			this.btnDistance.Click += new System.EventHandler(this.btnDistance_Click);
			// 
			// btnArea
			// 
			this.btnArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnArea.Image = ((System.Drawing.Image)(resources.GetObject("btnArea.Image")));
			this.btnArea.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnArea.Name = "btnArea";
			this.btnArea.Size = new System.Drawing.Size(36, 22);
			this.btnArea.Text = "面积";
			this.btnArea.Click += new System.EventHandler(this.btnArea_Click);
			// 
			// btnMark
			// 
			this.btnMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnMark.Image = ((System.Drawing.Image)(resources.GetObject("btnMark.Image")));
			this.btnMark.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMark.Name = "btnMark";
			this.btnMark.Size = new System.Drawing.Size(36, 22);
			this.btnMark.Text = "标注";
			this.btnMark.Click += new System.EventHandler(this.btnMark_Click);
			// 
			// btnRound
			// 
			this.btnRound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRound.Image = ((System.Drawing.Image)(resources.GetObject("btnRound.Image")));
			this.btnRound.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRound.Name = "btnRound";
			this.btnRound.Size = new System.Drawing.Size(60, 22);
			this.btnRound.Text = "绘制圆形";
			this.btnRound.Click += new System.EventHandler(this.btnRound_Click);
			// 
			// btnRect
			// 
			this.btnRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRect.Image = ((System.Drawing.Image)(resources.GetObject("btnRect.Image")));
			this.btnRect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRect.Name = "btnRect";
			this.btnRect.Size = new System.Drawing.Size(60, 22);
			this.btnRect.Text = "绘制矩形";
			this.btnRect.Click += new System.EventHandler(this.btnRect_Click);
			// 
			// btnPoly
			// 
			this.btnPoly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnPoly.Image = ((System.Drawing.Image)(resources.GetObject("btnPoly.Image")));
			this.btnPoly.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPoly.Name = "btnPoly";
			this.btnPoly.Size = new System.Drawing.Size(72, 22);
			this.btnPoly.Text = "绘制多边形";
			this.btnPoly.Click += new System.EventHandler(this.btnPoly_Click);
			// 
			// btnRoute
			// 
			this.btnRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRoute.Image = ((System.Drawing.Image)(resources.GetObject("btnRoute.Image")));
			this.btnRoute.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRoute.Name = "btnRoute";
			this.btnRoute.Size = new System.Drawing.Size(60, 22);
			this.btnRoute.Text = "绘制路线";
			this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
			// 
			// btnShowRound
			// 
			this.btnShowRound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnShowRound.Image = ((System.Drawing.Image)(resources.GetObject("btnShowRound.Image")));
			this.btnShowRound.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnShowRound.Name = "btnShowRound";
			this.btnShowRound.Size = new System.Drawing.Size(60, 22);
			this.btnShowRound.Text = "显示圆形";
			this.btnShowRound.Click += new System.EventHandler(this.btnShowRound_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(100, 25);
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// btnSearch
			// 
			this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(60, 22);
			this.btnSearch.Text = "清除搜索";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnClear
			// 
			this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
			this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(36, 22);
			this.btnClear.Text = "清空";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
			this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(36, 22);
			this.btnRefresh.Text = "刷新";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// demoMap
			// 
			this.demoMap.ApiURLs = null;
			this.demoMap.Default = ((CarEyeMap.Coordinate)(resources.GetObject("demoMap.Default")));
			this.demoMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.demoMap.JsCode = null;
			this.demoMap.Location = new System.Drawing.Point(0, 25);
			this.demoMap.Name = "demoMap";
			this.demoMap.Size = new System.Drawing.Size(1010, 593);
			this.demoMap.TabIndex = 3;
			this.demoMap.ExternalChanged += new CarEyeMap.MapExternalEventHandler(this.demoMap_ExternalChanged);
			this.demoMap.CursorMoved += new CarEyeMap.CursorMoveEventHandler(this.demoMap_CursorMoved);
			this.demoMap.LoadFinished += new System.EventHandler<CarEyeMap.LoadFinishedEventArgs>(this.demoMap_LoadFinished);
			this.demoMap.DrawedRound += new System.EventHandler<CarEyeMap.DrawedRoundEventArgs>(this.demoMap_DrawedRound);
			this.demoMap.DrawedPoly += new System.EventHandler<CarEyeMap.DrawedPolyEventArgs>(this.demoMap_DrawedPoly);
			// 
			// FrmDemo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1010, 618);
			this.Controls.Add(this.demoMap);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmDemo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "地图控件Demo";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel lblCursor;
		private System.Windows.Forms.ToolStripButton btnPan;
		private System.Windows.Forms.ToolStripButton btnZoomIn;
		private System.Windows.Forms.ToolStripButton btnZoomOut;
		private System.Windows.Forms.ToolStripButton btnDistance;
		private System.Windows.Forms.ToolStripButton btnArea;
		private System.Windows.Forms.ToolStripButton btnMark;
		private System.Windows.Forms.ToolStripButton btnRound;
		private System.Windows.Forms.ToolStripButton btnRect;
		private System.Windows.Forms.ToolStripButton btnPoly;
		private System.Windows.Forms.ToolStripButton btnRoute;
		private System.Windows.Forms.ToolStripButton btnShowRound;
		private System.Windows.Forms.ToolStripTextBox txtSearch;
		private System.Windows.Forms.ToolStripButton btnSearch;
		private System.Windows.Forms.ToolStripButton btnClear;
		private System.Windows.Forms.ToolStripButton btnRefresh;
		private WebMap demoMap;
	}
}

