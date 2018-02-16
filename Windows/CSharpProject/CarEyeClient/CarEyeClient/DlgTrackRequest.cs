using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarEyeClient.Model;
using CarEyeClient.Utils;

namespace CarEyeClient
{
	/// <summary>
	/// 历史轨迹查询窗口
	/// </summary>
	public partial class DlgTrackRequest : CarEyeClient.FrmBase
	{
		/// <summary>
		/// 全局存储的开始时间
		/// </summary>
		private static DateTime mEndTime = DateTime.Now;
		/// <summary>
		/// 全局存储的结束时间
		/// </summary>
		private static DateTime mStartTime = DateTime.Now.AddDays(-1);
		/// <summary>
		/// 获取查询到的历史轨迹
		/// </summary>
		public JsonHistoryPosition History { get; private set; }

		/// <summary>
		/// 历史轨迹查询窗口
		/// </summary>
		/// <param name="aTerminalId">默认终端编号</param>
		public DlgTrackRequest(string aTerminalId = null)
		{
			InitializeComponent();
			this.txtTerminalId.Text = aTerminalId;
			this.dtpEnd.Value = mEndTime;
			this.dtpStart.Value = mStartTime;
		}

		/// <summary>
		/// 进行查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOk_Click(object sender, EventArgs e)
		{
			DateTime startTime = this.dtpStart.Value;
			DateTime endTime = this.dtpEnd.Value;
			if (startTime > endTime)
			{
				errPrv.SetError(this.dtpStart, "开始时间不能晚于结束时间...");
				return;
			}
			string terminalId = this.txtTerminalId.Text.Trim();
			if (string.IsNullOrEmpty(terminalId))
			{
				errPrv.SetError(this.txtTerminalId, "终端编号不能为空...");
				this.txtTerminalId.Focus();
				return;
			}

			this.History = null;
			this.btnOk.Enabled = false;
			var task = Task.Factory.StartNew(() =>
			{
				var history = UrlApiHelper.GetHistory(terminalId, startTime, endTime);
				if (history == null)
				{
					GuiHelper.MsgBox("服务器连接异常...");
				}
				else if (history.Status != 0)
				{
					GuiHelper.MsgBox("轨迹查询失败: " + history.Message);
				}
				else if (history.Count < 1 || history.Items.Count < 1)
				{
					GuiHelper.MsgBox($"终端[{terminalId}]在该时间段内没有历史轨迹记录...");
				}
				else
				{
					this.History = history;
				}
			});
			task.Wait();
			this.btnOk.Enabled = true;
			if (this.History != null)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}
