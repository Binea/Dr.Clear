/**
 * 
 * @authors Your Name (you@example.org)
 * @date    2016-02-17 15:34:39
 * @version $Id$
 */
 $(function(){

 	var doctorPwd ; //密码域
 	var doctorPwd_reg; //确认密码域
 	var pwd_length; //密码长度
 	var doctorPwd_reg_length;//确认密码长度
 	var key; //验证码

 	function show_defaultTip(){ //确认密码输入错误
 		$('.repeat>span').html("两次输入密码不相同<i><b>!!</b></i>").css('vertical-align','baseline');
 	}
 	function show_trueTip(){ //确认密码输入正确
 		$('.repeat>span').html("<img src='images/icon_sin_true.png'>").css('vertical-align','-webkit-baseline-middle');
 	}

 	// 初始加载
 	$('.repeat>span').html("<i>*</i>请再次输入").css('vertical-align','baseline');
 	$('.sinPsw>input').val(''); //清空
 	$('.repeat>input').val('');
 	$('.vertif>input').val('');
 	$('.sinPhone>input').val('');


 	// 密码验证
 	$('.sinPsw>input').change(function(){
 		doctorPwd = $('.sinPsw>input').val();
 	    pwd_length = doctorPwd.length;
 		if(pwd_length < 6){
 			show_defaultTip();
 			alert('密码长度不小于6位数！');
 		}else if(pwd_length>0){		
 			if(doctorPwd == doctorPwd_reg){
 				show_trueTip();
 			}else if(doctorPwd_reg_length>0){
 				show_defaultTip();
 			}
 		}
 	})
 	$('.repeat>input').change(function(){		 
 		 doctorPwd_reg=$('.repeat>input').val();
 		 doctorPwd_reg_length = doctorPwd_reg.length;
 		if(doctorPwd !== doctorPwd_reg){
 			show_defaultTip();
 		}else if(pwd_length>0){
 			show_trueTip();
 		}
 	})

 	// 验证码验证
 	key = $('.vertif>input').val()

 	// 提交注册
     $('.sinNow').click(function(){
     	// 手机验证
     	var doctorCode = $('.sinPhone>input').val();
     	var doctorCode_reg = !!doctorCode.match(/^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/);
     	if(doctorCode_reg == false){
     		alert('请填写真实手机号')
     	}else if(pwd_length >= 6){ //密码存在
 		    	if(doctorPwd == doctorPwd_reg){ //用户名密码相同
 			    	// ajax请求
 			    	var data = {
 			    		 doctorCode : doctorCode,
 			    		 doctorPwd: doctorPwd,
 			    		 Key:key,
 			    		 operationType:'Register_D',
 			    	}
				  	$.ajax({
				  		type:'post',
				  		url:'http://192.168.3.112:4545/GetTest.ashx',
				  		data:data,
				  		dataType:'jsonp',
				  		success:function(data){
				  			if(data){ //data为true时
				  				 window.open('file:///E:/ZhuoShuiDental/Dentalweb/doctor/doctor_Certy.html','_self'); //打开医生认证页面
				  			}		  		
				  		},
				  		error:function(data){
				  			alert('请求不成功！');
				  		}
				  	})
				  	// 请求结束
 		    	}else{
 		    		alert('两次输入密码不相同！')
 		    	}
     	}else{
     		alert('请输入完整密码')
     	}
   	})
     // 提交注册结束


 })