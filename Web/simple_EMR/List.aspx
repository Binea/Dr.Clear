<%@ Page Title="simple_EMR" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="DentalMedical.Web.simple_EMR.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="Id,EMR_Code" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="Id" HeaderText="id,建议创建时为guid" SortExpression="Id" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="EMR_Code" HeaderText="病历号" SortExpression="EMR_Code" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="patient_Name" HeaderText="名字" SortExpression="patient_Name" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="patient_Age" HeaderText="年龄" SortExpression="patient_Age" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="patient_Sex" HeaderText="性别" SortExpression="patient_Sex" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="patient_Tel" HeaderText="电话" SortExpression="patient_Tel" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="patient_WeChatCode" HeaderText="微信（暂时无法得知是否能够获取" SortExpression="patient_WeChatCode" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="main_suit" HeaderText="主诉" SortExpression="main_suit" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="allergy_history" HeaderText="过敏史" SortExpression="allergy_history" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Medical_history" HeaderText="治疗史" SortExpression="Medical_history" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="therapeutic_schedule" HeaderText="治疗方案" SortExpression="therapeutic_schedule" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="doctorRemark" HeaderText="医生随笔" SortExpression="doctorRemark" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="cRemark" HeaderText="备注" SortExpression="cRemark" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="emr_status" HeaderText="订单状态" SortExpression="emr_status" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="confirm_time" HeaderText="确定时间" SortExpression="confirm_time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="processing_time" HeaderText="加工时间" SortExpression="processing_time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="processing_requirement" HeaderText="加工描述" SortExpression="processing_requirement" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="order_time" HeaderText="接单时间" SortExpression="order_time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pay_time" HeaderText="付款时间" SortExpression="pay_time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="production_time" HeaderText="排产时间" SortExpression="production_time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="delivery_time" HeaderText="发货时间" SortExpression="delivery_time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="end_time" HeaderText="结束时间" SortExpression="end_time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="createDate" HeaderText="创建时间" SortExpression="createDate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="createId" HeaderText="创建人" SortExpression="createId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="modifyDate" HeaderText="修改时间" SortExpression="modifyDate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="modifyId" HeaderText="修改人" SortExpression="modifyId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="flag" HeaderText="是否有效" SortExpression="flag" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Id,EMR_Code" DataNavigateUrlFormatString="Show.aspx?id0={0}&id1={1}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Id,EMR_Code" DataNavigateUrlFormatString="Modify.aspx?id0={0}&id1={1}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
