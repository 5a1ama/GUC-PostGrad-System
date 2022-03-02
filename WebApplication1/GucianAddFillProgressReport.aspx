<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GucianAddFillProgressReport.aspx.cs" Inherits="WebApplication1.GucianAddFillProgressReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="GucianAddFillProgressReport.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button id="Button1" runat="server" Text="Add Progress Report" OnClick="ADD" />

        <asp:Button id="Button2" runat="server" Text="Fill Progress Report" OnClick="FILL" />
    </form>
</body>
</html>
