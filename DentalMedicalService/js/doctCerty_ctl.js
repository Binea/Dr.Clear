/**
 * 
 * @authors Your Name (you@example.org)
 * @date    2016-02-18 11:31:49
 * @version $Id$
 */

$(function(){
	var RealName; //真实姓名
	var dres_province; //地址 省
	var dres_city; //地址 市
	var dres_hosp; //医院
	var drs_depart;//科室
 	var doc_Certytype; //职称

 	// 初始化数据
 	$('.doc_realName>input').val('');
 	$('.dres_province option:first').prop("selected",'selected');
 	$('.dres_city option:first').prop("selected",'selected');
 	$('.dres_hosp option:first').prop("selected",'selected');
 	$('.drs_depart option:first').prop("selected",'selected');
 	$('.doc_Certytype option:first').prop("selected",'selected');


 	// 选择值获取
	$('.dres_province').change(function(){  //省获取
	    dres_province = $('.dres_province option:selected').text();
	})
	$('.dres_city').change(function(){ //市获取
		dres_city = $('.dres_city option:selected').text();
	})
	$('.dres_hosp').change(function(){ //医院获取
		dres_hosp = $('.dres_hosp option:selected').text();
	})
	$('.drs_depart').change(function(){ //科室获取
		drs_depart = $('.drs_depart option:selected').text();
	})
	$('.doc_Certytype').change(function(){ //职称获取
		doc_Certytype = $('.doc_Certytype option:selected').text();
	})

	// 工作牌上传路径

	// 提交认证
	$('.open_btn>div').click(function(){
		RealName =  $('.doc_realName>input').val(); 
		if(RealName){ //姓名验证			
			if(dres_province){ //验证地址 省
				if(dres_province !== '省'){ 
					if(dres_city){ //验证地址 市
						if(dres_city !== '市'){
							if(dres_hosp){ //验证医院
								if(dres_hosp !== '医院'){
									if(drs_depart){ //科室验证
										if( drs_depart !== '科室'){
											if(doc_Certytype){ //职位验证
												if(doc_Certytype !== '职位'){
													$.ajax({
														type:'post',
														url:'http://192.168.3.112:4545/GetTest.ashx',
														data:{
															RealName :RealName,
															hospitalId :dres_hosp,
															departmentId :drs_depart,
															titleId :doc_Certytype ,
															operationType:'certification_D',
														},
														dataType:'jsonp',
														success:function(data){
															if(data){
																window.open('file:///E:/ZhuoShuiDental/Dentalweb/doctor/doct_index.html','_self'); //打开医生端首页
															}
														},
														error:function(){
															alert('认证请求错误！')
														}
													})
												}else{
													alert('请填写职称信息！')
												}
											}else{
												alert('请填写职称信息！')
											}	
										}else{
											alert('请填写科室信息！')
										}
									}else{
										alert('请填写科室信息！')	
									}
								}else{
									alert('请填写医院信息！')	
								}
							}else{
								alert('请填写医院信息！')	
							}
						}else{
							alert('请填写市信息！')
						}
					}else{
						alert('请填写市信息！')
					}
				}else{
					alert('请填写省信息！')
				}
			}else{
				alert('请填写省信息！')
			}
		}else{
			alert('请填写姓名！')
		}
	})
	// click结束

})