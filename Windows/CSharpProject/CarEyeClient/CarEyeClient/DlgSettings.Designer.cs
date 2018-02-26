namespace CarEyeClient
{
	partial class DlgSettings
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
			this.components = new System.ComponentModel.Container();
			this.nudDVRSvrPort = new System.Windows.Forms.NumericUpDown();
			this.txtDVRSvrIp = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSvrIp = new System.Windows.Forms.TextBox();
			this.nudSvrPort = new System.Windows.Forms.NumericUpDown();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.nudReportInterval = new System.Windows.Forms.NumericUpDown();
			this.errPrv = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.nudDVRSvrPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudSvrPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudReportInterval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errPrv)).BeginInit();
			this.SuspendLayout();
			// 
			// nudDVRSvrPort
			// 
			this.nudDVRSvrPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nudDVRSvrPort.Location = new System.Drawing.Point(111, 138);
			this.nudDVRSvrPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.nudDVRSvrPort.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudDVRSvrPort.Name = "nudDVRSvrPort";
			this.nudDVRSvrPort.Size = new System.Drawing.Size(84, 21);
			this.nudDVRSvrPort.TabIndex = 7;
			this.nudDVRSvrPort.Value = new decimal(new int[] {
            10554,
            0,
            0,
            0});
			// 
			// txtDVRSvrIp
			// 
			this.txtDVRSvrIp.Location = new System.Drawing.Point(111, 100);
			this.txtDVRSvrIp.MaxLength = 300;
			this.txtDVRSvrIp.Name = "txtDVRSvrIp";
			this.txtDVRSvrIp.Size = new System.Drawing.Size(161, 21);
			this.txtDVRSvrIp.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(34, 140);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 12);
			this.label4.TabIndex = 6;
			this.label4.Text = "服务器端口:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(22, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "视频服务器IP:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "通信服务器IP:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "通信服务器端口:";
			// 
			// txtSvrIp
			// 
			this.txtSvrIp.Location = new System.Drawing.Point(111, 20);
			this.txtSvrIp.MaxLength = 300;
			this.txtSvrIp.Name = "txtSvrIp";
			this.txtSvrIp.Size = new System.Drawing.Size(161, 21);
			this.txtSvrIp.TabIndex = 1;
			// 
			// nudSvrPort
			// 
			this.nudSvrPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nudSvrPort.Location = new System.Drawing.Point(111, 58);
			this.nudSvrPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.nudSvrPort.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudSvrPort.Name = "nudSvrPort";
			this.nudSvrPort.Size = new System.Drawing.Size(84, 21);
			this.nudSvrPort.TabIndex = 3;
			this.nudSvrPort.Value = new decimal(new int[] {
            801,
            0,
            0,
            0});
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(261, 238);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 31);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "取 消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOk.Location = new System.Drawing.Point(96, 238);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 31);
			this.btnOk.TabIndex = 10;
			this.btnOk.Text = "确 定";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(4, 181);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 12);
			this.label5.TabIndex = 8;
			this.label5.Text = "位置获取周期(s):";
			// 
			// nudReportInterval
			// 
			this.nudReportInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nudReportInterval.Location = new System.Drawing.Point(111, 179);
			this.nudReportInterval.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
			this.nudReportInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudReportInterval.Name = "nudReportInterval";
			this.nudReportInterval.Size = new System.Drawing.Size(84, 21);
			this.nudReportInterval.TabIndex = 9;
			this.nudReportInterval.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// errPrv
			// 
			this.errPrv.ContainerControl = this;
			// 
			// DlgSettings
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(432, 281);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.nudSvrPort);
			this.Controls.Add(this.nudReportInterval);
			this.Controls.Add(this.nudDVRSvrPort);
			this.Controls.Add(this.txtSvrIp);
			this.Controls.Add(this.txtDVRSvrIp);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgSettings";
			this.Text = "系统设置";
			this.Load += new System.EventHandler(this.DlgSettings_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudDVRSvrPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudSvrPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudReportInterval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errPrv)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown nudDVRSvrPort;
		private System.Windows.Forms.TextBox txtDVRSvrIp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSvrIp;
		private System.Windows.Forms.NumericUpDown nudSvrPort;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown nudReportInterval;
		private System.Windows.Forms.ErrorProvider errPrv;
	}
}
