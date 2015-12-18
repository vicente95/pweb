<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.master" AutoEventWireup="true" CodeFile="GerirClientes.aspx.cs" Inherits="Administrador_GerirClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            
            <div class="col-md-5">    
                <div style="margin-left: 100px">
                    <asp:TextBox ID="pesquisa1" runat="server" TextMode="Search" Text="Pesquisa"></asp:TextBox>
                </div>
            </div>
        </div>
    <hr />
        <div class="form-group">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    <hr />
    </div>
</asp:Content>

