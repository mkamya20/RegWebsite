<%@ Page Language="VB" AutoEventWireup="false" CodeFile="recent_logons.aspx.vb" Inherits="recent_logons" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="css/mind3.css" media="screen,projection" />
	<link rel="stylesheet" type="text/css" href="css/print.css" media="print" />
	<title>Recent Logons</title>

    </head>

<body>
    <form id="form1" runat="server">
    
        <div id="toptabs" runat="server">
        </div>

        <div id="container">
	        <div id="logo">
		        <p><span class="style1">Regulatory Website</span></p>
	        </div>

	        <div id="navitabs" runat="server">
	        </div>
	        
	        <div id="desc"><br />
	        
	        <p>Most recent logons</p>
	        
	        </div>
	        
	        <div id="main">
	        
	            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical">
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="Access Time" HeaderText="Access Time" 
                            SortExpression="Access Time" />
                        <asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login" />
                        <asp:BoundField DataField="Page Name" HeaderText="Page Name" 
                            SortExpression="Page Name" />
                        <asp:BoundField DataField="IP address" HeaderText="IP address" 
                            SortExpression="IP address" />
                        <asp:BoundField DataField="Browser" HeaderText="Browser" 
                            SortExpression="Browser" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#505050" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ProjectConnectionString %>" 
                    
                    
                    SelectCommand="SELECT top 1000 [AccessTime] as [Access Time], [LogonID] as [Login], [PageAccessed] as [Page Name], [ipaddress] as [IP address], [httpagent] as [Browser] FROM [tblAccessLog] order by recordid desc"></asp:SqlDataSource>
                <br />
	        
	        </div>
	        
	        
	        
	        
	        <div id="footer">
                <p><strong>Infectious Diseases Research Collaboration
                </strong></p>
            </div>
            
            
	        
	        
        
    </div>
    </form>
</body>
</html>
