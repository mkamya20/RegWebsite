<%@ Page Language="VB" AutoEventWireup="false" CodeFile="view_modify_project_details.aspx.vb" Inherits="view_modify_project_details" %>

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

        .auto-style8 {
            font-size: large;
        }
        .auto-style9 {
            width: 437px;
            vertical-align: top;
        }
        .auto-style10 {
            width: 437px;
            font-size: medium;
        }
        .auto-style11 {
            width: 131px;
        }
        .auto-style12 {
            font-size: medium;
        }
        .auto-style13 {
            width: 209px;
            font-size: medium;
        }
        .auto-style14 {
            width: 209px;
            vertical-align: top;
        }
        .auto-style15 {
            font-size: x-large;
        }
        .auto-style16 {
            width: 538px;
            font-size: medium;
        }
        .auto-style17 {
            width: 538px;
            vertical-align: top;
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
                    <h3>&nbsp; Select Project</h3>
                    <p>
                        <asp:DropDownList ID="DropDownListProject" runat="server" AutoPostBack="True" CssClass="auto-style8" DataSourceID="SqlDataSource1" DataTextField="project" DataValueField="project">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectConnectionString %>" SelectCommand="SELECT [project] FROM [projects] ORDER BY [project]"></asp:SqlDataSource>
                    </p>
                </div>

                <div id="main">
                    <table class="style3">
                        <tr>
                            <td class="auto-style10" colspan="2"><strong>
                                <asp:Label ID="LabelProject" runat="server" CssClass="auto-style15" Text="Label"></asp:Label>
                                <br />
                                </strong></td>
                            <td class="auto-style10"><strong><br />
                                </strong></td>
                            <td class="auto-style11" rowspan="2">&nbsp;</td>
                            <td rowspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style10" colspan="2">&nbsp;</td>
                            <td class="auto-style10">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style16"><strong>Regulatory Body Information<br />
                                <br />
                                <asp:Button ID="ButtonAddRegBody" runat="server" Text="Add New Reg Body to this Project" Width="302px" CssClass="auto-style12" />
                                <br />
                                </strong></td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style10"><strong>Email Information<br />
                                <br />
                                <asp:Button ID="ButtonAddEmail" runat="server" Text="Add New Email to this Project" Width="230px" CssClass="auto-style12" />
                                </strong></td>
                            <td class="auto-style11">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style17">

                                <asp:GridView ID="GridViewRegBodies" runat="server" BackColor="White"
                                    BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" CssClass="auto-style12">
                                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#505050" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="#DCDCDC" />
                                </asp:GridView>


                                </td>
                            <td class="auto-style14">

                                &nbsp;</td>
                            <td class="auto-style9">
                                <asp:GridView ID="GridViewEmail" runat="server" BackColor="White"
                                    BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" CssClass="auto-style12">
                                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#505050" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="#DCDCDC" />
                                </asp:GridView>
                            </td>
                            <td class="auto-style11">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9" colspan="2">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9" colspan="2">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <br />

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