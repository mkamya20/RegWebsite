<%@ Page Language="VB" AutoEventWireup="false" CodeFile="delete_email_in_project.aspx.vb" Inherits="delete_email_in_project" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="css/mind3.css" media="screen,projection" />
	<link rel="stylesheet" type="text/css" href="css/print.css" media="print" />
	<title>View queries</title>



    <style type="text/css">
        
        .style6
        {
            text-align: center;
            font-size: medium;
            font-weight: bold;
        }

        .style7
        {
            font-size: small;
            font-weight: bold;
        }
        .style8
        {
            font-size: small;
            font-weight: bold;
            color: #FF0000;
        }

        .auto-style1 {
            text-align: left;
        }
        .auto-style2 {
            font-size: large;
        }
        .auto-style3 {
            font-size: medium;
        }
        .auto-style4 {
            font-size: medium;
            font-weight: bold;
        }
        .auto-style5 {
            font-size: small;
        }

        .auto-style6 {
            text-align: left;
            font-size: medium;
            font-weight: bold;
        }

    </style>



</head>
<body>
    <form id="form1" runat="server">
    
 <div>
        <table>
            <tr>
                <td class="auto-style6" colspan="3">
                    <asp:Label ID="lblStudy" runat="server" 
                        Text="Label" style="font-weight: 700; " CssClass="auto-style2"></asp:Label></td>
                <td rowspan="4">
                    &nbsp;</td>
            </tr>
            
            
            <tr>
                <td class="auto-style1" colspan="3">
                    <asp:Label ID="lblEmailAddress" runat="server" Text="Label" 
                        style="text-align: right;" CssClass="auto-style3"></asp:Label></td>
            </tr>
            
            
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;</td>
                <td colspan="2" style="font-weight: 700">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td rowspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" 
                        Text="Click Delete to remove this Email Address from this project" CssClass="auto-style5"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Button ID="btnChange" runat="server" Text="Delete" Height="25px" 
                        Width="120px" OnClientClick="return confirm('Please confirm delete');"/>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Height="25px" Text="Cancel" 
                        Width="120px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
    </div>
    </form>
</body>
</html>