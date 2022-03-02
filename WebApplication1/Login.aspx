<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Login.css"/>
</head>
<body style="height: 155px">
    <form id="form1" runat="server">
        <p style="height: 32px">
            <asp:TextBox ID="TextBox1" runat="server"  name="id" OnTextChanged="TextBox1_TextChanged" ></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="User email" ></asp:Label>
        </p>
        <p style="height: 33px">
            <asp:TextBox ID="TextBox2" runat="server"   type="password" name="pass" OnTextChanged="TextBox2_TextChanged" ></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        </p>
        <p style="height: 85px">
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="login" />
            <asp:Button ID="Button2" runat="server" Text="Register" OnClick="signup" />
            </p>
    </form>
</body>
</html>
