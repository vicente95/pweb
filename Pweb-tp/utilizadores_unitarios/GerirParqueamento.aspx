<%@ Page Title="" Language="C#" MasterPageFile="~/utilizadores_unitarios/Cliente_unitario.master" AutoEventWireup="true" CodeFile="GerirParqueamento.aspx.cs" Inherits="utilizadores_unitarios_GerirParqueamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="form-horizontal">
    <hr />
    <div class="form-group">
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
    <hr />
    <div class="form-group">
        <h4>Nova Requisição: </h4>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Underline="true" Font-Size="15">Carro ativos: </asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="Selecionecarro" runat="server">
                    <asp:ListItem Text="Selecione" Selected="True" Value ="1"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Underline="true" Font-Size="15">Selecione o parque: </asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="Selecionaparque" runat="server">
                    <asp:ListItem Text="Parque 1 - Avenida Fernão Magalhães" Selected="True" Value ="1"></asp:ListItem>
                    <asp:ListItem Text="Parque 2 - Quinta das Flores" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Parque 3 - Celas(Hospital)" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Underline="true" Font-Size="15">Data Inicio: </asp:Label>
            <div class="col-md-5">       
                <asp:TextBox ID="Datainicio" runat="server" TextMode="Date"></asp:TextBox>
             </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Underline="true" Font-Size="15">Data Fim: </asp:Label>
            <div class="col-md-5">       
                <asp:TextBox ID="Datafim" runat="server" TextMode="Date"></asp:TextBox>


             </div>
        </div>
        <div class="form-group">
            <div style="margin-left: 340px">
            <asp:Button runat="server" Text="Adicionar" CssClass="btn btn-default" />
            </div>
         </div>


</div>
    <hr />
</div>
</asp:Content>

