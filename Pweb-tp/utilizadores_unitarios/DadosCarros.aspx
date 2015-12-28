<%@ Page Title="" Language="C#" MasterPageFile="~/utilizadores_unitarios/Cliente_unitario.master" AutoEventWireup="true" CodeFile="DadosCarros.aspx.cs" Inherits="utilizadores_unitarios_DadosCarros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="form-horizontal">
    <hr />
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Eleminar" AutoPostBack="True" />
    <div class="form-group">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                 <asp:CommandField ShowSelectButton="true" />
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
        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Visible="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                 <asp:CommandField ShowDeleteButton="true" />
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
        <br />
    <asp:Label ID="Label1" runat="server" Text="Label">Pode editar e eleminar a sua informação.</asp:Label>
    </div>
    <hr />
    <asp:Panel ID="Panel1" runat="server">
    <div class="form-group">
        <h4>Novo Carro: </h4>
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
                <asp:RequiredFieldValidator runat="server" ControlToValidate="marca"
                    CssClass="text-danger" ErrorMessage="Insira uma matrícula" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true">Carro está? </asp:Label>
            <div class="col-md-5">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem Text="Ativo" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Desativo"></asp:ListItem>
                </asp:RadioButtonList>
        <div class="form-group">
            <div class="col-md-5">
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
        </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true">Carro está? </asp:Label>
            <div class="col-md-5">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                    <asp:ListItem Text="Ativo"></asp:ListItem>
                    <asp:ListItem Text="Desativo"></asp:ListItem>
                </asp:RadioButtonList>
        <div class="form-group">
            <div class="col-md-5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList2" CssClass="text-danger" ErrorMessage="Selecione" />
            <asp:Button ID="Button2" runat="server" Text="Modificar Carro" CssClass="btn btn-default" OnClick="Button2_Click" />
            </div>
         </div>
            </div>
        </div>
    <hr />    

</div>
</asp:Panel>
</div>
</asp:Content>

