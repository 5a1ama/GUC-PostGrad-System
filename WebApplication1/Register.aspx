<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- <link rel="stylesheet" href="Register.css" /> -->
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Choose as who do you want to register"></asp:Label>

        <asp:Button ID="Button1" runat="server" Text="Gucian" OnClick="Gucian" />
        <asp:Button ID="Button2" runat="server" Text="NonGucian" OnClick="NonGucian" />
        <asp:Button ID="Button3" runat="server" Text="Supervisor" OnClick="Supervisor" />
        <asp:Button ID="Button4" runat="server" Text="Examiner" OnClick="Examiner" />
        
        
    </form>
</body>
</html>
