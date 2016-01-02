<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.master" AutoEventWireup="true" CodeFile="GerirCarros.aspx.cs" Inherits="Administrador_GerirCarros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="form-horizontal">
        <hr />
        Esta a gerir carros:<br />
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="Eleminar" />
                    &nbsp;<br />
        <div class="form-group">
            
            <div class="col-md-5">    
                <div style="margin-left: 100px">
                            <br />
                            <asp:Label ID="Label1" runat="server" Text="Label">Ver por matricula:</asp:Label>
                            <asp:TextBox ID="pesquisa1" runat="server" TextMode="Search"></asp:TextBox>
                            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Pesquizar" Width="90px" />
                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Reset" Width="61px" />
                </div>
            </div>
        </div>
    <hr />
        <div class="form-group">
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                 <asp:CommandField ShowSelectButton="true" SelectText=" Editar " />
                </Columns>
            </asp:GridView>

            <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                <Columns>
                 <asp:CommandField ShowSelectButton="true" SelectText=" Eleminar " />
                </Columns>
            </asp:GridView>

            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <br />

    <asp:Panel ID="Panel1" runat="server">
    <div class="form-group">
        <h4>Modificar Carro: </h4>
        <p>
            &nbsp;</p>
        <div class="form-group">
            <asp:Label runat="server" ID="marca" CssClass="col-md-2 control-label">Marca: </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox1"
                    CssClass="text-danger" ErrorMessage="Insira uma marca!" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="modelo" CssClass="col-md-2 control-label">Modelo: </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox2"
                    CssClass="text-danger" ErrorMessage="Insira um modelo!" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" ID="matricula" CssClass="col-md-2 control-label">Matrícula: </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox3"
                    CssClass="text-danger" ErrorMessage="Insira uma matrícula" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="condutor" CssClass="col-md-2 control-label">Condutor: </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control" Enabled="False" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox3"
                    CssClass="text-danger" ErrorMessage="Insira um condutor" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true">Carro está? </asp:Label>
            <div class="col-md-5">
        <div class="form-group">
            <div class="col-md-5">
                <br />
                <asp:RadioButtonList ID="RadioButtonList4" runat="server">
                    <asp:ListItem Value="1">Activo</asp:ListItem>
                    <asp:ListItem Value="0">Desativo</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList4" CssClass="text-danger" ErrorMessage="Selecione o estado do carro" />
                &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button5" runat="server" Text="voltar" CssClass="btn btn-default" OnClick="Button5_Click"/>
                <asp:Button ID="Button2" runat="server" CssClass="btn btn-default"  Text="Modificar Carro" OnClick="Button2_Click" />
            </div>
         </div>
            </div>
        </div>
    
</div>
</asp:Panel>
        </div>
    <hr />
    </div>
</asp:Content>
