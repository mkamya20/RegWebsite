<%@ Page Language="VB" AutoEventWireup="false" CodeFile="add_email_to_project.aspx.vb" Inherits="add_email_to_project" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/mind3.css" media="screen,projection" />
    <link rel="stylesheet" type="text/css" href="css/print.css" media="print" />
    <title>Regulatory Website</title>

    <style type="text/css">
        .style2 {
            font-size: x-small;
        }

        .style3 {
            width: 100%;
        }

        .style4 {
            height: 16px;
        }

        .auto-style1 {
            width: 425px;
        }

        .auto-style2 {
            width: 64px;
        }

        .auto-style5 {
            width: 85%;
        }
        .auto-style6 {
            width: 386px;
        }
        .auto-style7 {
            width: 607px;
        }
        .auto-style8 {
            font-size: medium;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server">
        <div>
            <div id="toptabs" runat="server">
            </div>

            <div id="container">
                <div id="logo">
                    <p><span class="style1">Regulatory Website</span></p>
                </div>

                <div id="navitabs" runat="server">
                </div>

                <div id="desc">
                    <br />
                    <h3>&nbsp; Add Email address to Project</h3>
                </div>

                <div id="main">

                    <table class="auto-style5">
                        <tr>
                            <td class="auto-style6">
                                <strong>
                                <asp:Label ID="LabelProject" runat="server" CssClass="auto-style8" Text="Label"></asp:Label>
                                </strong>
                            </td>
                            <td class="auto-style7" colspan="2">
                                &nbsp;</td>
                            <td colspan="2" rowspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                <asp:Button ID="ButtonAddProject" runat="server" Text="Add Email Address to Project" CssClass="auto-style8" />
                            </td>
                            <td class="auto-style7" colspan="2">
                                <asp:DropDownList ID="DropDownListEmail" runat="server" CssClass="auto-style8">
                                </asp:DropDownList>
                                <span class="auto-style8">&lt;-- Select email address and click the button</span></td>
                        </tr>
                        <tr>
                            <td rowspan="20" class="auto-style1" colspan="2">
                                <br />
                                <br />
                                <asp:Button ID="Button1" runat="server" Text="Cancel" CssClass="auto-style8" />
                                <br />

                            </td>

                            <td rowspan="20" class="auto-style1" colspan="2">
                                &nbsp;</td>

                            <td rowspan="20" class="auto-style2">&nbsp;</td>
                        </tr>
                    </table>

                </div>

                <div id="footer">
                    <p>
                        <strong>Infectious Diseases Research Collaboration
                        </strong>
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>