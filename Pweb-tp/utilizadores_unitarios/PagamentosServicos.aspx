<%@ Page Title="" Language="C#" MasterPageFile="~/utilizadores_unitarios/Cliente_unitario.master" AutoEventWireup="true" CodeFile="PagamentosServicos.aspx.cs" Inherits="utilizadores_unitarios_PagamentosServicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <hr />
    <asp:Label ID="Label1" runat="server" Text="Label">Ver por matricula:</asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Width="179px"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" Text="pesquizar" Width="81px" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" >
            <AlternatingRowStyle BackColor="White" />
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
    Estes pagamentos poderão ser feitos pelo multibanco ou dirigindo-se a seccção rodiviaria da Camarâ Municipal de Coimbra.<br />
    Escolha sempre como preferencial o pagamento por multibanco. Poderá demorar algum tempo a reconhecer os pagamentos.<hr />
</asp:Content>

