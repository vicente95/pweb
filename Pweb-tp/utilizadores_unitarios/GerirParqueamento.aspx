<%@ Page Title="" Language="C#" MasterPageFile="~/utilizadores_unitarios/Cliente_unitario.master" AutoEventWireup="true" CodeFile="GerirParqueamento.aspx.cs" Inherits="utilizadores_unitarios_GerirParqueamento" %>

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
        <br />
        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" Visible="False">
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
        &nbsp;<br />
&nbsp;&nbsp;&nbsp;
    </div>
    <hr />
    <div class="form-group">
        <h4>Nova Requisição: </h4>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Underline="true" Font-Size="15">Carro ativos: </asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="Selecionecarro" runat="server">
                    <asp:ListItem Text="Selecione" Selected="True" Value ="1"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Underline="true" Font-Size="15">Selecione o parque: </asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="Selecionaparque" runat="server">
                    <asp:ListItem Text="Parque 1 - Avenida Fernão Magalhães" Selected="True" Value ="1"></asp:ListItem>
                    <asp:ListItem Text="Parque 2 - Quinta das Flores" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Parque 3 - Celas(Hospital)" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Underline="true" Font-Size="15">Data Inicio: </asp:Label>
            <div class="col-md-5">       
                <asp:TextBox ID="Datainicio" runat="server" TextMode="Date"></asp:TextBox>
                <asp:CompareValidator runat="server" ID="cmp1" ErrorMessage="A data deve ser a partir de hoje" ControlToValidate="Datainicio" Type="String" Operator="GreaterThanEqual" ForeColor="Red" />
             </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Underline="true" Font-Size="15">Data Fim: </asp:Label>
            <div class="col-md-6">       
                <asp:TextBox ID="Datafim" runat="server" TextMode="Date"></asp:TextBox>
                <asp:CompareValidator runat="server" ID="cmp2" ErrorMessage="A data deve ser a partir de hoje - pelo menos um dia" ControlToValidate="Datafim" Type="String" Operator="GreaterThan" ForeColor="Red" />
             </div>
        </div>

        <div class="form-group">
            <div style="margin-left: 250px">
            <asp:Button runat="server" Text="Adicionar" CssClass="btn btn-default" ID="Criar" OnClick="Criar_Click" />
            </div>
         </div>

        <asp:Panel ID="Panel1" runat="server">
            <hr />
        <div class="form-group">
            Modificar Requisição:
            <br />
            <br />
            <asp:Label runat="server" CssClass="col-md-2 control-label" Text="Carro: " Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
            
                <asp:DropDownList ID="Selecionecarro0" runat="server">
                    <asp:ListItem Selected="True" Text="Selecione" Value="1"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;<br />&nbsp;<br /><br /><asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="17" Font-Underline="true" Text="Parque:"></asp:Label>
            &nbsp;<asp:DropDownList ID="Selecionaparque0" runat="server">
                <asp:ListItem Selected="True" Text="Avenida Fernão Magalhães" Value="1"></asp:ListItem>
                <asp:ListItem Text="Quinta das Flores" Value="2"></asp:ListItem>
                <asp:ListItem Text="Celas(Hospital)" Value="3"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;<br />&nbsp;<br /><br />&nbsp;<div class="form-group">
                <div class="col-md-5">
                    <asp:Label ID="Label1" runat="server" CssClass="col-md-5 control-label" Font-Bold="true" Font-Size="17" Font-Underline="true" Text="Data inicio:"></asp:Label>
                    <asp:TextBox ID="Datainicio0" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:CompareValidator ID="cmp3" runat="server" ControlToValidate="Datainicio" ErrorMessage="A data deve ser a partir de hoje" ForeColor="Red" Operator="GreaterThanEqual" Type="String" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="Label2" runat="server" CssClass="col-md-5 control-label" Font-Bold="true" Font-Size="17" Font-Underline="true" Text="Data fim:"></asp:Label>
                    
                    <asp:TextBox ID="Datafim0" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:CompareValidator ID="cmp4" runat="server" ControlToValidate="Datafim" ErrorMessage="A data deve ser a partir de hoje - pelo menos um dia" ForeColor="Red" Operator="GreaterThan" Type="String" />
                </div>
            </div>
                <br />
                
           
       
                    <asp:Button ID="Modificar" runat="server" Text="Modificar" Width="109px" OnClick="Modificar_Click" />
                </div>
        <hr />
        </asp:Panel>

</div>
    <hr />
</div>
</asp:Content>

