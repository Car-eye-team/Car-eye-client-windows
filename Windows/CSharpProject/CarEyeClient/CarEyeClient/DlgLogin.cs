using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CarEyeClient.Properties;
using CarEyeClient.Utils;
using CarEyeClient.Model;

namespace CarEyeClient
{
	/// <summary>
	/// 登陆验证窗体
	/// </summary>
	public partial class DlgLogin : CarEyeClient.FrmBase
	{
		/// <summary>
		/// 主窗口
		/// </summary>
		private FrmMain mParentFrm;
		/// <summary>
		/// 获取登陆成功设备的最新位置信息
		/// </summary>
		public JsonLastPosition LastLocation { get; private set; }

		public DlgLogin(FrmMain aFrm)
		{
			InitializeComponent();
			this.mParentFrm = aFrm;
			this.Text = $"{GlobalCfg.Title}[{GlobalCfg.Version}]";
		}

		/// <summary>
		/// 窗体载入过程
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DlgLogin_Load(object sender, EventArgs e)
		{
			this.txtSvrIp.Text = Settings.Default.SvrIp;
			this.nudPort.Value = Settings.Default.SvrPort;
			// 测试用临时填入终端编号
			this.txtName.Text = GlobalCfg.TerminalId;
		}

		/// <summary>
		/// 窗体关闭事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DlgLogin_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				return;
			}

			if (GuiHelper.MsgBox($"您确定要退出{GlobalCfg.Title}吗？") == DialogResult.OK)
			{
				return;
			}

			e.Cancel = true;
		}

		/// <summary>
		/// 更新用户登陆进度
		/// </summary>
		/// <param name="aValue">进度百分比</param>
		/// <param name="aMsg">进度消息</param>
		private void UpdateLoginProgress(int aValue, string aMsg)
		{
			this.pgrLogin.InvokeIfRequired((pgr) =>
			{
				if (aValue >= pgr.Minimum && aValue <= pgr.Maximum)
				{
					pgr.Value = aValue;
				}
			});
			this.lblTip.InvokeIfRequired((lbl) => lbl.Text = aMsg);
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
		/// 登陆按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLogin_Click(object sender, EventArgs e)
		{
			// 清空上次可能出现的错误标识
			errPrv.Clear();
			UpdateLoginProgress(0, string.Empty);

			string loginName = this.txtName.Text.Trim();
			if (string.IsNullOrEmpty(loginName))
			{
				SetError(txtName, "用户名不能为空.");
				return;
			}
			string loginPwd = this.txtPwd.Text.Trim();
			if (string.IsNullOrEmpty(loginPwd))
			{
				SetError(txtPwd, "用户密码不能为空.");
				return;
			}
			Settings.Default.SvrIp = this.txtSvrIp.Text.Trim();
			if (string.IsNullOrEmpty(Settings.Default.SvrIp))
			{
				SetError(txtSvrIp, "用户密码不能为空.");
				return;
			}
			Settings.Default.SvrPort = (ushort)this.nudPort.Value;

			// 开启后台登陆工作
			UpdateLoginProgress(10, "连接服务器中...");
			this.btnLogin.Enabled = false;
			this.loginWorker.RunWorkerAsync(new string[] { loginName, loginPwd });
		}

		/// <summary>
		/// 登陆验证后台工作
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void loginWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;

			if (e.Argument is string[] loginArgs)
			{
				// FIXME: 目前是通过获取终端编号的位置信息模拟登陆过程, 后期将通过用户名密码验证API进行登陆
				string loginName = loginArgs[0];
				string loginPwd = loginArgs[1];

				LastLocation = UrlApiHelper.GetLastLocation(loginName);
				if (LastLocation == null)
				{
					worker.ReportProgress(-1, "服务器连接异常...");
					return;
				}
				else if (LastLocation.Status != 0)
				{
					worker.ReportProgress(-1, LastLocation.Message);
					return;
				}

				// 登陆成功
				UpdateLoginProgress(50, "登陆成功, 正在载入界面...");
				mParentFrm.InvokeIfRequired(frm => frm.LoadUI());
				worker.ReportProgress(100);
			}
			else
			{
				// 失败
				worker.ReportProgress(-1, "参数错误");
			}
		}

		/// <summary>
		/// 进度状态更新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void loginWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.btnLogin.Enabled = true;
			if (e.ProgressPercentage < 0)
			{
				// 登陆失败
				GuiHelper.MsgBox("登陆失败: " + Convert.ToString(e.UserState));
				return;
			}

			// 登陆成功 保存配置信息
			Settings.Default.Save();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
