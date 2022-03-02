<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminViewPayInst.aspx.cs" Inherits="WebApplication1.AdminViewPayInst" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Admin.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button3" runat="server" OnClick="OnGoing" Text="List ongoing Thesis and its count" />
            <asp:Button ID="Button4" runat="server" OnClick="Payment" Text="View all payments" />
        </div>
        <p>
        <asp:Button ID="Button1" runat="server" OnClick="Supervisor" Text="View Supervisors" />
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="AllThesis" Text="List all thesis" />
            <asp:Button ID="Button5" runat="server" Text="View payments and installments" Enabled="false" OnClick="PaymentInst" />
        </p>
    <script type="text/javascript" >
    </script>
        <asp:Table ID="Table1" runat="server" GridLines="Both">
            
        </asp:Table>
    </form>
</body>
</html>
