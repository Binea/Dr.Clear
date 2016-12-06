<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="DentalMedical.Web.sys_logs.Show" Title="显示页" %>
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
		doctor_Id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbldoctor_Id" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LogsType
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLogsType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Entity
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEntity" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		incident
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblincident" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IP
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIP" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		clientInfo
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblclientInfo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		logmessage
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbllogmessage" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		排序
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblorderId" runat="server"></asp:Label>
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




