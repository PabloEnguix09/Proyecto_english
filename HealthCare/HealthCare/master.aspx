<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="master.aspx.cs" Inherits="HealthCare.master" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="common_style.css" />
    <title>MasterPage</title>
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
            <h1>Page title</h1>
            <div id="data"></div>
        </div>
    </form>

        <footer>
            <a id="logo" href="home.aspx">
                <img src ="logo.png" alt="logo"/>
            </a>
            <p id="copy">&copy; 2021 Copyright Grau Llopis HealthCare systems. All rights reserved</p>
    </footer>
</body>
</html>
