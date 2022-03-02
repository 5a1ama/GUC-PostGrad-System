<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NonGucianAddFillProgressReport.aspx.cs" Inherits="WebApplication1.NonGucianAddFillProgressReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="NonGucianAddFillProgressReport.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button id="Button1" runat="server" Text="Add Progress Report" OnClick="ADD"/>

        <asp:Button id="Button2" runat="server" Text="Fill Progress Report" OnClick="FILL" />
    </form>
</body>
</html>
