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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMap));
			this.toolMap = new System.Windows.Forms.ToolStrip();
			this.wbMap = new CarEyeMap.WebMap();
			this.SuspendLayout();
			// 
			// toolMap
			// 
			this.toolMap.Location = new System.Drawing.Point(0, 0);
			this.toolMap.Name = "toolMap";
			this.toolMap.Size = new System.Drawing.Size(799, 25);
			this.toolMap.TabIndex = 0;
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
			this.wbMap.LoadFinished += new System.EventHandler<CarEyeMap.LoadFinishedEventArgs>(this.wbMap_LoadFinished);
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
			this.Load += new System.EventHandler(this.FrmMap_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolMap;
		private CarEyeMap.WebMap wbMap;
	}
}