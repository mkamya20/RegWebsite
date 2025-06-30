Imports System.Data.SqlClient
Imports System.Data

Partial Class [Default]
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

        Dim Complete As String = ""
        Dim OK As String = ""
        Dim Critical As String = ""
        Dim NeedsAttention As String = ""
        Dim Submitted As String = ""

        If CheckBoxComplete.Checked = True Then
            Complete = "Complete"
        End If

        If CheckBoxOK.Checked = True Then
            OK = "OK"
        End If

        If CheckBoxCritical.Checked = True Then
            Critical = "Critical"
        End If

        If CheckBoxNeedsAttention.Checked = True Then
            NeedsAttention = "Needs Attention"
        End If

        If CheckBoxSubmitted.Checked = True Then
            Submitted = "Submitted"
        End If


        strSQL = "SELECT [project], [regbody], [submissiondate], [expirydate], [expirystatus], 'Change Expiry Date' as changeexpdate, 'Mark as Complete' as changestatus FROM [projectbodies] WHERE expirystatus  in ('" & Complete & "', '" & OK & "', '" & Critical & "', '" & Submitted & "', '" & NeedsAttention & "') ORDER BY [expirydate]"

        Dim sqlConnection As New SqlConnection(ConnectionString)
        Dim cmd = New SqlDataAdapter(strSQL, sqlConnection)
        Dim ds As DataSet = New DataSet()
        Dim dt As DataTable
        cmd.Fill(ds)

        dt = ds.Tables(0)

        GridView3.DataSource = dt
        GridView3.DataBind()
        sqlConnection.Close()



    End Sub

    Protected Sub GridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim link1 As HyperLink = New HyperLink With {
                .ImageUrl = "~/images/edit_date.png",
                .NavigateUrl = "edit_expiry_date.aspx?project=" & e.Row.Cells(0).Text & "&regbody=" & e.Row.Cells(1).Text & "&oldvalue=" & e.Row.Cells(3).Text
            }
            link1.Attributes.Add("onclick", "javascript:window.open('edit_expiry_date.aspx?project=" & e.Row.Cells(0).Text & "&regbody=" & e.Row.Cells(1).Text & "&oldvalue=" & e.Row.Cells(3).Text & "', 'DETAILS', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,location=0,width=600,height=500');return false;")
            e.Row.Cells(5).Controls.Add(link1)


            Dim link2 As HyperLink = New HyperLink With {
                .ImageUrl = "~/images/change_status.png",
                .NavigateUrl = "update_status.aspx?project=" & e.Row.Cells(0).Text & "&regbody=" & e.Row.Cells(1).Text & "&oldvalue=" & e.Row.Cells(3).Text
            }
            link2.Attributes.Add("onclick", "javascript:window.open('update_status.aspx?project=" & e.Row.Cells(0).Text & "&regbody=" & e.Row.Cells(1).Text & "&oldvalue=" & e.Row.Cells(3).Text & "', 'DETAILS', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,location=0,width=600,height=300');return false;")
            e.Row.Cells(6).Controls.Add(link2)

        End If
    End Sub

    Protected Sub btnAddPS_Click(sender As Object, e As EventArgs)
        ' Retrieve the PS date from the TextBox
        Dim txtPSDate As TextBox = CType(FindControlRecursive(Me, "txtPSDate"), TextBox)
        Dim projectName As String = "YourProjectName" ' You can retrieve this from the context of the GridView row

        If txtPSDate IsNot Nothing Then
            Dim psDate As DateTime
            If DateTime.TryParse(txtPSDate.Text, psDate) Then
                ' Insert into the database using SqlDataSource or SqlCommand
                Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("ProjectConnectionString").ToString())
                    Dim cmd As New SqlCommand("INSERT INTO ProtocolSubmissions (project, versiondate) VALUES (@project, @versiondate)", conn)
                    cmd.Parameters.AddWithValue("@project", projectName)
                    cmd.Parameters.AddWithValue("@versiondate", psDate)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End If
        End If
    End Sub

    ' Helper method to find a control recursively
    Private Function FindControlRecursive(root As Control, id As String) As Control
        If root.ID = id Then
            Return root
        End If

        For Each child As Control In root.Controls
            Dim found As Control = FindControlRecursive(child, id)
            If found IsNot Nothing Then
                Return found
            End If
        Next

        Return Nothing
    End Function

    Protected Sub btnAddICF_Click(sender As Object, e As EventArgs)
        Dim txtICFDate As TextBox = CType(FindControlRecursive(Me, "txtICFDate"), TextBox)
        Dim projectName As String = "YourProjectName" ' Replace this dynamically later

        If txtICFDate IsNot Nothing Then
            Dim icfDate As DateTime
            If DateTime.TryParse(txtICFDate.Text, icfDate) Then
                Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("ProjectConnectionString").ToString())
                    Dim cmd As New SqlCommand("INSERT INTO InformedConsentForms (project, versiondate) VALUES (@project, @versiondate)", conn)
                    cmd.Parameters.AddWithValue("@project", projectName)
                    cmd.Parameters.AddWithValue("@versiondate", icfDate)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End If
        End If
    End Sub

    Protected Sub btnAddIRB_Click(sender As Object, e As EventArgs)
        Dim txtSubmitted As TextBox = CType(FindControlRecursive(Me, "txtIRBSubmitted"), TextBox)
        Dim txtApproved As TextBox = CType(FindControlRecursive(Me, "txtIRBApproved"), TextBox)
        Dim parentType As String = "PS" ' or "ICF", depending on context
        Dim parentId As Integer = 1 ' Replace with logic to identify PS_ID or ICF_ID

        If txtSubmitted IsNot Nothing AndAlso txtApproved IsNot Nothing Then
            Dim submittedDate As DateTime
            Dim approvedDate As DateTime

            If DateTime.TryParse(txtSubmitted.Text, submittedDate) AndAlso DateTime.TryParse(txtApproved.Text, approvedDate) Then
                Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("ProjectConnectionString").ToString())
                    Dim cmd As New SqlCommand("INSERT INTO IRBs (parenttype, parentid, submitteddate, approveddate) VALUES (@parenttype, @parentid, @submitteddate, @approveddate)", conn)
                    cmd.Parameters.AddWithValue("@parenttype", parentType)
                    cmd.Parameters.AddWithValue("@parentid", parentId)
                    cmd.Parameters.AddWithValue("@submitteddate", submittedDate)
                    cmd.Parameters.AddWithValue("@approveddate", approvedDate)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End If
        End If
    End Sub






End Class
