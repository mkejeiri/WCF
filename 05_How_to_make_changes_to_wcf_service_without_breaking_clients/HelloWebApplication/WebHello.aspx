﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebHello.aspx.cs" Inherits="HelloWebApplication.WebHello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </div>
      <div>
          <asp:Label ID="Label1" runat="server"></asp:Label>
      </div>
    </form>
</body>
</html>
