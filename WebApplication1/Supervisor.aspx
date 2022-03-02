<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Supervisor.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 159px;
            left: 568px;
            z-index: 1;
            width: 376px;
        }
        .auto-style2 {
            position: absolute;
            top: 16px;
            left: 661px;
            z-index: 1;
            width: 254px;
            font-size: 40px;
        }

        .auto-style3 {
            position: absolute;
            top: 15px;
            left: 10px;
        }
        .auto-style7 {
            position: absolute;
            top: 216px;
            left: 569px;
            z-index: 1;
            width: 373px;
        }
        .auto-style8 {
            position: absolute;
            top: 264px;
            left: 578px;
            z-index: 1;
            width: 183px;
        }
        .auto-style9 {
            position: absolute;
            top: 264px;
            left: 762px;
            z-index: 1;
            width: 189px;
        }
        .auto-style10 {
            position: absolute;
            top: 348px;
            left: 578px;
            z-index: 1;
            width: 368px;
            margin-top: 0px;
        }
        .auto-style11 {
            position: absolute;
            top: 303px;
            left: 581px;
            z-index: 1;
            width: 366px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="SUPERVISOR"></asp:Label>
            <asp:Button ID="Button2" runat="server" CssClass="auto-style3" style="z-index: 1" Text="LOGOUT" />
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style1" OnClick="Button1_Click" Text="View student's names and years spent in thesis" />
        </p>
        <p>
            &nbsp;</p>
        <p>

            &nbsp;</p>
        <p>
            <asp:Button ID="Button3" runat="server" CssClass="auto-style7" Text=" View all publications of a student" OnClick="Button3_Click" />
        </p>
        <asp:Button ID="Button4" runat="server" CssClass="auto-style8" Text="Add Defence Gucian" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" CssClass="auto-style9" Text="Add Defence NonGucian" OnClick="Button5_Click" />
        <asp:Button ID="Button6" runat="server" CssClass="auto-style10" Text="Cancel A Thesis" OnClick="Button6_Click" />
        <asp:Button ID="Button7" runat="server" CssClass="auto-style11" Text="Evaluate a Thesis" OnClick="Button7_Click" />
    </form>
</body>
</html>
