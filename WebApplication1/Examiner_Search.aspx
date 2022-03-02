<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examiner_Search.aspx.cs" Inherits="WebApplication1.Examiner_Search" %>

<!DOCTYPE html>
<style>
    .top_left{
        position:absolute;
        top: 5%;
        left: 5%;
    }
    .bottom_left{
        position:absolute;
        bottom: 5%;
        left: 5%;
        }
    .center{
        position:absolute;
        top:20%;
        left:5%;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="center">
             <asp:gridview runat="server" ID="Gv1" AutoGenerateColumns="true">  
            </asp:gridview>  
        </div>
        <div class="top_left">

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />

        </div>
        <div class ="bottom_left">

            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Home" />

        </div>
    </form>
</body>
</html>

