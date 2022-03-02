<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examiner_Defense.aspx.cs" Inherits="WebApplication1.Examiner_Defense" %>

<!DOCTYPE html>
<style>
    .center{
        position:absolute;
        top:10%;
        left:35%;
    }
    .topRight{
        position:absolute;
        top:5%;
        right:5%;
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
        <div class ="topRight">
             
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" />
             
        </div>
    </form>
</body>
</html>
