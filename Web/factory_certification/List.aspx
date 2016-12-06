<%@ Page Title="factory_certification" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="DentalMedical.Web.factory_certification.List" %>
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
                    BorderWidth="1px" DataKeyNames="Id" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="Id" HeaderText="id,建议创建时为guid" SortExpression="Id" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="factory_Id" HeaderText="工厂ID" SortExpression="factory_Id" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="legal_Person" HeaderText="法人" SortExpression="legal_Person" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="organization_Code" HeaderText="组织机构代码" SortExpression="organization_Code" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="main_Person" HeaderText="主要联系人" SortExpression="main_Person" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="main_Tel" HeaderText="联系人电话" SortExpression="main_Tel" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="business_license" HeaderText="营业执照" SortExpression="business_license" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Legal_ID" HeaderText="法人身份证" SortExpression="Legal_ID" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="factory_Address" HeaderText="地址" SortExpression="factory_Address" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="medical_license" HeaderText="医疗企业生产许可证" SortExpression="medical_license" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="instrument_license" HeaderText="医疗器械产品注册证" SortExpression="instrument_license" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="status" HeaderText="状态" SortExpression="status" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="orderId" HeaderText="排序" SortExpression="orderId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="createDate" HeaderText="创建时间" SortExpression="createDate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="createId" HeaderText="创建人" SortExpression="createId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="modifyDate" HeaderText="修改时间" SortExpression="modifyDate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="modifyId" HeaderText="修改人" SortExpression="modifyId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="flag" HeaderText="是否有效" SortExpression="flag" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
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
