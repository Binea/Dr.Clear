var apiAjax = function(){  //options:path,params,type
	var self = this;
	this.host = 'http://www.clearbos.com';
    //this.host = 'http://1dp5014066.imwork.net';
	this.post = function(options,success,error){
		$.ajax({
			type:"post",
			url:self.host+options.path,
			data:options.params,
			dataType:'jsonp',
			success: function(msg){
				success(msg,options);
			},
			error: function(msg){
				error(msg,options);
			}
		});
	}
	this.doctorRegister=function(params,success,error){  //医生注册
		params.operationType='Register_D';
		var options={
			path:'/doctorService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.factoryRegister=function(params,success,error){  //工厂注册
		params.operationType='Register_F';
		var options={
			path:'/factoryService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.verifyCode=function(params,success,error){  //短信验证码
		params.operationType='message';
		var options={
			path:'/BaseService.ashx',
			params:params
		}
		console.log(options);
		this.post(options,success,error);
	}
	this.factoryLogin=function(params,success,error){  //工厂登录
		params.operationType='Login';
		var options={
			path:'/factoryService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.doctorLogin=function(params,success,error){  //医生登录
		params.operationType='Login_D';
		var options={
			path:'/doctorService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.factoryLoginOut=function(params,success,error){  //工厂退出登陆
		params.operationType='Login_out';
		var options={
			path:'/factoryService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.doctorLoginOut=function(params,success,error){  //医生退出登陆
		params.operationType='login_out';
		var options={
			path:'/doctorService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.factoryGetNum = function(params,success,error){  //工厂认证获取工厂数量
		params.operationType = 'GetNum';
		var options = {
			path:'/factoryService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.doctorGetNum = function(params,success,error){  //医生认证获取医生数量
		params.operationType = 'doctorNum';
		var options = {
			path:'/doctorService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.getSimpleEMRService=function(params,success,error){  //医生病例列表
		params.operationType='d_list';
		var options={
			path:'/simpleEMRService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.factoryCerty = function(params,success,error){  //工厂认证
		params.operationType='certification_F';
		var options={
			path:'/factoryService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.doctorCerty = function(params,success,error){  //医生认证/新增
		params.operationType='certification_D';
		var options={
			path:'/doctorService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.updateDoctorCerty = function(params,success,error){  //医生认证编辑
		params.operationType='update_d_certification';
		var options={
			path:'/doctorService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.deleteDoctorCerty = function(params,success,error){  //医生认证编辑
		params.operationType='delete_d_certification';
		var options={
			path:'/doctorService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.addressHospital = function(params,success,error){  //地址医院科室
		params.operationType='BaseData';
		var options={
			path:'/BaseService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.positionalTitle = function(params,success,error){  //职称
		params.operationType='titles';
		var options={
			path:'/BaseService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.factoryList = function(params,success,error){  //工厂列表(列表)
		//type:1:列表 2:接单,排产 3:物流 4:搜索
		if(params.type == 1) params.operationType='f_list'; 
		else if(params.type == 2) params.operationType='update_emr_status';
		else if(params.type == 3) params.operationType='express';
		else if(params.type == 4) params.operationType='find_Emr_f';
		var options={
			path:'/simpleEMRService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.logisticalName = function(params,success,error){ //物流公司
		params.operationType='expressCompany';
		var options={
			path:'/factoryService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.factoryRecords = function(params,success,error){  //工厂交易记录
		params.operationType='deal';
		var options={
			path:'/factoryService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.factoryOrderList = function(params,success,error){  //工厂订单详情
		params.operationType='simple_emr';
		var options={
			path:'/simpleEMRService.ashx',
			params:params
		}
		this.post(options,success,error);
	}

	this.searchEmr=function(params,success,error){  //医生搜索
		params.operationType='find_Emr_d';
		var options={
			path:'/simpleEMRService.ashx',
			params: params            
		}
		console.log(params);
		this.post(options,success,error);
	}

	this.factorInfo = function(params,success,error){  //工厂信息
		params.operationType='setInfo';
		var options={
			path:'/factoryService.ashx',
			params:params
		}
		this.post(options,success,error);
	}

	this.addEmr=function(params,success,error){
		params.operationType='New';
		var options={
			path:'/simpleEMRService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.updateEmrStatus=function(params,success,error){
		params.operationType='update_emr_status';
		var options={
			path:'/simpleEMRService.ashx',
			params:params
		}
		this.post(options,success,error);
	}

	this.updateDoctorInfo=function(params,success,error){
		params.operationType='update_info';
		var options={
			path:'/doctorService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.doctorDataLog=function(params,success,error){  //病例进程
		params.operationType='simple_stream';
		var options={
			path:'/simpleEMRService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.doctorCertyPower=function(params,success,error){  //认证信息授权
		params.operationType='authorize_technician';
		var options={
			path:'/doctorService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.weixinLogin = function(params,success,error){  //微信登录
		params.operationType='Addweixin';
		var options={
			path:'/weixin.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.weixinDetails = function(params,success,error){ //微信病例详情
		params.operationType='weixin';
		var options={
			path:'/weixin.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.doctorFcode=function(params,success,error){
		params.operationType='F_Code';
		var options={
			path:'/doctorService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.getFileChange=function(params,success,error){
		params.operationType='isFileChange';
		var options={
			path:'/simpleEMRService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.addDoctorRemark=function(params,success,error){
		params.operationType='update_doctorRemark';
		var options={
			path:'/simpleEMRService.ashx',
			params:params
		}
		this.post(options,success,error);
	}
	this.newemrCode = function (params, success, error) {
	    var options = {
	        path: '/simpleEMRService.ashx',
	        params: params
	    }
	    this.post(options, success, error);
	}

	this.designLogin = function (params, success, error) {  //设计登录
	    params.operationType = 'Login_desgin';
	    var options = {
	        path: '/designerService.ashx',
	        params: params
	    }
	    this.post(options, success, error);
	}

	this.designList = function (params, success, error) {  //设计列表
	    params.operationType = 'design_list';
	    var options = {
	        path: '/simpleEMRService.ashx',
	        params: params
	    }
	    this.post(options, success, error);
	}
	this.designersearchEmr = function (params, success, error) {  //设计搜索
	    params.operationType = 'find_Emr_design';
	    var options = {
	        path: '/simpleEMRService.ashx',
	        params: params
	    }
	    console.log(params);
	    this.post(options, success, error);
	}
	this.updateDesignerInfo = function (params, success, error) {//更新设计组信息
	    params.operationType = 'update_designer_info';
	    var options = {
	        path: '/designerService.ashx',
	        params: params
	    }
	    this.post(options, success, error);
	}
	this.getstldata = function (params, success, error) {//获取stl文件数据
	    params.operationType = 'get_stl';
	    var options = {
	        path: '/simpleEMRService.ashx',
	        params: params
	    }
	    this.post(options, success, error);
	}
	this.addstldata = function (params, success, error) {//上传stl文件数据
	    params.operationType = 'uploadmodel';
	    var options = {
	        path: '/doctorService.ashx',
	        params: params
	    }
	    this.post(options, success, error);
	}
}

var api=new apiAjax();

/*
var callback=$_GET['callback'];//每个请求要拿到callback参数的值

//将已经处理好的json格式的数据，拼接callback参数的值，再返回给客户端（解决跨域问题，以后如果不跨域，更改此方法，将拼接去掉即可）
//下面是个示例方法  不同语言请自行拼接
//拼接格式为  callback(json)
function jsonResponse(callback,json){
	return callback . "(".json.")";
}*/
