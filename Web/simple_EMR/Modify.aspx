<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="DentalMedical.Web.simple_EMR.Modify" Title="修改页" %>
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
		<asp:label id="lblId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		病历号
	：</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblEMR_Code" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		名字
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpatient_Name" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		年龄
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpatient_Age" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		性别
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpatient_Sex" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpatient_Tel" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		微信（暂时无法得知是否能够获取
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpatient_WeChatCode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		主诉
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtmain_suit" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		过敏史
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtallergy_history" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		治疗史
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMedical_history" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		治疗方案
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txttherapeutic_schedule" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		医生随笔
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtdoctorRemark" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		备注
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcRemark" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		订单状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtemr_status" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		确定时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtconfirm_time" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		加工时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtprocessing_time" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		加工描述
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtprocessing_requirement" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		接单时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtorder_time" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		付款时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtpay_time" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		排产时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtproduction_time" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		发货时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtdelivery_time" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		结束时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtend_time" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		创建时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtcreateDate" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		创建人
	：</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblcreateId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		修改时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtmodifyDate" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		修改人
	：</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblmodifyId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		是否有效
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtflag" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>
<script src="/js/calendar1.js" type="text/javascript"></script>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

