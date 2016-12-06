/**
 * 
 * @authors Your Name (you@example.org)
 * @date    2016-02-16 13:25:24
 * @version $Id$
 */

  document.write('<script src="../js/login_data.js"><\/script>');

 
 $(function(){

 	// 头部数据替换 数据获取
 	// var sw_userRealName = sessionStorage.getItem("ss_userRealName"); //从sessionStorage获取数据替换数据sw_

 	$('.userName').text(openUserName());

 	// 下拉框
 	 openDocWorkAdd(); 
 	var vlength= getDocWorkAddLen();// 输
 	if(vlength >= 1)
 	{
		for( i = 0; i < vlength; i++)
		{
			// var string_vDocWorkAddLength = vDocWorkAddSaveLength
			// getDocWorkAddUserDep[i]
			// getDocWorkAddUserHpl[i]
		 	var divBox = '<div class="showSelect">'+'<span>'+getDocWorkAddUserDep(i) +'</span>'+'<span class="line">'+'|'+'</span>'+'<span>'+ getDocWorkAddUserHpl(i) +'</span>'+'</div>'
 			$('.showselectBox').append(divBox)
 		}

 	}

 })
