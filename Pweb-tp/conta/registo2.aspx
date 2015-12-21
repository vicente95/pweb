<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageteste.master" AutoEventWireup="true" CodeFile="registo2.aspx.cs" Inherits="registo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <h2>Registo-</h2>
    <p class="text-danger">
        &nbsp;</p>

    <div class="form-horizontal">
        <h4>Continuação.</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="N_contribuinte" CssClass="col-md-2 control-label">Nº de contribuinte</asp:Label>
            <div class="col-md-2">
                <asp:TextBox runat="server" ID="N_contribuinte" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="N_contribuinte"
                    CssClass="text-danger" ErrorMessage="O numero de contribuinte é necessario." />
                <br />
                <asp:RegularExpressionValidator ID="N_contribuinteexp" runat="server" ControlToValidate="N_contribuinte" ErrorMessage="RegularExpressionValidator" ValidationExpression="\d{9}"></asp:RegularExpressionValidator>
                <br />
                <br />
            </div>
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
                    <asp:Button runat="server" Text="Finalizar Registo" CssClass="btn btn-default" OnClick="button_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

