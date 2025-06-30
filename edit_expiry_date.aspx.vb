Imports System.Data.SqlClient
Imports System.Data
Imports System.Globalization

Partial Class edit_expiry_date
    Inherits System.Web.UI.Page
    Private ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
    Private ReadOnly sqlConnection As New SqlConnection(ConnectionString)

    Private Project As String
    Private Regbody As String
    Private OldValue As String

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




            ' Set default expiry date to today's date
            LabelNewDate.Text = DateTime.Parse(Today()).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)


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


        Project = Request.QueryString("project")
        Regbody = Request.QueryString("regbody")
        OldValue = Request.QueryString("oldvalue")

        lblStudy.Text = "Project: " & Project
        lblOld.Text = OldValue
        lblRegBody.Text = "Regulatory Body: " & Regbody
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Write("<script language='javascript'> { window.close();}</script>")
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

        LabelNewDate.Text = DropDownListExpDateYear.Text & "-" & mnth & "-" & dy
    End Sub


    Protected Sub BtnChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChange.Click

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



        Dim strSQL As String = "update projectbodies set expirydate ='" & LabelNewDate.Text & "' where project = '" & Project & "'" & " and regbody = '" & Regbody & "'"

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

        'Update the status
        UpdateRegStatus()

        'reload main window and close this window
        Response.Write("<script language='javascript'> { window.opener.location.reload();}</script>")
        Response.Write("<script language='javascript'> { window.close();}</script>")

    End Sub




    Private Function ConvertDate(SelectedDate As String) As String
        Dim yr, mnth, dy As String

        yr = Microsoft.VisualBasic.Right(SelectedDate, 4)
        mnth = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(SelectedDate, 5), 2)
        dy = Microsoft.VisualBasic.Left(SelectedDate, 2)

        Return yr + "-" + mnth + "-" + dy
    End Function



    Private Sub UpdateRegStatus()

        Dim TimePeriod As Long = DateDiff(DateInterval.Day, Today(), Convert.ToDateTime(LabelNewDate.Text))
        Dim CurStatus As String = ""
        Dim NewStatus As String
        Dim strSQL As String

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString

        'Get current status
        strSQL = "SELECT expirystatus from projectbodies where project = '" & Project & "' and regbody = '" & Regbody & "'"
        Dim ds As New DataSet()
        Dim adapter As New SqlDataAdapter(strSQL, ConnectionString)
        adapter.Fill(ds)
        Dim dt As DataTable
        dt = ds.Tables(0)
        For Each row As DataRow In ds.Tables(0).Rows
            CurStatus = row.Item("expirystatus")
        Next



        Select Case TimePeriod
            Case <= 31
                If CurStatus = "Needs Attention" Then
                    NewStatus = "Critical"
                    strSQL = "UPDATE projectbodies set expirystatus = '" & NewStatus & "' where project = '" & Project & "'" & " and regbody = '" & Regbody & "'"
                End If
            Case <= 61
                If CurStatus = "OK" Then
                    NewStatus = "Needs Attention"
                    strSQL = "UPDATE projectbodies set expirystatus = '" & NewStatus & "' where project = '" & Project & "'" & " and regbody = '" & Regbody & "'"
                End If
            Case Else
                NewStatus = "OK"
                strSQL = "UPDATE projectbodies set expirystatus = '" & NewStatus & "', needsattentionsent = 0, criticalsent = 0 where project = '" & Project & "'" & " and regbody = '" & Regbody & "'"
        End Select


        Dim cmdAL As SqlDataAdapter = New SqlDataAdapter(strSQL, ConnectionString)
        Dim dsAL As DataSet = New DataSet()
        cmdAL.Fill(dsAL)

    End Sub


End Class
