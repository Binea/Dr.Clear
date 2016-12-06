using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// FD_relation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FD_relation
	{
		public FD_relation()
		{}
		#region Model
		private Guid _id;
		private Guid _factory_id;
		private Guid _doctor_id;
		private string _cremark;
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
		/// 工厂Id
		/// </summary>
		public Guid factory_Id
		{
			set{ _factory_id=value;}
			get{return _factory_id;}
		}
		/// <summary>
		/// 医生Id
		/// </summary>
		public Guid doctor_Id
		{
			set{ _doctor_id=value;}
			get{return _doctor_id;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string cRemark
		{
			set{ _cremark=value;}
			get{return _cremark;}
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

