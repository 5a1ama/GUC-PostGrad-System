<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GucianTheses.aspx.cs" Inherits="WebApplication1.GucianTheses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" Visible="False" runat="server" AutoGenerateColumns="False" DataKeyNames="serialNumber" DataSourceID="SqlDataSource1" style="margin-top: 8px">
            <Columns>
                <asp:BoundField DataField="serialNumber" HeaderText="serialNumber" InsertVisible="False" ReadOnly="True" SortExpression="serialNumber" />
                <asp:BoundField DataField="field" HeaderText="field" SortExpression="field" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="startDate" HeaderText="startDate" SortExpression="startDate" />
                <asp:BoundField DataField="endDate" HeaderText="endDate" SortExpression="endDate" />
                <asp:BoundField DataField="defenseDate" HeaderText="defenseDate" SortExpression="defenseDate" />
                <asp:BoundField DataField="years" HeaderText="years" ReadOnly="True" SortExpression="years" />
                <asp:BoundField DataField="grade" HeaderText="grade" SortExpression="grade" />
                <asp:BoundField DataField="payment_id" HeaderText="payment_id" SortExpression="payment_id" />
                <asp:BoundField DataField="noOfExtensions" HeaderText="noOfExtensions" SortExpression="noOfExtensions" />
            </Columns>
        </asp:GridView>
 
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:projConnectionString %>" SelectCommand="ViewAllMyTheses" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="1" Name="studentID" SessionField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
