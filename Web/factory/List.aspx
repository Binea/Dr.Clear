<%@ Page Title="factory" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="DentalMedical.Web.factory.List" %>
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
                    BorderWidth="1px" DataKeyNames="Id,factoryCode" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="Id" HeaderText="id,建议创建时为guid" SortExpression="Id" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="factoryCode" HeaderText="账户" SortExpression="factoryCode" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="factoryTel" HeaderText="电话" SortExpression="factoryTel" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="factoryPwd" HeaderText="密码" SortExpression="factoryPwd" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="factoryEmail" HeaderText="邮箱" SortExpression="factoryEmail" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="factoryKey" HeaderText="验证号" SortExpression="factoryKey" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="factoryLogo" HeaderText="厂家logo" SortExpression="factoryLogo" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="onlineStatus" HeaderText="在线状态" SortExpression="onlineStatus" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="factoryName" HeaderText="厂家名字" SortExpression="factoryName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="fee" HeaderText="厂家服务费" SortExpression="fee" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="invit_code" HeaderText="邀请码" SortExpression="invit_code" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="orderId" HeaderText="排序号" SortExpression="orderId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="factoryRemark" HeaderText="备注" SortExpression="factoryRemark" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="createDate" HeaderText="创建时间" SortExpression="createDate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="createId" HeaderText="创建人" SortExpression="createId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="modifyDate" HeaderText="修改时间" SortExpression="modifyDate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="modifyId" HeaderText="修改人" SortExpression="modifyId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="flag" HeaderText="是否有效" SortExpression="flag" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Id,factoryCode" DataNavigateUrlFormatString="Show.aspx?id0={0}&id1={1}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Id,factoryCode" DataNavigateUrlFormatString="Modify.aspx?id0={0}&id1={1}"
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
