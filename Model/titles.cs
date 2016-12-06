using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// titles:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class titles
	{
		public titles()
		{}
		#region Model
		private Guid _id;
		private string _titlename;
		private string _titleintroduction;
		private int? _orderid;
		private DateTime _createdate;
		private Guid _createid;
		private DateTime? _modifydate;
		private Guid _modifyid;
		private int _flag;
		/// <summary>
		/// id,建议创建时为guid
		/// </summary>
		public Guid Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 职称
		/// </summary>
		public string titleName
		{
			set{ _titlename=value;}
			get{return _titlename;}
		}
		/// <summary>
		/// 简介
		/// </summary>
		public string titleIntroduction
		{
			set{ _titleintroduction=value;}
			get{return _titleintroduction;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int? orderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid createId
		{
			set{ _createid=value;}
			get{return _createid;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? modifyDate
		{
			set{ _modifydate=value;}
			get{return _modifydate;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public Guid modifyId
		{
			set{ _modifyid=value;}
			get{return _modifyid;}
		}
		/// <summary>
		/// 是否有效
		/// </summary>
		public int flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		#endregion Model

	}
}

