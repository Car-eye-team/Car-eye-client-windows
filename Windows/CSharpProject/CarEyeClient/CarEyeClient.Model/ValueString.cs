using System;

namespace CarEyeClient.Model
{
	/// <summary>
	/// 包含有一个值与一个字符串的泛型类
	/// </summary>
	public class ValueString<T> : IComparable where T : IComparable
	{
		/// <summary>
		/// 值类型
		/// </summary>
		public T Value { get; set; }
		/// <summary>
		/// 字符串
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="aValue">初始值</param>
		/// <param name="aText">初始字符串</param>
		public ValueString(T aValue, string aText)
		{
			Value = aValue;
			Text = aText;
		}

		/// <summary>
		/// 构造函数, 默认值都为null
		/// </summary>
		public ValueString()
		{

		}

		/// <summary>
		/// 重写ToString函数，返回Text值
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.Text;
		}

		/// <summary>
		/// 根据Value值比较大小
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int CompareTo(object obj)
		{
			try
			{
				ValueString<T> tmp_val = obj as ValueString<T>;

				if (this.Value == null && tmp_val.Value == null)
				{
					return 0;
				}
				if (this.Value == null)
				{
					return -1;
				}
				if (tmp_val.Value == null)
				{
					return 1;
				}
				return this.Value.CompareTo(tmp_val.Value);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
