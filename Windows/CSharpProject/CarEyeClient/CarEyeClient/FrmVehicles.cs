using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarEyeClient.Model;
using CarEyeClient.Utils;

namespace CarEyeClient
{
	/// <summary>
	/// 车辆详情列表窗口
	/// </summary>
	public partial class FrmVehicles : CarEyeClient.FrmChild
	{
		/// <summary>
		/// 主窗体
		/// </summary>
		private FrmMain mParent;

		public FrmVehicles(FrmMain aParent)
		{
			InitializeComponent();
			// 禁止自动生成属性列
			this.dgvVechiles.AutoGenerateColumns = false;
			mParent = aParent;
		}

		/// <summary>
		/// 添加一个车辆到车辆列表中
		/// </summary>
		/// <param name="aVehicle"></param>
		public void AddVehicle(JsonLastPosition aVehicle)
		{
			List<JsonLastPosition> vehicles;
			if (this.dgvVechiles.DataSource is List<JsonLastPosition>)
			{
				vehicles = this.dgvVechiles.DataSource as List<JsonLastPosition>;
			}
			else
			{
				vehicles = new List<JsonLastPosition>();
			}

			int tmpIndex = vehicles.FindIndex(x => x.VehicleIndex == aVehicle.VehicleIndex);
			if (tmpIndex < 0)
			{
				vehicles.Insert(0, aVehicle);
			}
			else
			{
				vehicles[tmpIndex] = aVehicle;
			}


			this.dgvVechiles.DataSource = null;
			this.dgvVechiles.DataSource = vehicles;
			this.dgvVechiles.Refresh();
		}

		/// <summary>
		/// 双击进行定位
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvVechiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
			{
				return;
			}

			JsonLastPosition location = this.dgvVechiles.Rows[e.RowIndex].DataBoundItem as JsonLastPosition;
			if (location == null)
			{
				return;
			}
			mParent.LocatedVehicle(location);
		}

		/// <summary>
		/// 获取选中的车辆信息, 未选中返回null
		/// </summary>
		/// <returns></returns>
		private JsonLastPosition GetSelectedVehicle()
		{
			if (this.dgvVechiles.SelectedRows.Count < 1)
			{
				return null;
			}

			return this.dgvVechiles.SelectedRows[0].DataBoundItem as JsonLastPosition;
		}

		/// <summary>
		/// 点名, 获取最新位置信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuRequest_Click(object sender, EventArgs e)
		{
			var selVehicle = GetSelectedVehicle();
			if (selVehicle == null)
			{
				return;
			}

			var task = Task.Factory.StartNew(() =>
			{
				var lastLocation = UrlApiHelper.GetLastLocation(selVehicle.TerminalId);
				if (lastLocation == null)
				{
					GuiHelper.MsgBox("服务器连接异常...");
				}
				else if (lastLocation.Status != 0)
				{
					GuiHelper.MsgBox("点名失败: " + lastLocation.Message);
				}
				else
				{
					this.dgvVechiles.Invoke(new Action<JsonLastPosition>(AddVehicle), lastLocation);
					mParent.LocatedVehicle(lastLocation);
				}
			});
		}

		/// <summary>
		/// 轨迹回放功能
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuTrack_Click(object sender, EventArgs e)
		{
			var selVehicle = GetSelectedVehicle();
			if (selVehicle == null)
			{
				return;
			}

			DlgTrackRequest tmpDlg = new DlgTrackRequest(selVehicle.TerminalId);
			if (tmpDlg.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			var history = tmpDlg.History;
		}
	}
}
