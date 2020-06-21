<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CalculatorClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="font-family: Arial">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Numerator" Font-Bold="true"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtNumerator" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Denomirator" Font-Bold="true"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDenomirator" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnDivide" runat="server" Text="Divide" OnClick="btnDivide_Click" /></td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
