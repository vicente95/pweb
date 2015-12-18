<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.master" AutoEventWireup="true" CodeFile="GerirCarros.aspx.cs" Inherits="Administrador_GerirCarros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            
            <div class="col-md-5">    
                <div style="margin-left: 100px">
                    <asp:TextBox ID="pesquisa2" runat="server" TextMode="Search" Text="Pesquisa"></asp:TextBox>
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
