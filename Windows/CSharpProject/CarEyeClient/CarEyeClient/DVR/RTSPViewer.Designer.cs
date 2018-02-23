namespace CarEyeClient.DVR
{
	partial class RTSPViewer
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

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RTSPViewer));
			this.pnlBase = new System.Windows.Forms.Panel();
			this.lblView = new System.Windows.Forms.Label();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.btnPlay = new System.Windows.Forms.ToolStripButton();
			this.btnScreenShot = new System.Windows.Forms.ToolStripButton();
			this.lblInfo = new System.Windows.Forms.ToolStripLabel();
			this.btnRecord = new System.Windows.Forms.ToolStripButton();
			this.btnSound = new System.Windows.Forms.ToolStripButton();
			this.pnlBase.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlBase
			// 
			this.pnlBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlBase.BackColor = System.Drawing.SystemColors.Control;
			this.pnlBase.Controls.Add(this.lblView);
			this.pnlBase.Controls.Add(this.toolStrip);
			this.pnlBase.Location = new System.Drawing.Point(1, 1);
			this.pnlBase.Name = "pnlBase";
			this.pnlBase.Size = new System.Drawing.Size(398, 298);
			this.pnlBase.TabIndex = 0;
			// 
			// lblView
			// 
			this.lblView.BackColor = System.Drawing.Color.Black;
			this.lblView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblView.Font = new System.Drawing.Font("宋体", 10.5F);
			this.lblView.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lblView.Location = new System.Drawing.Point(0, 25);
			this.lblView.Name = "lblView";
			this.lblView.Size = new System.Drawing.Size(398, 273);
			this.lblView.TabIndex = 1;
			this.lblView.Text = "无 图 像 ...";
			this.lblView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblView.Click += new System.EventHandler(this.lblView_Click);
			this.lblView.DoubleClick += new System.EventHandler(this.lblView_DoubleClick);
			// 
			// toolStrip
			// 
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPlay,
            this.btnScreenShot,
            this.lblInfo,
            this.btnRecord,
            this.btnSound});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(398, 25);
			this.toolStrip.TabIndex = 0;
			// 
			// btnPlay
			// 
			this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnPlay.Enabled = false;
			this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
			this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPlay.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(40, 22);
			this.btnPlay.Text = "播 放";
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// btnScreenShot
			// 
			this.btnScreenShot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnScreenShot.Enabled = false;
			this.btnScreenShot.Image = ((System.Drawing.Image)(resources.GetObject("btnScreenShot.Image")));
			this.btnScreenShot.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnScreenShot.Name = "btnScreenShot";
			this.btnScreenShot.Size = new System.Drawing.Size(40, 22);
			this.btnScreenShot.Text = "截 图";
			this.btnScreenShot.Click += new System.EventHandler(this.btnScreenShot_Click);
			// 
			// lblInfo
			// 
			this.lblInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.lblInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(126, 22);
			this.lblInfo.Text = "13824512354-驾驶员";
			// 
			// btnRecord
			// 
			this.btnRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRecord.Enabled = false;
			this.btnRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord.Image")));
			this.btnRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRecord.Name = "btnRecord";
			this.btnRecord.Size = new System.Drawing.Size(40, 22);
			this.btnRecord.Text = "录 像";
			this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
			// 
			// btnSound
			// 
			this.btnSound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnSound.Enabled = false;
			this.btnSound.Image = ((System.Drawing.Image)(resources.GetObject("btnSound.Image")));
			this.btnSound.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSound.Name = "btnSound";
			this.btnSound.Size = new System.Drawing.Size(40, 22);
			this.btnSound.Text = "声 音";
			this.btnSound.Click += new System.EventHandler(this.btnSound_Click);
			// 
			// RTSPViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Firebrick;
			this.Controls.Add(this.pnlBase);
			this.Name = "RTSPViewer";
			this.Size = new System.Drawing.Size(400, 300);
			this.pnlBase.ResumeLayout(false);
			this.pnlBase.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlBase;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton btnPlay;
		private System.Windows.Forms.ToolStripButton btnRecord;
		private System.Windows.Forms.ToolStripButton btnScreenShot;
		private System.Windows.Forms.ToolStripLabel lblInfo;
		private System.Windows.Forms.Label lblView;
		private System.Windows.Forms.ToolStripButton btnSound;
	}
}
