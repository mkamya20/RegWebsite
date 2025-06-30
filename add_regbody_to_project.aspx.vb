Imports System.Data.SqlClient
Imports System.Data
Imports System.Globalization
Imports System.Windows.Forms

Partial Class add_regbody_to_project
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

        Dim ProjectName As String = Request.QueryString("project")
        LabelProject.Text = "Adding Regulatory Body for project: " & ProjectName

        If IsPostBack = False Then
            'add to tblAccessLog
            strSQL = "INSERT INTO tblaccesslog (AccessTime, LogonID, PageAccessed, ipaddress, httpagent) " &
            "VALUES (GetDate(),'" & logon & "','" & fname & "','" & ip & "', '" & useragent & "')"

            Dim cmdAL As SqlDataAdapter = New SqlDataAdapter(strSQL, ConnectionString)
            Dim dsAL As DataSet = New DataSet()
            cmdAL.Fill(dsAL)



            'Update Reg bodies list
            DropDownListRegBody.Items.Clear()

            strSQL = "select regbody from regbodies where regbody not in (select regbody from projectbodies where project = '" & ProjectName & "')"
            Dim ds As New DataSet()
            Dim adapter As New SqlDataAdapter(strSQL, ConnectionString)
            adapter.Fill(ds)
            Dim dt As DataTable
            dt = ds.Tables(0)
            For Each row As DataRow In dt.Rows
                DropDownListRegBody.Items.Add(row.Item(0))
            Next row


            ' Set default expiry date to today's date
            LabelExpDate.Text = DateTime.Parse(Today()).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)


            ' Expiry date year
            DropDownListExpDateYear.Items.Clear()
            Dim CurYear As Integer = Today().Year
            For i = CurYear - 1 To CurYear + 12
                DropDownListExpDateYear.Items.Add(New ListItem(i.ToString(), i.ToString()))
            Next
            DropDownListExpDateYear.Items.FindByText(CurYear).Selected = True


            ' Expiry date month
            DropDownListExpDateMonth.Items.Clear()
            For i = 1 To 12
                DropDownListExpDateMonth.Items.Add(New ListItem(i.ToString(), i.ToString()))
            Next
            DropDownListExpDateMonth.Items.FindByText(Today().Month).Selected = True

            ' Expiry date day
            DropDownListExpDateDay.Items.Clear()
            For i = 1 To 31
                DropDownListExpDateDay.Items.Add(New ListItem(i.ToString(), i.ToString()))
            Next
            DropDownListExpDateDay.Items.FindByText(Today().Day).Selected = True
        Else
            SetCalendarExpDate()
        End If




    End Sub

    Private Sub DropDownListExpDateYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListExpDateYear.SelectedIndexChanged
        SetCalendarExpDate()
    End Sub


    Sub SetCalendarExpDate()
        Dim mnth As String = DropDownListExpDateMonth.Text
        Dim dy As String = DropDownListExpDateDay.Text

        If Len(mnth) = 1 Then
            mnth = "0" & mnth
        End If

        If Len(dy) = 1 Then
            dy = "0" & dy
        End If

        LabelExpDate.Text = DropDownListExpDateYear.Text & "-" & mnth & "-" & dy
    End Sub




    Protected Sub ButtonAddProject_Click(sender As Object, e As EventArgs) Handles ButtonAddProject.Click
        If DropDownListRegBody.Text <> "" Then
            ' Check for valid date
            Select Case DropDownListExpDateMonth.Text
                Case Is = "4", "6", "9", "11"
                    If DropDownListExpDateDay.Text = "31" Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('The date you selected is not a valid date!');", True)
                        Exit Sub
                    End If
                Case Is = "2"
                    If CInt(DropDownListExpDateYear.Text) Mod 4 = 0 Then
                        If DropDownListExpDateDay.Text = "30" Or DropDownListExpDateDay.Text = "31" Then
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('The date you selected is not a valid date!');", True)
                            Exit Sub
                        End If
                    Else
                        If DropDownListExpDateDay.Text = "29" Or DropDownListExpDateDay.Text = "30" Or DropDownListExpDateDay.Text = "31" Then
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('The date you selected is not a valid date!');", True)
                            Exit Sub
                        End If
                    End If
            End Select

            Dim ExpDate As String = LabelExpDate.Text
            Dim SubDateDate As Date = DateAdd(DateInterval.Month, -2, CDate(ExpDate))
            Dim SubDateText As String = DateTime.Parse(SubDateDate).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)

            Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
            Dim strSQL As String = "INSERT INTO projectbodies (project, regbody, submissiondate, expirydate) VALUES ('" & Request.QueryString("project") & "', '" & DropDownListRegBody.SelectedValue & "', '" & SubDateText & "', '" & ExpDate & "')"
            Dim cmd As SqlDataAdapter = New SqlDataAdapter(strSQL, ConnectionString)
            Dim ds As DataSet = New DataSet()
            cmd.Fill(ds)

            'Update the status
            UpdateRegStatus()
        End If



        Dim url As String = "view_modify_project_details.aspx?project=" & Request.QueryString("project")
        Response.Redirect(url)
    End Sub

    Private Sub UpdateRegStatus()

        Dim TimePeriod As Long = DateDiff(DateInterval.Day, Today(), CDate(LabelExpDate.Text))
        Dim Status As String

        Select Case TimePeriod
            Case < 28
                Status = "Critical"
            Case < 56
                Status = "Needs Attention"
            Case Else
                Status = "OK"
        End Select

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
        Dim strSQL As String = "UPDATE projectbodies set expirystatus = '" & Status & "' where project = '" & Request.QueryString("project") & "' and regbody = '" & DropDownListRegBody.Text & "'"

        Dim cmdAL As SqlDataAdapter = New SqlDataAdapter(strSQL, ConnectionString)
        Dim dsAL As DataSet = New DataSet()
        cmdAL.Fill(dsAL)

    End Sub



    Protected Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Dim url As String = "view_modify_project_details.aspx?project=" & Request.QueryString("project")
        Response.Redirect(url)
    End Sub


End Class
