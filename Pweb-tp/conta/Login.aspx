<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageteste.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="conta_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
    &nbsp;<asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:Login ID="Login1" runat="server" VisibleWhenLoggedIn="False" DestinationPageUrl="~/conta/registo2.aspx" CreateUserUrl="~/conta/Registo1.aspx" CreateUserText="Não tem conta? Faça o registo aqui" ></asp:Login>

        </AnonymousTemplate>
    </asp:LoginView>
            </div>
                </section>
               </div>
        </div>
    <asp:LoginView ID="LoginView2" runat="server">
        <AnonymousTemplate>
            <asp:PasswordRecovery ID="PasswordRecovery1" runat="server"></asp:PasswordRecovery>

        </AnonymousTemplate>
    </asp:LoginView>


</asp:Content>

