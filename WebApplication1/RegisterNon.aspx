<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterNon.aspx.cs" Inherits="WebApplication1.RegisterNon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
    <style>
        #Button5{
            position:absolute;
            top:615px;
            left:420px;
            width:400px;
        }
    </style>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Choose as who do you want to register"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Gucian" OnClick="Gucian" />
        <asp:Button ID="Button2" runat="server" Text="NonGucian" OnClick="NonGucian" />
        <asp:Button ID="Button3" runat="server" Text="Supervisor" OnClick="Supervisor" />
        <asp:Button ID="Button4" runat="server" Text="Examiner" OnClick="Examiner" />
        <asp:Button ID="Button5" runat="server" Text="Submit" OnClick="Submit" />
        
        <div id="divNon" runat="server" visible="false">
            <asp:Button ID="Button6" runat="server" Text="-" OnClick="B3_Click" />
            <asp:Button ID="Button7" runat="server" Text="+" OnClick="B2_Click" />

        </div>
        </div>
    </form>
</body>
</html>
