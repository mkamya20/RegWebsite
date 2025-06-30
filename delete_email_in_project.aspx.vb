Imports System.Data.SqlClient
Imports System.Data
Partial Class delete_email_in_project
    Inherits System.Web.UI.Page
    Private ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
    Private ReadOnly sqlConnection As New SqlConnection(ConnectionString)

    Private Project As String
    Private EmailAddress As String

    Protected Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Dim fsp As Integer  'Forward slash Position in URL
        Dim fname As String 'file name

        fsp = InStrRev(Request.Path, "/")
        fname = Mid(Request.Path, fsp + 1, Len(Request.Path) - fsp) ' get the current page name

        'add record to tblAccessLog
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


        Project = Request.QueryString("project")
        EmailAddress = Request.QueryString("emailaddress")

        lblStudy.Text = "Project: " & Project
        lblEmailAddress.Text = "Email Address: " & EmailAddress
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Write("<script language='javascript'> { window.close();}</script>")
    End Sub





    Protected Sub BtnChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChange.Click
        Dim strSQL As String

        strSQL = "delete from projectemails where project = '" & Project & "'" & " and emailaddress = '" & EmailAddress & "'"

        'update the data
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader

        cmd.CommandText = strSQL
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection

        sqlConnection.Open()
        reader = cmd.ExecuteReader()
        reader.Read()
        reader.Close()


        sqlConnection.Close()

        'reload main window and close this window
        Response.Write("<script language='javascript'> { window.opener.location.reload();}</script>")
        Response.Write("<script language='javascript'> { window.close();}</script>")

    End Sub
End Class
