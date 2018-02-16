using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using CarEyeClient.Model;
using CarEyeClient.Utils;

/**
 * 使用Panel控件是为了获取控件的颜色可变边框效果
 **/

namespace CarEyeClient.DVR
{
	/// <summary>
	/// 每通道视频播放控件
	/// </summary>
	internal partial class RTSPViewer : UserControl
	{
		/// <summary>
		/// 预览的设备单元
		 /// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DVRToken Token { get; private set; }

		/// <summary>
		/// 视频播放通道编号
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int ChannelId { get; private set; }
		/// <summary>
		/// 是否处于播放状态
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsPlaying
		{
			get
			{
				return ChannelId > 0;
			}
		}

		/// <summary>
		/// 本控件所在窗口
		/// </summary>
		private FrmDVR mParent;
		/// <summary>
		/// 视频保存路径
		/// </summary>
		private string mVideoPath;
		/// <summary>
		/// 截图保存路径
		/// </summary>
		private string mImagePath;

		public RTSPViewer()
		{
			InitializeComponent();
			this.lblInfo.Text = string.Empty;
		}

		/// <summary>
		/// 视频监控窗体控件
		/// </summary>
		public RTSPViewer(FrmDVR aParent)
			: this()
		{
			UpdateParent(aParent);
		}

		#region 对外的API方法

		/// <summary>
		/// 更新本窗口所在的父窗口
		/// </summary>
		/// <param name="aParent"></param>
		public void UpdateParent(FrmDVR aParent)
		{
			mParent = aParent;
		}

		/// <summary>
		/// 设置设备参数
		/// </summary>
		/// <param name="aToken"></param>
		/// <returns></returns>
		public void LinkToken(DVRToken aToken)
		{
			this.Token = aToken;
			if (aToken != null)
			{
				this.lblInfo.Text = aToken.ToString();
			}
			else
			{
				this.lblInfo.Text = string.Empty;
			}
		}

		/// <summary>
		/// 对比Token与本窗口Token是否相同
		/// </summary>
		/// <param name="aToken"></param>
		/// <returns></returns>
		public bool EqualToken(DVRToken aToken)
		{
			if (aToken == null || Token == null)
			{
				return false;
			}

			return (Token.TerminalId == aToken.TerminalId
				&& Token.LogicChn == aToken.LogicChn);
		}

		/// <summary>
		/// 设置视频存储路径
		/// </summary>
		/// <param name="aPath"></param>
		public void SetVideoPath(string aPath)
		{
			if (string.IsNullOrEmpty(aPath))
			{
				return;
			}
			mVideoPath = aPath;
		}

		/// <summary>
		/// 设置截图存储路径
		/// </summary>
		/// <param name="aPath"></param>
		public void SetImagePath(string aPath)
		{
			if (string.IsNullOrEmpty(aPath))
			{
				return;
			}
			mImagePath = aPath;
		}

		/// <summary>
		/// 开始播放流媒体
		/// </summary>
		/// <returns></returns>
		public bool StartPlay()
		{
			if (ChannelId > 0)
			{
				return true;
			}
			if (Token == null)
			{
				GuiHelper.MsgBox("无效的监控终端。。。");
				return false;
			}

			if (string.IsNullOrEmpty(this.Token.Url))
			{
				GuiHelper.MsgBox("视频监控地址无效。。。");
				return false;
			}

			// TODO: 连接代码
			// 设置抓图和录制存放路径
			GenRecordPath();
			GenScreenPath();

			this.btnPlay.Checked = true;
			UpdateDisplayStatus(true);
			return true;
		}

		/// <summary>
		/// 根据Token生成录像路径
		/// </summary>
		/// <returns></returns>
		private void GenRecordPath()
		{
			if (string.IsNullOrEmpty(mVideoPath))
			{
				mVideoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Record\\{0}\\", Token));
			}
		}

		/// <summary>
		/// 根据Token生成截图路径
		/// </summary>
		/// <returns></returns>
		private void GenScreenPath()
		{
			if (string.IsNullOrEmpty(mImagePath))
			{
				mImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("SnapShot\\{0}\\", Token));
			}
		}

		/// <summary>
		/// 停止播放流媒体
		/// </summary>
		public void StopPlay()
		{
			if (ChannelId > 0)
			{
				// 预览停止代码
				UrlApiHelper.ControlVideo(Token.TerminalId, Token.LogicChn, VedioControlType.Stop);
				ChannelId = -1;
			}
			
			LinkToken(null);
			mImagePath = null;
			mVideoPath = null;
			UpdateDisplayStatus();
			this.btnPlay.Checked = false;
		}

		#endregion

		/// <summary>
		/// 更新lblDisplay显示的播放状态
		/// </summary>
		/// <param name="isPlay">是否播放状态</param>
		private void UpdateDisplayStatus(bool isPlay = false)
		{
			if (this.InvokeRequired)
			{
				try
				{
					this.BeginInvoke(new Action<bool>(UpdateDisplayStatus), isPlay);
				}
				catch
				{

				}
				return;
			}

			this.lblView.Text = isPlay ? string.Empty : "无 图 像 ...";
			this.btnScreenShot.Enabled = isPlay;
			this.btnRefresh.Enabled = isPlay;
			this.btnPlay.Checked = isPlay;
		}

		/// <summary>
		/// 控件销毁时进行资源释放
		/// </summary>
		/// <param name="e"></param>
		protected override void OnHandleDestroyed(EventArgs e)
		{
			// 释放资源
			if (ChannelId > 0)
			{
				// TODO: 相应资源回收处理代码
				ChannelId = -1;
			}
			base.OnHandleDestroyed(e);
		}

		/// <summary>
		/// 播放或者停止播放, 选中时为播放状态
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPlay_Click(object sender, EventArgs e)
		{
			if (this.btnPlay.Checked)
			{
				// 正在播放状态,则停止播放
				if (GuiHelper.MsgBox($"确定要断开{this.Token}的视频预览吗？") != DialogResult.OK)
				{
					return;
				}
				this.btnPlay.Enabled = false;
				StopPlay();
				this.btnPlay.Enabled = true;
				return;
			}

			// 开始播放
			this.btnPlay.Enabled = false;
			StartPlay();
			this.btnPlay.Enabled = true;
		}

		/// <summary>
		/// 刷新链接
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRefresh_Click(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 截图
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnScreenShot_Click(object sender, EventArgs e)
		{
			if (ChannelId <= 0)
			{
				GuiHelper.MsgBox("该窗口当前处于非播放状态,无法抓拍...");
				return;
			}

			GenScreenPath();
			if (!Directory.Exists(mImagePath))
			{
				Directory.CreateDirectory(mImagePath);
			}

			// TODO: 视频截图代码

		}

		/// <summary>
		/// 将播放控件单击事件传递给整个控件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lblView_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		/// <summary>
		/// 将播放控件双击事件传递给整个控件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lblView_DoubleClick(object sender, EventArgs e)
		{
			this.OnDoubleClick(e);
		}
	}
}
