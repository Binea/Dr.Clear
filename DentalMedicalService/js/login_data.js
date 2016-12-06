/**
 * 
 * @authors Your Name (you@example.org)
 * @date    2016-02-16 09:49:57
 * @version $Id$
 */
 	var userName ="";
 	var passWord ="";
 	var userRealName ="";
 	var puserType ="";

function setUserName(pUserName)
{
	userName = pUserName;
}

function getUserName()
{
	return userName;
}
function saveUserName(pUserName)
{
	sessionStorage.setItem("ss_pUserName",pUserName ); 

}
function openUserName()
{
 	return	sessionStorage.getItem("ss_pUserName"); 
}

// 定义下拉数组
var arrDocWorkAddList = [
	// ob0 = { UserDepartment:'科室1', pUserHospital:'医院1'},
	// ob1 = { UserDepartment:'科室2', pUserHospital:'医院2'},
	// ob2 = { UserDepartment:'科室3', pUserHospital:'医院3'}
]


function setDocWorkAdd(pUserDepartment, pUserHospital)
{
	var obi = { userDepartment:pUserDepartment, userHospital:pUserHospital}

	arrDocWorkAddList.push(obi)
}
function getDocWorkAddLen()
{
	return arrDocWorkAddList.length;
}

function getDocWorkAddUserDep(pIndex)
{
	if(pIndex < arrDocWorkAddList.length)
	{
		return arrDocWorkAddList[pIndex].userDepartment;
	}
}

function getDocWorkAddUserHpl(pIndex)
{
	if(pIndex < arrDocWorkAddList.length)
	{
		return arrDocWorkAddList[pIndex].userHospital;
	}
}

function saveDocWorkAdd()
{
    // var array_string = arrDocWorkAddList.toString();
    var array_string = JSON.stringify(arrDocWorkAddList)
	sessionStorage.setItem("ss_saveDocWorkAdd",array_string ); 
	// sessionStorage.setItem("ss_pUserHospital",pUserHospital ); 
}
function openDocWorkAdd()
{
	var stemp = sessionStorage.getItem("ss_saveDocWorkAdd"); 
	stemp_arr = stemp.split(","); //字符串转换数组
	arrDocWorkAddList = JSON.parse(stemp_arr)
	// var ss = eval(stemp_arr[0])
	// return sessionStorage.getItem("ss_pUserHospital"); 
}



