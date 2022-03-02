<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminViewOngoing.aspx.cs" Inherits="WebApplication1.AdminViewOngoing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="AdminViewOngoing.css" />
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <asp:Button ID="Button3" runat="server" OnClick="OnGoing" Enabled="false" Text="List ongoing Thesis and its count" />
            <asp:Button ID="Button4" runat="server" OnClick="Payment" Text="View all payments" />
        </div>
        <p>
        <asp:Button ID="Button1" runat="server" OnClick="Supervisor" Text="View Supervisors" />
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="AllThesis" Text="List all thesis" />
            <asp:Button ID="Button5" runat="server" Text="View payments and installments" OnClick="PaymentInst" />
        </p>
    <script type="text/javascript" >
    </script>
        <asp:Table ID="Table1" runat="server" GridLines="Both">
            
        </asp:Table>
        
        <div id="div" runat="server" visible="false">
        </div>
        <asp:Label ID="Label1" runat="server" Text="Total Number of Ongoing Theses is "></asp:Label>
    </form>
</body>
</html>
