$(function(){
	//忘记密码，帮助
	var sty = {
		"h":"170px",
		"mt":"-85",
		"conh":"30px"
	}
	$(".infoHelp").on("click",function(e){
	    //utils.dialog("温馨提示：", "请联系客服，021-51696863", "确定", "取消", "", "", sty);
	    window.open("helppage.html");
	});
	$(".back").on("click",function(e){ //返回上一级，元素加back class即可
		window.history.go(-1);
	})
	$(".infoforget").on("click", function (e) {
		$('.psd').css({display:"block"})
	    // utils.dialog("温馨提示：", "请关注微信公众号(ID)：clearbos11", "确定", "取消", "", "", sty);
	    //window.open("http://www.gtooth.com/helpdoc/gtooth1.html");
	});
	$('.psd').on('click',function(){
		$(this).css({display:"none"})
	})
});
function createXmlFile(options){

	var oFso,oFile,sFile;

	sFile = options.path;

	var content='<?xml version="1.0" encoding="UTF-8" ?>'+
		'<PatientInfo>'+
		'<patientnum>'+options.emrcode+'</patientnum>'+
		'<name>'+options.realName+'</name>'+
		'<sex>'+options.sex+'</sex>'+
		'<birthday>'+options.birthday+'</birthday>'+
		'<operationstyle>'+options.action+'</operationstyle>'+
		'</PatientInfo>';

	//写文件
	oFso = new ActiveXObject("Scripting.FileSystemObject");

	oFile = oFso.OpenTextFile(sFile,2,true); //写方式打开

	oFile.WriteLine(content);

	oFile.Close();
}
var utils = {  //一些公共方法
	chek: function(btn){
		btn.on("click", function(e){  //选中
			var ischecked = $(this).is(".selected");
			if($(this).find(".disabled").length > 0) return false;
			ischecked ? $(this).removeClass("selected") :  $(this).addClass("selected").siblings().removeClass("selected");
		});
	},
	msg: function(title){  //提示信息
		if($(".msg").length > 0) $(".msg").remove();
		var msg = $("<div class='msg'></div>").appendTo("body");
		var windowW = $(window).outerWidth();
		msg.text(title);
		var w = windowW / 2 - msg.outerWidth() / 2;
		msg.css({"left":w + "px"});
		msg.css({"opacity":"1","z-index":"999"});
		setTimeout(function(){
			msg.css({"opacity":"0","z-index":"-1"});
		},2500);
	},
	close: function(target,mainclass){  //关闭
		target.on("click",function(e){
			mainclass.hide();
		});
	},
	banner: function(target,nextclass){  // target: 轮播最外层class,nextclass：需移动的class
		var star = 0,w,h,num,all_w;
		h = target.outerHeight();
		w = target.outerWidth();  //最外层浏览器的宽度
		nextclass.find(".imgbox").css({"width":w});
		nextclass.find(".img").css({"width":w,"height":h});
		num = nextclass.find(".img").length - 1;
		all_w = w * num;
		
		//prev:上一张  next:下一张  引用时，需在html中加入此class
		$(".prev").on("click",function(e){
			if(star == 0) return false;
			if(-star > all_w) star = star + w;  //next按钮多走一步
			star = star + w ;
			if(star < all_w) return nextclass.animate({left: star + "px"}, 1000);
			else return false;
		});
		$(".next").on("click",function(e){
			if(star < -all_w) return false;
			star = star - w ;
			if(star >= -all_w) return nextclass.animate({left: star + "px"}, 1000);
			else return false;
		});
	},
	/*** 弹框 ***/
	dialog: function(title,details,btntxt1,btntxt2,subSuc,target,style,unClose){  //触发事件的选择器，内容,是否有btn,第一个按钮文字,第二个按钮文字
		// if(!details) return false;  //如果没有内容
		if($(".dialogbox")) $(".dialogbox").remove();
		//创建弹框
		var dialogbox = $("<div class='dialogbox'></div>").appendTo("body");
		var bg = $("<div class='dialog-bg'></div>").appendTo(dialogbox);
		var dialog = $("<div class='dialog'></div>").appendTo(dialogbox);
		if(style) {
			var w = style.w,ml = style.ml,heihgt = style.h, mt = style.mt;
			dialog.css({"width":w,"marginLeft":ml,"height":heihgt,"marginTop":mt});
		}
		var tit = title? $("<div class='dialog-tit'></div>").appendTo(dialog) : "";
		title ? tit.text(title) : "";
		var content = details ? $("<div class='dialog-content'></div>").appendTo(dialog) : "";
		details ? content.html(details) : "";
		if(style) (content && style.conh) ? content.css("height",style.conh) : "";
		var btnbox = (btntxt1 || btntxt2) ? $("<div class='dialog-btnbox'></div>").appendTo(dialog) : "";
		var cancel = btntxt2 ? $("<div class='btn cancel'></div>").appendTo(btnbox) : "";
		btntxt2 ? cancel.text(btntxt2) : "";
		var confirm = btntxt1 ? $("<div class='btn confirm'></div>").appendTo(btnbox) : "";
		btntxt1 ? confirm.text(btntxt1): "";
		utils.close(bg,dialogbox);
		//点击底部确认或取消按钮
		$(".dialog-btnbox .btn").on("click",function(e){
			if($(this).is(".cancel")) dialogbox.hide();  //点击取消

			else{
				if(!unClose){
					dialogbox.hide();
					if(subSuc){
						subSuc();
					}
				}else{
					if(subSuc){
						if(subSuc()) dialogbox.hide();
					}
				}

			}
		});
				
	},
	addUploadFileEvent: function(options) {  //图片上传
		var uploader = new plupload.Uploader({
			browse_button: options.uploadBtn,
			url: 'uploadFiles.ashx?operationType=' + options.operationType + '&dirname=' + options.userCode + '&imageType=' + options.imagetype,
			flash_swf_url:'js/Moxie.swf',
			silverlight_xap_url:'js/Moxie.xap',
			max_file_size : '1mb',
			chunk_size : 0
		});
		uploader.init();
		uploader.bind('FilesAdded', function(uploader, files) {
			uploader.start();
			for(var i = 0, len = files.length; i<len; i++) {
				// console.log(files);
				var file = files[i];
				var $li = $(uploader.settings.browse_button).closest('li');
				var $image = $li.find('.uploadPreview').children('img');
				var preloader = new mOxie.Image();
				preloader.onload = function() {
				    // $($li).addClass("success");  //	前端判断成功上传标志
				    var dom = $('#'+options.imgSuofang);
				    var w = options.previewWidth;
				    var h = options.previewHeight;
				    var W = preloader.width;
				    var H = preloader.height;
				    if ((w / h) < (W / H)) {
				        dom.addClass('active')
				    } else {
				        dom.removeClass('active')
				    }
				    preloader.downsize(options.previewWidth, options.previewHeight);
					$image.prop("src", preloader.getAsDataURL());
				};
				preloader.load( file.getSource() );
			}
		});
		uploader.bind('Error', function (uploader, errObject) {
		    //console.log(errObject.message);
		    utils.msg(errObject.message);
		})
		uploader.bind('fileUploaded',function(uploader,file,response){

			var data=JSON.parse(response.response);
			// console.log(data);
			utils.msg(data.message);
			$('#'+options.fileInput).val(data.data.jsString);
		})
	},
	uploadSingleFile:function(options) {  //图片上传
		var uploader = new plupload.Uploader({
			browse_button: options.uploadBtn,
			url: 'uploadFiles.ashx?operationType=' + options.operationType + '&dirname=' + options.userCode,
			flash_swf_url:'js/Moxie.swf',
			silverlight_xap_url:'js/Moxie.xap',
			max_file_size : '1mb',
			chunk_size : 0
		});
		uploader.init();
		uploader.bind('FilesAdded', function(uploader, files) {
			uploader.start();
			for(var i = 0, len = files.length; i<len; i++) {
				// console.log(files);
				var file = files[i];
				var preloader = new mOxie.Image();
				preloader.onload = function () {
				    var dom = $('.upList .imgSuofang');
				    var w = options.previewWidth;
				    var h = options.previewHeight;
				    var W = preloader.width;
				    var H = preloader.height;
				    if ((w / h) < (W / H)) {
				        dom.addClass('active')
				    } else {
				        dom.removeClass('active')
				    }
					dom.closest('.upList').addClass('change')
					preloader.downsize(options.previewWidth, options.previewHeight);
					$('#'+options.previewContainer).prop("src", preloader.getAsDataURL());
				};
				preloader.load( file.getSource() );
			}
		});
		uploader.bind('Error', function (uploader, errObject) {
		    //console.log(errObject.message);
		    utils.msg(errObject.message);
		})
		uploader.bind('fileUploaded',function(uploader,file,response){

			var data=JSON.parse(response.response);
			// console.log(data);
			utils.msg(data.message);
			$('#'+options.fileInput).val(data.data.jsString);
		})
	},
	//getRequest: function(){ 
	//	var url = location.search; //获取url中"?"符后的字串 
	//	var theRequest = new Object(); 
	//	if (url.indexOf("?") != -1) { 
	//	var str = url.substr(1); 
	//	strs = str.split("&"); 
	//	for(var i = 0; i < strs.length; i ++) { 
	//		theRequest[strs[i].split("=")[0]]=unescape(strs[i].split("=")[1]); 
	//		} 
	//	} 
	//	return theRequest; 
    //} 
    /*模型上传*/
	uploadmodelfile:function(options){
	    var uploader = new plupload.Uploader({
	        browse_button: options.uploadBtn,
	        url: 'uploadSTL.ashx?emrcode=' + options.emrcode,
	        flash_swf_url: 'js/Moxie.swf',
	        silverlight_xap_url: 'js/Moxie.xap',
	        max_file_size: '40mb',
	        chunk_size: 0,
	        multi_selection: false,
	        filters: {
	            mime_types: [ //只允许上传图片文件和rar压缩文件
                  { title: "STL文件", extensions: "stl,tsd,osd" },
                  { title: "Image", extensions: "jpg,png,gif,bmp" }
	            ],
	            max_file_size: '25M', //最大只能上传100kb的文件
	            prevent_duplicates: true //不允许队列中存在重复文件
	        }
	    });
	    uploader.init();
	    
	    uploader.bind('FilesAdded', function (uploader, files) {
	        uploader.start();
	        for (var i = 0, len = files.length; i < len; i++) {
	            // console.log(files);
	            var file = files[i];
	            //var preloader = new mOxie.Image();
	            //preloader.onload = function () {
	            //    preloader.downsize(options.previewWidth, options.previewHeight);
	            //    $('#' + options.previewContainer).prop("src", preloader.getAsDataURL());
	            //};
	            $('#filename' + options.imagetype).html(file.name);
	            //preloader.load(file.getSource());
	        }
	    });
	    uploader.bind('Error', function (uploader, errObject) {
	        console.log(errObject.message);
	        utils.msg(errObject.message);
	    })
	    uploader.bind('UploadProgress', function (uploader, file) {
	        $('#progress'+options.imagetype).css('width', file.percent + '%');//控制进度条
	    });

	    uploader.bind('fileUploaded', function (uploader, file, response) {
	        //console.log(response.response);
	        var data = JSON.parse(response.response);
	        // console.log(data);
	        utils.msg(data.message);
	        console.log(data);
	        $('#' + options.fileInput).val(data.data.jsString);
	    })
	},
	getRequest: function () {
	    var url = window.location.search; //获取url中"?"符后的字串   
	    var theRequest = new Object();   
	    if (url.indexOf("?") != -1) {   
	        var str = url.substr(1);   
	        strs = str.split("&");   
	        for(var i = 0; i < strs.length; i ++) {   
	            //就是这句的问题
	            theRequest[strs[i].split("=")[0]]=decodeURI(strs[i].split("=")[1]); 
	            //之前用了unescape()
	            //才会出现乱码  
	        }   
	    }   
	    return theRequest;
	},

	
}