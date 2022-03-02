<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GucianDefense.aspx.cs" Inherits="WebApplication1.GucianDefense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            position: absolute;
            top: 10px;
            left: 1287px;
            z-index: 1;
            width: 93px;
            height: 34px;
        }
        .auto-style3 {
            position: absolute;
            top: 37px;
            left: 10px;
        }
        .auto-style4 {
            position: absolute;
            top: 38px;
            left: 161px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 99px;
            left: 528px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 86px;
            left: 8px;
            z-index: 1;
            height: 45px;
            width: 144px;
        }
        .auto-style7 {
            position: absolute;
            top: 92px;
            left: 161px;
            z-index: 1;
        }
        .auto-style8 {
            position: absolute;
            top: 151px;
            left: 169px;
            z-index: 1;
        }
        .auto-style9 {
            position: absolute;
            top: 151px;
            left: 10px;
            z-index: 1;
            width: 103px;
            height: 31px;
        }
        .auto-style10 {
            position: absolute;
            top: 38px;
            color: red;
            left: 347px;
            z-index: 1;
        }
        .auto-style11 {
            position: absolute;
            top: 92px;
            color: red;
            left: 353px;
            z-index: 1;
        }
        .auto-style12 {
            position: absolute;
            top: 58px;
            color: lawngreen;
            font-size: 40px;
            left: 771px;
            z-index: 1;
            width: 497px;
        }
        .auto-style13 {
            position: absolute;
            top: 157px;
            left: 901px;
            color: blue;
            z-index: 1;
            width: 162px;
        }
        .auto-style14 {
            position: absolute;
            top: 237px;
            left: 11px;
            z-index: 1;
        }
        .auto-style17 {
            position: absolute;
            top: 226px;
            left: 185px;
            z-index: 1;
            height: 21px;
            right: 1214px;
        }
        .auto-style23 {
            position: absolute;
            top: 157px;
            left: 776px;
            z-index: 1;
            color: blue;
            width: 114px;
        }
        .auto-style24 {
            position: absolute;
            top: 175px;
            left: 1063px;
            color: red;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style2" Text="Back" OnClick="Button1_Click" formnovalidate />
        </div>
        <asp:Label ID="Label1" runat="server" CssClass="auto-style3" style="z-index: 1" Text="Enter Thesis No."></asp:Label>
        <asp:Label ID="Label4" runat="server" CssClass="auto-style10" Text="Enter Correct Thesis No"></asp:Label>
        <asp:TextBox ID="idd" runat="server" CssClass="auto-style4" required="true"></asp:TextBox>
        <asp:Label ID="Label12" runat="server" CssClass="auto-style23" Text="Examiner doesn't exist"></asp:Label>
        <asp:Button ID="Button2" runat="server" CssClass="auto-style5" Text="Submit" OnClick="Button2_Click" />
        <asp:Label ID="Label2" runat="server" CssClass="auto-style6" Text="Enter Defense Date"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style7" required="true"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style8" required="true"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" CssClass="auto-style9" Text="Enter Defense Location"></asp:Label>
        <asp:Label ID="Label13" runat="server" CssClass="auto-style24" Text="PLEASE ENTER ALL VALUES"></asp:Label>
        <p>
                <asp:Label ID="Label5" runat="server" CssClass="auto-style11" Text="Enter Correct Date"></asp:Label>
    <asp:Label ID="Label6" runat="server" CssClass="auto-style12" Text="SUCCESS"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style17" required="true"></asp:TextBox>
    <asp:Label ID="Label7" runat="server" CssClass="auto-style13" Text="Defense already exists with this examiner"></asp:Label>
    <asp:Label ID="Label8" runat="server" CssClass="auto-style14" Text="Enter Examiner ID"></asp:Label>
        </p>

</body>
</html>

    </form>

