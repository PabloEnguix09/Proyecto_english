<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="HealthCare.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="common_style.css" />
    <title>Grau Llopis HealthCare</title>
</head>
<body>
    <header>
        <nav class="navbar">
            <a id="logo" href="home.aspx">
                <img src ="logo.png" alt="logo"/>
            </a>
            <ul class="navbar-links">
                <li>
                    <a href="#">About us</a>
                </li>
                <li>
                    <a href="#">Contact us</a>
                </li>
                <li>
                    <a href="login.aspx">Login</a>
                </li>
            </ul>
        </nav>
    </header>

    <form id="form1" runat="server">
        <div id="landingPage">
            <div class="brand">
                <img src ="logo.png" alt="logo"/>
                <h1>Grau Llopis HealthCare</h1>
            </div>
            <p>The Power to Heal</p>
            <button class="button">Start feeling good</button>
        </div>
    </form>

    <main>

    </main>

        <footer>
            <a id="logo" href="home.aspx">
                <img src ="logo.png" alt="logo"/>
            </a>
            <p id="copy">&copy; 2021 Copyright Grau Llopis HealthCare systems. All rights reserved</p>
    </footer>
</body>
</html>
