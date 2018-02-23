using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CarEyeClient.DVR;
using CarEyeClient.Utils;

namespace CarEyeClient
{
	/// <summary>
	/// 视频实时预览子窗体
	/// </summary>
	internal partial class FrmDVR : FrmChild
	{
		/// <summary>
		/// 主窗体
		/// </summary>
		private FrmMain mParent;
		/// <summary>
		/// 最大直播视频窗口个数
		/// </summary>
		private const int MaxViewerCount = 16;

		/// <summary>
		/// 直播窗口集合
		/// </summary>
		private List<RTSPViewer> mViewers = new List<RTSPViewer>(MaxViewerCount);

		/// <summary>
		/// 之前的分屏布局按钮
		/// </summary>
		private ToolStripButton mOldLayout;
		/// <summary>
		/// 被选中的视频窗口
		/// </summary>
		private RTSPViewer mSelectedViewer;
		/// <summary>
		/// 是否有窗口进入全屏状态了
		/// </summary>
		private bool mIsFullScreen = false;

		public FrmDVR(FrmMain aParent)
		{
			InitializeComponent();
			mParent = aParent;

			mOldLayout = null;
			// 赋值对应的分屏个数
			btnFull.Tag = 1;
			btnFour.Tag = 4;
			btnSix.Tag = 6;
			btnEight.Tag = 8;
			btnNine.Tag = 9;
			btnSixteen.Tag = 16;
		}

		/// <summary>
		/// 添加一个视频监控单元
		/// </summary>
		/// <param name="aToken"></param>
		/// <returns></returns>
		public void AddVideoToken(DVRToken aToken)
		{
			this.Show();
			this.Activate();
			aToken.Url = string.Format(GlobalCfg.RTSPUrl, aToken.TerminalId, (byte)aToken.LogicChn);
			this.AddRTSP(aToken);
		}

		/// <summary>
		/// 窗口载入过程
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmDVR_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < MaxViewerCount; i++)
			{
				RTSPViewer tmpViewer = new RTSPViewer(this);
				tmpViewer.Click += RTSPViewer_Click;
				tmpViewer.DoubleClick += RTSPViewer_DoubleClick;
				tmpViewer.Visible = false;
				mViewers.Add(tmpViewer);
				this.pnlBase.Controls.Add(tmpViewer);
			}

