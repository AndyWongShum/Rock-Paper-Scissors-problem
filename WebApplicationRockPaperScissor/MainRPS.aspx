<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainRPS.aspx.cs" Inherits="WebApplicationRockPaperScissor.MainRPS"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type ="text/css" href="StyleSheetRPS.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 725px; width: 1197px;">
    <form id="form1" runat="server">
        <div class="centered" style="height: 39px; width: 444px;">
            <h1 style="width: 489px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Rock-Paper-Scissors challenge</h1>
        </div>
        <br class="centered" />
    <div class="imaged" style="height: 677px; width: 1174px; margin-left: 40px;">
        <img src="http://img4.wikia.nocookie.net/__cb20140704173457/magicite/images/5/5f/Copy-of-rock-paper-scissors.jpg" style="height: 248px; width: 378px" /><br />
&nbsp;&nbsp;<br />
        <asp:Label ID="Label2" runat="server" Text="Please insert the players and there strategy"></asp:Label>
        &nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Example: [[ &quot;Armando&quot;, &quot;P&quot; ], [ &quot;Dave&quot;, &quot;S&quot; ]]"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="P = Paper, R= Rock and S= Scissors"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="151px" Width="435px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Not enough?, try the tournament"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Play" Width="86px" OnClientClick = "return confirm('Are you sure you want to play?');"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:FileUpload ID="FileUpload1" runat="server" Width="273px" />
&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Upload" Width="68px" />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="The winner is "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
