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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_usr %>" SelectCommand="SELECT Carro.matricula, Carro.modelo, Parque.nome, Requisicao.Data_inicio, Requisicao.Data_fim FROM Parque_requisicao INNER JOIN Parque ON Parque_requisicao.Id_parque = Parque.Id_parque INNER JOIN Carro INNER JOIN Requisicao_carro ON Carro.Id_carro = Requisicao_carro.Id_carro INNER JOIN Requisicao ON Requisicao_carro.Id_requisicao = Requisicao.Id_requisicao ON Parque_requisicao.Id_requisicao = Requisicao.Id_requisicao WHERE (Carro.id_utilizador = @id)">
            <SelectParameters>
                <asp:Parameter Name="id" />
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
