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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_usr %>" SelectCommand="SELECT Carro.marca, Carro.matricula, Carro.modelo, Requisicao.Data_inicio, Requisicao.Data_fim, Parque.nome, Requisicao.Entidade, Requisicao.Referencia, Requisicao.Valor, Requisicao.Estado_pagamento FROM Parque_requisicao INNER JOIN Parque ON Parque_requisicao.Id_parque = Parque.Id_parque INNER JOIN Requisicao ON Parque_requisicao.Id_requisicao = Requisicao.Id_requisicao INNER JOIN Requisicao_carro ON Requisicao.Id_requisicao = Requisicao_carro.Id_requisicao INNER JOIN Carro ON Requisicao_carro.Id_carro = Carro.Id_carro INNER JOIN Utilizador_requisicao ON Requisicao.Id_requisicao = Utilizador_requisicao.Id_requisicao WHERE (Utilizador_requisicao.Id_utilizador = @id)">
            <SelectParameters>
                <asp:Parameter Name="id" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_usr %>" SelectCommand="SELECT COUNT([estado]) FROM [Carro] WHERE [estado]=1 AND id_utilizador = @id">
            <SelectParameters>
                <asp:Parameter Name="id" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
