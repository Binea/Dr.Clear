/**
 * 
 * @authors Your Name (you@example.org)
 * @date    2016-02-16 11:44:16
 * @version $Id$
 // */
 // document.write('<script src="../js/head_ctl.js"><\/script>');
 // document.write('<script src="data:application/octet-stream;base64,DQogZG9jdW1lbnQud3JpdGUoJzxzY3JpcHQgc3JjPSIuLi9qcy9pbmRleF9zY2hlbWVfZGF0YS5qcyI+PFwvc2NyaXB0PicpOw0KDQogJChmdW5jdGlvbigpIHsNCg0KIAkvLyDlvqrnjq/liqDovb3lpJrliJfmlbDmja4NCiAJZnVuY3Rpb24gbGlzdExvb3AoKXsNCiAJCXZhciBsaXN0RnVuX2xlbmd0aCA9IGFyci5sZW5ndGg7IA0KIAkJZm9yICggdmFyIGkgPSAwOyBpIDxsaXN0RnVuX2xlbmd0aDsgaSsrKXsNCg0KIAkJICAgIHZhciBuZXdfaW1hZ2VQYXRoID0gYXJyW2ldLmdldFNob3dJbSgpOw0KIAkJCXZhciBuZXdfcGF0aWVudF9OYW1lID0gYXJyW2ldLmdldFNIb3dOYW1lKCk7DQogCQkJdmFyIG5ld19FTVJfQ29kZSA9IGFycltpXS5nZXRTaG93TnVtKCk7DQogCQkJdmFyIG5ld19tYWluX3N1aXQgPSBhcnJbaV0uZ2V0U2hvd1NheSgpOw0KIAkJCXZhciBuZXdfdGhlcmFwZXV0aWNfc2NoZWR1bGUgPSBhcnJbaV0uZ2V0U2hvd1dheSgpOw0KIAkJCXZhciBuZXdfZG9jdG9yUmVtYXJrID0gYXJyW2ldLmdldFNob3dXcml0ZSgpOw0KDQogCQkJdmFyIGFwcGVuZExpc3QgPSAnPGRpdiBjbGFzcz0ibWFpbkJveCI+PHVsPicNCiAJCQkJCQkJKyc8bGkgY2xhc3M9Imxpc3RJbSI+PGltZyBzcmM9IicrbmV3X2ltYWdlUGF0aCsnIj48L2xpPicNCiAJCQkJCQkJKyc8bGkgY2xhc3M9Imxpc3ROYW1lIj4nK25ld19wYXRpZW50X05hbWUrJzwvbGk+Jw0KIAkJCQkJCQkrJzxsaSBjbGFzcz0ibGlzdE51bSI+JytuZXdfRU1SX0NvZGUrJzwvbGk+Jw0KIAkJCQkJCQkrJzxsaSBjbGFzcz0ibGlzdFNheSI+PGRpdj4nK25ld19tYWluX3N1aXQrJzwvZGl2PjwvbGk+Jw0KIAkJCQkJCQkrJzxsaSBjbGFzcz0ibGlzdFdheSI+PGRpdj4nK25ld190aGVyYXBldXRpY19zY2hlZHVsZSsnPC9kaXY+PC9saT4nDQogCQkJCQkJCSsnPGxpIGNsYXNzPSJsaXN0UmVjb3JkIj48ZGl2PicrbmV3X2RvY3RvclJlbWFyaysnPC9kaXY+PC9saT4nDQogCQkJCQkJCSsnPGxpIGNsYXNzPSJsaXN0QnV0dG9uIj48YnV0dG9uIGNsYXNzPSJub3JtYWxfYnRuIGxpc3RfYnRuMSI+56GuJm5ic3A7Jm5ic3A75a6aPC9idXR0b24+PGJ1dHRvbiBjbGFzcz0ibm9ybWFsX2J0biBsaXN0X2J0bjIiPue7kyZuYnNwOyZuYnNwO+adnzwvYnV0dG9uPjwvbGk+Jw0KIAkJCQkJCQkrJzxsaSBjbGFzcz0ibGlzdENvbnRyb2wiPjxpbWcgc3JjPSIuLi9pbWFnZXMvbW9kZS5wbmciPjxpbWcgc3JjPSIuLi9pbWFnZXMvZGVzaWduLnBuZyI+PGltZyBzcmM9Ii4uL2ltYWdlcy9kZXNpZ24ucG5nIj48L2xpPicNCiAJCQkJCQkJKyc8L3VsPjwvZGl2PicNCiAJCQkkKCcuYWxsZGF0YScpLmFwcGVuZChhcHBlbmRMaXN0KTsJCQ0KIAkJfQ0KIAl9DQogCWxpc3RMb29wKCk7DQoNCiAJLy8g54K55Ye754+N5YmN56Gu6K6k5oyJ6ZKuDQogCQkkKCcubGlzdEJ1dHRvbj4ubGlzdF9idG4xJykuY2xpY2soZnVuY3Rpb24oKSB7DQogCQkJJCh0aGlzKS5wYXJlbnQoKS5wYXJlbnQoKS5wYXJlbnQoKS5yZW1vdmUoKTsNCiAJCQkkLmFqYXgoew0KIAkJCQl0eXBlOidQT1NUJywNCiAJCQkJdXJsOicnLA0KIAkJCQkNCiAJCQl9KQ0KIAkJfSkNCg0KIAkNCg0KDQoNCiB9KQ=="><\/script>');
 // document.write('<script src="../js/login_data.js"><\/script>');
$(function(){

	//下拉框 
	$('.showselectIcon').click(function(){
	    $('.showselectBox').toggle();
	})
	//诊前中后切换显示状态
	$('.current>ul>li').click(function(){
	    $(this).addClass('currentActive').siblings().removeClass('currentActive');

	    if($('.current1').hasClass('currentActive')){
	        $('.list_btn1').show();
	        $('.list_btn1').text('确定');
	        $('.list_btn2').show();
	    }
	    else if($('.current2').hasClass('currentActive'))
	    {
	        $('.list_btn1').show();
	        $('.list_btn1').text('加工');
	        $('.list_btn2').show(); 
	    }
	    else if($('.current3').hasClass('currentActive'))
	    {
	        $('.list_btn1').hide();
	        $('.list_btn1').text('加工');
	        $('.list_btn2').show(); 
	    }
	})

	// 
	// openUserName()

	// angular 
	// var app = angular.module('myApp',[]);
	// app.controller('mainCtrl',function($scope){
	// 	$scope.userRealName = "杰"; //用户名
	// 	$scope.userType = '类型'; //
	// })




	
//end 
})