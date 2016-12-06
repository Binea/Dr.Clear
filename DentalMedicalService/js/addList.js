/**
 * 
 * @authors Your Name (you@example.org)
 * @date    2016-02-29 17:21:54
 * @version $Id$
 */

$(function(){
	// 获取第一组数据
	var listName = $('.addList_name>input').val(); //姓名
	var listSex = $('.addList_sex>input').val; //性别
	var listAge = $('.addList_brith>input').val; //生日
	var listPhone = $('.addList_phone>input').val(); //手机号

	// 获取第二组数据
	var addListSay = $('.addList_say>textarea').val(); //主诉
	var addListHistory = $('.addList_history>textarea').val(); //过敏史
	var addListTreat = $('.addList_treat>textarea').val(); //过敏史
	var addListTreatPlan =$('.addList_treatPlan>textarea').val(); //治疗方案

})