<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="patient.aspx.cs" Inherits="HealthCare.patient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="common_style.css" />
    <title>Your medical history</title>
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
                    <a href="#">Ask for an appointment</a>
                </li>
                <li>
                    <a href="#">Logout</a>
                </li>
            </ul>
        </nav>
    </header>

    <form id="form1" runat="server">
        <div>
            <h1>Your medical history</h1>
            <div id="data">
                <div id="info">
                    <img src="def-user.png" alt="Your user photo"/>
                    <p>Datos </p>
                    <p>de la tabla </p>
                    <p>de pacientes</p>
                </div>
                <div id="treatment">
                    <p>Doctor</p>
                    <p>Enfermedad</p>
                    <p>Tratamiento</p>
                    <p>Síntomas para pedir cita</p>
                    <p>Si hay algo más, pues eso</p>
                </div>
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
