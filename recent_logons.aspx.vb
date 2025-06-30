Imports System.Data.SqlClient
Imports System.Data

Partial Class recent_logons
    Inherits System.Web.UI.Page

    Protected Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Dim fsp As Integer  'Forward slash Position in URL
        Dim fname As String 'file name

        fsp = InStrRev(Request.Path, "/")
        fname = Mid(Request.Path, fsp + 1, Len(Request.Path) - fsp) ' get the current page name

        toptabs.InnerHtml = PublicFunctions.PopulateTopTabs(fname)      'call function to populate top tabs
        navitabs.InnerHtml = PublicFunctions.PopulateNaviTabs(fname)    'call function to populate navigation tabs

        'add record to tblAccessLog
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

    End Sub
End Class
