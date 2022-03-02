<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="evaluate.aspx.cs" Inherits="WebApplication1.evaluate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 79px;
            left: 563px;
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
            top: 24px;
            left: 505px;
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
        .auto-style8 {
            position: absolute;
            top: 79px;
            left: 78px;
            z-index: 1;
        }
        .auto-style9 {
            position: absolute;
            top: 16px;
            left: 1489px;
            z-index: 1;
        }
        .auto-style10 {
            position: absolute;
            top: 135px;
            left: 84px;
            z-index: 1;
            width: 62px;
            height: 35px;
        }
        .auto-style11 {
            position: absolute;
            top: 144px;
            left: 163px;
            z-index: 1;
        }
        .auto-style12 {
            position: absolute;
            top: 73px;
            left: 166px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="Thesis No."></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style2" required="true"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style1" Text="Submit Evaluation" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" CssClass="auto-style9" Text="Back" OnClick="Button2_Click" formnovalidate  />
            <asp:Label ID="Label2" runat="server" CssClass="auto-style4" Text="Thesis doesn't exist"></asp:Label>
        </div>
        <asp:Label ID="Label3" runat="server" CssClass="auto-style5" Text="SUCCESS"></asp:Label>
        <asp:Label ID="Label5" runat="server" CssClass="auto-style8" Text="Grade"></asp:Label>
        <asp:Label ID="Label6" runat="server" CssClass="auto-style10" Text="Progress Report No."></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style11" required="true"></asp:TextBox>
        
        <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style12"></asp:TextBox>
        
    </form>
</body>
</html>
