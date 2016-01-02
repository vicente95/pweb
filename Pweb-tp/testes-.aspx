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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_usr %>" SelectCommand="SELECT [Email] FROM [Utilizador] WHERE ([Nome] NOT LIKE '%' + @Nome + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="Nome" PropertyName="Text" Type="String" />
            </SelectParameters>
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
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
        </asp:PasswordRecovery>
        <br />
    </form>
</body>
</html>
