Imports System.Data.SqlClient
Imports System.Data
Partial Class add_new_regbody
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

        If IsPostBack = True Then
            GridView3.DataBind()
        End If

    End Sub


    Protected Sub ButtonAddProject_Click(sender As Object, e As EventArgs) Handles ButtonAddRegBody.Click
        Dim RegBodyName = TextBoxNewRegBody.Text.Trim()
        If RegBodyName.Length < 3 Then
            DisplayMessage("Please enter a longer name")
        ElseIf RegBodyExists(RegBodyName) = True Then
            DisplayMessage("This regulatory body already exists!")
        Else
            AddRegBody(RegBodyName)
            DisplayMessage(RegBodyName & " successfully added!")
            TextBoxNewRegBody.Text = ""
        End If
    End Sub


    Private Sub DisplayMessage(message As String)
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(message)
        sb.Append("')};")
        sb.Append("</script>")
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    End Sub

    Private Function RegBodyExists(RegBodyName As String) As Boolean
        RegBodyExists = False

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
        Dim strSQL As String = "SELECT regbody FROM regbodies where regbody = '" & RegBodyName & "'"

        Dim ds As New DataSet()
        Dim adapter As New SqlDataAdapter(strSQL, ConnectionString)
        adapter.Fill(ds)

        Dim dt As DataTable
        dt = ds.Tables(0)
        If dt.Rows.Count() > 0 Then
            RegBodyExists = True
        End If
    End Function


    Private Sub AddRegBody(RegBodyName As String)
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
        Dim strSQL As String = "INSERT INTO regbodies (regbody) VALUES ('" & RegBodyName & "')"
        Dim cmd As SqlDataAdapter = New SqlDataAdapter(strSQL, ConnectionString)
        Dim ds As DataSet = New DataSet()
        cmd.Fill(ds)
    End Sub

    Protected Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    End Sub
End Class

