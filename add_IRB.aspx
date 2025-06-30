

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>App A1 - Consent Form Input</title>
    <link href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css" rel="stylesheet" />
</head>
<body class="bg-gray-100 p-8">
    <form id="form1" runat="server" class="max-w-2xl mx-auto bg-white shadow-md rounded-lg p-8">
        <h2 class="text-2xl font-bold text-center text-indigo-700 mb-6">
            📝 Add informed consent form
        </h2>

        <div class="mb-6">
            <label class="block text-lg font-medium text-gray-700">ICF Title</label>
            <asp:TextBox ID="txtVersionDate" runat="server" CssClass="mt-1 block w-full border border-gray-300 rounded px-3 py-2" placeholder="Housing Modifications Household Informed Consent Form" />
        </div>

        <div class="mb-6">
    <label class="block text-sm font-medium text-gray-700">Version Date</label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="mt-1 block w-full border border-gray-300 rounded px-3 py-2" placeholder="e.g. 02-Sep-21" />
</div>

        <%-- IRB1 --%>
        <div class="mb-6">
            <h3 class="text-lg font-semibold text-gray-800 mb-2">IRB 1</h3>
            <div class="grid grid-cols-3 gap-4">
                <div>
                    <label>IRB Name</label>
                    <asp:TextBox ID="txtIRB1Name" runat="server" CssClass="w-full border rounded px-3 py-2" placeholder="e.g. CDC" />
                </div>
                <div>
                    <label>Submitted</label>
                    <asp:TextBox ID="txtIRB1Submitted" runat="server" CssClass="w-full border rounded px-3 py-2" />
                </div>
                <div>
                    <label>Approved</label>
                    <asp:TextBox ID="txtIRB1Approved" runat="server" CssClass="w-full border rounded px-3 py-2" />
                </div>
            </div>
        </div>

        <%-- IRB2 --%>
        <div class="mb-6">
            <h3 class="text-lg font-semibold text-gray-800 mb-2">IRB 2</h3>
            <div class="grid grid-cols-3 gap-4">
                <div>
                    <label>IRB Name</label>
                    <asp:TextBox ID="txtIRB2Name" runat="server" CssClass="w-full border rounded px-3 py-2" placeholder="e.g. LSHTM" />
                </div>
                <div>
                    <label>Submitted</label>
                    <asp:TextBox ID="txtIRB2Submitted" runat="server" CssClass="w-full border rounded px-3 py-2" />
                </div>
                <div>
                    <label>Approved</label>
                    <asp:TextBox ID="txtIRB2Approved" runat="server" CssClass="w-full border rounded px-3 py-2" />
                </div>
            </div>
        </div>

        <%-- IRB3 --%>
        <div class="mb-6">
            <h3 class="text-lg font-semibold text-gray-800 mb-2">IRB 3</h3>
            <div class="grid grid-cols-3 gap-4">
                <div>
                    <label>IRB Name</label>
                    <asp:TextBox ID="txtIRB3Name" runat="server" CssClass="w-full border rounded px-3 py-2" placeholder="e.g. SPHDREC" />
                </div>
                <div>
                    <label>Submitted</label>
                    <asp:TextBox ID="txtIRB3Submitted" runat="server" CssClass="w-full border rounded px-3 py-2" />
                </div>
                <div>
                    <label>Approved</label>
                    <asp:TextBox ID="txtIRB3Approved" runat="server" CssClass="w-full border rounded px-3 py-2" />
                </div>
            </div>
        </div>

        <div class="text-center mt-6">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit (Placeholder)" CssClass="bg-indigo-600 hover:bg-indigo-700 text-white font-bold py-2 px-6 rounded" />
        </div>
    </form>
</body>
</html>
