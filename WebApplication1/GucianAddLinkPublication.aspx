<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GucianAddLinkPublication.aspx.cs" Inherits="WebApplication1.GucianAddLinkPublication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="GucianAddLinkPublication.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
            <asp:Button ID="Button1" runat="server" Text="Add Publication" OnClick="ADD" />
                    <asp:Button ID="Button2" runat="server" Text="Link Publication" OnClick="LINK" />


        <p>
            <asp:CheckBox ID="CheckBox1" runat="server" name="accepeted"/>
        </p>
  

    </form>
</body>
</html>
