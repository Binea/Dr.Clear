/**
 * 
 * @authors yangjie (914569804@qq.com)
 * @date    2016-01-25 21:51:23
 * @version $Id$
 */
$(function(){
	//切换显示状态
	$('.current>ul>li').click(function(){
		$(this).addClass('currentActive').siblings().removeClass('currentActive');	
		//工厂端切换选择状态
		if($('.current1').hasClass('currentActive')){ 
			$('.fac_payShow').text('1000.00元')
			$('.list_btn2').html('接&nbsp;单');
		}
		else if($('.current2').hasClass('currentActive')){ 
			$('.fac_payShow').text('交易成功')
			$('.list_btn2').html('排&nbsp;产');
		}
		else if($('.current3').hasClass('currentActive')){ 
			$('.fac_payShow').text('交易成功')
			$('.list_btn2').html('发&nbsp;货');
		}
		if($('.current4').hasClass('currentActive')){
			$('#payTable').show();
			$('#mainTable').hide();
		}else{
			$('#payTable').hide();
			$('#mainTable').show();
		}

	})

})
