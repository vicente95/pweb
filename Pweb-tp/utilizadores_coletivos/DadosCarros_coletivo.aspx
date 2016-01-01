<%@ Page Title="" Language="C#" MasterPageFile="~/utilizadores_coletivos/Cliente_coletivo.master" AutoEventWireup="true" CodeFile="DadosCarros_coletivo.aspx.cs" Inherits="utilizadores_unitarios_DadosCarros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="form-horizontal">
    <hr />
        Aqui poderá ver, editar e eleminar os seus carros.
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Eleminar" AutoPostBack="True" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Label">Ver por condutor:</asp:Label>
        <asp:TextBox ID="procurar" runat="server" Width="179px"></asp:TextBox>
        &nbsp;<asp:Button ID="pesq" runat="server" Text="Pesquizar" Width="90px" OnClick="pesq_Click"/>
        <asp:Button ID="reset" runat="server" Text="Reset" Width="61px" OnClick="reset_Click" />
        <br />
        <br />
    <div class="form-group">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                 <asp:CommandField ShowSelectButton="true" SelectText=" Editar " />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Visible="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                 <asp:CommandField ShowSelectButton="true" SelectText=" Eleminar"  />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <p>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <br />
    <asp:Label ID="Label1" runat="server" Text="Label">Pode editar e eleminar a sua informação.</asp:Label>
        </p>
    </div>
    <hr />
    <asp:Panel ID="Panel1" runat="server">
    <div class="form-group">
        <h4>Novo Carro: </h4>
        <p>
            &nbsp;</p>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="marca" CssClass="col-md-2 control-label">Marca: </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="marca" CssClass="form-control" />
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
                <asp:RequiredFieldValidator runat="server" ControlToValidate="matricula"
                    CssClass="text-danger" ErrorMessage="Insira uma matrícula" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="condutor" CssClass="col-md-2 control-label">Condutor(nome): </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="condutor" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="condutor"
                    CssClass="text-danger" ErrorMessage="Insira o nome do funcionario que anda com o carro" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true">Carro está? </asp:Label>
            <div class="col-md-5">
        <div class="form-group">
            <div class="col-md-5">
                <br />
                <asp:RadioButtonList ID="RadioButtonList3" runat="server">
                    <asp:ListItem Value="1">Activo</asp:ListItem>
                    <asp:ListItem Value="0">Desativo</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RadioButtonList3" CssClass="text-danger" ErrorMessage="Selecione o estado do carro" />
                <br />
            <asp:Button ID="adcarro" runat="server" Text="Adicionar Carro" CssClass="btn btn-default" OnClick="adcarro_Click" />
            </div>
         </div>
            </div>
        </div>
    <hr />    

</div>
</asp:Panel>

    <asp:Panel ID="Panel2" runat="server">
    <div class="form-group">
        <h4>Modificar Carro: </h4>
        <p>
            &nbsp;</p>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="marca" CssClass="col-md-2 control-label">Marca: </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox1"
                    CssClass="text-danger" ErrorMessage="Insira uma marca!" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="modelo" CssClass="col-md-2 control-label">Modelo: </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox2"
                    CssClass="text-danger" ErrorMessage="Insira um modelo!" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="matricula" CssClass="col-md-2 control-label">Matrícula: </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox3"
                    CssClass="text-danger" ErrorMessage="Insira uma matrícula" />
            </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="condutor" CssClass="col-md-2 control-label">Condutor(nome): </asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="condutor2" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="condutor2"
                    CssClass="text-danger" ErrorMessage="Insira o nome do funcionario que anda com o carro" />
            </div>
        </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true">Carro está? </asp:Label>
            <div class="col-md-5">
        <div class="form-group">
            <div class="col-md-5">
                <br />
                <br />
                <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                    <asp:ListItem Value="1">Activo</asp:ListItem>
                    <asp:ListItem Value="0">Desativo</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList2" CssClass="text-danger" ErrorMessage="Selecione o estado do carro" />
                &nbsp;&nbsp;&nbsp;<br />
                <br />
                &nbsp;
            <asp:Button ID="Button3" runat="server" Text="voltar" CssClass="btn btn-default" OnClick="Button3_Click"/>
                <asp:Button ID="Button2" runat="server" CssClass="btn btn-default" OnClick="Button2_Click" Text="Modificar Carro" />
            </div>
         </div>
            </div>
        </div>
    
</div>
</asp:Panel>
</div>
</asp:Content>

