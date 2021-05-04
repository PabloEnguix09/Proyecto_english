<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="treatment.aspx.cs" Inherits="HealthCare.treatment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="common_style.css" />
    <title>Add treatment</title>
</head>
<body>
    <header>
        <nav class="navbar">
            <a id="logo" href="home.aspx">
                <img src ="logo.png" alt="logo"/>
            </a>
            <ul class="navbar-links">
                <li>
                    <a href="home.aspx#about">About us</a>
                </li>
                <li>
                    <a href="home.aspx#contact">Contact us</a>
                </li>
                <li>
                    <a href="login.aspx">Logout</a>
                </li>
            </ul>
        </nav>
    </header>

    <form id="form1" runat="server">
        <div>
            <h1>Add treatment</h1>

            <div id="treatmentData">
                <input id="illness" runat="server" type="text" placeholder="Illness"/>
                <input id="record" runat="server" type="text" placeholder="Record" />
                <input id="date" runat="server" type="text" placeholder="Date" />
                <asp:Button id="treatmentButton" runat="server" OnClick="Button1_Click" Text="Add treatment" />
            </div>
        </div>
    </form>
            <footer class="noFullPage">
            <a id="logo" href="home.aspx">
                <img src ="logo.png" alt="logo"/>
            </a>
            <p id="copy">&copy; 2021 Copyright Grau Llopis HealthCare systems. All rights reserved</p>
    </footer>
</body>
</html>


