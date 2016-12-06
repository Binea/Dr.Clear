<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="DentalMedical.Web.simple_EMR.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		id,建议创建时为guid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		病历号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEMR_Code" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		名字
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpatient_Name" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		年龄
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpatient_Age" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		性别
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpatient_Sex" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpatient_Tel" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		微信（暂时无法得知是否能够获取
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpatient_WeChatCode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		主诉
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmain_suit" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		过敏史
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblallergy_history" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		治疗史
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMedical_history" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		治疗方案
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbltherapeutic_schedule" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		医生随笔
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbldoctorRemark" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		备注
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcRemark" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		订单状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblemr_status" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		确定时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblconfirm_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		加工时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblprocessing_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		加工描述
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblprocessing_requirement" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		接单时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblorder_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		付款时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpay_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		排产时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblproduction_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		发货时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbldelivery_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		结束时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblend_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		创建时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcreateDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		创建人
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcreateId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		修改时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmodifyDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		修改人
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmodifyId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		是否有效
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblflag" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




