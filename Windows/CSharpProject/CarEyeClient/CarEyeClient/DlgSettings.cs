using System;
using System.Windows.Forms;
using CarEyeClient.Properties;
using CarEyeClient.Utils;

namespace CarEyeClient
{
	/// <summary>
	/// 系统设置窗口
	/// </summary>
	internal partial class DlgSettings : CarEyeClient.FrmBase
	{
		public DlgSettings()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 窗口载入过程
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DlgSettings_Load(object sender, EventArgs e)
		{
			this.txtSvrIp.Text = Settings.Default.SvrIp;
			this.nudSvrPort.Value = Settings.Default.SvrPort;
			this.txtDVRSvrIp.Text = Settings.Default.DVRSvrIp;
			this.nudDVRSvrPort.Value = Settings.Default.DVRSvrPort;
			this.nudReportInterval.Value = Settings.Default.AutoReportInterval;
		}

		/// <summary>
		/// 标识某个控件输入错误
		/// </summary>
		/// <param name="aControl">聚焦的控件</param>
		/// <param name="aMessage">错误信息</param>
		private void SetError(Control aControl, string aMessage)
		{
			errPrv.SetError(aControl, aMessage);
			aControl.Focus();
		}

		/// <summary>
		/// 存储设置项
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOk_Click(object sender, EventArgs e)
		{
			errPrv.Clear();

			string svrIp = this.txtSvrIp.Text.Trim();
			if (string.IsNullOrEmpty(svrIp))
			{
				SetError(txtSvrIp, "通信服务器IP地址不能为空.");
				return;
			}
			ushort svrPort = (ushort)this.nudSvrPort.Value;

			string dvrSvrIp = this.txtDVRSvrIp.Text.Trim();
			if (string.IsNullOrEmpty(dvrSvrIp))
			{
				SetError(txtDVRSvrIp, "视频服务器IP地址不能为空.");
				return;
			}
			ushort dvrSvrPort = (ushort)this.nudDVRSvrPort.Value;

			Settings.Default.SvrIp = svrIp;
			Settings.Default.SvrPort = svrPort;
			Settings.Default.DVRSvrIp = dvrSvrIp;
			Settings.Default.DVRSvrPort = dvrSvrPort;
			Settings.Default.AutoReportInterval = (int)this.nudReportInterval.Value;
			Settings.Default.Save();

			GuiHelper.MsgBox("设置成功~!");
			this.DialogResult = DialogResult.OK;
		}
	}
}
