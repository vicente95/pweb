<%@ Page Language="C#" AutoEventWireup="true" CodeFile="inutilizavel.aspx.cs" Inherits="inutilizavel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Nome" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_usr %>" SelectCommand="SELECT * FROM [TestTable]"></asp:SqlDataSource>
    </form>
</body>
</html>
