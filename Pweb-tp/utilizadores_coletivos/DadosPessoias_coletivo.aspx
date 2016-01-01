<%@ Page Title="" Language="C#" MasterPageFile="~/utilizadores_coletivos/Cliente_coletivo.master" AutoEventWireup="true" CodeFile="DadosPessoias_coletivo.aspx.cs" Inherits="utilizadores_unitarios_DadosPessoias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
<div class="form-horizontal">
            <hr />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Nome: " Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
            <div class="col-lg-2">
                <asp:Label ID="Label1" runat="server" Text="Aqui vai ser o nome do utilizador" Font-Size="15"></asp:Label>
            </div>
        </div>
                <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Email: " Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
            <div class="col-lg-2">
                <asp:Label ID="Label2" runat="server" Text="Aqui vai ser o email do utilizador" Font-Size="15"></asp:Label>
            </div>
        </div>
                <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Morada " Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
            <div class="col-lg-2">
                <asp:Label ID="Label3" runat="server" Text="Aqui vai ser a morada do utilizador" Font-Size="15"></asp:Label>
            </div>
        </div>
                <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Nº Contribuinte: " Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
            <div class="col-lg-2">
                <asp:Label ID="Label4" runat="server" Text="Aqui vai ser o Contribuinte do utilizador" Font-Size="15"></asp:Label>
            </div>
        </div>
                <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Underline="true" Font-Size="13">
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Alterar Palabvra-passe? Carregue aqui!"></asp:HyperLink></asp:Label>
                </div>
        <hr />
</div>
</asp:Content>

