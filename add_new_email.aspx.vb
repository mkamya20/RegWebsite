Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Data

Partial Class add_new_email
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


    Protected Sub ButtonAddProject_Click(sender As Object, e As EventArgs) Handles ButtonAddEmail.Click
        Dim EmailAddress = TextBoxNewEmail.Text.Trim()

        If IsValidEmail(EmailAddress) = False Then
            DisplayMessage("That is an invalid email address!")
        ElseIf EmailExists(EmailAddress) = True Then
            DisplayMessage("This email address already exists in the system!")
        Else
            AddEmail(EmailAddress)
            DisplayMessage(EmailAddress & " successfully added!")
            TextBoxNewEmail.Text = ""
        End If
    End Sub

    Private Function IsValidEmail(email As String) As Boolean

        If String.IsNullOrWhiteSpace(email) Then Return False
        ' Use IdnMapping class to convert Unicode domain names.
        Try
            'Examines the domain part of the email and normalizes it.
            Dim DomainMapper =
                Function(match As Match) As String
                    'Use IdnMapping class to convert Unicode domain names.
                    Dim idn = New IdnMapping

                    'Pull out and process domain name (throws ArgumentException on invalid)
                    Dim domainName As String = idn.GetAscii(match.Groups(2).Value)

                    Return match.Groups(1).Value & domainName
                End Function

            'Normalize the domain
            email = Regex.Replace(email, "(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200))

        Catch e As RegexMatchTimeoutException
            Return False

        Catch e As ArgumentException
            Return False

        End Try

        Try
            Return Regex.IsMatch(email,
                                 "^[^@\s]+@[^@\s]+\.[^@\s]+$",
                                 RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))

        Catch e As RegexMatchTimeoutException
            Return False

        End Try

    End Function

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

    Private Function EmailExists(EmailAddress As String) As Boolean
        EmailExists = False

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
        Dim strSQL As String = "SELECT emailaddress FROM emails where emailaddress = '" & EmailAddress & "'"

        Dim ds As New DataSet()
        Dim adapter As New SqlDataAdapter(strSQL, ConnectionString)
        adapter.Fill(ds)

        Dim dt As DataTable
        dt = ds.Tables(0)
        If dt.Rows.Count() > 0 Then
            EmailExists = True
        End If
    End Function


    Private Sub AddEmail(EmailAddress As String)
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
        Dim strSQL As String = "INSERT INTO emails (emailaddress) VALUES ('" & EmailAddress & "')"
        Dim cmd As SqlDataAdapter = New SqlDataAdapter(strSQL, ConnectionString)
        Dim ds As DataSet = New DataSet()
        cmd.Fill(ds)
    End Sub

    Protected Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    End Sub



End Class
