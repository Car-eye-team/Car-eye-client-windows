namespace CarEyeClient
{
	partial class FrmMap
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMap));
			this.toolMap = new System.Windows.Forms.ToolStrip();
			this.lblLocation = new System.Windows.Forms.ToolStripLabel();
			this.btnRefresh = new System.Windows.Forms.ToolStripButton();
			this.btnDrag = new System.Windows.Forms.ToolStripButton();
			this.btnDistance = new System.Windows.Forms.ToolStripButton();
			this.btnArea = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
			this.btnSearch = new System.Windows.Forms.ToolStripButton();
			this.btnClear = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnPlay = new System.Windows.Forms.ToolStripButton();
			this.btnStop = new System.Windows.Forms.ToolStripButton();
			this.wbMap = new CarEyeMap.WebMap();
			this.tmrPlay = new System.Windows.Forms.Timer(this.components);
			this.toolMap.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolMap
			// 
			this.toolMap.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLocation,
            this.btnRefresh,
            this.btnDrag,
            this.btnDistance,
            this.btnArea,
            this.toolStripSeparator1,
            this.txtSearch,
            this.btnSearch,
            this.btnClear,
            this.toolStripSeparator2,
            this.btnPlay,
            this.btnStop});
			this.toolMap.Location = new System.Drawing.Point(0, 0);
			this.toolMap.Name = "toolMap";
			this.toolMap.Size = new System.Drawing.Size(799, 25);
			this.toolMap.TabIndex = 0;
			// 
			// lblLocation
			// 
			this.lblLocation.AutoSize = false;
			this.lblLocation.Name = "lblLocation";
			this.lblLocation.Size = new System.Drawing.Size(150, 22);
			// 
			// btnRefresh
			// 
			this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
			this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(40, 22);
			this.btnRefresh.Text = "刷 新";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnDrag
			// 
			this.btnDrag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnDrag.Image = ((System.Drawing.Image)(resources.GetObject("btnDrag.Image")));
			this.btnDrag.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDrag.Name = "btnDrag";
			this.btnDrag.Size = new System.Drawing.Size(40, 22);
			this.btnDrag.Text = "拖 动";
			this.btnDrag.Click += new System.EventHandler(this.btnDrag_Click);
			// 
			// btnDistance
			// 
			this.btnDistance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnDistance.Image = ((System.Drawing.Image)(resources.GetObject("btnDistance.Image")));
			this.btnDistance.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDistance.Name = "btnDistance";
			this.btnDistance.Size = new System.Drawing.Size(40, 22);
			this.btnDistance.Text = "测 距";
			this.btnDistance.Click += new System.EventHandler(this.btnDistance_Click);
			// 
			// btnArea
			// 
			this.btnArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnArea.Image = ((System.Drawing.Image)(resources.GetObject("btnArea.Image")));
			this.btnArea.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnArea.Name = "btnArea";
			this.btnArea.Size = new System.Drawing.Size(40, 22);
			this.btnArea.Text = "面 积";
			this.btnArea.Click += new System.EventHandler(this.btnArea_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// txtSearch
			// 
			this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(140, 25);
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// btnSearch
			// 
			this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(40, 22);
			this.btnSearch.Text = "搜 索";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnClear
			// 
			this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
			this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(40, 22);
			this.btnClear.Text = "清 空";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// btnPlay
			// 
			this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
			this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(40, 22);
			this.btnPlay.Text = "播 放";
			this.btnPlay.Visible = false;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// btnStop
			// 
			this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
			this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(40, 22);
			this.btnStop.Text = "停 止";
			this.btnStop.Visible = false;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// wbMap
			// 
			this.wbMap.ApiURLs = null;
			this.wbMap.Default = ((CarEyeMap.Coordinate)(resources.GetObject("wbMap.Default")));
			this.wbMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbMap.EnableHashtable = true;
			this.wbMap.JsCode = null;
			this.wbMap.Location = new System.Drawing.Point(0, 25);
			this.wbMap.Name = "wbMap";
			this.wbMap.Size = new System.Drawing.Size(799, 485);
			this.wbMap.TabIndex = 1;
			this.wbMap.CursorMoved += new CarEyeMap.CursorMoveEventHandler(this.wbMap_CursorMoved);
			this.wbMap.LoadFinished += new System.EventHandler<CarEyeMap.LoadFinishedEventArgs>(this.wbMap_LoadFinished);
			// 
			// tmrPlay
			// 
			this.tmrPlay.Interval = 700;
			this.tmrPlay.Tick += new System.EventHandler(this.tmrPlay_Tick);
			// 
			// FrmMap
			// 
			this.AllowEndUserDocking = false;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 510);
			this.CloseButton = false;
			this.CloseButtonVisible = false;
			this.Controls.Add(this.wbMap);
			this.Controls.Add(this.toolMap);
			this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmMap";
			this.Text = "地图";
			this.toolMap.ResumeLayout(false);
			this.toolMap.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolMap;
		private CarEyeMap.WebMap wbMap;
		private System.Windows.Forms.ToolStripButton btnDrag;
		private System.Windows.Forms.ToolStripButton btnDistance;
		private System.Windows.Forms.ToolStripButton btnArea;
		private System.Windows.Forms.ToolStripButton btnRefresh;
		private System.Windows.Forms.ToolStripLabel lblLocation;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripTextBox txtSearch;
		private System.Windows.Forms.ToolStripButton btnSearch;
		private System.Windows.Forms.ToolStripButton btnClear;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnPlay;
		private System.Windows.Forms.ToolStripButton btnStop;
		private System.Windows.Forms.Timer tmrPlay;
	}
}