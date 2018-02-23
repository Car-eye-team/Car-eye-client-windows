namespace CarEyeClient
{
	partial class FrmDVR
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDVR));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.btnFull = new System.Windows.Forms.ToolStripButton();
			this.btnFour = new System.Windows.Forms.ToolStripButton();
			this.btnSix = new System.Windows.Forms.ToolStripButton();
			this.btnEight = new System.Windows.Forms.ToolStripButton();
			this.btnNine = new System.Windows.Forms.ToolStripButton();
			this.btnSixteen = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.lblInfo = new System.Windows.Forms.ToolStripLabel();
			this.pnlBase = new System.Windows.Forms.Panel();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.BackColor = System.Drawing.Color.DarkCyan;
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFull,
            this.btnFour,
            this.btnSix,
            this.btnEight,
            this.btnNine,
            this.btnSixteen,
            this.toolStripSeparator1,
            this.lblInfo});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(912, 25);
			this.toolStrip.TabIndex = 0;
			// 
			// btnFull
			// 
			this.btnFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnFull.Image = global::CarEyeClient.Properties.Resources._1;
			this.btnFull.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFull.Name = "btnFull";
			this.btnFull.Size = new System.Drawing.Size(23, 22);
			this.btnFull.Text = "全 屏";
			this.btnFull.Click += new System.EventHandler(this.btnLayout_Click);
			// 
			// btnFour
			// 
			this.btnFour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnFour.Image = global::CarEyeClient.Properties.Resources._4;
			this.btnFour.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFour.Name = "btnFour";
			this.btnFour.Size = new System.Drawing.Size(23, 22);
			this.btnFour.Text = "4分屏";
			this.btnFour.Click += new System.EventHandler(this.btnLayout_Click);
			// 
			// btnSix
			// 
			this.btnSix.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSix.Image = global::CarEyeClient.Properties.Resources._6;
			this.btnSix.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSix.Name = "btnSix";
			this.btnSix.Size = new System.Drawing.Size(23, 22);
			this.btnSix.Text = "6分屏";
			this.btnSix.Click += new System.EventHandler(this.btnLayout_Click);
			// 
			// btnEight
			// 
			this.btnEight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEight.Image = global::CarEyeClient.Properties.Resources._8;
			this.btnEight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEight.Name = "btnEight";
			this.btnEight.Size = new System.Drawing.Size(23, 22);
			this.btnEight.Text = "8分屏";
			this.btnEight.Click += new System.EventHandler(this.btnLayout_Click);
			// 
			// btnNine
			// 
			this.btnNine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNine.Image = global::CarEyeClient.Properties.Resources._9;
			this.btnNine.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNine.Name = "btnNine";
			this.btnNine.Size = new System.Drawing.Size(23, 22);
			this.btnNine.Text = "9分屏";
			this.btnNine.Click += new System.EventHandler(this.btnLayout_Click);
			// 
			// btnSixteen
			// 
			this.btnSixteen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSixteen.Image = global::CarEyeClient.Properties.Resources._16;
			this.btnSixteen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSixteen.Name = "btnSixteen";
			this.btnSixteen.Size = new System.Drawing.Size(23, 22);
			this.btnSixteen.Text = "16分屏";
			this.btnSixteen.Click += new System.EventHandler(this.btnLayout_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// lblInfo
			// 
			this.lblInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(12, 22);
			this.lblInfo.Text = " ";
			// 
			// pnlBase
			// 
			this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBase.Location = new System.Drawing.Point(0, 25);
			this.pnlBase.Name = "pnlBase";
			this.pnlBase.Size = new System.Drawing.Size(912, 549);
			this.pnlBase.TabIndex = 1;
			// 
			// FrmDVR
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.ClientSize = new System.Drawing.Size(912, 574);
			this.CloseButton = false;
			this.CloseButtonVisible = false;
			this.Controls.Add(this.pnlBase);
			this.Controls.Add(this.toolStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmDVR";
			this.Text = "视频预览";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDVR_FormClosing);
			this.Load += new System.EventHandler(this.FrmDVR_Load);
			this.SizeChanged += new System.EventHandler(this.FrmDVR_SizeChanged);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton btnFull;
		private System.Windows.Forms.ToolStripButton btnFour;
		private System.Windows.Forms.ToolStripButton btnSix;
		private System.Windows.Forms.ToolStripButton btnEight;
		private System.Windows.Forms.ToolStripButton btnNine;
		private System.Windows.Forms.ToolStripButton btnSixteen;
		private System.Windows.Forms.Panel pnlBase;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel lblInfo;
	}
}
