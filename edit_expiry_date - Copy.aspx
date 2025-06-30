<%@ Page Language="VB" AutoEventWireup="false" CodeFile="edit_expiry_date - Copy.aspx.vb" Inherits="edit_expiry_date" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Regulatory Dates</title>
    <!-- Tailwind CDN -->
    <script src="https://cdn.tailwindcss.com"></script>
    <style>
        :root {
            --theme-color: #00016B;
        }
        .btn-theme {
            background-color: var(--theme-color);
        }
        .btn-theme:hover {
            background-color: #0000a0;
        }
        .text-theme {
            color: var(--theme-color);
        }
        .border-theme {
            border-color: var(--theme-color);
        }
    </style>
</head>
<body class="bg-teal-800 min-h-screen flex items-center justify-center">
    <form id="form1" runat="server" class="w-full max-w-xl bg-white shadow-xl rounded-2xl p-8">
        <h2 class="text-2xl font-bold text-theme mb-6">Edit Regulatory Dates</h2>

        <!-- Project ID -->
        <div class="mb-4">
            <label for="txtProjectID" class="block text-sm font-medium text-gray-700">Project ID</label>
            <asp:TextBox ID="txtProjectID" runat="server" CssClass="mt-1 w-full border rounded-md p-2 bg-gray-100" ReadOnly="True" />
        </div>

        <!-- Regulatory Body -->
        <div class="mb-4">
            <label for="txtRegBody" class="block text-sm font-medium text-gray-700">Regulatory Body</label>
            <asp:TextBox ID="txtRegBody" runat="server" CssClass="mt-1 w-full border rounded-md p-2 bg-gray-100" ReadOnly="True" />
        </div>

        <!-- Protocol Submission -->
        <div class="mb-4">
            <label for="txtProtocolSubmission" class="block text-sm font-medium text-gray-700">Protocol Submission</label>
            <asp:TextBox ID="txtProtocolSubmission" runat="server" CssClass="mt-1 w-full border rounded-md p-2" />
        </div>

        <!-- Protocol Submission Date -->
        <div class="mb-4">
            <label class="block text-sm font-medium text-gray-700">Protocol Submission Date</label>
            <div class="flex space-x-2 mt-1">
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Year</span>
                    <asp:DropDownList ID="ddlProtSubYear" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Month</span>
                    <asp:DropDownList ID="ddlProtSubMonth" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Day</span>
                    <asp:DropDownList ID="ddlProtSubDay" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
            </div>
        </div>

         <!-- Protocol Approval Date -->
        <div class="mb-4">
            <label class="block text-sm font-medium text-gray-700">Protocol Approval Date</label>
            <div class="flex space-x-2 mt-1">
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Year</span>
                    <asp:DropDownList ID="ddlProtAppYear" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Month</span>
                    <asp:DropDownList ID="ddlProtAppMonth" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Day</span>
                    <asp:DropDownList ID="ddlProtAppDay" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
            </div>
        </div>

        <!-- Informed Consent Form -->
        <div class="mb-4">
            <label for="txtICF" class="block text-sm font-medium text-gray-700">Informed Consent Form</label>
            <asp:TextBox ID="txtICF" runat="server" CssClass="mt-1 w-full border rounded-md p-2" />
        </div>

        <!-- ICF Submission Date -->
        <div class="mb-4">
            <label class="block text-sm font-medium text-gray-700">ICF Submission Date</label>
            <div class="flex space-x-2 mt-1">
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Year</span>
                    <asp:DropDownList ID="ddlICFSubYear" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Month</span>
                    <asp:DropDownList ID="ddlICFSubMonth" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Day</span>
                    <asp:DropDownList ID="ddlICFSubDay" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
            </div>
        </div>

        <!-- ICF Approval Date -->
        <div class="mb-4">
            <label class="block text-sm font-medium text-gray-700">ICF Approval Date</label>
            <div class="flex space-x-2 mt-1">
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Year</span>
                    <asp:DropDownList ID="ddlICFAppYear" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Month</span>
                    <asp:DropDownList ID="ddlICFAppMonth" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Day</span>
                    <asp:DropDownList ID="ddlICFAppDay" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
            </div>
        </div>

        <!-- Version Date -->
        <div class="mb-4">
            <label class="block text-sm font-medium text-gray-700">Version Date</label>
            <div class="flex space-x-2 mt-1">
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Year</span>
                    <asp:DropDownList ID="ddlVersionYear" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Month</span>
                    <asp:DropDownList ID="ddlVersionMonth" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
                <div class="w-1/3">
                    <span class="block text-xs text-gray-600 mb-1">Day</span>
                    <asp:DropDownList ID="ddlVersionDay" runat="server" CssClass="w-full border rounded-md p-2" />
                </div>
            </div>
        </div>

        <!-- Save Button -->
        <div class="mt-6">
            <asp:Button ID="btnSave" runat="server" Text="Save Changes"
                CssClass="w-full btn-theme text-white font-semibold py-2 px-4 rounded-lg shadow-md hover:shadow-lg transition duration-300 ease-in-out" OnClick="btnSave_Click" />
        </div>

        <!-- Message -->
        <div class="mt-4 text-center">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-red-600 font-semibold" />
        </div>
    </form>
</body>
</html>
