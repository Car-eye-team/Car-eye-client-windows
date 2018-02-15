using System.Text;
using CarEyeClient.Model;
using CarEyeMap;

namespace CarEyeClient.Utils
{
	/// <summary>
	/// 地图帮助类
	/// </summary>
	internal static class MapHelper
	{
		/// <summary>
		/// 未报警在线车俩颜色
		/// </summary>
		public const int NORMAL_COLOR = 0;
		/// <summary>
		/// 离线车辆颜色
		/// </summary>
		public const int OFFLINE_COLOR = 1;
		/// <summary>
		/// 报警车辆颜色
		/// </summary>
		public const int WARN_COLOR = 2;

		/// <summary>
		/// 获取主地图HTML数据
		/// </summary>
		/// <returns></returns>
		public static string GetMainMap()
		{
			return Properties.Resources.BdMain;
		}

		/// <summary>
		/// 在指定地图中定位车辆
		/// </summary>
		/// <param name="aMap"></param>
		/// <param name="aParams"></param>
		public static void LocatedVehicle(this WebMap aMap, object[] aParams)
		{
			aMap.InvokeScript("LocatedVehicle", aParams);
		}

		/// <summary>
		/// 获取信息窗口代码
		/// </summary>
		/// <param name="aLocation"></param>
		/// <returns></returns>
		public static string GenInfoWindow(JsonLastPosition aLocation)
		{
			StringBuilder htmlBuilder = new StringBuilder();

			htmlBuilder.AppendLine("<table width='360' style='font-size: 12px'>");

			htmlBuilder.AppendFormat("<tr valign='middle'><td width='60' height='22' align='right'><strong>车牌号码:</strong></td><td width='70'>{0}</td>"
								+ "<td width='95' align='right'><strong>所属企业:</strong></td><td width='135'>{1}</td></tr>\r\n",
								aLocation.LicensePlate, GlobalCfg.Company);
			htmlBuilder.AppendFormat("<tr valign='middle'><td height='22' align='right'><strong>实时速度:</strong></td><td>{0}Km/h</td>"
								+ "<td align='right'><strong>经度纬度:</strong></td><td>{1:F5},{2:F6}</td></tr>\r\n",
								aLocation.Speed, aLocation.Longitude, aLocation.Latitude);
			htmlBuilder.AppendFormat("<tr valign='middle'><td height='22' align='right'><strong>车辆状态:</strong></td><td colspan='3'>{0}</td></tr>\r\n",
								aLocation.StatusDescription);

			htmlBuilder.AppendLine("</table>");

			return htmlBuilder.ToString();
		}

		/// <summary>
		/// 生成定位车辆的参数
		/// </summary>
		/// <param name="aLocation"></param>
		/// <param name="aShow">是否显示车辆</param>
		/// <returns></returns>
		public static object[] GetLocatedVehicleParams(JsonLastPosition aLocation, bool aShow = true)
		{
			int vehicleColor = NORMAL_COLOR;
			VehicleStatusType tmpState = (VehicleStatusType)aLocation.VehicleStatus;
			if (tmpState == VehicleStatusType.LongOffline
				|| tmpState == VehicleStatusType.Offline)
			{
				vehicleColor = OFFLINE_COLOR;
			}
			else if (tmpState == VehicleStatusType.Alarm)
			{
				vehicleColor = WARN_COLOR;
			}
			return new object[]{aLocation.LicensePlate,
								aLocation.BdLongitude, aLocation.BdLatitude, aLocation.Direction,
								vehicleColor, aShow ? GenInfoWindow(aLocation) : ""};
		}

		/// <summary>
		/// 在指定地图中定位车辆
		/// </summary>
		/// <param name="aMap"></param>
		/// <param name="aLocation"></param>
		public static void LocatedVehicle(this WebMap aMap, JsonLastPosition aLocation)
		{
			LocatedVehicle(aMap, GetLocatedVehicleParams(aLocation));
		}
	}
}
