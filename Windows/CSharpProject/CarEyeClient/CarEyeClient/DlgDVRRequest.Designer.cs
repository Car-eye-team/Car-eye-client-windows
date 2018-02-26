namespace CarEyeClient
{
	partial class DlgDVRRequest
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
			this.txtTerminalId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.cboChn = new System.Windows.Forms.ComboBox();
			this.errPrv = new System.Windows.Forms.ErrorProvider(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.txtSvrIp = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.nudPort = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.errPrv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
			this.SuspendLayout();
			// 
			// txtTerminalId
			// 
			this.txtTerminalId.Location = new System.Drawing.Point(122, 24);
			this.txtTerminalId.MaxLength = 20;
			this.txtTerminalId.Name = "txtTerminalId";
			this.txtTerminalId.Size = new System.Drawing.Size(161, 21);
			this.txtTerminalId.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(57, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "终端编号:";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(210, 173);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 31);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "取 消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOk.Location = new System.Drawing.Point(78, 173);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 31);
			this.btnOk.TabIndex = 8;
			this.btnOk.Text = "开 启";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(57, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "视频通道:";
			// 
			// cboChn
			// 
			this.cboChn.FormattingEnabled = true;
			this.cboChn.Location = new System.Drawing.Point(122, 61);
			this.cboChn.Name = "cboChn";
			this.cboChn.Size = new System.Drawing.Size(161, 20);
			this.cboChn.TabIndex = 3;
			// 
			// errPrv
			// 
			this.errPrv.ContainerControl = this;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(33, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "视频服务器IP:";
			// 
			// txtSvrIp
			// 
			this.txtSvrIp.Location = new System.Drawing.Point(122, 98);
			this.txtSvrIp.MaxLength = 300;
			this.txtSvrIp.Name = "txtSvrIp";
			this.txtSvrIp.Size = new System.Drawing.Size(161, 21);
			this.txtSvrIp.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(45, 138);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 12);
			this.label4.TabIndex = 6;
			this.label4.Text = "服务器端口:";
			// 
			// nudPort
			// 
			this.nudPort.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.nudPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nudPort.Location = new System.Drawing.Point(122, 136);
			this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.nudPort.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudPort.Name = "nudPort";
			this.nudPort.Size = new System.Drawing.Size(84, 21);
			this.nudPort.TabIndex = 7;
			this.nudPort.Value = new decimal(new int[] {
            10554,
            0,
            0,
            0});
			// 
			// DlgDVRRequest
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(363, 216);
			this.Controls.Add(this.nudPort);
			this.Controls.Add(this.cboChn);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtSvrIp);
			this.Controls.Add(this.txtTerminalId);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgDVRRequest";
			this.Text = "开启实时预览";
			this.Load += new System.EventHandler(this.DlgDVRRequest_Load);
			((System.ComponentModel.ISupportInitialize)(this.errPrv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtTerminalId;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboChn;
		private System.Windows.Forms.ErrorProvider errPrv;
		private System.Windows.Forms.TextBox txtSvrIp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nudPort;
	}
}
