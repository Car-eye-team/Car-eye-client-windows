using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CarEyeMap
{
	/// <summary>
	/// 地球坐标结构
	/// </summary>
	[Serializable]
	[DataContract]
	public struct Coordinate
	{
		/// <summary>
		/// 获取一个空的地球坐标
		/// </summary>
		public static readonly Coordinate Empty = new Coordinate();

		/// <summary>
		/// X轴坐标(经度)
		/// </summary>
		[DataMember]
		private double mX;
		/// <summary>
		/// Y轴坐标(纬度)
		/// </summary>
		[DataMember]
		private double mY;
		/// <summary>
		/// 本坐标是否不为空, 结构体不能赋初始值
		/// </summary>
		[DataMember]
		private bool mNotEmpty;

		/// <summary>
		/// 本坐标是否为空坐标，未赋值的坐标
		/// </summary>
		[DataMember]
		public bool IsEmpty
		{
			get
			{
				return !this.mNotEmpty;
			}
			set { }
		}

		/// <summary>
		/// X轴坐标(经度)
		/// </summary>
		[DataMember]
		public double X
		{
			get
			{
				return this.mX;
			}
			set
			{
				this.mX = value;
				this.mNotEmpty = true;
			}
		}
		/// <summary>
		/// Y轴坐标(纬度)
		/// </summary>
		[DataMember]
		public double Y
		{
			get
			{
				return this.mY;
			}
			set
			{
				this.mY = value;
				this.mNotEmpty = true;
			}
		}

		/// <summary>
		/// 构造函数，可直接赋值
		/// </summary>
		/// <param name="aX">X轴坐标(经度)</param>
		/// <param name="aY">Y轴坐标(纬度)</param>
		public Coordinate(double aX, double aY)
		{
			this.mX = aX;
			this.mY = aY;
			this.mNotEmpty = true;
		}

		/// <summary>
		/// 构造函数，根据经纬度字符串进行构造
		/// </summary>
		/// <param name="aLngLat">经纬度字符串，格式为[X,Y]</param>
		/// <param name="aFrmt">解析经纬度字符串格式,false则为[Y,X]格式</param>
		public Coordinate(string aLngLat, bool aFrmt = true)
		{
			this.mX = 0.0;
			this.mY = 0.0;
			this.mNotEmpty = false;
			Set(aLngLat, aFrmt);
		}

		/// <summary>
		/// 将“经度,纬度”格式的字符串转换为坐标
		/// </summary>
		/// <param name="aLngLat">经纬度字符串，格式为[X,Y]</param>
		/// <param name="aFrmt">解析经纬度字符串格式,false则为[Y,X]格式</param>
		public void Set(string aLngLat, bool aFrmt = true)
		{
			string[] str_buf = aLngLat.Split(',');
			try
			{
				double tmp_x = Convert.ToDouble(str_buf[0].Trim());
				double tmp_y = Convert.ToDouble(str_buf[1].Trim());
				this.mX = aFrmt ? tmp_x : tmp_y;
				this.mY = aFrmt ? tmp_y : tmp_x;
				this.mNotEmpty = true;
			}
			catch
			{
				this.mNotEmpty = false;
			}
		}

		/// <summary>
		/// 重写Equals方法，判断坐标是否相等
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (!(obj is Coordinate))
			{
				return false;
			}

			Coordinate tmp_pnt = (Coordinate)obj;
			return (((tmp_pnt.X == this.X) && (tmp_pnt.Y == this.Y)) && tmp_pnt.GetType().Equals(base.GetType()));
		}

		/// <summary>
		/// 将当前坐标在经纬度上向东南偏移，即经度相加，纬度相减
		/// </summary>
		/// <param name="aPoint"></param>
		public void Offset(Coordinate aPoint)
		{
			this.Offset(aPoint.X, aPoint.Y);
		}

		/// <summary>
		/// 将当前坐标在经纬度上向东南偏移，即经度相加，纬度相减
		/// </summary>
		/// <param name="aX"></param>
		/// <param name="aY"></param>
		public void Offset(double aX, double aY)
		{
			this.X += aY;
			this.Y -= aX;
		}

		/// <summary>
		/// 返回此实例的哈希代码
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (this.X.GetHashCode() ^ this.Y.GetHashCode());
		}

		/// <summary>
		/// 将坐标转为"经度X,纬度Y"格式字符串输出
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("{0},{1}", X, Y);
		}

		/// <summary>
		/// 将坐标转为"纬度Y,经度X"格式输出
		/// </summary>
		/// <returns></returns>
		public string ToRString()
		{
			return string.Format("{0},{1}", Y, X);
		}

		#region 运算符重写方法

		/// <summary>
		/// 两个坐标经纬度相加运算符实现
		/// </summary>
		/// <param name="aPt1"></param>
		/// <param name="aPt2"></param>
		/// <returns></returns>
		public static Coordinate operator +(Coordinate aPt1, Coordinate aPt2)
		{
			return new Coordinate(aPt1.X + aPt2.X, aPt1.Y + aPt2.Y);
		}

		/// <summary>
		/// 两个坐标经纬度相减运算符实现
		/// </summary>
		/// <param name="aPt1"></param>
		/// <param name="aPt2"></param>
		/// <returns></returns>
		public static Coordinate operator -(Coordinate aPt1, Coordinate aPt2)
		{
			return new Coordinate(aPt1.X - aPt2.X, aPt2.Y - aPt1.Y);
		}

		/// <summary>
		/// 两个坐标相等运算符实现
		/// </summary>
		/// <param name="aPt1"></param>
		/// <param name="aPt2"></param>
		/// <returns></returns>
		public static bool operator ==(Coordinate aPt1, Coordinate aPt2)
		{
			return ((aPt1.X == aPt2.X) && (aPt1.Y == aPt2.Y));
		}

		/// <summary>
		/// 两个坐标不等运算符实现
		/// </summary>
		/// <param name="aPt1"></param>
		/// <param name="aPt2"></param>
		/// <returns></returns>
		public static bool operator !=(Coordinate aPt1, Coordinate aPt2)
		{
			return !(aPt1 == aPt2);
		}

		/// <summary>
		/// 两个坐标经纬度大于运算符实现，西南小，东北大
		/// </summary>
		/// <param name="aPt1"></param>
		/// <param name="aPt2"></param>
		/// <returns></returns>
		public static bool operator >(Coordinate aPt1, Coordinate aPt2)
		{
			if (aPt1.X > aPt2.X && aPt1.Y > aPt2.Y)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// 两个坐标经纬度大于等于运算符实现，西南小，东北大
		/// </summary>
		/// <param name="aPt1"></param>
		/// <param name="aPt2"></param>
		/// <returns></returns>
		public static bool operator >=(Coordinate aPt1, Coordinate aPt2)
		{
			if (aPt1.X >= aPt2.X && aPt1.Y >= aPt2.Y)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// 两个坐标经纬度小于运算符实现，西南小，东北大
		/// </summary>
		/// <param name="aPt1"></param>
		/// <param name="aPt2"></param>
		/// <returns></returns>
		public static bool operator <(Coordinate aPt1, Coordinate aPt2)
		{
			if (aPt1.X < aPt2.X && aPt1.Y < aPt2.Y)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// 两个坐标经纬度小于等于运算符实现，西南小，东北大
		/// </summary>
		/// <param name="aPt1"></param>
		/// <param name="aPt2"></param>
		/// <returns></returns>
		public static bool operator <=(Coordinate aPt1, Coordinate aPt2)
		{
			if (aPt1.X <= aPt2.X && aPt1.Y <= aPt2.Y)
			{
				return true;
			}

			return false;
		}

		#endregion

		/// <summary>
		/// 将包含经纬度的字符串整理为经纬度字符串集合
		/// </summary>
		/// <param name="aPoints">包含经纬度的字符串,每组用;分割,经纬度间使用,号分割</param>
		/// <returns></returns>
		public static List<Coordinate> GetCoordinates(string aPoints)
		{
			// 传递进来的参数最后带有;号
			string strLst = aPoints.TrimEnd(';');
			if (string.IsNullOrEmpty(strLst))
			{
				return null;
			}

			string[] posLst = strLst.Split(';');
			List<Coordinate> tmpLst = new List<Coordinate>();
			foreach (string tmpStr in posLst)
			{
				tmpLst.Add(new Coordinate(tmpStr));
			}

			return tmpLst;
		}
	}
}
