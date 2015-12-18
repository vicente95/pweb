<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageteste.master" AutoEventWireup="true" CodeFile="registo.aspx.cs" Inherits="registo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <h2>Registo-</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Criar uma nova conta.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">User name</asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="O email é necessario." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                <br />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="N_contribuinte" CssClass="col-md-2 control-label">Nº de contribuinte</asp:Label>
            <div class="col-md-2">
                <asp:TextBox runat="server" ID="N_contribuinte" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="N_contribuinte"
                    CssClass="text-danger" ErrorMessage="O numero de contribuinte é necessario." />
                <br />
            </div>
        </div>
        <div class="form-group">
            <div style="margin-left: 340px">
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem Selected="True" Value="1">Cliente Unitario</asp:ListItem>
                    <asp:ListItem Value="2">Cliente coletivo</asp:ListItem>
                </asp:DropDownList>
                <div>
                Cliente Unitario-&gt; Pessoa individual, sem representação empresarial, para uso pessoal ou familiar dos parques pelas respetivas viaturas. 
                - 2 matriculas ativas no máximo.
                </div>
                <div>
               Cliente Coletivo-&gt; Pessoa que representa um coletivo, nomeadamente uma empresa, e pretende que os parques sejam utilizados por um conjunto de veiculos.
Poderá atribuir pessoas as respetivas matriculas. - 10 matriculas ativas no maximo. 
                </div>
                <div>
                <asp:Button runat="server" Text="Registar" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

