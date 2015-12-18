<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageteste.master" AutoEventWireup="true" CodeFile="Registo.aspx.cs" Inherits="conta_Registo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="~/conta/Login.aspx">
    <WizardSteps>
        <asp:CreateUserWizardStep runat="server" />
        <asp:CompleteWizardStep runat="server" />
    </WizardSteps>
</asp:CreateUserWizard>


</asp:Content>

