<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gucian.aspx.cs" Inherits="WebApplication1.Gucian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <asp:Button ID="Button1" runat="server" Text="View profile" OnClick="view" />
    <asp:Button ID="Button2" runat="server" Text="List my theses" OnClick="theses"/>
    <asp:Button ID="Button4" runat="server" Text="Add and Fill progress report" OnClick="addfillProgressReport"/>
    <asp:Button ID="Button5" runat="server" Text="Add publication" OnClick="addlinkPublication"/>
    </form>
</body>
</html>
