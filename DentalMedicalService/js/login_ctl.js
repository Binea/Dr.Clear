/**
 * 
 * @authors Your Name (you@example.org)
 * @date    2016-02-14 15:07:30
 * @version $Id$
 */

 /*-------------------------------初始变量----------------------------*/ 



 document.write('<script src="../js/login_data.js"><\/script>');


 $(function(){

	var puserCode; //用户名
	var puserPwd;//密码
/*-------------------------------submit----------------------------*/ 
 	// 登录验证
 	$('.submit').click(function(){
 		puserCode = $('.userNameInput').val();
 		puserPwd  = $('.passwordInput').val();
 		if(!puserCode ||!puserPwd)
 		{
 			alert('用户名或密码不能为空');
 		}
 		else
 		{
			$.ajax({
				type:'post',
				url:'http://192.168.3.112:4545/GetTest.ashx',
				data:{
					userCode:puserCode,
					userPwd:puserPwd,
					operationType:'Login_D'
				},
				dataType:'jsonp',
				success:function(data){	
					console.log(data)
					//ajax请求的数据set进构造函数
					 // var userRealName = data[7]; 
					 // vLoginInfo.setUserRealName(userRealName); 
					 saveUserName(data[7]);
					 
					 // 下拉框数组
					 // for( i =0; i < data[5].length; i++)
					 // {
 					// 	setDocWorkAdd(data[5][i].userDepartment, data[5][i].userHospital)
 					//  }
					for( i =0; i < 3; i++)
					 {
 						setDocWorkAdd(i+i, i*i);
 					 }

 					 saveDocWorkAdd();






					 // // 数据存储
					 // var get_userRealName = vLoginInfo.getUserRealName(); //从构造函数获取数据get_
					 // sessionStorage.setItem("ss_userRealName", get_userRealName); //将从构造函数获取的数据存在sessionStorage上ss_
					 window.open('file:///E:/ZhuoShuiDental/Dentalweb/doctor/doct_index.html','_self'); //打开医生端首页	 			
				},
				error:function(){ 
					console.log('error')
				}
			})
		} 
 	})
 	// click结束
 })

