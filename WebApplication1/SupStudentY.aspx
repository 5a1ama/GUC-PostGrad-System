<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupStudentY.aspx.cs" Inherits="WebApplication1.SupStudentY" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 621px;
            height: 152px;
            position: absolute;
            top: 37px;
            left: 10px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 38px;
            left: 1490px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 27px;
            left: 713px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="EMPTY"></asp:Label>
        </div>
        <asp:GridView ID="GridView1" runat="server" CssClass="auto-style1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style2" Text="Back" OnClick="Button1_Click" formnovalidate />
    </form>
</body>
</html>
