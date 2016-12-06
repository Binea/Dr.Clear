<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="DentalMedical.Web.hospitals.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hospitalName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhospitalName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hospitalEName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhospitalEName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hospitalCode
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhospitalCode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hospitalAddress
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhospitalAddress" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hospitalTel
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhospitalTel" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hospitalWeb
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhospitalWeb" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		hospitalIntroduction
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhospitalIntroduction" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		orderId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblorderId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		createDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcreateDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		createId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcreateId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		modifyDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmodifyDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		modifyId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmodifyId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		flag
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




