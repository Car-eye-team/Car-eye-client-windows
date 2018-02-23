using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
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

		/// <summary>
		/// 委托方法定义,必须这样定义一个委托方法实例,否则会报以下异常:
		/// 托管调试助手 "”类型的已垃圾回收委托进行了回调。这可能会导致应用程序崩溃、损坏和数据丢失。向非托管代码传递委托时，托管应用程序必须让这些委托保持活动状态，直到确信不会再次调用它们。
		/// 因为回调给C++函数后托管代码管理器无法跟踪委托方法了,也就会被随机回收,这样就不会被回收了.
		/// </summary>
		private static MediaSourceCallBack mPlayerCallBack = new MediaSourceCallBack(EasyPlayerCallBack);

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
			if (ChannelId > 0)
			{
				PlayerMethods.EasyPlayer_SetManuRecordPath(ChannelId, mVideoPath);
			}
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
			if (ChannelId > 0)
			{
				PlayerMethods.EasyPlayer_SetManuPicShotPath(ChannelId, mImagePath);
			}
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
				LogAppend("无效的监控终端。。。");
				return false;
			}

			if (string.IsNullOrEmpty(this.Token.Url))
			{
				LogAppend("视频监控地址无效。。。");
				return false;
			}

			// TCP连接 YUY2显示,软解码
			ChannelId = PlayerMethods.EasyPlayer_OpenStream(this.Token.Url, this.lblView.Handle, RENDER_FORMAT.DISPLAY_FORMAT_YUY2,
								1, string.Empty, string.Empty,
								mPlayerCallBack, this.Handle, false);

			if (ChannelId <= 0)
			{
				this.btnPlay.Enabled = true;
				LogAppend("视频监控打开失败...");
				return false;
			}

			// 设置缓存
			// 最大帧缓存为30,超过该值将只播放I帧
			PlayerMethods.EasyPlayer_SetFrameCache(ChannelId, 3);
			mParent.PlayChnSound(ChannelId);
			// 按比例播放
			PlayerMethods.EasyPlayer_SetShownToScale(ChannelId, 1);

			// 设置抓图和录制存放路径
			GenRecordPath();
			PlayerMethods.EasyPlayer_SetManuRecordPath(ChannelId, mVideoPath);
			GenScreenPath();
			PlayerMethods.EasyPlayer_SetManuPicShotPath(ChannelId, mImagePath);

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
			this.btnPlay.Enabled = false;

			if (ChannelId > 0)
			{
				if (this.btnRecord.Checked)
				{
					// 正在录制则进行停止
					LogAppend("正在停止视频录制...");
					// 停止录像
					this.btnRecord.Checked = false;
					PlayerMethods.EasyPlayer_StopManuRecording(ChannelId);
					LogAppend("视频录制已停止.");
				}

				// 预览停止代码
				PlayerMethods.EasyPlayer_CloseStream(ChannelId);
				UrlApiHelper.ControlVideo(Token.TerminalId, Token.LogicChn, VedioControlType.Stop);
				ChannelId = -1;
			}
			
			LinkToken(null);
			mImagePath = null;
			mVideoPath = null;
			UpdateDisplayStatus();
		}

		#endregion

		/// <summary>
		/// 播放回调方法
		/// </summary>
		/// <param name="channelId"></param>
		/// <param name="channelPtr"></param>
		/// <param name="frameType"></param>
		/// <param name="log"></param>
		/// <param name="frameInfo"></param>
		/// <returns></returns>
		private static int EasyPlayerCallBack(int channelId, IntPtr channelPtr, int frameType, string log, [MarshalAs(UnmanagedType.LPArray)] RTSP_FRAME_INFO[] frameInfo)
		{
			// 在该回调方法中如果需要进行Invoke操作的话必须要使用BeginInvoke,否则将卡死...
			if (frameType == AVFrameFlag.EASY_SDK_EVENT_FRAME_FLAG)
			{
				RTSPViewer tmpViewer = (RTSPViewer)FromHandle(channelPtr);
				if (tmpViewer == null || tmpViewer.IsDisposed)
				{
					return 0;
				}
				
				if (frameInfo != null && frameInfo[0].codec == AVFrameFlag.EASY_SDK_EVENT_CODEC_EXIT)
				{
					tmpViewer.UpdateDisplayStatus();
				}
			}
			return 0;
		}

		/// <summary>
		/// 更新记录
		/// </summary>
		/// <param name="aMsg"></param>
		/// <param name="aParams"></param>
		private void LogAppend(string aMsg, params object[] aParams)
		{
			if (mParent != null)
			{
				string tmpStr = string.Format(DateTime.Now.ToString("[HH:mm:ss]: ") + aMsg, aParams);
				if (this.Token != null)
				{
					tmpStr = this.Token.ToString() + tmpStr;
				}

				mParent.UpdateInfo(tmpStr);
			}
		}

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
			this.btnRecord.Enabled = isPlay;
			this.btnSound.Enabled = isPlay;
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
				// 相应资源回收处理代码
				PlayerMethods.EasyPlayer_CloseStream(ChannelId);
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
				StopPlay();
				return;
			}

			// 开始播放
			this.btnPlay.Enabled = false;
			StartPlay();
			this.btnPlay.Enabled = true;
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

			// 视频截图
			if (PlayerMethods.EasyPlayer_StartManuPicShot(ChannelId) > 0)
			{
				LogAppend("已成功抓取拍照！");
			}
			else
			{
				LogAppend("抓取拍照失败...");
			}
		}

		/// <summary>
		/// 录像
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRecord_Click(object sender, EventArgs e)
		{
			this.btnRecord.Enabled = false;
			if (this.btnRecord.Checked)
			{
				// 停止录像
				this.btnRecord.Checked = false;
				PlayerMethods.EasyPlayer_StopManuRecording(ChannelId);
				LogAppend("视频录制已停止.");
			}
			else
			{
				do
				{
					if (ChannelId <= 0)
					{
						GuiHelper.MsgBox("该窗口当前处于非播放状态,无法录制...");
						break;
					}

					GenRecordPath();
					if (!Directory.Exists(mVideoPath))
					{
						Directory.CreateDirectory(mVideoPath);
					}
					// 开始录像
					if (PlayerMethods.EasyPlayer_StartManuRecording(ChannelId) > 0)
					{
						LogAppend("开始录制视频...");
						this.btnRecord.Checked = true;
					}
					else
					{
						LogAppend("视频录制启动失败...");
					}
				} while (false);
			}
			this.btnRecord.Enabled = true;
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

		/// <summary>
		/// 设置音频按钮选中状态
		/// </summary>
		/// <param name="aChecked"></param>
		public void SetSoundStatus(bool aChecked = false)
		{
			this.btnSound.Checked = aChecked;
		}

		/// <summary>
		/// 静音切换
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSound_Click(object sender, EventArgs e)
		{
			if (!IsPlaying)
			{
				return;
			}
			if (this.btnSound.Checked)
			{
				this.btnSound.Checked = false;
				PlayerMethods.EasyPlayer_StopSound();
				return;
			}
			mParent.PlayChnSound(ChannelId);
		}
	}
}
