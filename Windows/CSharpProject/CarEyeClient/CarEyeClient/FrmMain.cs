using System;
using System.Windows.Forms;
using CarEyeClient.Model;
using CarEyeClient.Properties;
using CarEyeClient.Utils;
using WeifenLuo.WinFormsUI.Docking;

namespace CarEyeClient
{
	public partial class FrmMain : CarEyeClient.FrmBase
	{
		/// <summary>
		/// 地图窗体
		/// </summary>
		private FrmMap mFrmMap;
		/// <summary>
		/// 视频实时预览窗体
		/// </summary>
		private FrmDVR mFrmDVR;
		/// <summary>
		/// 车辆详情窗体
		/// </summary>
		private FrmVehicles mFrmVehicles;
		/// <summary>
		/// 当前登陆的终端以及其最新位置信息
		/// </summary>
		private JsonLastPosition mLastLocation;

		public FrmMain()
		{
			InitializeComponent();
			this.Text = $"{GlobalCfg.Title}[{GlobalCfg.Version}]";
			// 缩放到最大
			this.Size = SystemInformation.WorkingArea.Size;
		}

		/// <summary>
		/// 强制关闭程序，不弹出提示框
		/// </summary>
		private void ForceClose()
		{
			this.BeginInvokeIfRequired((frm) =>
			{
				frm.DialogResult = DialogResult.Cancel;
				frm.Close();
			});
		}

		/// <summary>
		/// 登陆成功后载入界面操作
		/// </summary>
		public void LoadUI()
		{
			// 载入地图与视频预览界面
			mFrmMap = new FrmMap(this);
			mFrmMap.Show(this.dockMain);
			mFrmDVR = new FrmDVR(this);
			mFrmDVR.Show(this.dockMain);
			mFrmVehicles = new FrmVehicles(this);
			mFrmVehicles.Show(this.dockMain, DockState.DockBottom);

			// 默认显示地图页面
			mFrmMap.Show();
		}

		/// <summary>
		/// 窗体载入过程
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmMain_Load(object sender, EventArgs e)
		{
			// 首先进行登陆
			DlgLogin dlg = new DlgLogin(this);
			if (dlg.ShowDialog() != DialogResult.OK)
			{
				this.ForceClose();
				return;
			}

			mLastLocation = dlg.LastLocation;
			mFrmVehicles.AddVehicle(mLastLocation);
		}

		/// <summary>
		/// 准备关闭窗体时触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult != DialogResult.Cancel)
			{
				if (GuiHelper.MsgBox($"确认要退出{GlobalCfg.Title}？") != DialogResult.OK)
				{
					e.Cancel = true;
					return;
				}

				// 保存设置项
				Settings.Default.Save();
			}
		}

		/// <summary>
		/// 系统设置
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuSysSet_Click(object sender, EventArgs e)
		{
			new DlgSettings().ShowDialog();
		}
	}
}
