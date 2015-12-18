<%@ Page Title="" Language="C#" MasterPageFile="~/utilizadores_unitarios/Cliente_unitario.master" AutoEventWireup="true" CodeFile="DadosCarros.aspx.cs" Inherits="utilizadores_unitarios_DadosCarros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="form-horizontal">
    <hr />
    <div class="form-group">
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
    <hr />
    <div class="form-group">
        <h4>Novo Carro: </h4>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="marca" CssClass="col-md-2 control-label">Marca: </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="Marca" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="marca"
                    CssClass="text-danger" ErrorMessage="Insira uma marca!" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="modelo" CssClass="col-md-2 control-label">Modelo: </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="modelo" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="modelo"
                    CssClass="text-danger" ErrorMessage="Insira um modelo!" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="matricula" CssClass="col-md-2 control-label">Matrícula: </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="matricula" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="marca"
                    CssClass="text-danger" ErrorMessage="Insira uma matrícula" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true">Carro está? </asp:Label>
            <div class="col-md-5">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem Text="Ativo"></asp:ListItem>
                    <asp:ListItem Text="Desativo"></asp:ListItem>
                </asp:RadioButtonList>
        <div class="form-group">
            <div class="col-md-5">
            <asp:Button runat="server" Text="Adicionar Carro" CssClass="btn btn-default" />
            </div>
         </div>
            </div>
        </div>


    <hr />    
</div>
</asp:Content>

