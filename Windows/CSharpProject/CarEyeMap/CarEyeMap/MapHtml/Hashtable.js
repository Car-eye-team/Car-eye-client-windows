// Hashtable构造
function Hashtable() {
	this.count = 0;
	this.contant = new Object();

	// 添加
	this.add = function (key, value) {
		if (!this.hasKey(key)) {
			this.count++;
		}

		this.contant[key] = value;
	}

	// 输出字符串
	this.toString = function () {
		var strHash = "";
		for (var key in this.contant) {
			strHash += "," + key + "=" + this.contant[key];
		}
		if (strHash != "") {
			strHash = strHash.substring(1, strHash.length);
		}
		return strHash;
	}

	// 清空Hashtable
	this.clear = function () {
		for (var key in this.contant) {
			this.delKey(key);
		}
		this.count = 0;
	}

	// 根据键值获取内容
	this.getValue = function (key) {
		return this.contant[key];
	}

	// 判断是否包含此键值
	this.hasKey = function (key) {
		if (key == null) return false;
		return (key in this.contant);
	}

	// 根据内容获取键值
	this.getKey = function (value) {
		var tempKey;
		for (var key in this.contant) {
			if (this.contant[key] == value) {
				tempKey += key;
			}
		}
		return tempKey;
	}

	// 删除制定键值内容
	this.delKey = function (key) {
		if (this.hasKey(key)) {
			this.count--;
		}
		delete this.contant[key];
	}

	// 获取所有内容
	this.getValues = function () {
		var values = new Array();
		for (var prop in contant) {
			values.push(contant[prop]);
		}
		return values;
	}

	// 获取所有键值
	this.getKeys = function () {
		var keys = new Array();
		for (var prop in contant) {
			keys.push(prop);
		}
		return keys;
	}

	// 合并另外一个Hashtable
	this.merge = function (ht) {
		for (var key in ht.contant) {
			this.add(key, ht.getValue(key));
		}
	}
}
