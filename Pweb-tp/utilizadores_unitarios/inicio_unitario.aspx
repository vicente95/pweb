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
    <br />
    <asp:Panel ID="Panel1" runat="server">
        <asp:Panel ID="Panel2" runat="server">
            <hr />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Nome: " Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
            
                <asp:TextBox ID="Textnome" runat="server" Width="438px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Textnome" CssClass="text-danger" ErrorMessage="O nome é necessario." />
                &nbsp;<asp:RegularExpressionValidator ID="N_nome" runat="server" ControlToValidate="Textnome" ErrorMessage="RegularExpressionValidator" ValidationExpression="\s{3}"></asp:RegularExpressionValidator>
                <br />
           
        
               <br />
            <br />
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Email: " Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
            
                <asp:TextBox ID="Textemail" runat="server" Width="336px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Textemail" CssClass="text-danger" ErrorMessage="O email é necessario." />
                &nbsp;<asp:RegularExpressionValidator ID="N_mail" runat="server" ControlToValidate="Textemail" ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
            
     
                <br />
            <br />
              
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Nº Contribuinte: " Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
            
                <asp:TextBox ID="Textcontribuinte" runat="server" Width="336px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Textcontribuinte" CssClass="text-danger" ErrorMessage="O numero de contribuinte é necessario." />
                &nbsp;<asp:RegularExpressionValidator ID="N_contri" runat="server" ControlToValidate="Textcontribuinte" ErrorMessage="RegularExpressionValidator" ValidationExpression="\d{9}"></asp:RegularExpressionValidator>
                <br />
            
        
        <br />
            <br />
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Tipo de utilizador" Font-Bold="True" Font-Underline="True" Font-Size="17pt"></asp:Label>
            
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem Selected="True" Value="1">Cliente Unitario</asp:ListItem>
                    <asp:ListItem Value="2">Cliente coletivo</asp:ListItem>
                </asp:DropDownList>
                
                <br />
                <br />
                
           
       
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Underline="true" Font-Size="13">
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Alterar Palabvra-passe? Carregue aqui!"></asp:HyperLink></asp:Label>
                    <asp:Button ID="Button1" runat="server" Text="Modificar" Width="109px" />
                </div>
        <hr />
        </asp:Panel>
    </asp:Panel>

</asp:Content>

