<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testes-.aspx.cs" Inherits="testes_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_usr %>" SelectCommand="SELECT Carro.modelo, Carro.marca, Parque.nome, Requisicao.Data_inicio, Requisicao.Data_fim FROM Carro CROSS JOIN Requisicao CROSS JOIN Parque INNER JOIN Requisicao_carro ON Requisicao_carro.Id_carro = Carro.Id_carro INNER JOIN Parque_carro ON Parque_carro.Id_carro = Carro.Id_carro WHERE (Requisicao_carro.Id_carro = @status)">
            <SelectParameters>
                <asp:Parameter Name="status" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_usr %>" SelectCommand="SELECT Carro.modelo, Carro.marca, Parque.nome, Requisicao.Data_inicio, Requisicao.Data_fim FROM Carro CROSS JOIN Requisicao CROSS JOIN Parque INNER JOIN Requisicao_carro ON Requisicao_carro.Id_carro = Carro.Id_carro INNER JOIN Parque_carro ON Parque_carro.Id_carro = Carro.Id_carro WHERE (Requisicao_carro.Id_carro = @status)">
            <SelectParameters>
                <asp:Parameter Name="status" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
