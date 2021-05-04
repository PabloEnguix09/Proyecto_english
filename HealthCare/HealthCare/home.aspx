<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="HealthCare.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="bootstrap.min.css" />
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
                    <a href="#about">About us</a>
                </li>
                <li>
                    <a href="#contact">Contact us</a>
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

    <main id="about">
        <h2>About us</h2>
            <div>
                <p>
                    Grau Llopis HealthCare was born in 1937 in Gandia, and we've been expanding around Spain. We have professionals from very different branches, 
                such as anatomy, embryology, endocrinology, gynecology, surgery, internal medicine and dermatology. Here, we will give you the best possible treatment for you
                and your loved ones. We put users first when creating and transforming our content. We take an agile, iterative approach, starting with identifying the user needs.
                We test our ideas with users, and use the feedback we receive to learn and improve. We're continuously improving the website to help and empower people to 
                engage with their own health, care and wellbeing, and that of the people they care for.
                </p>
                <p>
                    We are continually listening to feedback from our patients and public and we act as a learning organisation, using these experiences to inform how we develop. 
                    We are committed to improvement through learning.
                </p>
            </div>
    </main>

    <div id="contact">
        <h2>Contact us</h2>
        <div id="phone">
            <img src="phone.png" alt="phone"/>
            <p>+34 888 88 88 88</p>
        </div>
        <div id="email">
            <img src="email.png" alt="email"/>
            <p>info@healthcare.com</p>
        </div>
        <div id="location">
            <img src="marker.png" alt="location"/>
            <p>Paranimf St., 1, Building H, 46730, Grau de Gandia, Valencia</p>
        </div>
    </div>

        <footer>
            <a id="logo" href="home.aspx">
                <img src ="logo.png" alt="logo"/>
            </a>
            <p id="copy">&copy; 2021 Copyright Grau Llopis HealthCare systems. All rights reserved</p>
    </footer>
</body>
</html>
