<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HealthCare.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="common_style.css" />
    <title>Log in</title>
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
                    <a href="login.aspx">Login</a>
                </li>
            </ul>
        </nav>
    </header>

    <form id="form1" runat="server">
        <div>
            <h1>Log in</h1>

            <div id="loginData">
                <input id="username" type="text" placeholder="Name, number..."/>
                <input id="pass" type="password" placeholder="Code"/>
                <button id="loginButton" class="button"> Log in</button>
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
