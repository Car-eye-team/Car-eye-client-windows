namespace CarEyeMap
{
	partial class WebMap
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
			this.wbMap = new System.Windows.Forms.WebBrowser();
			this.lblLoading = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// wbMap
			// 
			this.wbMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbMap.IsWebBrowserContextMenuEnabled = false;
			this.wbMap.Location = new System.Drawing.Point(0, 0);
			this.wbMap.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbMap.Name = "wbMap";
			this.wbMap.ScrollBarsEnabled = false;
			this.wbMap.Size = new System.Drawing.Size(600, 400);
			this.wbMap.TabIndex = 1;
			this.wbMap.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbMap_DocumentCompleted);
			this.wbMap.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.wbMap_PreviewKeyDown);
			// 
			// lblLoading
			// 
			this.lblLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblLoading.AutoSize = true;
			this.lblLoading.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblLoading.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblLoading.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.lblLoading.Location = new System.Drawing.Point(212, 185);
			this.lblLoading.Name = "lblLoading";
			this.lblLoading.Padding = new System.Windows.Forms.Padding(5);
			this.lblLoading.Size = new System.Drawing.Size(176, 31);
			this.lblLoading.TabIndex = 2;
			this.lblLoading.Text = "地图载入中，请稍后...";
			this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLoading.Paint += new System.Windows.Forms.PaintEventHandler(this.lblLoading_Paint);
			// 
			// WebMap
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.lblLoading);
			this.Controls.Add(this.wbMap);
			this.Name = "WebMap";
			this.Size = new System.Drawing.Size(600, 400);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.WebBrowser wbMap;
		private System.Windows.Forms.Label lblLoading;
	}
}
