<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.master" AutoEventWireup="true" CodeFile="GerirClientes.aspx.cs" Inherits="Administrador_GerirClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="form-horizontal">
        <hr />
        <br />
        Esta a ver os clientes:<br />
&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="Eleminar" />
        <br />
        <div class="form-group">
            
            <div class="col-md-8">    
                <div>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label">Ver por nomes:</asp:Label><asp:TextBox ID="pesquisa1" runat="server" TextMode="Search"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="Pesquizar" Width="90px" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" Text="Reset" Width="61px" OnClick="Button4_Click"/>
                </div>
            </div>
        </div>
    <hr />
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                 <asp:CommandField ShowSelectButton="true" SelectText=" Editar " />
            </Columns>
            </asp:GridView>
            <br />
            <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <Columns>
                 <asp:CommandField ShowSelectButton="true" SelectText=" Eleminar " />
            </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    <asp:Panel ID="Panel1" runat="server">
            <hr />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Nome: " Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
            
                <asp:TextBox ID="Textnome" runat="server" Width="438px" Enabled="False"></asp:TextBox>
                &nbsp;<br />&nbsp;<br /><br /><asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="17" Font-Underline="true" Text="Email: "></asp:Label>
            <asp:TextBox ID="Textemail" runat="server" Width="336px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Textemail" CssClass="text-danger" ErrorMessage="O email é necessario." />
            &nbsp;<asp:RegularExpressionValidator ID="N_mail" runat="server" ControlToValidate="Textemail" ErrorMessage="Email invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
            
     
                <br />
            <br />
              
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Nº Contribuinte: " Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
            
                <asp:TextBox ID="Textcontribuinte" runat="server" Width="336px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Textcontribuinte" CssClass="text-danger" ErrorMessage="O numero de contribuinte é necessario." />
                &nbsp;<asp:RegularExpressionValidator ID="N_contri" runat="server" ControlToValidate="Textcontribuinte" ErrorMessage="O numero de contribuinte têm 9 digitos" ValidationExpression="\d{9}"></asp:RegularExpressionValidator>
                <br />
            
        
        <br />
            <br />
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Tipo de utilizador" Font-Bold="True" Font-Underline="True" Font-Size="17pt"></asp:Label>
            
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem Selected="True" Value="Cliente Unitario">Cliente Unitario</asp:ListItem>
                    <asp:ListItem Value="Cliente coletivo">Cliente coletivo</asp:ListItem>
                </asp:DropDownList>
                
                <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                
                <br />
                <br />
                
           
       
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Underline="true" Font-Size="13">
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Alterar Palabvra-passe? Carregue aqui!"></asp:HyperLink></asp:Label>
                    <asp:Button ID="voltar" runat="server" Text="voltar" Width="109px" OnClick="voltar_Click" />
                    <asp:Button ID="Button1" runat="server" Text="Modificar" Width="109px" OnClick="Button1_Click" />
                </div>
        <hr />
        </asp:Panel>

        </div>
    <hr />
    </div>
</asp:Content>

