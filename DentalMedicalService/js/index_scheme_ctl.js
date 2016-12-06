
 document.write('<script src="../js/index_scheme_data.js"><\/script>');

 $(function() {

 	// 循环加载多列数据
 	function listLoop(){
 		var listFun_length = arr.length; 
 		for ( var i = 0; i <listFun_length; i++){

 		    var new_imagePath = arr[i].getShowIm();
 			var new_patient_Name = arr[i].getSHowName();
 			var new_EMR_Code = arr[i].getShowNum();
 			var new_main_suit = arr[i].getShowSay();
 			var new_therapeutic_schedule = arr[i].getShowWay();
 			var new_doctorRemark = arr[i].getShowWrite();

 			var appendList = '<div class="mainBox"><ul>'
 							+'<li class="listIm"><img src="'+new_imagePath+'"></li>'
 							+'<li class="listName">'+new_patient_Name+'</li>'
 							+'<li class="listNum">'+new_EMR_Code+'</li>'
 							+'<li class="listSay"><div>'+new_main_suit+'</div></li>'
 							+'<li class="listWay"><div>'+new_therapeutic_schedule+'</div></li>'
 							+'<li class="listRecord"><div>'+new_doctorRemark+'</div></li>'
 							+'<li class="listButton"><button class="normal_btn list_btn1">确&nbsp;&nbsp;定</button><button class="normal_btn list_btn2">结&nbsp;&nbsp;束</button></li>'
 							+'<li class="listControl"><img src="../images/mode.png"><img src="../images/design.png"><img src="../images/design.png"></li>'
 							+'</ul></div>'
 			$('.alldata').append(appendList);		
 		}
 	}
 	listLoop();

 	// 点击珍前确认按钮
 		$('.listButton>.list_btn1').click(function() {
 			$(this).parent().parent().parent().remove();
 			$.ajax({
 				type:'POST',
 				url:'',
 				
 			})
 		})

 	



 })