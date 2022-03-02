<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cancel.aspx.cs" Inherits="WebApplication1.cancel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 13px;
            left: 362px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 16px;
            z-index: 1;
            left: 162px;
        }
        .auto-style3 {
            position: absolute;
            top: 13px;
            left: 75px;
            z-index: 1;
            height: 28px;
        }
        .auto-style4 {
            position: absolute;
            top: 19px;
            left: 502px;
            color: red;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 22px;
            left: 505px;
            color: green;
            z-index: 1;
        }
        .auto-style6 {
            color: red;
            position: absolute;
            top: 19px;
            left: 684px;
            z-index: 1;
        }
        .auto-style7 {
            position: absolute;
            top: 20px;
            left: 1451px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="Thesis No."></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style2"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style1" Text="Cancel" OnClick="Button1_Click" />
            <asp:Label ID="Label2" runat="server" CssClass="auto-style4" Text="Thesis doesn't exist"></asp:Label>
            <asp:Label ID="Label4" runat="server" CssClass="auto-style6" Text="Please write a number"></asp:Label>
        </div>
        <asp:Label ID="Label3" runat="server" CssClass="auto-style5" Text="SUCCESS"></asp:Label>
        <asp:Button ID="Button2" runat="server" CssClass="auto-style7" Text="Back" OnClick="Button2_Click" />
    </form>
</body>
</html>
