<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examiner_Comment.aspx.cs" Inherits="WebApplication1.Examiner_Comment" %>

<!DOCTYPE html>
<style type="text/css">
    .wrap { 
        white-space: normal; 
        width: 200px;

    }
    .comment {
        position: fixed;
        left: 45%;
        bottom: 101px;
        transform: translate(-50%, -50%);
        margin: 0 auto;
        height: 202px;
        width: 341px;
    }
     grade {
        position: fixed;
        left: 15%;
        bottom: 101px;
        transform: translate(-50%, -50%);
        margin: 0 auto;
        height: 202px;
        width: 341px;
    }
    home {
        position: fixed;
        left: 0%;
        bottom: 58px;
        transform: translate(-50%, -50%);
        margin: 0 auto;
    }
    #TextArea1 {
        width: 319px;
        height: 302px;
        margin-left: 0px;
    }
    .grade {
        width: 141px;
        height: 40px;
        margin-left: 243px;
        margin-top: 193px;
    }
    #div1 {
        height: 210px;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1" runat="server">
        </div>
        

            
        <div class ="comment">
            <asp:Label ID="Label1" runat="server" Text="Comments:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Height="191px" Width="313px"></asp:TextBox>
            </div>
        
        <div class=" grade">

            <asp:Label ID="Label2" runat="server" Text="Grade"></asp:Label>
            <br />

            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

        </div>
        
    </form>
</body>
</html>
