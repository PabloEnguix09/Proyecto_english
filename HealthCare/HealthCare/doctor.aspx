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
                    <ul>
                        <li>
                            <a>Aquí</a>
                        </li>
                        <li>
                            <a>van</a>
                        </li>
                        <li>
                            <a>los nombres</a>
                        </li>
                        <li>
                            <a>de los</a>
                        </li>
                        <li>
                            <a>pacientes</a>
                        </li>
                        <li>
                            <a>que tiene</a>
                        </li>
                        <li>
                            <a>asignados</a>
                        </li>
                    </ul>
                </div>
                <div id="info">
                    <img src="def-user.png" alt="Patient photo"/>
                    <p>Datos </p>
                    <p>de la tabla </p>
                    <p>de pacientes</p>
                </div>
                <div id="treatment">
                    <p>Enfermedad</p>
                    <p>Tratamiento</p>
                    <p>Síntomas para pedir cita</p>
                    <p>Si hay algo más, pues eso</p>
                    <button class="button">Add treatment</button>
                    <br />
                    <button class="button">Export to JSON</button>
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
