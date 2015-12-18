<%@ Page Title="" Language="C#" MasterPageFile="~/utilizadores_unitarios/Cliente_unitario.master" AutoEventWireup="true" CodeFile="inicio_unitario.aspx.cs" Inherits="utilizadores_unitarios_inicio_unitario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="770px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:CommandField ShowSelectButton="true" />
        <asp:CommandField ShowDeleteButton="true" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>

    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>

</asp:Content>

