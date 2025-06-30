<%@ Page Language="VB" AutoEventWireup="false" CodeFile="delete_regbody_in_project.aspx.vb" Inherits="delete_regbody_in_project" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="css/mind3.css" media="screen,projection" />
	<link rel="stylesheet" type="text/css" href="css/print.css" media="print" />
	<title>View queries</title>



    <style type="text/css">
        


        body {
    font-family: Segoe UI, Tahoma, Geneva, Verdana, sans-serif;
    background-color: #f7f9fc;
    margin: 0;
    padding: 0;
}

table {
    margin: 80px auto;
    padding: 20px 30px;
    border: 1px solid #ccc;
    border-radius: 8px;
    background-color: #ffffff;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
}

.auto-style6, .auto-style2 {
    font-size: 20px;
    font-weight: bold;
    color: #2c3e50;
    padding-bottom: 10px;
}

.auto-style3 {
    font-size: 16px;
    font-weight: normal;
    color: #555;
}

.auto-style5 {
    font-size: 14px;
    color: #444;
}

.style8 {
    color: #c0392b;
    font-size: 14px;
    font-weight: bold;
}

asp\:Button {
    margin: 10px 8px 0 0;
}

#btnChange {
    background-color: #c0392b;
    color: #fff;
    border: none;
    padding: 8px 18px;
    font-size: 15px;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

#btnChange:hover {
    background-color: #e74c3c;
}

#btnCancel {
    background-color: #7f8c8d;
    color: #fff;
    border: none;
    padding: 8px 18px;
    font-size: 15px;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

#btnCancel:hover {
    background-color: #95a5a6;
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
                        Text="Click Delete to remove this Regulatory Body from this project" CssClass="auto-style5"></asp:Label>
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
