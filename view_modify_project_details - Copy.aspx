<%@ Page Language="VB" AutoEventWireup="false" CodeFile="view_modify_project_details - Copy.aspx.vb" Inherits="view_modify_project_details" %>

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

        .main-table {
    width: 100%;
    border-collapse: collapse;
    margin-top: 20px;
}

.project-label {
    font-size: 24px;
    font-weight: bold;
    color: #00016B;
    display: block;
    margin-bottom: 10px;
}

.section-title {
    font-size: 18px;
    font-weight: bold;
    margin-bottom: 10px;
}

.custom-button {
    background-color: #00016B;
    color: white;
    padding: 8px 16px;
    font-size: 16px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

.custom-button:hover {
    background-color: #0000A0;
}

.styled-gridview {
    width: 100%;
    margin-top: 20px;
    font-size: 14px;
    border-collapse: collapse;
}

.edit-button {
    background-color: #00016B; /* deep blue theme */
    color: white;
    border: none;
    padding: 6px 12px;
    font-size: 14px;
    border-radius: 4px;
    margin-left: 6px;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

.edit-button:hover {
    background-color: #0000A0; /* slightly lighter on hover */
}

.delete-button {
    background-color: #C0392B; /* deep red */
    color: white;
    border: none;
    padding: 6px 12px;
    font-size: 14px;
    border-radius: 4px;
    cursor: pointer;
    margin-left: 6px;
    transition: background-color 0.3s ease;
    margin-top: 3px;
}

.delete-button:hover {
    background-color: #E74C3C; /* lighter red on hover */
}


    .styled-gridview tr:hover {
        background-color: #dcdcff !important;
        transition: 0.2s;
    }



    .edit-button:hover, .delete-button:hover {
        background-color: #333399;
    }
</style>


    

</head>

<body class="">
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
    <table class="main-table">
        <tr>
            <td colspan="2">
                <asp:Label ID="LabelProject" runat="server" CssClass="project-label" Text="Label"></asp:Label>
            </td>
            <td></td>
            <td rowspan="2"></td>
            <td rowspan="2"></td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <div class="section-title">Submission Overview</div>
                <asp:Button ID="ButtonAddRegBody" runat="server" Text="Add New Reg Body to this Project" CssClass="custom-button" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
            <asp:GridView ID="GridViewRegBodies" runat="server" CssClass="styled-gridview"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
                CellPadding="2" GridLines="Both" AutoGenerateColumns="True">
        
                <HeaderStyle BackColor="#00016B" Font-Bold="True" ForeColor="White" Font-Size="14px" />
                <RowStyle BackColor="White" ForeColor="Black" Font-Size="13px" />
                <AlternatingRowStyle BackColor="#F0F0F5" ForeColor="Black" />
                <SelectedRowStyle BackColor="#00016B" ForeColor="White" Font-Bold="True" />
                <PagerStyle BackColor="#E0E0F8" ForeColor="Black" HorizontalAlign="Center" />
                <FooterStyle BackColor="#00016B" ForeColor="White" Font-Bold="True" />
            </asp:GridView>
        </td>

            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td></td>
            <td></td>
            <td></td>
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