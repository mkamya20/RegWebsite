Imports System.Data.SqlClient
Imports System.Data


Partial Class view_modify_project_details
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

        Dim ProjectName As String

        If IsPostBack = True Then
            ProjectName = Request.Form("DropDownListProject")
        Else
            ProjectName = Request.QueryString("project")
            If ProjectName Is Nothing Then
                'DropDownListProject.SelectedIndex = 0
            Else
                DropDownListProject.SelectedValue = ProjectName
            End If
        End If

        LabelProject.Text = ProjectName

        'Dim ProjectName As String = Request.Form("DropDownListProject")


        Dim sqlConnection As New SqlConnection(ConnectionString)

        strSQL = "SELECT project as Project, regbody as [Regulatory Body], submissiondate as [Submission Deadline], expirydate as [IRB Expiry Date], expirystatus as [Status], 'EditExpiryDate' as [Edit Expiry Date], 'Delete' as [Delete] FROM projectbodies where project = '" & ProjectName & "' ORDER BY expirydate"

        Dim cmd As SqlDataAdapter = New SqlDataAdapter(strSQL, sqlConnection)
        Dim ds As DataSet = New DataSet()
        Dim dt As DataTable
        cmd = New SqlDataAdapter(strSQL, sqlConnection)
        cmd.Fill(ds)
        dt = ds.Tables(0)

        GridViewRegBodies.DataSource = dt
        GridViewRegBodies.DataBind()

        ds.Dispose()
        dt.Dispose()



        ds = New DataSet()
        'dt = New DataTable
        strSQL = "SELECT project as Project, emailaddress as [Email Address], 'Delete' as [Delete] FROM projectemails where project = '" & ProjectName & "' ORDER BY project"

        cmd = New SqlDataAdapter(strSQL, sqlConnection)
        cmd.Fill(ds)

        dt = ds.Tables(0)
        GridViewEmail.DataSource = dt
        GridViewEmail.DataBind()

        sqlConnection.Close()



    End Sub


    Protected Sub ButtonAddRegBody_Click(sender As Object, e As EventArgs) Handles ButtonAddRegBody.Click
        Dim url As String = "add_regbody_to_project.aspx?project=" & DropDownListProject.Text
        Response.Redirect(url)
    End Sub



    Protected Sub ButtonAddEmail_Click(sender As Object, e As EventArgs) Handles ButtonAddEmail.Click
        Dim url As String = "add_email_to_project.aspx?project=" & DropDownListProject.Text
        Response.Redirect(url)
    End Sub

    Private Sub GridViewRegBodies_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewRegBodies.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim SubDate As Date = e.Row.Cells(2).Text
            e.Row.Cells(2).Text = Format(SubDate, "dd/MM/yyyy")

            Dim ExpDate As Date = e.Row.Cells(3).Text
            e.Row.Cells(3).Text = Format(ExpDate, "dd/MM/yyyy")

            Dim link1 As HyperLink = New HyperLink With {
                .ImageUrl = "~/images/edit_date.png",
                .NavigateUrl = "edit_expiry_date.aspx?project=" & e.Row.Cells(0).Text & "&regbody=" & e.Row.Cells(1).Text & "&oldvalue=" & e.Row.Cells(3).Text
            }
            link1.Attributes.Add("onclick", "javascript:window.open('edit_expiry_date.aspx?project=" & e.Row.Cells(0).Text & "&regbody=" & e.Row.Cells(1).Text & "&oldvalue=" & e.Row.Cells(3).Text & "', 'DETAILS', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,location=0,width=600,height=500');return false;")
            e.Row.Cells(5).Controls.Add(link1)


            Dim link2 As HyperLink = New HyperLink With {
                .ImageUrl = "~/images/delete.png",
                .NavigateUrl = "delete_regbody_in_project.aspx?project=" & e.Row.Cells(0).Text & "&regbody=" & e.Row.Cells(1).Text
            }
            link2.Attributes.Add("onclick", "javascript:window.open('delete_regbody_in_project.aspx?project=" & e.Row.Cells(0).Text & "&regbody=" & e.Row.Cells(1).Text & "', 'DETAILS', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,location=0,width=600,height=300');return false;")
            e.Row.Cells(6).Controls.Add(link2)


        End If
    End Sub

    Private Sub GridViewEmail_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewEmail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim link2 As HyperLink = New HyperLink With {
                .ImageUrl = "~/images/delete.png",
                .NavigateUrl = "delete_email_in_project.aspx?project=" & e.Row.Cells(0).Text & "&emailaddress=" & e.Row.Cells(1).Text
            }
            link2.Attributes.Add("onclick", "javascript:window.open('delete_email_in_project.aspx?project=" & e.Row.Cells(0).Text & "&emailaddress=" & e.Row.Cells(1).Text & "', 'DETAILS', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,location=0,width=600,height=300');return false;")
            e.Row.Cells(2).Controls.Add(link2)
        End If
    End Sub
End Class
