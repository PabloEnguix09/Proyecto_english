<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doctor.aspx.cs" Inherits="HealthCare.doctor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="common_style.css" />
    <title>Your patients</title>
</head>
<body>
    <header>
        <nav class="navbar">
            <a id="logo" href="home.aspx">
                <img src ="logo.png" alt="logo"/>
            </a>
            <ul class="navbar-links">
                <li>
                    <a href="#">My personal data</a>
                </li>
                <li>
                    <a href="#">My treatments</a>
                </li>
                <li>
                    <a href="#">My patients</a>
                </li>
                <li>
                    <a href="#">My schedule</a>
                </li>
                <li>
                    <a href="#">Logout</a>
                </li>
            </ul>
        </nav>
    </header>

    <form id="form1" runat="server">
        <div>
            <h1>Your patients</h1>
            <div id="data">
                <div id ="list">
                    <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="200px"></asp:ListBox>
                    <asp:Button class="button" ID="Button1" runat="server" OnClick="Button1_Click" Text="Select" />
                </div>
                <div id="info">
                    <img src="def-user.png" alt="Patient photo"/>&nbsp;<p>
                        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                        <asp:Label ID="lName" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="Label4" runat="server" Text="Birthdate"></asp:Label>
                        <asp:Label ID="lDate" runat="server"></asp:Label>
                    </p>
                                        <p>
                        <asp:Label ID="Label6" runat="server" Text="Gender"></asp:Label>
                        <asp:Label ID="lGender" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="Label8" runat="server" Text="DNI"></asp:Label>
                        <asp:Label ID="lDNI" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="Label3" runat="server" Text="SIP"></asp:Label>
                        <asp:Label ID="lSIP" runat="server"></asp:Label>
                    </p>
                </div>
                <div id="treatment">
                    <asp:Button class="button" ID="Button2" runat="server" OnClick="Button2_Click" Text="Details" />
                    <asp:button class="button" runat="server" OnClick="Unnamed1_Click" Text="Add a treatment"></asp:button>
                    <asp:ListBox ID="ListBox2" runat="server" Height="186px" Width="300px"></asp:ListBox>
                    <asp:TextBox ID="TextBox1" runat="server" Height="121px" ReadOnly="True" TextMode="MultiLine" Width="300px"></asp:TextBox>
                    <br />
                    <button class="button">Export to JSON</button>
                </div>
            </div>
        </div>

    <footer class="noFullPage">
            <a id="logo" href="home.aspx">
                <img src ="logo.png" alt="logo"/>
            </a>
            <p id="copy">&copy; 2021 Copyright Grau Llopis HealthCare systems. All rights reserved</p>
    </footer>
    </form>

    </body>
</html>
