<%@ Page Language="VB" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Regulatory Website</title>

    <!-- Tailwind CSS CDN -->
    <script src="https://cdn.tailwindcss.com"></script>
    <script>
        tailwind.config = {
            theme: {
                extend: {
                    colors: {
                        primary: '#00016B',
                    }
                }
            }
        }
    </script>
<style>
.accordion-btn {
    background-color: #eee;
    border: none;
    padding: 5px 10px;
    font-size: 16px;
    cursor: pointer;
}

.accordion-panel-row {
    background-color: #f9f9f9;
}

.accordion-panel {
    padding: 10px;
    background-color: #ffffff;
    border-top: 1px solid #ccc;
    animation: slideDown 0.3s ease-out;
}

@keyframes slideDown {
    from { opacity: 0; transform: translateY(-5px); }
    to { opacity: 1; transform: translateY(0); }
}
</style>
<style>
.crud-btn {
    display: inline-block;
    margin: 5px 10px;
    padding: 4px 8px;
    background-color: #ccc;
    color: black;
    text-decoration: none;
    border-radius: 4px;
}

.crud-btn:hover {
    background-color: #0056b3;
}
</style>



<script>
    function toggleAccordion(button, rowIndex) {
        var grid = document.getElementById("GridView3");
        var currentRow = button.closest("tr");

        // Check if panel row already exists
        var nextRow = currentRow.nextElementSibling;
        if (nextRow && nextRow.classList.contains("accordion-panel-row")) {
            // Toggle visibility
            if (nextRow.style.display === "none") {
                nextRow.style.display = "table-row";
                button.textContent = "−";
            } else {
                nextRow.style.display = "none";
                button.textContent = "+";
            }
            return;
        }

        // Create new row
        var colCount = currentRow.cells.length;
        var newRow = grid.insertRow(currentRow.rowIndex + 1);
        newRow.className = "accordion-panel-row";

        var newCell = newRow.insertCell(0);
        newCell.colSpan = colCount;
        newCell.innerHTML = `
<div class="accordion-panel">

    <h2 style="text-align: center; font-weight: bold;">Protocol Submissions/Approvals</h2>
    <table border="1" cellpadding="5" style="border-collapse: collapse; width: 100%; margin-bottom: 10px;">
        <thead>
            <tr>
                <th>Version</th>
                <th>Version Date</th>
                <th>CDC Submitted</th>
                <th>LSHTM Submitted</th>
                <th>LSHTM Approved</th>
                <th>SPHDREC Submitted</th>
                <th>SPHDREC Approved</th>
                <th>UNCST Submitted</th>
                <th>UNCST Approved</th>
            </tr>
        </thead>
        <tbody>
            <tr><td>2.0</td><td>01-Sep-20</td><td>15-Sep-20</td><td>14-Sep-20</td><td>N/A</td><td>11-Sep-20</td><td>N/A</td><td>N/A</td><td>N/A</td></tr>
            <tr><td>2.0</td><td>26-Oct-20</td><td>16-Nov-20</td><td>19-Sep-20</td><td>27-Nov-20</td><td>27-Oct-20</td><td>29-Oct-20</td><td>16-Nov-20</td><td>18-Dec-20</td></tr>
            <tr><td>3.0</td><td>02-Sep-21</td><td>29-Nov-21</td><td>30-Nov-21</td><td>03-Dec-21</td><td>24-Sep-21</td><td>12-Nov-21</td><td>12-Dec-21</td><td>N/A</td></tr>
            <tr><td>4.0</td><td>04-Apr-22</td><td>24-Aug-22</td><td>10-May-22</td><td>06-Jun-22</td><td>06-May-22</td><td>28-May-22</td><td>02-Jun-22</td><td>N/A</td></tr>
        </tbody>
    </table>



    <h2 style="text-align: center; font-weight: bold;">Housing Modifications Household Informed Consent Form (App A1)</h2>
    <table border="1" cellpadding="5" style="border-collapse: collapse; width: 100%;">
        <thead>
            <tr>
                <th>Version Date</th>
                <th>LSHTM Submitted</th>
                <th>LSHTM Approved</th>
                <th>SPHDREC Submitted</th>
                <th>SPHDREC Approved</th>
                <th>UNCST Submitted</th>
                <th>UNCST Approved</th>
            </tr>
        </thead>
        <tbody>
            <tr><td>01-Sep-20</td><td>14-Sep-20</td><td>N/A</td><td>11-Sep-20</td><td>N/A</td><td>N/A</td><td>N/A</td></tr>
            <tr><td>26-Oct-20</td><td>19-Sep-20</td><td>27-Nov-20</td><td>27-Oct-20</td><td>29-Oct-20</td><td>16-Nov-20</td><td>18-Dec-20</td></tr>
            <tr><td>02-Sep-21</td><td>30-Nov-21</td><td>03-Dec-21</td><td>21-Sep-21</td><td>12-Nov-21</td><td>12-Dec-21</td><td>N/A</td></tr>
        </tbody>
    </table>

    <div style="text-align:center; margin-top: 15px;">
        <a href="add_IRB.aspx" class="crud-btn">Add</a>
        <a href="#" class="crud-btn">Edit</a>
        <a href="#" class="crud-btn">Delete</a>
    </div>
</div>
`;


        button.textContent = "−";
    }