			// 默认切换到全屏
			btnLayout_Click(btnFour, null);
		}


		/// <summary>
		/// 双击Viewer触发参数
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RTSPViewer_DoubleClick(object sender, EventArgs e)
		{
			RTSPViewer_Click(sender, e);
			if (mOldLayout == btnFull)
			{
				// 已经全屏状态了
				return;
			}
			if (mIsFullScreen)
			{
				// 全屏状态切换回正常状态
				mIsFullScreen = false;
				btnLayout_Click(mOldLayout, null);
				return;
			}
			SetLayout(SplitScreenType.Full);
		}

		/// <summary>
		/// 选中Viewer触发事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RTSPViewer_Click(object sender, EventArgs e)
		{
			SelectViewer(sender as RTSPViewer);
		}

		/// <summary>
		/// 设置选中指定Viewer
		/// </summary>
		/// <param name="aViewer"></param>
		private void SelectViewer(RTSPViewer aViewer)
		{
			if (mSelectedViewer != null)
			{
				mSelectedViewer.BackColor = Color.Firebrick;
			}

			mSelectedViewer = aViewer;
			mSelectedViewer.BackColor = Color.LimeGreen;
		}

		/// <summary>
		/// 布局切换
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLayout_Click(object sender, EventArgs e)
		{
			ToolStripButton tmpBtn = sender as ToolStripButton;

			if (mOldLayout != null)
			{
				mOldLayout.Checked = false;
			}
			tmpBtn.Checked = true;
			mOldLayout = tmpBtn;

			SetLayout((SplitScreenType)Convert.ToInt32(tmpBtn.Tag));
		}

		/// <summary>
		/// 根据数量设置分屏布局
		/// </summary>
		/// <param name="aType"></param>
		private void SetLayout(SplitScreenType aType)
		{
			mIsFullScreen = false;
			switch (aType)
			{
				case SplitScreenType.Full:
					SetFullScreen();
					break;

				case SplitScreenType.Four:
				case SplitScreenType.Nine:
				case SplitScreenType.Sixteen:
					SetMatrixScreen(aType);
					break;

				case SplitScreenType.Six:
				case SplitScreenType.Eight:
					SetMasterSlaveScreen(aType);
					break;

				default:
					break;
			}
		}

		/// <summary>
		/// 隐藏所有的视频输出窗口
		/// </summary>
		private void HideAllViewer()
		{
			foreach (var tmpItem in mViewers)
			{
				tmpItem.Visible = false;
			}
		}

		/// <summary>
		/// 设置全屏模式
		/// </summary>
		private void SetFullScreen()
		{
			if (mSelectedViewer == null)
			{
				if (mViewers == null || mViewers.Count < 1)
				{
					return;
				}
				mSelectedViewer = mViewers[0];
			}

			HideAllViewer();
			mSelectedViewer.Location = new Point(0, 0);
			mSelectedViewer.Size = this.pnlBase.Size;
			mSelectedViewer.Visible = true;
			mIsFullScreen = true;
		}

		/// <summary>
		/// 符合4、9、16矩阵的分屏布局
		/// </summary>
		private void SetMatrixScreen(SplitScreenType aType)
		{
			HideAllViewer();

			// 每行每列的视频输出窗口个数
			int tmpCount = (int)Math.Sqrt((int)aType);
			int perWidth = this.pnlBase.Width / tmpCount;
			int perHeight = this.pnlBase.Height / tmpCount;
			Size perSize = new Size(perWidth, perHeight);

			for (int i = 0; i < tmpCount; i++)
			{
				for (int j = 0; j < tmpCount; j++)
				{
					RTSPViewer tmpViewer = mViewers[i * tmpCount + j];
					tmpViewer.Location = new Point(j * perWidth, i * perHeight);
					tmpViewer.Size = perSize;
					tmpViewer.Visible = true;
					if (j == tmpCount - 1)
					{
						// 最后一列对齐控件右边
						tmpViewer.Width += this.pnlBase.Right - tmpViewer.Right;
					}
					if (i == tmpCount - 1)
					{
						tmpViewer.Height += this.pnlBase.Bottom - tmpViewer.Bottom;
					}
				}
			}

			if (mSelectedViewer == null)
			{
				return;
			}
			if (mViewers.FindIndex((x) => x == mSelectedViewer) >= (int)aType)
			{
				// 超出分屏个数则不清除选中状态
				mSelectedViewer = null;
			}
		}

		/// <summary>
		/// 设置6、8分屏布局
		/// </summary>
		private void SetMasterSlaveScreen(SplitScreenType aType)
		{
			HideAllViewer();

			// 6分屏布局为一个大屏，5个小屏，横竖为3个,相当于9分屏中的左上四屏合一
			int tmpCount = (int)aType / 2;
			int perWidth = this.pnlBase.Width / tmpCount;
			int perHeight = this.pnlBase.Height / tmpCount;
			Size perSize = new Size(perWidth, perHeight);
			Size mainSize = new Size(this.pnlBase.Width - perWidth, this.pnlBase.Height - perHeight);

			RTSPViewer tmpViewer = mViewers[0];
			tmpViewer.Location = new Point(0, 0);
			tmpViewer.Size = mainSize;
			tmpViewer.Visible = true;

			// 右手边两个分屏
			for (int i = 1; i < tmpCount; i++)
			{
				tmpViewer = mViewers[i];
				tmpViewer.Location = new Point(mainSize.Width, (i - 1) * perHeight);
				tmpViewer.Size = perSize;
				tmpViewer.Visible = true;
			}

			for (int i = tmpCount; i < (int)aType; i++)
			{
				tmpViewer = mViewers[i];
				tmpViewer.Location = new Point((i - tmpCount) * perWidth, mainSize.Height);
				tmpViewer.Size = perSize;
				tmpViewer.Visible = true;
			}

			if (mSelectedViewer == null)
			{
				return;
			}
			if (mViewers.FindIndex((x) => x == mSelectedViewer) >= (int)aType)
			{
				// 超出分屏个数则不清除选中状态
				mSelectedViewer = null;
			}
		}

		/// <summary>
		/// 获取一个空闲的Viewer
		/// </summary>
		/// <returns></returns>
		private RTSPViewer GetFreeViewer()
		{
			foreach (var tmpViewer in mViewers)
			{
				if (!tmpViewer.IsPlaying)
				{
					return tmpViewer;
				}
			}

			return null;
		}

		/// <summary>
		/// 根据终端编号以及通道号获取Viewer
		/// </summary>
		/// <param name="aToken"></param>
		/// <returns></returns>
		private RTSPViewer GetViewer(DVRToken aToken)
		{
			foreach (var tmpViewer in mViewers)
			{
				if (tmpViewer.IsPlaying
					&& tmpViewer.EqualToken(aToken))
				{
					return tmpViewer;
				}
			}

			return null;
		}

		/// <summary>
		/// 根据添加的视频监控进行合理布局
		/// </summary>
		private void ReLayout()
		{
			int tmpCnt = 0;

			for (int i = MaxViewerCount - 1; i >= 0; i--)
			{
				if (mViewers[i].IsPlaying)
				{
					tmpCnt = i + 1;
					break;
				}
			}

			if (tmpCnt <= Convert.ToInt32(mOldLayout.Tag))
			{
				// 当前分屏数足够放下正在播放的视频窗口则不改变布局
				return;
			}

			ToolStripButton tmpBtn = btnSixteen;
			if (tmpCnt <= 1)
			{
				tmpBtn = btnFull;
			}
			else if (tmpCnt <= 4)
			{
				tmpBtn = btnFour;
			}
			else if (tmpCnt <= 6)
			{
				tmpBtn = btnSix;
			}
			else if (tmpCnt <= 8)
			{
				tmpBtn = btnEight;
			}
			else if (tmpCnt <= 9)
			{
				tmpBtn = btnNine;
			}

			if (!tmpBtn.Checked)
			{
				btnLayout_Click(tmpBtn, null);
			}
		}

		/// <summary>
		/// 添加新的视频监控播放
		/// </summary>
		/// <param name="aMsg"></param>
		private void AddRTSP(DVRToken aToken)
		{
			RTSPViewer tmpViewer = GetViewer(aToken);
			if (tmpViewer != null)
			{
				// 调试测试时先不判断该条件
				SelectViewer(tmpViewer);
				ReLayout();
				return;
			}

			tmpViewer = GetFreeViewer();
			if (tmpViewer == null)
			{
				GuiHelper.MsgBox("视频监控窗口已被占满，请关闭一些监控窗口...");
				return;
			}

			UpdateInfo("开启监控" + aToken);
			tmpViewer.LinkToken(aToken);
			SelectViewer(tmpViewer);
			tmpViewer.StartPlay();
			ReLayout();
		}

		/// <summary>
		/// 更新信息到信息栏
		/// </summary>
		/// <param name="aMsg"></param>
		/// <param name="aParams"></param>
		public void UpdateInfo(string aMsg, params object[] aParams)
		{
			if (this.toolStrip.InvokeRequired)
			{
				try
				{
					this.BeginInvoke(new Action<string, object[]>(UpdateInfo),
											aMsg, aParams);
				}
				catch
				{

				}
				return;
			}

			this.lblInfo.Text = string.Format(aMsg, aParams);
		}

		/// <summary>
		/// 窗口大小改变时触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmDVR_SizeChanged(object sender, EventArgs e)
		{
			if (mOldLayout != null)
			{
				SetLayout((SplitScreenType)Convert.ToInt32(mOldLayout.Tag));
			}
		}

		/// <summary>
		/// 窗口关闭时触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmDVR_FormClosing(object sender, FormClosingEventArgs e)
		{
			// 异步委托关闭
			this.BeginInvoke(new Action(() =>
			{
				foreach (var tmpViewer in mViewers)
				{
					if (tmpViewer.IsPlaying)
					{
						tmpViewer.StopPlay();
					}
				}
			}));
		}

		/// <summary>
		/// 播放指定通道音频
		/// </summary>
		/// <param name="aChannelId"></param>
		public void PlayChnSound(int aChannelId)
		{
			if (aChannelId <= 0)
			{
				return;
			}

			PlayerMethods.EasyPlayer_PlaySound(aChannelId);

			foreach (var tmpItem in mViewers)
			{
				if (tmpItem.ChannelId == aChannelId)
				{
					tmpItem.SetSoundStatus(true);
					UpdateInfo("播放{0}的音频信号...", tmpItem.Token);
				}
				else
				{
					tmpItem.SetSoundStatus();
				}
			}
		}
	}
}
