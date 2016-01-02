<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.master" AutoEventWireup="true" CodeFile="GerirParqueamento.aspx.cs" Inherits="Administrador_GerirParqueamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            Esta a gerir as requisições:
            &nbsp;<br />
            <div class="col-md-5">    
                <div style="margin-left: 100px">
                    <br />
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="Eleminar" />
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
                    <asp:CommandField ShowSelectButton="true" SelectText="Eleminar" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
        <asp:Panel ID="Panel1" runat="server">
            <hr />
        <div class="form-group">
            Modificar Requisição:
            <br />
            <br />
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Carro: " Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
            
            &nbsp;<asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
            <br />&nbsp;<br /><br /><asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="17" Font-Underline="true" Text="Parque:"></asp:Label>
            &nbsp;<asp:DropDownList ID="Selecionaparque0" runat="server">
                <asp:ListItem Selected="True" Text="Avenida Fernao Magalhaes" Value="Avenida Fernao Magalhaes"></asp:ListItem>
                <asp:ListItem Text="Quinta das Flores" Value="Quinta das Flores"></asp:ListItem>
                <asp:ListItem Text="Celas(Hospital)" Value="Celas(Hospital)"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;<br />&nbsp;<br /><br />&nbsp;<div class="form-group">
                <div class="col-md-5">
                    <asp:Label ID="Label3" runat="server" CssClass="col-md-5 control-label" Font-Bold="true" Font-Size="17" Font-Underline="true" Text="Data inicio:"></asp:Label>
                    <asp:TextBox ID="Datainicio0" runat="server" TextMode="Date" AutoPostBack="True"></asp:TextBox>
                    <asp:CompareValidator ID="cmp3" runat="server" ControlToValidate="Datainicio0" ErrorMessage="A data deve ser a partir de hoje" ForeColor="Red" Operator="GreaterThanEqual" Type="String" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="Label4" runat="server" CssClass="col-md-5 control-label" Font-Bold="true" Font-Size="17" Font-Underline="true" Text="Data fim:"></asp:Label>
                    
                    <asp:TextBox ID="Datafim0" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:CompareValidator ID="cmp4" runat="server" ControlToValidate="Datafim0" ErrorMessage="A data deve ser a partir de hoje - pelo menos um dia" ForeColor="Red" Operator="GreaterThan" Type="String" />
                    <br />
                    <br />
                    <asp:CompareValidator ID="cmp6" runat="server" ControlToValidate="Datafim0" ErrorMessage="A data final não é maior que a inicial" ForeColor="Red" Operator="GreaterThan"></asp:CompareValidator>
                </div>
            </div>
                <br />
                    <asp:Button ID="voltar" runat="server" Text="voltar" Width="109px" OnClick="voltar_Click"/>
                <asp:Button ID="Modificar" runat="server" OnClick="Modificar_Click" Text="Modificar" Width="109px" />
                </div>
        <hr />
        </asp:Panel>

        </div>
    <hr />
    </div>
</asp:Content>
