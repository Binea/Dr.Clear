using System;
namespace DentalMedical.Model
{
	/// <summary>
	/// FaceImage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FaceImage
	{
		public FaceImage()
		{}
		#region Model
		private Guid _id;
		private string _emr_code;
		private string _imagepath;
		private int _orderid;
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
		/// 病历编号
		/// </summary>
		public string EMR_Code
		{
			set{ _emr_code=value;}
			get{return _emr_code;}
		}
		/// <summary>
		/// 图片路径(也有可能为二进制)
		/// </summary>
		public string imagePath
		{
			set{ _imagepath=value;}
			get{return _imagepath;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int orderId
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
	///
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

