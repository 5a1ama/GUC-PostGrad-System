<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NonGucianCourses.aspx.cs" Inherits="WebApplication1.NonGucianCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
         <asp:GridView ID="GridView1" Visible="False" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" style="margin-top: 8px" Width="845px">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="fees" HeaderText="fees" SortExpression="fees" />
                <asp:BoundField DataField="creditHours" HeaderText="creditHours" SortExpression="creditHours" />
                <asp:BoundField DataField="code" HeaderText="code" SortExpression="code" />
                <asp:BoundField DataField="grade" HeaderText="grade" SortExpression="grade" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:projConnectionString %>" SelectCommand="ViewCoursesAndGrades" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="1" Name="studentID" SessionField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
