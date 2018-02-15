using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CarEyeClient.Model;

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

			if (vehicles.Find(x => x.VehicleIndex == aVehicle.VehicleIndex) == null)
			{
				vehicles.Insert(0, aVehicle);
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
	}
}
