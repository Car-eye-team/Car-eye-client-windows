	// 主地图容器
	var MapPanel = null;
	// 当前正在使用的工具
	var CurTool = null;
	// 区域/路线图层
	var AreaLayer = null;
	// 路段图层
	var LineLayer = null;
	// 本地查询工具
	var LocalSearchTool = null;
	// 用户标注集合
	var UserMarkers = [];

	// 区域显示样式
	var AREA_STYLE = {
		strokeColor: "#de6136",	//边线颜色。
		fillColor: "#9ac4fd",	//填充颜色。当参数为空时，圆形将没有填充效果。
		strokeWeight: 2,		//边线的宽度，以像素为单位。
		strokeOpacity: 0.8,		//边线透明度，取值范围0 - 1。
		fillOpacity: 0.6,		//填充的透明度，取值范围0 - 1。
		strokeStyle: "solid"	//边线的样式，solid或dashed。
	}

	// 路线显示样式
	var ROUTE_STYLE = { strokeColor: "#3EFE0B", strokeWeight: 3, strokeOpacity: 0.7, strokeStyle: "dashed" }
	// 路段显示样式
	var LINE_STYLE = { strokeColor: "#de6136", strokeWeight: 7, strokeOpacity: 0.5, strokeStyle: "solid" }

	/*******************************************************************************
	** 函数名称: endWith
	** 功能描述: 为string增加endWith方法
	** 参    数: aStr: [输入] 检测的结尾字符串
	** 返 回 值: 是否以参数字符串结尾
	** 作　  者: 王国蛟
	** 日  　期: 2015-01-20
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	String.prototype.endWith = function (aStr) {
		if (aStr == null || aStr == ""
			|| this.length == 0 || aStr.length > this.length) {
			return false;
		}
		if (this.substring(this.length - aStr.length) == aStr) {
			return true;
		}
	
		return false;
	}

	// 获取当前程序运行的路径, 以'\'结尾
	function GetCurrentPath()
	{
		return window.external.GetCurrentPath();
	}

	// 弹出对话框
	function MsgBox(msg) {
		window.external.MsgBox(msg);
	}

	// 调用C#外部方法,最多可传入7个参数
	function External(aName) {
		if (arguments == null || arguments.length <= 1) {
			return window.external.OnExternal(aName);
		}
		else if (arguments.length == 2) {
			return window.external.OnExternal(aName, arguments[1]);
		}
		else if (arguments.length == 3) {
			return window.external.OnExternal(aName, arguments[1], arguments[2]);
		}
		else if (arguments.length == 4) {
			return window.external.OnExternal(aName, arguments[1],
										arguments[2], arguments[3]);
		}
		else if (arguments.length == 5) {
			return window.external.OnExternal(aName, arguments[1], arguments[2],
										arguments[3], arguments[4]);
		}
		else if (arguments.length == 6) {
			return window.external.OnExternal(aName, arguments[1], arguments[2],
										arguments[3], arguments[4], arguments[5]);
		}
		else if (arguments.length == 7) {
			return window.external.OnExternal(aName, arguments[1],
										arguments[2], arguments[3], arguments[4],
										arguments[5], arguments[6]);
		}
		else if (arguments.length == 8) {
			return window.external.OnExternal(aName, arguments[1],
										arguments[2], arguments[3], arguments[4],
										arguments[5], arguments[6], arguments[7]);
		}
	}

	/*******************************************************************************
	** 函数名称: onMouseMove
	** 功能描述: 事件函数，鼠标移过地图显示对应的经纬度
	** 参    数: aPoint: [输入] 鼠标位置
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-13
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function onMouseMove(e) {
		window.external.OnCursorMoved(e.point.lng, e.point.lat);
	}

	/*******************************************************************************
	** 函数名称: ZoomSwitch
	** 功能描述: 激活拉框放大缩小功能
	** 参    数: aType: [输入] 1为放大 2为缩小
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-13
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function ZoomSwitch(aType) {
		CloseTool();
		if (aType == 1) {
			// 放大
			CurTool = new BMapLib.RectangleZoom(MapPanel);
		}
		else {
			// 缩小
			CurTool = new BMapLib.RectangleZoom(MapPanel, { zoomType: 1 });
		}
		CurTool.open();
	}

	// 判断是否存在指定函数 
	function isExitsFunction(funcName) {
		try {
			if (typeof (eval(funcName)) == "function") {
				return true;
			}
		} catch (e) { }
		return false;
	}

	// 清空地图所有图层
	function ClearMap() {
		if (MapPanel == null) {
			return false;
		}

		MapPanel.clearOverlays();
		AreaLayer = null;
		LineLayer = null;
		UserMarkers.length = 0;
		LocalSearchTool = null;
		if (isExitsFunction("ClearGloble")) {
			ClearGloble();
		}

		return true;
	}

	/*******************************************************************************
	** 函数名称: OpenMarkTool
	** 功能描述: 开启标注工具
	** 参    数: None
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-05-05
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function OpenMarkTool() {
		CloseTool();
		if (UserMarkers.length > 14) {
			MsgBox("抱歉，您最多只能添加15个标注！");
			return;
		}
		//实例化鼠标绘制工具
		CurTool = new BMapLib.MarkerTool(MapPanel, { followText: "添加一个标注" });
		CurTool.addEventListener('markend', onMarkFinished);
		CurTool.open();
	}

	/*******************************************************************************
	** 函数名称: AddLocationMarker
	** 功能描述: 在指定的经纬度上添加Marker
	** 参    数: aPos: [输入] GPS位置
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-13
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function AddLocationMarker(aLng, aLat) {
		if (UserMarkers.length > 14) {
			MsgBox("抱歉，您最多只能添加15个标注！");
			return;
		}
		var new_point = new BMap.Point(aLng, aLat);
		var marker = new BMap.Marker(new_point);	// 创建标注
		MapPanel.addOverlay(marker);		// 将标注添加到地图中
		MapPanel.panTo(new_point);
		AddMarkerInfo(marker);
	}

	// 删除指定经纬度的标注
	function RemoveMark(lng, lat) {
		for (var i = 0; i < UserMarkers.length; i++) {
			var pt = UserMarkers[i].getPosition();
			if (pt.lng == lng && pt.lat == lat) {
				MapPanel.removeOverlay(UserMarkers[i]);
				UserMarkers.splice(i, 1);
				break;
			}
		}
		return false;
	}

	// 编辑Mark的窗口信息
	function EditMarkInfo(lng, lat) {
		for (var i = 0; i < UserMarkers.length; i++) {
			var pt = UserMarkers[i].getPosition();
			if (pt.lng == lng && pt.lat == lat) {
				var marker = UserMarkers[i];
				var body_html = [];
				var addr_str = document.getElementById("txtAddr").value;
				if (!addr_str) {
					alert("请填写该标注的名称！");
					return;
				}
				var remark = document.getElementById("areaDesc").value;
				body_html.push(addr_str + "<br />");
				body_html.push(remark);
				var title_html = "标注详情 <span style='font-size:12px'>[<a href='javascript:void(0);' onclick='RemoveMark(" + pt.lng + "," + pt.lat + ")'>删 除</a>]</span>";
				var info_window = new BMap.InfoWindow(body_html.join(""), { enableMessage: false, title: title_html });  // 创建信息窗口对象
				marker.openInfoWindow(info_window); // 开启信息窗口
				marker.removeEventListener("click", markerShowInfo);
				marker.addEventListener('click', function (evt) {
					evt.target.openInfoWindow(info_window);
				});
				break;
			}
		}
	}

	// 添加一个InfoWindow到Marker中
	function AddMarkerInfo(marker) {
		var geoc = new BMap.Geocoder();
		UserMarkers.push(marker);
		var pt = marker.getPosition();
		// 获取地理位置
		geoc.getLocation(pt, function (rs) {
			var addComp = rs.addressComponents;
			var addr_str = addComp.district + addComp.street + addComp.streetNumber;
			var body_html = [];
			body_html.push("<table border='0' style = 'font-size:12px;table-layout:fixed'>");
			body_html.push("<tr><td width='50' align='center'>名 称：</td>");
			body_html.push("<td width='200'><input id=\"txtAddr\" type=\"text\" size='26' value=\"" + addr_str + "\" /></td></tr>");
			body_html.push("<tr valign='top'><td align='center'>备 注：</td>");
			body_html.push("<td><textarea rows=\"4\" cols='21' id=\"areaDesc\" ></textarea></td></tr>");
			body_html.push("<tr valign='bottom'><td align='center' colspan='2'>");
			body_html.push("<input type='button' name='btnOK' style=");
			body_html.push("\"width: 70px;color: #606060;padding-top:2px;margin-top:7px;");
			body_html.push("border: solid 1px #b7b7b7;");
			body_html.push("background: #fff;");
			body_html.push("background: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#ededed));");
			body_html.push("background: -moz-linear-gradient(top, #fff, #ededed);");
			body_html.push("filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffffff', endColorstr='#ededed');\"");
			body_html.push(" onclick='EditMarkInfo(" + pt.lng + "," + pt.lat + ")' value='确 定'></td></tr></table>");
			var title_html = "编辑标注详情 <span style='font-size:12px'>[<a href='javascript:void(0);' onclick='RemoveMark(" + pt.lng + "," + pt.lat + ")'>删 除</a>]</span>";
			var info_window = new BMap.InfoWindow(body_html.join(""), { enableMessage: false, title: title_html });  // 创建信息窗口对象
			marker.openInfoWindow(info_window); // 开启信息窗口
			marker.setLabel(new BMap.Label(addr_str, { offset: new BMap.Size(20, -10) }));
			marker.addEventListener('click', markerShowInfo = function (evt) {
				evt.target.openInfoWindow(info_window);
			});
		});
	}

	// 点击确定标注
	function onMarkFinished(e) {
		CloseTool();
		AddMarkerInfo(e.marker);
	}

	/*******************************************************************************
	** 函数名称: CloseTool
	** 功能描述: 切换回漫游状态，即关闭其他工具
	** 参    数: None
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-13
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function CloseTool() {
		if (CurTool) {
			CurTool.close();
			CurTool = null;
		}
	}

	/*******************************************************************************
	** 函数名称: OnMouseDown
	** 功能描述: DIV层的鼠标点击事件，提前关闭当前的工具
	** 参    数: aEvt: [输入] 鼠标点击输入参数
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-18
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function OnMouseDown(aEvt) {
		if (aEvt.button == 2 && CurTool) {
			// 在右键按下的情况下先关闭当前工具
			if (!(CurTool instanceof BMapLib.DrawingManager))
			{
				CurTool.close();
				CurTool = null;
			}
		}
	}

	/*******************************************************************************
	** 函数名称: RemoveAreaLayer
	** 功能描述: 删除当前存在的区域图层
	** 参    数: None
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-18
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function RemoveAreaLayer() {
		if (AreaLayer) {
			MapPanel.removeOverlay(AreaLayer);
			AreaLayer = null;
		}
	}

	/*******************************************************************************
	** 函数名称: RemoveLineLayer
	** 功能描述: 删除当前存在的路段图层
	** 参    数: None
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-18
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function RemoveLineLayer() {
		if (LineLayer) {
			MapPanel.removeOverlay(LineLayer);
			LineLayer = null;
		}
	}

	/*******************************************************************************
	** 函数名称: GetBoundsArray
	** 功能描述: 从EV.LngLatBounds中提取经纬度数组
	** 参    数: aBounds: [输入] EV.LngLatBounds类型
	** 返 回 值: Array<EV.LngLat>
	** 作　  者: 王国蛟
	** 日  　期: 2014-12-20
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function GetBoundsArray(aBounds) {
		var poly_round = [];
		poly_round.push(aBounds.getSouthWest());
		poly_round.push(aBounds.getNorthEast());

		return poly_round;
	}

	/*******************************************************************************
	** 函数名称: GetMapCenter
	** 功能描述: 获取当前地图中心的经纬度
	** 参    数: None
	** 返 回 值: 当前地图中心的经纬度
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-16
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function GetMapCenter() {
		if (!MapPanel) {
			return "";
		}
		var ret_pt = MapPanel.getCenter();
		return ret_pt.lng + "," + ret_pt.lat;
	}

	// 将指定经纬度显示在地图中心
	function SetCenter(aLng, aLat) {
		var tmp_pos = new BMap.Point(aLng, aLat);
		// 不要使用setCenter方法，当位置处于非洲周围的时候该方法失效。。。
		MapPanel.centerAndZoom(tmp_pos, MapPanel.getZoom());
	}

	// 显示指定内容的Loading内容
	function ShowLoading(aMsg)
	{
		window.external.ShowLoading(aMsg);
	}

	// 隐藏Loading条
	function HideLoading()
	{
		window.external.HideLoading();
	}

	/*******************************************************************************
	** 函数名称: ShowRound
	** 功能描述: 居中显示圆形区域
	** 参    数: aLng: 圆心经度
	**			aLat: 圆心纬度
	**			aRad: 半径
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2015-12-08
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function ShowRound(aLng, aLat, aRad, aCenter) {
		var tmp_pos = new BMap.Point(aLng, aLat);

		RemoveAreaLayer();
		AreaLayer = new BMap.Circle(tmp_pos, aRad, AREA_STYLE);
		MapPanel.addOverlay(AreaLayer);
		if (aCenter) {
			MapPanel.setViewport(GetBoundsArray(AreaLayer.getBounds()));
		}
	}

	/*******************************************************************************
	** 函数名称: ShowRect
	** 功能描述: 居中显示矩形区域
	** 参    数: aSLng: 起始位置经度 左上角
	**			aSLat: 起始位置纬度
	**			aELng: 结束位置经度 左上角
	**			aELat: 结束位置纬度
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2015-12-08
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function ShowRect(aSLng, aSLat, aELng, aELat, aCenter) {
		RemoveAreaLayer();
		AreaLayer = new BMap.Polygon([
						new BMap.Point(aSLng, aSLat),
						new BMap.Point(aELng, aSLat),
						new BMap.Point(aELng, aELat),
						new BMap.Point(aSLng, aELat)
		], AREA_STYLE);

		MapPanel.addOverlay(AreaLayer);
		if (aCenter) {
			MapPanel.setViewport(AreaLayer.getPath());
		}
	}

	/*******************************************************************************
	** 函数名称: ShowPoly
	** 功能描述: 居中显示多边形区域
	** 参    数: aList: 多个节点的集合字符串, 各组以;分割，经纬度以,分割
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2015-12-08
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function ShowPoly(aList, aCenter) {
		// 进行经纬度分割提取
		var pos_list = aList.split(";");
		if (pos_list.length <= 0) {
			// 无有效数据返回
			return;
		}

		var poly_round = [];
		for (var i = 0; i < pos_list.length; i++) {
			var tmp_item = pos_list[i].split(",");
			poly_round.push(new BMap.Point(tmp_item[0], tmp_item[1]));
		}

		RemoveAreaLayer();
		AreaLayer = new BMap.Polygon(poly_round, AREA_STYLE);
		MapPanel.addOverlay(AreaLayer);
		if (aCenter) {
			MapPanel.setViewport(poly_round);
		}
	}

	/*******************************************************************************
	** 函数名称: ShowRoute
	** 功能描述: 居中显示路线
	** 参    数: aList: 多个节点的集合字符串, 各组以;分割，经纬度以,分割
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2015-12-08
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function ShowRoute(aList, aCenter) {
		// 进行经纬度分割提取
		var pos_list = aList.split(";");
		if (pos_list.length <= 0) {
			// 无有效数据返回
			return;
		}

		var path_round = [];
		for (var i = 0; i < pos_list.length; i++) {
			var tmp_item = pos_list[i].split(",");
			path_round.push(new BMap.Point(tmp_item[0], tmp_item[1]));
		}

		RemoveLineLayer();
		RemoveAreaLayer();
		AreaLayer = new BMap.Polyline(path_round, ROUTE_STYLE);
		MapPanel.addOverlay(AreaLayer);
		if (aCenter) {
			MapPanel.setViewport(path_round);
		}
	}

	/*******************************************************************************
	** 函数名称: ShowLine
	** 功能描述: 居中显示路段
	** 参    数: aSLng: 起始位置经度
	**			aSLat: 起始位置纬度
	**			aELng: 结束位置经度
	**			aELat: 结束位置纬度
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2015-12-08
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function ShowLine(aSLng, aSLat, aELng, aELat, aCenter) {
		var line_round = [];
		line_round.push(new BMap.Point(aSLng, aSLat));
		line_round.push(new BMap.Point(aELng, aELat));

		RemoveLineLayer();
		LineLayer = new BMap.Polyline(line_round, LINE_STYLE);
		MapPanel.addOverlay(LineLayer);
		if (aCenter) {
			MapPanel.setViewport(line_round);
		}
	}

	/*******************************************************************************
	** 函数名称: MapLocalSearch
	** 功能描述: 地图本地搜索
	** 参    数: 要搜索的字符串
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2015-08-20
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function MapLocalSearch(aStr) {
		ShowLoading("正在搜索，请稍后...");
		if (LocalSearchTool == null) {
			LocalSearchTool = new BMap.LocalSearch(MapPanel, {
				renderOptions: { map: MapPanel }
			});
			LocalSearchTool.setSearchCompleteCallback(function (results) {
				HideLoading();
				// 判断状态是否正确
				if (LocalSearchTool.getStatus() != BMAP_STATUS_SUCCESS) {
					MsgBox("未能搜索到符合您要求的热点！");
				}
				else {
					MsgBox("共查询到" + results.getCurrentNumPois() + "个符合您要求的热点！");
				}
			});
		}
		LocalSearchTool.clearResults();
		LocalSearchTool.search(aStr);
	}

	// 清空搜索结果
	function ClearSearchResult()
	{
		if (LocalSearchTool != null) {
			LocalSearchTool.clearResults();
		}
	}

	/*******************************************************************************
	** 函数名称: OpenDistanceTool
	** 功能描述: 测量两点的距离
	** 参    数: None
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-13
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function OpenDistanceTool() {
		CloseTool();
		CurTool = new BMapLib.DistanceTool(MapPanel);
		CurTool.open();  //开启鼠标测距
	}

	/*******************************************************************************
	** 函数名称: OpenAreaTool
	** 功能描述: 开启面积测量工具
	** 参    数: None
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-13
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function OpenAreaTool() {
		RemoveAreaLayer();
		CloseTool();
		//实例化鼠标绘制工具
		CurTool = new BMapLib.DrawingManager(MapPanel, {
			isOpen: false, //是否开启绘制模式
			enableDrawingTool: false, //是否显示工具栏
			polygonOptions: AREA_STYLE //多边形的样式
		});
		CurTool.setDrawingMode(BMAP_DRAWING_POLYGON);
		CurTool.enableCalculate();
		CurTool.open();
		//添加鼠标绘制工具监听事件，用于获取绘制结果
		CurTool.addEventListener('overlaycomplete', onPolyComplete);
	}

	/*******************************************************************************
	** 函数名称: onPolyComplete
	** 功能描述: 绘制完多边形触发事件
	** 参    数: None
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2015-01-20
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function onPolyComplete(e) {
		AreaLayer = e.overlay;
		MsgBox("共" + e.calculate + "平方米/" + e.calculate / 10000 + "平方公里");
	}

	/*******************************************************************************
	** 函数名称: OpenCircleTool
	** 功能描述: 开启画圆工具
	** 参    数: None
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-18
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function OpenCircleTool() {
		// 清空所有标志
		RemoveAreaLayer();
		CloseTool();
		//实例化鼠标绘制工具
		CurTool = new BMapLib.DrawingManager(MapPanel, {
			isOpen: false, //是否开启绘制模式
			enableDrawingTool: false, //是否显示工具栏
			circleOptions: AREA_STYLE //多边形的样式
		});
		CurTool.setDrawingMode(BMAP_DRAWING_CIRCLE);
		CurTool.open();
		//添加鼠标绘制工具监听事件，用于获取绘制结果
		CurTool.addEventListener('overlaycomplete', onDrawCircle);
	}

	/*******************************************************************************
	** 函数名称: onDrawCircle
	** 功能描述: 绘制圆形触发事件
	** 参    数: aCPoint: [输入] 中心点坐标
	**			 aRadius: [输入] 半径 单位米
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-18
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function onDrawCircle(e) {
		// 更新窗体
		CloseTool();
		AreaLayer = e.overlay;

		var tmp_pos = AreaLayer.getCenter();
		var tmp_rad = AreaLayer.getRadius();

		window.external.OnDrawedRound(tmp_pos.lng, tmp_pos.lat, tmp_rad);
	}

	/*******************************************************************************
	** 函数名称: OpenRectTool
	** 功能描述: 开启绘制矩形工具
	** 参    数: None
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-18
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function OpenRectTool() {
		// 清空所有标志
		RemoveAreaLayer();
		CloseTool();
		//实例化鼠标绘制工具
		CurTool = new BMapLib.DrawingManager(MapPanel, {
			isOpen: false, //是否开启绘制模式
			enableDrawingTool: false, //是否显示工具栏
			rectangleOptions: AREA_STYLE //多边形的样式
		});
		CurTool.setDrawingMode(BMAP_DRAWING_RECTANGLE);
		CurTool.open();
		//添加鼠标绘制工具监听事件，用于获取绘制结果
		CurTool.addEventListener('overlaycomplete', onDrawRect);
	}

	/*******************************************************************************
	** 函数名称: onDrawRect
	** 功能描述: 矩形绘制完成的触发函数
	** 参    数: aBounds: [输入] 完成后的矩形区域
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-18
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function onDrawRect(e) {
		// 更新窗体
		CloseTool();
		AreaLayer = e.overlay;

		var tmp_bounds = AreaLayer.getBounds();
		// 根据808标准获取西北角与东南角坐标
		var s_pos = tmp_bounds.getSouthWest();
		var e_pos = tmp_bounds.getNorthEast();

		window.external.OnDrawedRect(s_pos.lng, s_pos.lat,
									e_pos.lng, e_pos.lat);
	}

	/*******************************************************************************
	** 函数名称: OpenPolyTool
	** 功能描述: 开启多边形绘制工具
	** 参    数: None
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-18
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function OpenPolyTool() {
		// 清空所有标志
		RemoveAreaLayer();
		CloseTool();
		//实例化鼠标绘制工具
		CurTool = new BMapLib.DrawingManager(MapPanel, {
			isOpen: false, //是否开启绘制模式
			enableDrawingTool: false, //是否显示工具栏
			polygonOptions: AREA_STYLE //多边形的样式
		});
		CurTool.setDrawingMode(BMAP_DRAWING_POLYGON);
		CurTool.open();
		//添加鼠标绘制工具监听事件，用于获取绘制结果
		CurTool.addEventListener('overlaycomplete', onDrawPoly);
	}

	/*******************************************************************************
	** 函数名称: onDrawPoly
	** 功能描述: 绘制完多边形事件触发
	** 参    数: aBounds: [输入] 多边形经纬度集合
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-18
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function onDrawPoly(e) {
		CloseTool();
		// 更新窗体
		AreaLayer = e.overlay;

		var posarray = AreaLayer.getPath();
		var pos_list = "";
		for (var i = 0; i < posarray.length; i++) {
			pos_list += posarray[i].lng + "," + posarray[i].lat + ";";
		}

		// 更新窗体
		window.external.OnDrawedPoly(pos_list);
	}

	/*******************************************************************************
	** 函数名称: OpenRouteTool
	** 功能描述: 开启路线绘制工具
	** 参    数: None
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-18
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function OpenRouteTool() {
		// 清空所有标志
		RemoveLineLayer();
		RemoveAreaLayer();
		CloseTool();
		//实例化鼠标绘制工具
		CurTool = new BMapLib.DrawingManager(MapPanel, {
			isOpen: false, //是否开启绘制模式
			enableDrawingTool: false, //是否显示工具栏
			polylineOptions: ROUTE_STYLE //多边形的样式
		});
		CurTool.setDrawingMode(BMAP_DRAWING_POLYLINE);
		CurTool.open();
		//添加鼠标绘制工具监听事件，用于获取绘制结果
		CurTool.addEventListener('overlaycomplete', onDrawRoute);
	}

	/*******************************************************************************
	** 函数名称: onDrawRoute
	** 功能描述: 绘制完路线事件触发
	** 参    数: aPts: [输入] 路线经纬度集合
	** 返 回 值: None
	** 作　  者: 王国蛟
	** 日  　期: 2014-04-18
	**------------------------------------------------------------------------------
	** 修 改 人:
	** 日　  期:
	**------------------------------------------------------------------------------
	********************************************************************************/
	function onDrawRoute(e) {
		CloseTool();
		// 更新窗体
		AreaLayer = e.overlay;

		var posarray = AreaLayer.getPath();
		var pos_list = "";
		for (var i = 0; i < posarray.length; i++) {
			pos_list += posarray[i].lng + "," + posarray[i].lat + ";";
		}

		// 更新窗体
		window.external.OnDrawedRoute(pos_list);
	}
