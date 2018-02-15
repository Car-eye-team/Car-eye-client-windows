using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CarEyeClient.Model
{
	/// <summary>
	/// 实体类工具集
	/// </summary>
	public static class ModelUtils
	{
		/// <summary>
		/// 获取字段描述
		/// </summary>
		/// <param name="aFieldInfo">FieldInfo</param>
		/// <returns>DescriptionAttribute[] </returns>
		private static DescriptionAttribute[] GetDescriptAttr(FieldInfo aFieldInfo)
		{
			if (aFieldInfo != null)
			{
				return (DescriptionAttribute[])aFieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
			}

			return null;
		}

		/// <summary>
		/// 获取枚举类型的描述
		/// </summary>
		/// <param name="aEnum">枚举类型</param>
		/// <returns></returns>
		public static string ToDescription(this Enum aEnum)
		{
			FieldInfo fieldInfo = aEnum.GetType().GetField(aEnum.ToString());
			DescriptionAttribute[] attrs = GetDescriptAttr(fieldInfo);
			if (attrs != null && attrs.Length > 0)
			{
				return attrs[0].Description;
			}

			return aEnum.ToString();
		}

		/// <summary>
		/// 将对象转化为Json字符串
		/// </summary>
		/// <typeparam name="T">源类型</typeparam>
		/// <param name="aObj">源类型实例</param>
		/// <returns>Json字符串</returns>
		public static string ToJson<T>(this T aObj) where T : JsonBase
		{
			try
			{
				if (aObj == null)
				{
					return null;
				}

				DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(aObj.GetType());
				using (MemoryStream ms = new MemoryStream())
				{
					jsonSerializer.WriteObject(ms, aObj);
					return Encoding.UTF8.GetString(ms.ToArray());
				}
			}
			catch (System.Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// 从Json字符串中获取Json对象
		/// </summary>
		/// <typeparam name="T">目标类型</typeparam>
		/// <param name="aStrJson">Json字符串</param>
		/// <returns>目标类型的一个实例</returns>
		public static T GetJsonObject<T>(string aStrJson) where T : JsonBase
		{
			try
			{
				T obj = Activator.CreateInstance<T>();
				using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(aStrJson)))
				{
					DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(obj.GetType());
					return (T)jsonSerializer.ReadObject(ms);
				}
			}
			catch (System.Exception)
			{
				return default(T);
			}
		}
	}
}
