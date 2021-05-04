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
<p>
                        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                        <asp:Label ID="lName" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="Label4" runat="server" Text="Birthdate"></asp:Label>
                        <asp:Label ID="lDate" runat="server" Text="Label"></asp:Label>
                    </p>
                                        <p>
                        <asp:Label ID="Label6" runat="server" Text="Gender"></asp:Label>
                        <asp:Label ID="lGender" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="Label8" runat="server" Text="DNI"></asp:Label>
                        <asp:Label ID="lDNI" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="Label3" runat="server" Text="SIP"></asp:Label>
                        <asp:Label ID="lSIP" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
                <div id="treatment">
                    
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="16px" Width="577px">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    
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