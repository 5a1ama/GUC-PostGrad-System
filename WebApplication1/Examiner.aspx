<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examiner.aspx.cs" Inherits="WebApplication1.Examiner" %>

<!DOCTYPE html>
<style>
.buttons{
    position:absolute;
    left:40%;
    right:50%;
    bottom:50%;
    top:40%;
}
.info{
    position:absolute;
    left:0%;
    top:1%;
    width: 460px;  
    }
.id{
    position:absolute;
    left:229px;
    top:0%;
    width: 221px;  
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
    
<head runat="server">
    <title>Examiner Home Page</title>
</head>
<body style="height: 313px">
    <form id="form1" runat="server">
        <div class="buttons" style="height: 295px; width: 363px">
            <asp:Button ID="personal" runat="server" Text="Edit Personal Information" Width="354px" OnClick="personal_Click" />
            <asp:Button ID="comment" runat="server" Text="Add Comment and/or grade to a Defense" Width="354px" OnClick="comment_Click" />
            <asp:Button ID="search" runat="server" Text="Search for a Thesis" OnClick="search_Click" Width="354px" />
            <br />
            <asp:Button ID="defense" runat="server" style="margin-top: 0px" Text="View Defenses Attended" Width="354px" OnClick="defense_Click" />
            <br />
            <br />
            <br />
        </div>
        <div id="div1" class ="info" runat="server">
            <label> Examiner Home Page</label>
            <asp:Label ID="Label2" class="id" runat="server"></asp:Label>
            
        </div>
    </form>
</body>
</html>
