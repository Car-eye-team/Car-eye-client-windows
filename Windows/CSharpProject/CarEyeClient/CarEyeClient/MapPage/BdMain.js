// 车辆图层Hashtable
var VehicleMarkers = new Hashtable();

// 默认的LABEL显示样式 蓝底白字
var LABEL_STYLE = {
	borderColor: "#045493",
	backgroundColor: "#4a6cfc",
	fontSize: "12px",
	color: "white",
	padding: "3px,5px,3px,5px"
}

// 信息窗口属性
var INFO_WINDOW_OPTS = {
	enableMessage: false,	// 不显示发送到手机
	title: "车辆详情"			// 信息窗口标题
}

/*******************************************************************************
** 函数名称: GenVehicleIcon
** 功能描述: 根据角度返回车辆图标
** 参    数: None
** 返 回 值: None
** 作　  者: Main
** 日  　期: 2018-02-14
**------------------------------------------------------------------------------
** 修 改 人:
** 日　  期:
**------------------------------------------------------------------------------
********************************************************************************/
function GenVehicleIcon(aAngle, aColor) {
	if (aAngle > 359)
	{
		aAngle %= 360;
	}

	// 角度索引
	var tmp_index = parseInt(aAngle / 30);
	var angle_str = tmp_index < 10 ? ("0" + tmp_index) : tmp_index.toString();

	// 颜色路径
	var color_str = "green";
	if (aColor == 1) {
		// 重车
		color_str = "purple";
	}
	else if (aColor == 2)
	{
		// 报警
		color_str = "red";
	}

	var cur_path = GetCurrentPath();
	var img_path = cur_path + "car_img/" + color_str + "/" + angle_str + ".png";
	return new BMap.Icon(img_path, new BMap.Size(32, 32));
}

/*******************************************************************************
** 函数名称: GenLabel
** 功能描述: 生成一个Label
** 参    数: aPlate: [输入] 车牌号码
** 返 回 值: 车牌号码Label
** 作　  者: Main
** 日  　期: 2018-02-14
**------------------------------------------------------------------------------
** 修 改 人:
** 日　  期:
**------------------------------------------------------------------------------
********************************************************************************/
function GenLabel(aPlate) {
	var tmp_lab = new BMap.Label(aPlate, { offset: new BMap.Size(-20, -35) });
	tmp_lab.setStyle(LABEL_STYLE);

	return tmp_lab;
}

/*******************************************************************************
** 函数名称: LocatedVehicle
** 功能描述: 定位车辆图标到地图中
** 参   数: aPlate: 车牌号码
**			aLng: 经度
**			aLat: 纬度
**			aAngle: 角度
**			aColor: 颜色
**			aHtml: 显示标签
** 返 回 值: None
** 作　  者: Main
** 日  　期: 2018-02-14
**------------------------------------------------------------------------------
** 修 改 人:
** 日　  期:
**------------------------------------------------------------------------------
********************************************************************************/
function LocatedVehicle(aPlate, aLng, aLat, aAngle, aColor, aHtml)
{
	var tmp_pos = new BMap.Point(aLng, aLat);

	var tmp_marker = VehicleMarkers.getValue(aPlate);
	if (tmp_marker == null) {
		// 否则添加小车图层
		tmp_marker = new BMap.Marker(tmp_pos);
		MapPanel.addOverlay(tmp_marker);
		tmp_marker.setLabel(GenLabel(aPlate));
		VehicleMarkers.add(aPlate, tmp_marker);
		tmp_marker.addEventListener("mouseout", function (e) {
			tmp_marker.closeInfoWindow();
		});
	}
	else {
		tmp_marker.setPosition(tmp_pos);
		// 移除事件，重新进行注册
		tmp_marker.removeEventListener("mouseover", markerShowInfo);
	}

	tmp_marker.addEventListener("mouseover", markerShowInfo = function (e) {
		if (aHtml != null && aHtml != "") {
			var infoWindow = new BMap.InfoWindow(aHtml, INFO_WINDOW_OPTS);  // 创建信息窗口对象
			tmp_marker.openInfoWindow(infoWindow); // 开启信息窗口
		}
	});

	// 设置显示图标
	tmp_marker.setIcon(GenVehicleIcon(aAngle, aColor));
}
