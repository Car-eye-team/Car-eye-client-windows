using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarEyeClient.Model;
using CarEyeClient.Utils;

namespace CarEyeClient
{
	/// <summary>
	/// 视频实时预览查询窗体
	/// </summary>
	public partial class DlgDVRRequest : CarEyeClient.FrmBase
	{
		/// <summary>
		/// 开启视频预览的终端编号
		/// </summary>
		public string TerminalId { get; private set; }
		/// <summary>
		/// 开启的视频预览通道
		/// </summary>
		public AVChannel Channel { get; private set; }

		/// <summary>
		/// 视频实时预览查询窗体
		/// </summary>
		/// <param name="aTerminalId">默认要打开的终端编号</param>
		public DlgDVRRequest(string aTerminalId = null)
		{
			InitializeComponent();
			this.txtTerminalId.Text = aTerminalId;
		}

		/// <summary>
		/// 窗体载入过程
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DlgDVRRequest_Load(object sender, EventArgs e)
		{
			// 载入通道列表
			GuiHelper.LoadEnumLst(cboChn, AVChannel.Chn1,
							AVChannel.Chn1, AVChannel.Chn2, AVChannel.Chn3, AVChannel.Chn6);
		}

		/// <summary>
		/// 开启视频预览
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOk_Click(object sender, EventArgs e)
		{
			string terminalId = this.txtTerminalId.Text.Trim();
			if (string.IsNullOrEmpty(terminalId))
			{
				errPrv.SetError(this.txtTerminalId, "终端编号不能为空...");
				this.txtTerminalId.Focus();
				return;
			}

			ValueString<AVChannel> selChn = this.cboChn.SelectedItem as ValueString<AVChannel>;
			if (selChn == null)
			{
				errPrv.SetError(this.cboChn, "请选择有效的预览通道...");
				this.cboChn.Focus();
				return;
			}

			this.btnOk.Enabled = false;
			this.TerminalId = null;
			var task = Task.Factory.StartNew(() =>
			{
				var result = UrlApiHelper.ControlVideo(terminalId, selChn.Value, VedioControlType.RealTime);
				if (result == null)
				{
					GuiHelper.MsgBox("服务器连接异常...");
				}
				else if (result.Status != 0)
				{
					GuiHelper.MsgBox("实时预览开启失败: " + result.Message);
				}
				else
				{
					this.TerminalId = terminalId;
					this.Channel = selChn.Value;
				}
			});
			task.Wait();
			this.btnOk.Enabled = true;
			if (!string.IsNullOrEmpty(this.TerminalId))
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}
