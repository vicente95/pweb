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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_usr %>" SelectCommand="SELECT Carro.marca, Carro.matricula, Carro.modelo, Requisicao.Data_inicio, Requisicao.Data_fim, Parque.nome, Requisicao.Entidade, Requisicao.Referencia, Requisicao.Valor, Requisicao.Estado_pagamento FROM Parque_requisicao INNER JOIN Parque ON Parque_requisicao.Id_parque = Parque.Id_parque INNER JOIN Requisicao ON Parque_requisicao.Id_requisicao = Requisicao.Id_requisicao INNER JOIN Requisicao_carro ON Requisicao.Id_requisicao = Requisicao_carro.Id_requisicao INNER JOIN Carro ON Requisicao_carro.Id_carro = Carro.Id_carro INNER JOIN Utilizador_requisicao ON Requisicao.Id_requisicao = Utilizador_requisicao.Id_requisicao WHERE (Utilizador_requisicao.Id_utilizador = @id) AND (Carro.matricula LIKE '%' + @matricula + '%')" UpdateCommand="UPDATE Carro SET matricula = @x1, marca = @x2, modelo = @x3, condutor = @x4, estado = @x5 WHERE (id_utilizador = @x6) AND (matricula = @x7)">
            <SelectParameters>
                <asp:Parameter Name="id" />
                <asp:ControlParameter ControlID="TextBox1" Name="matricula" PropertyName="Text" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="x1" />
                <asp:Parameter Name="x2" />
                <asp:Parameter Name="x3" />
                <asp:Parameter Name="x4" />
                <asp:Parameter Name="x5" />
                <asp:Parameter Name="x6" />
                <asp:Parameter Name="x7" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        t<br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_usr %>" SelectCommand="SELECT COUNT([estado]) FROM [Carro] WHERE [estado]=1 AND id_utilizador = @id">
            <SelectParameters>
                <asp:Parameter Name="id" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" />
                <asp:CompleteWizardStep runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
        <br />
        <br />
    </form>
</body>
</html>
