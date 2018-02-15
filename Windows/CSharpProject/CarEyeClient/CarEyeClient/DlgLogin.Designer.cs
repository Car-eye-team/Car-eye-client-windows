namespace CarEyeClient
{
	partial class DlgLogin
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSvrIp = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.nudPort = new System.Windows.Forms.NumericUpDown();
			this.pgrLogin = new System.Windows.Forms.ProgressBar();
			this.lblTip = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnCancle = new System.Windows.Forms.Button();
			this.loginWorker = new System.ComponentModel.BackgroundWorker();
			this.errPrv = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errPrv)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(98, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "用户名:";
			// 
			// txtName
			// 
			this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Location = new System.Drawing.Point(151, 28);
			this.txtName.MaxLength = 30;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(145, 21);
			this.txtName.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(104, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "密 码:";
			// 
			// txtPwd
			// 
			this.txtPwd.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPwd.Location = new System.Drawing.Point(151, 65);
			this.txtPwd.MaxLength = 50;
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '#';
			this.txtPwd.Size = new System.Drawing.Size(145, 21);
			this.txtPwd.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 118);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "服务器IP:";
			// 
			// txtSvrIp
			// 
			this.txtSvrIp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.txtSvrIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSvrIp.Location = new System.Drawing.Point(81, 115);
			this.txtSvrIp.MaxLength = 255;
			this.txtSvrIp.Name = "txtSvrIp";
			this.txtSvrIp.Size = new System.Drawing.Size(145, 21);
			this.txtSvrIp.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(247, 118);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 12);
			this.label4.TabIndex = 6;
			this.label4.Text = "端 口:";
			// 
			// nudPort
			// 
			this.nudPort.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.nudPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nudPort.Location = new System.Drawing.Point(295, 116);
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
            801,
            0,
            0,
            0});
			// 
			// pgrLogin
			// 
			this.pgrLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pgrLogin.Location = new System.Drawing.Point(2, 160);
			this.pgrLogin.Name = "pgrLogin";
			this.pgrLogin.Size = new System.Drawing.Size(390, 23);
			this.pgrLogin.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pgrLogin.TabIndex = 8;
			// 
			// lblTip
			// 
			this.lblTip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTip.BackColor = System.Drawing.Color.Transparent;
			this.lblTip.Location = new System.Drawing.Point(15, 144);
			this.lblTip.Name = "lblTip";
			this.lblTip.Size = new System.Drawing.Size(362, 12);
			this.lblTip.TabIndex = 9;
			this.lblTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnLogin
			// 
			this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnLogin.Location = new System.Drawing.Point(70, 192);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 34);
			this.btnLogin.TabIndex = 10;
			this.btnLogin.Text = "登 陆";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// btnCancle
			// 
			this.btnCancle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancle.Location = new System.Drawing.Point(250, 192);
			this.btnCancle.Name = "btnCancle";
			this.btnCancle.Size = new System.Drawing.Size(75, 34);
			this.btnCancle.TabIndex = 11;
			this.btnCancle.Text = "取 消";
			this.btnCancle.UseVisualStyleBackColor = true;
			// 
			// loginWorker
			// 
			this.loginWorker.WorkerReportsProgress = true;
			this.loginWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loginWorker_DoWork);
			this.loginWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.loginWorker_ProgressChanged);
			// 
			// errPrv
			// 
			this.errPrv.ContainerControl = this;
			// 
			// DlgLogin
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.CancelButton = this.btnCancle;
			this.ClientSize = new System.Drawing.Size(394, 238);
			this.Controls.Add(this.btnCancle);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.lblTip);
			this.Controls.Add(this.nudPort);
			this.Controls.Add(this.txtPwd);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtSvrIp);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pgrLogin);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgLogin";
			this.Text = "登陆窗口";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgLogin_FormClosing);
			this.Load += new System.EventHandler(this.DlgLogin_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errPrv)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSvrIp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nudPort;
		private System.Windows.Forms.ProgressBar pgrLogin;
		private System.Windows.Forms.Label lblTip;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnCancle;
		private System.ComponentModel.BackgroundWorker loginWorker;
		private System.Windows.Forms.ErrorProvider errPrv;
	}
}
