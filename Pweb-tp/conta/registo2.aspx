<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageteste.master" AutoEventWireup="true" CodeFile="registo2.aspx.cs" Inherits="registo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <h2>Registo-</h2>
    <p class="text-danger">
        &nbsp;</p>

    <div class="form-horizontal">
        <h4>Continuação.</h4>
        <hr />
        <div class="form-group">
            <div >
            <asp:Label runat="server" AssociatedControlID="N_contribuinte" CssClass=" control-label">Nº de contribuinte</asp:Label>
            
                <asp:TextBox runat="server" ID="N_contribuinte" CssClass="form-control" Height="32px" Width="300px" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="N_contribuinte"
                    CssClass="text-danger" ErrorMessage="O numero de contribuinte é necessario." />
                <br />
                <asp:RegularExpressionValidator ID="N_contribuinteexp" runat="server" CssClass="text-danger" ControlToValidate="N_contribuinte" ErrorMessage="Não tem 9 digitos" ValidationExpression="\d{9}"></asp:RegularExpressionValidator>
                <br />
                <br /><br />
                <br />
            </div >
                Registo carro:(insira um carro obrigatorio ter pelo menos 1)-<br />
                <div class="col-md-8">
                    <br />
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="marca" CssClass=" control-label">Marca: </asp:Label>
                    <div>
                        <asp:TextBox ID="marca" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="marca" CssClass="text-danger" ErrorMessage="Insira uma marca!" />
                    </div>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="modelo" CssClass=" control-label">Modelo: </asp:Label>
                    <div>
                        <asp:TextBox ID="modelo" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="modelo" CssClass="text-danger" ErrorMessage="Insira um modelo!" />
                    </div>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="matricula" CssClass=" control-label">Matrícula: </asp:Label>
                    <div>
                        <asp:TextBox ID="matricula" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="marca" CssClass="text-danger" ErrorMessage="Insira uma matrícula" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="matricula" ErrorMessage="Matricula invalida" ValidationExpression="^\d{2}-\w{2}-\d{2}$"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="Label4" runat="server" CssClass=" control-label" Font-Bold="true">Carro está? </asp:Label>
                    <div>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem Selected="True" Text="Ativo"></asp:ListItem>
                            <asp:ListItem Text="Desativo"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
              
            </div>
            <div><br /><br />
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="1">Cliente Unitario</asp:ListItem>
                    <asp:ListItem Value="2">Cliente coletivo</asp:ListItem>
                </asp:DropDownList>
                <div>
                Cliente Unitario-&gt; Pessoa individual, sem representação empresarial, para uso pessoal ou familiar dos parques pelas respetivas viaturas. 
                - 2 matriculas ativas no máximo.
                </div>
                <div>
               Cliente Coletivo-&gt; Pessoa que representa um coletivo, nomeadamente uma empresa, e pretende que os parques sejam utilizados por um conjunto de veiculos.
Poderá atribuir pessoas as respetivas matriculas. - 10 matriculas ativas no maximo. 
                    <br />
                    <div class="col-md-8">
                        <br />
                        <br />
                        <asp:Label ID="Label5" runat="server" AssociatedControlID="matricula" CssClass=" control-label">Condutor: </asp:Label>
                        <div>
                            <asp:TextBox ID="condut" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="condut" CssClass="text-danger" ErrorMessage="Insira uma matrícula" />
                            <asp:RegularExpressionValidator ID="N_nome" runat="server" ControlToValidate="condut" ErrorMessage="Tem de ter mais de 3 caracteres sem números" ValidationExpression="^[\s\S]{3,}$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <br />
                </div>
                <br /><br /> <br />
                <br />
                <div>
                    <asp:Button runat="server" Text="Finalizar Registo" CssClass="btn btn-default" OnClick="button_Click" />
                </div>
            </div>
        </div>
    </div>
    <hr />

</asp:Content>

