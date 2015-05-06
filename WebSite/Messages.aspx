<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="WebSite.Messages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="ReadMessagesButton" runat="server" OnClick="ReadMessagesButton_Click" Text="Read Messages" />
        <asp:GridView ID="MessagesGridView" runat="server" AllowSorting="True" OnSorting="MessagesGridView_Sorting">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
