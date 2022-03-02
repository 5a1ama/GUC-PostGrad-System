<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupStudentPub.aspx.cs" Inherits="WebApplication1.SupStudentPub" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 719px;
            height: 222px;
            position: absolute;
            top: 113px;
            left: 468px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 38px;
            left: 1477px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 20px;
            left: 419px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 26px;
            left: 223px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 26px;
            left: 79px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 30px;
            left: 700px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" CssClass="auto-style1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
        <asp:Button ID="Button2" runat="server" CssClass="auto-style3" Text="Submit" OnClick="Button2_Click" />
        <div>
            
        <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4" required="true"></asp:TextBox>
        </div>
        <asp:Label ID="Label1" runat="server" CssClass="auto-style5" Text="Enter Student ID"></asp:Label>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style2" Text="Back" OnClick="Button1_Click" formnovalidate/>
        <asp:Label ID="Label2" runat="server" CssClass="auto-style6" Text="EMPTY"></asp:Label>
    </form>
</body>
</html>
