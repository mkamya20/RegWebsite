Imports System.Data.SqlClient
Imports System.Data

Partial Class ProtocolICFSubmission
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim fsp As Integer
        Dim fname As String

        fsp = InStrRev(Request.Path, "/")
        fname = Mid(Request.Path, fsp + 1, Len(Request.Path) - fsp)

        toptabs.InnerHtml = PublicFunctions.PopulateTopTabs(fname)
        navitabs.InnerHtml = PublicFunctions.PopulateNaviTabs(fname)

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
        Dim logon As String = Request.ServerVariables("LOGON_USER")
        Dim ip As String = Request.ServerVariables("remote_addr")
        Dim useragent As String = Request.ServerVariables("http_user_agent")
        Dim strSQL As String

        If Not IsPostBack Then
            ' Log page access
            strSQL = "INSERT INTO tblaccesslog (AccessTime, LogonID, PageAccessed, ipaddress, httpagent) " &
                     "VALUES (GetDate(), '" & logon & "', '" & fname & "', '" & ip & "', '" & useragent & "')"

            Dim cmdAL As SqlDataAdapter = New SqlDataAdapter(strSQL, ConnectionString)
            Dim dsAL As DataSet = New DataSet()
            cmdAL.Fill(dsAL)

            ' Example GridView binding (customize your query/table)
            BindGrid(ConnectionString)
        End If
    End Sub

    Private Sub BindGrid(ByVal ConnectionString As String)
        Dim strSQL As String = "SELECT project, regbody, expirydate FROM projectbodies ORDER BY expirydate"

        Dim sqlConnection As New SqlConnection(ConnectionString)
        Dim cmd As SqlDataAdapter = New SqlDataAdapter(strSQL, sqlConnection)
        Dim ds As New DataSet()

        cmd.Fill(ds)

        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()

        ds.Dispose()
        sqlConnection.Close()
    End Sub
End Class
