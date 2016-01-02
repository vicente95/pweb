<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Administrador.master" AutoEventWireup="true" CodeFile="PagamentoServiços.aspx.cs" Inherits="Administrador_PagamentoServiços" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="form-horizontal">
        <hr />
        Esta a ver o pagamento de serviços:
        <br />
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
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <br />
   <asp:Panel ID="Panel2" runat="server">
    <div class="form-group">
        <h4>Editar pagamento: </h4>
        <div class="form-group">
            <asp:Label runat="server"  Font-Bold="true" Font-Underline="true" Font-Size="15">Marca: </asp:Label>
            <div>
                &nbsp;<asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Font-Bold="true" Font-Underline="true" Font-Size="15">Matricula: </asp:Label>
            <div>
                <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Size="15" Font-Underline="true">Modelo: </asp:Label>
                <br />
                <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label8" runat="server" Font-Bold="true" Font-Size="15" Font-Underline="true">Parque: </asp:Label>
                <br />
                <asp:TextBox ID="TextBox7" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Font-Bold="true" Font-Size="15" Font-Underline="true">Entidade: </asp:Label>
                <br />
                <asp:TextBox ID="TextBox4" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" Font-Bold="true" Font-Size="15" Font-Underline="true">Referencia: </asp:Label>
                <br />
                <asp:TextBox ID="TextBox5" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Font-Bold="true" Font-Size="15" Font-Underline="true">Valor: </asp:Label>
                <br />
                <asp:TextBox ID="TextBox6" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Font-Bold="true" Font-Size="15" Font-Underline="true">Estado do pagamento: </asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="Por pagar">Por pagar</asp:ListItem>
                    <asp:ListItem Value="Pago">Pago</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <div style="margin-left: 250px">
            <asp:Button runat="server" Text="Modificar" CssClass="btn btn-default" ID="Alterar" OnClick="Alterar_Click" />
            </div>
         </div>
       </div>
     </asp:Panel>
        </div>
    <hr />
    </div>
</asp:Content>

