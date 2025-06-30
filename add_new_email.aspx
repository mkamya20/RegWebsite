<%@ Page Language="VB" AutoEventWireup="false" CodeFile="add_new_email.aspx.vb" Inherits="add_new_email" %>

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
            width: 92%;
        }
        .auto-style6 {
            width: 135px;
        }
        .auto-style7 {
            width: 647px;
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
                    <h3>&nbsp; Add New Email address</h3>
                </div>

                <div id="main">

                    <table class="auto-style5">
                        <tr>
                            <td class="auto-style6">
                                <asp:Button ID="ButtonAddEmail" runat="server" Text="Add New Email Address" CssClass="auto-style8" />
                            </td>
                            <td class="auto-style7">
                                <asp:TextBox ID="TextBoxNewEmail" runat="server" Width="378px" CssClass="auto-style8"></asp:TextBox>
                                <span class="auto-style8">&lt;-- Enter new email address here</span></td>
                            <td colspan="2" rowspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                <asp:Button ID="ButtonRefresh" runat="server" Text="Refresh List" CssClass="auto-style8" />
                            </td>
                            <td class="auto-style7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td rowspan="20" class="auto-style1" colspan="3">
                                <br />

                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White"
                                    BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"
                                    DataKeyNames="emailaddress" DataSourceID="SqlDataSource2" CssClass="auto-style8">
                                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                    <Columns>
                                        <asp:BoundField DataField="emailaddress" HeaderText="Current Emails" ReadOnly="True" SortExpression="emailaddress" />
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#505050" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="#DCDCDC" />
                                </asp:GridView>


                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectConnectionString %>" SelectCommand="SELECT [emailaddress] FROM [emails] ORDER BY [emailaddress]"></asp:SqlDataSource>
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