<%@ Page Language="VB" AutoEventWireup="false" CodeFile="add_regbody_to_project.aspx.vb" Inherits="add_regbody_to_project" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/mind3.css" media="screen,projection" />
    <link rel="stylesheet" type="text/css" href="css/print.css" media="print" />
    <title>Data Management Website</title>

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
            vertical-align: top;
        }
        .auto-style7 {
            width: 607px;
        }
        .auto-style8 {
            font-size: medium;
        }
        .auto-style9 {
            width: 607px;
            font-size: medium;
        }
        .auto-style10 {
            width: 386px;
        }
        .auto-style11 {
            width: 298px;
            font-size: medium;
        }
        .auto-style15 {
            width: 386px;
            vertical-align: top;
        }
        .auto-style17 {
            width: 607px;
        }
        .auto-style18 {
            width: 352px;
            font-size: medium;
        }
        .auto-style19 {
            width: 352px;
        }
        .auto-style20 {
            width: 298px;
        }
        .auto-style24 {
            width: 85px;
            font-size: medium;
        }
        .auto-style27 {
            width: 85px;
            font-size: medium;
        }
        .auto-style28 {
            width: 298px;
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
                    <h3>&nbsp; Add Regulatory Body to Project</h3>
                </div>

                <div id="main">

                    <table class="auto-style5">
                        <tr>
                            <td class="auto-style6" rowspan="2">
                                <strong>
                                <asp:Label ID="LabelProject" runat="server" CssClass="auto-style8" Text="Label"></asp:Label>
                                </strong>
                            </td>
                            <td class="auto-style7" colspan="4">
                                &nbsp;</td>
                            <td colspan="2" rowspan="7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style7" colspan="4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                <asp:Button ID="ButtonAddProject" runat="server" Text="Add Regulatory Body to Project" CssClass="auto-style8" />
                            </td>
                            <td class="auto-style7" colspan="4">
                                <asp:DropDownList ID="DropDownListRegBody" runat="server" CssClass="auto-style8">
                                </asp:DropDownList>
                                <span class="auto-style8">&lt;-- Select regulatory body and expiry date and click the button</span></td>
                        </tr>


                        <tr>
                            <td class="auto-style10">
                            </td>
                            <td class="auto-style11" colspan="2">
                                <strong>Expiry Date:
                                <asp:Label ID="LabelExpDate" runat="server" Text="LabelExpDate"></asp:Label>
                                </strong>
                            </td>
                            <td class="auto-style18">
                                &nbsp;</td>
                            <td class="auto-style9">

                    <table class="auto-style5">


                        <tr>
                            <td class="auto-style9">
                                &nbsp;</td>
                        </tr>



                    </table>

                            </td>
                        </tr>



                        <tr>
                            <td class="auto-style15" rowspan="3">
                                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="auto-style8" />
                            </td>
                            <td class="auto-style24">
                                <strong>Year</strong></td>


                            <td class="auto-style20">
                                                <asp:DropDownList ID="DropDownListExpDateYear" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                            </td>


                            <td class="auto-style19" rowspan="3">
                                </td>


                            <td class="auto-style17" rowspan="3">
                                &nbsp;</td>

                        </tr>



                        <tr>
                            <td class="auto-style27">
                                <strong>Month</strong></td>


                            <td class="auto-style28">
                                                <asp:DropDownList ID="DropDownListExpDateMonth" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                            </td>


                        </tr>



                        <tr>
                            <td class="auto-style27">
                                <strong>Day</strong></td>


                            <td class="auto-style28">
                                                <asp:DropDownList ID="DropDownListExpDateDay" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                            </td>


                        </tr>



                        <tr>
                            <td rowspan="20" class="auto-style1" colspan="6">
                                <br />

                                <br />
                                <br />
                                <br />

                                <br />

                            </td>

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