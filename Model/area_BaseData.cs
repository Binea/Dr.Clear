using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// area_BaseData:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class area_BaseData
	{
		public area_BaseData()
		{}
		#region Model
		private string _codeid;
		private string _parentid;
		private string _cityname;
		/// <summary>
		/// 
		/// </summary>
        public string codeid
		{
			set{ _codeid=value.ToLower();}
			get{return _codeid.ToLower();}
		}
		/// <summary>
		/// 
		/// </summary>
        public string parentid
		{
			set{ _parentid=value.ToLower();}
			get{return _parentid.ToLower();}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cityName
		{
			set{ _cityname=value;}
			get{return _cityname;}
		}
		#endregion Model

	}
}

