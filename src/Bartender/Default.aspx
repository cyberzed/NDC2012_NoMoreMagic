<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bartender.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<h1>Party Time!!!</h1>
		<asp:Repeater ID="drinkcardsRepeater" runat="server">
			<HeaderTemplate><hr /></HeaderTemplate>
			<ItemTemplate>
				CardName: <%# Eval("Name") %><br/>
				CardType: <%# Eval("CardType") %><br /><br/>
			</ItemTemplate>
			<FooterTemplate><hr /></FooterTemplate>
		</asp:Repeater>
	</div>
	</form>
</body>
</html>
