<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPxRichEditBinding.Default" %>
<%@ Register Assembly="DevExpress.Web.ASPxRichEdit.v15.2, Version=15.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRichEdit" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxRichEdit ID="RichEdit" runat="server" WorkDirectory="~\App_Data\WorkDirectory" OnSaving="RichEdit_Saving"></dx:ASPxRichEdit>
        <dx:ASPxButton ID="OpenFromStreamBtn" runat="server" Text="Open from Stream" OnClick="OpenFromStreamBtn_Click"></dx:ASPxButton>
        <dx:ASPxButton ID="OpenFromByteArrayBtn" runat="server" Text="Open from Byte Array" OnClick="OpenFromByteArrayBtn_Click"></dx:ASPxButton>
        <dx:ASPxButton ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click"></dx:ASPxButton>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DocumentsConnectionString %>" OnUpdating="SqlDataSource1_Updating" SelectCommand="SELECT * FROM [Docs]" UpdateCommand="UPDATE [Docs] SET [DocBytes] = @DocBytes WHERE [Id] = @Id">
            <UpdateParameters>
                <asp:Parameter Name="DocBytes" />
                <asp:Parameter Name="Id" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>