</script>





</head>
<body class="bg-gray-500 font-sans text-gray-800">
    <form id="form1" runat="server">
        <div class="min-h-screen flex flex-col bg-gray-50">

    <!-- Top Tabs -->
    <div id="toptabs" runat="server" class="bg-primary text-white py-4 px-6 shadow-md">
        <div class="flex justify-between items-center max-w-7xl mx-auto">
            <span class="text-lg font-semibold tracking-wide">🔧 Admin Panel</span>
            <div class="space-x-4">

            </div>
        </div>
    </div>

    <!-- Page Container -->
    <div id="container" class="flex-grow container mx-auto p-6 bg-white rounded shadow-md mt-4">

        <!-- Logo -->
        <div id="logo" class="mb-8 text-center">
            <h1 class="text-4xl font-extrabold text-primary tracking-tight">🧾 Regulatory System</h1>
            <p class="text-gray-600 mt-1">Track your IRB approvals, submissions, and more.</p>
        </div>

        <!-- Navigation Tabs -->
        <div id="navitabs" runat="server" class="mb-2 flex justify-center">
            <!-- You can inject server-side nav here -->
            <div class="space-x-6">
                <a href="#" class="text-indigo-600 font-medium hover:underline">Overview</a>
                <a href="#" class="text-gray-600 hover:text-indigo-600 hover:underline">Protocols</a>
                <a href="#" class="text-gray-600 hover:text-indigo-600 hover:underline">ICFs</a>
                <a href="#" class="text-gray-600 hover:text-indigo-600 hover:underline">Reports</a>
            </div>
        </div>

        <!-- Description -->
        <div id="desc" class="mb-8 text-center">
            <h3 class="text-xl font-semibold text-gray-700">📄 Below is a summary of all projects and expiration dates</h3>
            <p class="text-sm text-gray-500 mt-1">Use the filters to narrow down by status or view specific project details.</p>
        </div>


                <!-- Main Content -->
                <div id="main" class="space-y-6">
                    <!-- Status Checkboxes -->
                    <div class="space-y-2">
                        <label class="block font-medium text-gray-900 text-xl">Status:</label>
                        <div class="flex flex-wrap gap-4">
                            <asp:CheckBox ID="CheckBoxComplete" runat="server" AutoPostBack="True" CssClass="form-checkbox text-indigo-600 text-lg ml-2 mr-2" Text="Complete" />
                            <asp:CheckBox ID="CheckBoxOK" runat="server" AutoPostBack="True" Checked="True" CssClass="form-checkbox text-green-600 text-lg ml-2 mr-2" Text="OK" />
                            <asp:CheckBox ID="CheckBoxNeedsAttention" runat="server" AutoPostBack="True" Checked="True" CssClass="form-checkbox text-yellow-600 text-lg ml-2 mr-2" Text="Needs Attention" />
                            <asp:CheckBox ID="CheckBoxCritical" runat="server" AutoPostBack="True" Checked="True" CssClass="form-checkbox text-red-600 text-lg ml-2 mr-2" Text="Critical" />
                            <asp:CheckBox ID="CheckBoxSubmitted" runat="server" AutoPostBack="True" Checked="True" CssClass="form-checkbox text-blue-600 text-lg ml-2 mr-2" Text="Submitted" />
                        </div>
                    </div>

                    <!-- Grid View Table -->
                    <div class="overflow-x-auto bg-gray-100 rounded-lg shadow-lg p-4">
                        <asp:GridView ID="GridView3" runat="server" ClientIDMode="Static"
                            AutoGenerateColumns="False" 
                            CssClass="min-w-full text-sm text-left text-gray-800"
                            GridLines="None" CellPadding="6" BorderStyle="None"
                            DataKeyNames="project,regbody">
                            <HeaderStyle CssClass="bg-primary text-white font-bold" />
                            <RowStyle CssClass="bg-white border-b hover:bg-gray-100 transition duration-200" />
                            <AlternatingRowStyle CssClass="bg-gray-50 border-b hover:bg-gray-100 transition duration-200" />
                            <SelectedRowStyle CssClass="bg-indigo-600 text-white font-bold" />


                            <Columns>
                                <asp:BoundField DataField="project" HeaderText="Project" ReadOnly="True" />
                                <asp:BoundField DataField="regbody" HeaderText="Reg Body" ReadOnly="True" />
                                <asp:BoundField DataField="submissiondate" HeaderText="Submission Deadline" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="expirydate" HeaderText="IRB Expiry Date" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="expirystatus" HeaderText="Status" />
                                <asp:BoundField DataField="changeexpdate" HeaderText="Change Expiry Date" ReadOnly="True" />
                                <asp:BoundField DataField="changestatus" HeaderText="Mark as Complete" ReadOnly="True" />

        
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <button type="button" class="accordion-btn" onclick="toggleAccordion(this, '<%# Container.DataItemIndex %>')">+</button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>





                        <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                            ConnectionString="<%$ ConnectionStrings:ProjectConnectionString %>"
                            SelectCommand="SELECT [project], [regbody], [expirydate], [expirystatus], 'Change Expiry Date' as changeexpdate, 'Mark as Complete' as changestatus FROM [projectbodies] WHERE expirystatus not in ('Complete') ORDER BY [expirydate]">
                        </asp:SqlDataSource>
                    </div>
                </div>

                <!-- Footer -->
                <div id="footer" class="text-center mt-10 text-gray-600 text-3xl border-t pt-4">
                    <strong>Infectious Diseases Research Collaboration</strong>
                </div>
            </div>
        </div>

        <!-- Back to Top Button -->
        <button id="backToTop" class="fixed bottom-6 right-6 bg-primary text-white p-3 rounded-full shadow-lg hover:bg-indigo-900 hidden">
            ↑
        </button>
    </form>

    
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        // Show/hide back to top
        $(window).scroll(function () {
            if ($(this).scrollTop() > 300) {
                $('#backToTop').fadeIn();
            } else {
                $('#backToTop').fadeOut();
            }
        });

        // Scroll to top
        $('#backToTop').click(function () {
            $('html, body').animate({ scrollTop: 0 }, 600);
            return false;
        });

        // Fade in main content
        $(document).ready(function () {
            $('#main').hide().fadeIn(700);
        });
    </script>
</body>
</html>
