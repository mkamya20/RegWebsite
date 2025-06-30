Imports System.Data.SqlClient
Imports System.Data
Partial Class add_email_to_project
    Inherits System.Web.UI.Page
    Protected Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Dim fsp As Integer  'Forward slash Position in URL
        Dim fname As String 'file name

        fsp = InStrRev(Request.Path, "/")
        fname = Mid(Request.Path, fsp + 1, Len(Request.Path) - fsp) ' get the current page name

        toptabs.InnerHtml = PublicFunctions.PopulateTopTabs(fname)      'call function to populate top tabs
        navitabs.InnerHtml = PublicFunctions.PopulateNaviTabs(fname)    'call function to populate navigation tabs

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
        Dim logon As String = Request.ServerVariables("LOGON_USER")
        Dim ip As String = Request.ServerVariables("remote_addr")
        Dim useragent As String = Request.ServerVariables("http_user_agent")
        Dim strSQL As String

        If IsPostBack = False Then
            'add to tblAccessLog
            strSQL = "INSERT INTO tblaccesslog (AccessTime, LogonID, PageAccessed, ipaddress, httpagent) " &
            "VALUES (GetDate(),'" & logon & "','" & fname & "','" & ip & "', '" & useragent & "')"

            Dim cmdAL As SqlDataAdapter = New SqlDataAdapter(strSQL, ConnectionString)
            Dim dsAL As DataSet = New DataSet()
            cmdAL.Fill(dsAL)
        End If

        Dim ProjectName As String = Request.QueryString("project")
        LabelProject.Text = "Adding email for project: " & ProjectName



        strSQL = "select emailaddress from emails where emailaddress not in (select emailaddress from projectemails where project = '" & ProjectName & "')"
        Dim ds As New DataSet()
        Dim adapter As New SqlDataAdapter(strSQL, ConnectionString)
        adapter.Fill(ds)
        Dim dt As DataTable
        dt = ds.Tables(0)
        For Each row As DataRow In dt.Rows
            DropDownListEmail.Items.Add(row.Item(0))
        Next row


    End Sub


    Protected Sub ButtonAddProject_Click(sender As Object, e As EventArgs) Handles ButtonAddProject.Click
        Dim ProjectName = Request.QueryString("project")

        If DropDownListEmail.Text <> "" Then


            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
            Dim strSQL As String = "INSERT INTO projectemails (project, emailaddress) VALUES ('" & ProjectName & "', '" & DropDownListEmail.Text & "')"
            Dim cmd As SqlDataAdapter = New SqlDataAdapter(strSQL, ConnectionString)
            Dim ds As DataSet = New DataSet()
            cmd.Fill(ds)
        End If


        Dim url As String = "view_modify_project_details.aspx?project=" & ProjectName
        Response.Redirect(url)
    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim url As String = "view_modify_project_details.aspx?project=" & Request.QueryString("project")
        Response.Redirect(url)
    End Sub
End Class
