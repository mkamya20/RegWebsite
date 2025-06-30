<%@ Page Language="VB" AutoEventWireup="false" CodeFile="update_status.aspx.vb" Inherits="UpdateStatus" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>View Queries</title>
    <script src="https://cdn.tailwindcss.com"></script>
</head>
<body class="bg-gray-100 text-gray-800 font-sans">
    <form id="form1" runat="server">

        <div class="max-w-4xl mx-auto my-12 bg-white rounded-lg shadow-md p-8 space-y-6">
            
            <!-- Header / Title -->
            <div class="text-center">
                <asp:Label ID="lblStudy" runat="server" CssClass="text-2xl font-bold text-indigo-700"></asp:Label>
                <div class="mt-2 text-lg text-gray-600">
                    <asp:Label ID="lblRegBody" runat="server" CssClass="text-base"></asp:Label>
                </div>
            </div>

            <!-- Current Status -->
            <div class="border-t pt-6">
                <label class="block text-lg font-semibold mb-1 text-gray-700">Current Status:</label>
                <asp:Label ID="lblOld" runat="server" CssClass="text-base font-medium text-gray-800"></asp:Label>
            </div>

            <!-- New Status Selection -->
            <div class="pt-4">
                <label class="block text-red-600 text-sm font-semibold mb-2">New Status →</label>
                <asp:DropDownList ID="ddlNewStatus" runat="server" CssClass="w-full p-2 border border-gray-300 rounded-md shadow-sm focus:ring-indigo-500 focus:border-indigo-500 text-sm"
                    DataSourceID="NewStatus" DataTextField="expirystatus" DataValueField="expirystatus">
                </asp:DropDownList>
            </div>

            <!-- Instruction -->
            <div class="text-sm text-gray-500">
                <asp:Label ID="Label1" runat="server" Text="Select 'New status' and click 'Accept Change'"></asp:Label>
            </div>

            <!-- Buttons -->
            <div class="flex justify-start space-x-4 pt-2">
                <asp:Button ID="btnChange" runat="server" Text="Accept Change"
                    CssClass="bg-indigo-600 text-white px-4 py-2 rounded-md shadow hover:bg-indigo-700 transition"
                    OnClientClick="return confirm('Is all the information correct?');" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                    CssClass="bg-gray-300 text-gray-700 px-4 py-2 rounded-md hover:bg-gray-400 transition" />
            </div>

        </div>

        <!-- Script Manager & DataSource -->
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
        <asp:SqlDataSource ID="NewStatus" runat="server"
            ConnectionString="<%$ ConnectionStrings:ProjectConnectionString %>"
            SelectCommand="SELECT [expirystatus] FROM [expirystatus] WHERE [expirystatus] in ('Complete', 'Submitted')">
        </asp:SqlDataSource>

    </form>
</body>
</html>

