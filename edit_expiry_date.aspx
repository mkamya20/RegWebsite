<%@ Page Language="VB" AutoEventWireup="false" CodeFile="edit_expiry_date.aspx.vb" Inherits="edit_expiry_date" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            height: 20px;
        }
        .auto-style7 {
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
                <td class="auto-style7" colspan="3">
                    <asp:Label ID="lblStudy" runat="server" 
                        Text="Label" style="font-weight: 700; " CssClass="auto-style2"></asp:Label></td>
                <td rowspan="4">
                    &nbsp;</td>
            </tr>
            
            
            <tr>
                <td class="auto-style1" colspan="3">
                    <asp:Label ID="lblRegBody" runat="server" Text="Label" 
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
                    Current Expiry Date:</td>
                <td colspan="2">
        <asp:Label ID="lblOld" runat="server" Text="Label" 
                        style="font-weight: 700; " CssClass="auto-style3"></asp:Label>
                </td>
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
                <td class="style8" rowspan="3">
                    <span class="auto-style3">Select New Date</span>--&gt;</td>
                <td class="auto-style5">
                    <strong>Year</strong></td>
                <td>
                    <asp:DropDownList ID="DropDownListExpDateYear" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td rowspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <strong>Month</strong></td>
                <td>
                    <asp:DropDownList ID="DropDownListExpDateMonth" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <strong>Day</strong></td>
                <td>
                    <asp:DropDownList ID="DropDownListExpDateDay" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label2" runat="server" 
                        Text="Select 'New expiry date' and click 'Accept Change'" CssClass="auto-style5"></asp:Label>
                </td>
                <td rowspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" class="auto-style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    New Expiry Date:</td>
                <td colspan="2">
                            <asp:Label ID="LabelNewDate" runat="server" Text="Label" 
                        style="font-weight: 700; " CssClass="auto-style3"></asp:Label>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;</td>
                <td colspan="2">
                            &nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Button ID="btnChange" runat="server" Text="Accept Change" Height="25px" 
                        Width="120px" OnClientClick="return confirm('Is all the information correct?');"/>
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
        <asp:SqlDataSource ID="NewStatus" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ProjectConnectionString %>" 
            SelectCommand="SELECT [expirystatus] FROM [expirystatus]">
        </asp:SqlDataSource>
        <br />
    </div>
    </form>
</body>
</html>
