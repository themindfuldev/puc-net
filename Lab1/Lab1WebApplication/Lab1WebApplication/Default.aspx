<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab1WebApplication._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="SayHelloButton" runat="server" onclick="Button1_Click" 
            Text="Say Hello!" />    
        &nbsp;&nbsp;<asp:Label ID="ResultLabel" runat="server"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Button ID="ComplexMethodButton" runat="server" 
            onclick="ComplexMethodButton_Click" Text="Complex Method" />
    </div>
    </form>
</body>
</html>
