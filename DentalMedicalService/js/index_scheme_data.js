/**
 * 
 * @authors Your Name (you@example.org)
 * @date    2016-02-16 13:30:30
 * @version $Id$
 */
var vIndexData1 = new IndexData ('../images/userIm.png','李白1','0000001','主诉txt1','方案txt1','记录txt1');
var vIndexData2 = new IndexData ('../images/imShow.png','李白2','0000002','主诉txt2','方案txt2','记录txt2');

var arr = new Array;
	arr.push(vIndexData1);
	arr.push(vIndexData2);

function IndexData(imagePath,patient_Name,EMR_Code,main_suit,therapeutic_schedule,doctorRemark)
{
	this.showIm = imagePath;
	this.showName = patient_Name;
	this.showNum = EMR_Code;
	this.showSay = main_suit;
	this.showWay = therapeutic_schedule;
	this.showWrite = doctorRemark; 
}
 // IndexData.prototype.setShowIm = function(imagePath){ this.showIm = new_imagePath};
	IndexData.prototype.getShowIm = function(){ return this.showIm};

 // IndexData.prototype.setShowName = function(patient_Name){ this.showName = new_patient_Name};
	IndexData.prototype.getSHowName = function(){ return this.showName };
	IndexData.prototype.getShowNum = function(){ return this.showNum };
	IndexData.prototype.getShowSay = function(){ return this.showSay };
	IndexData.prototype.getShowWay = function(){ return this.showWay };
	IndexData.prototype.getShowWrite = function(){ return this.showWrite };

