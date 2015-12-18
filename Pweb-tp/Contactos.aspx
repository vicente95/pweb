<%@ Page Title="Contactos" Language="C#" MasterPageFile="~/MasterPageteste.master" AutoEventWireup="true" CodeFile="Contactos.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Contactos</h2>
        <div class="form-horizontal">
        <hr />
            <div style="margin-left: 50px">Este é um serviço pertencente à Câmara Municipal de Coimbra. Qualquer dúvida que tenha podera dirigir à secção de serviços rodoviarios do município.
            </div>
            <br />
            <div style="margin-left: 50px">
              <asp:Label runat="server" Text="Morada:" Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
              <br />
              <asp:Label runat="server" Text="Praça 8 de Maio - 3000-300 Coimbra" Font-Size="17"></asp:Label>
              <br /><br />
              <asp:Label runat="server" Text="Secção de serviços rodoviários: " Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
              <br />
              <asp:Label runat="server" Text="Horário: Segundo à Sexta das 09h00 às 12h30 e 15h00 às 18h00." Font-Size="17"></asp:Label>
              <br /><br />
              <asp:Label runat="server" Text="Telefones:" Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
              <br />
              <asp:Label runat="server" Font-Size="17">Telefone: 235 555 555  <br />Câmara: 255 555 556 <br />Secção rodoviaria: 255 555 557</asp:Label>
              <br />
              <br />
              <asp:Label runat="server" Text="Email:" Font-Bold="true" Font-Underline="true" Font-Size="17"></asp:Label>
              <br />
              <asp:Label runat="server" Font-Size="17">Qualquer duvida poderá sempre contactar-nos por parquescoimbra@gmail.com ou servicosrodoviarioscoimbra@gmail.com</asp:Label>
              <br />
              <br />
                <hr />
              <div>
                  <img height="250" width="500" src="Img/cm_coimbra.jpg" />
                  <img height="250" width="500" src="Img/Câmara_Coimbra.jpg" /> 
                  <asp:Label runat="server" Text="Visite-nos em " Font-Size="22">
                      <asp:HyperLink ID="HyperLink1" runat="server">www.cmc-coimbra.pt</asp:HyperLink></asp:Label>
              </div>
             
            </div>
        </div>
 <hr />
</asp:Content>
