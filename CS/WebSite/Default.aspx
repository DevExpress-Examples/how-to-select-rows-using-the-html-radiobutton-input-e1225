<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication9._Default" %>

<%@ register Assembly="DevExpress.Web.ASPxGridView.v8.3" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ register Assembly="DevExpress.Web.ASPxEditors.v8.3" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
  
         <dxwgv:aspxgridview ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
            DataSourceID="AccessDataSource1" KeyFieldName="CategoryID" ClientInstanceName="grid" OnCustomCallback="ASPxGridView1_CustomCallback" OnHtmlRowCreated="ASPxGridView1_HtmlRowCreated">

            <columns>
                <dxwgv:gridviewcommandcolumn VisibleIndex="0" ShowSelectCheckbox="True">
                </dxwgv:gridviewcommandcolumn>
                <dxwgv:gridviewdatatextcolumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="1">
                    <editformsettings Visible="False" />
                </dxwgv:gridviewdatatextcolumn>
                <dxwgv:gridviewdatatextcolumn FieldName="CategoryName" VisibleIndex="2">
                </dxwgv:gridviewdatatextcolumn>
                <dxwgv:gridviewdatatextcolumn FieldName="Description" VisibleIndex="3">
                    <dataitemtemplate>
                         <input  type='radio' id="group1"  runat="server"/>
                    </dataitemtemplate>
                </dxwgv:gridviewdatatextcolumn>
            </columns>
           
        </dxwgv:aspxgridview>
    

        <asp:accessdatasource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT * FROM [Categories]"></asp:accessdatasource>
        <asp:accessdatasource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice] FROM [Products] WHERE ([CategoryID] = ?)">
            <selectparameters>
                <asp:sessionparameter Name="CategoryID" SessionField="CategoryID" Type="Int32" />
            </selectparameters>
        </asp:accessdatasource>
 
    </form>
</body>
</html>
