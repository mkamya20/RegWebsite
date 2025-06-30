Imports System.Data.SqlClient
Imports System.Data
Imports System.Globalization



Partial Class edit_expiry_date
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulateDateDropdowns()
            LoadExistingData()
        End If
    End Sub

    Private Sub LoadExistingData()
        Dim projectID As String = Request.QueryString("project")
        Dim regBody As String = Request.QueryString("regbody")

        txtProjectID.Text = projectID
        txtRegBody.Text = regBody

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
        Dim query As String = "SELECT * FROM projectbodies WHERE project = @ProjectID AND regbody = @RegBody"

        Using con As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ProjectID", projectID)
                cmd.Parameters.AddWithValue("@RegBody", regBody)
                con.Open()

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Fill textboxes
                        txtProtocolSubmission.Text = reader("ProtocolTitle").ToString()
                        txtICF.Text = reader("ICFTitle").ToString()

                        ' Fill PS_SubmissionDate
                        If Not IsDBNull(reader("PS_SubmissionDate")) Then
                            Dim dateVal As Date = Convert.ToDateTime(reader("PS_SubmissionDate"))
                            ddlProtSubYear.SelectedValue = dateVal.Year.ToString()
                            ddlProtSubMonth.SelectedValue = dateVal.Month.ToString()
                            ddlProtSubDay.SelectedValue = dateVal.Day.ToString()
                        End If

                        ' Fill PS_ApprovalDate
                        If Not IsDBNull(reader("PS_ApprovalDate")) Then
                            Dim dateVal As Date = Convert.ToDateTime(reader("PS_ApprovalDate"))
                            ddlProtAppYear.SelectedValue = dateVal.Year.ToString()
                            ddlProtAppMonth.SelectedValue = dateVal.Month.ToString()
                            ddlProtAppDay.SelectedValue = dateVal.Day.ToString()
                        End If

                        ' Fill ICF_SubmissionDate
                        If Not IsDBNull(reader("ICF_SubmissionDate")) Then
                            Dim dateVal As Date = Convert.ToDateTime(reader("ICF_SubmissionDate"))
                            ddlICFSubYear.SelectedValue = dateVal.Year.ToString()
                            ddlICFSubMonth.SelectedValue = dateVal.Month.ToString()
                            ddlICFSubDay.SelectedValue = dateVal.Day.ToString()
                        End If

                        ' Fill ICF_ApprovalDate
                        If Not IsDBNull(reader("ICF_ApprovalDate")) Then
                            Dim dateVal As Date = Convert.ToDateTime(reader("ICF_ApprovalDate"))
                            ddlICFAppYear.SelectedValue = dateVal.Year.ToString()
                            ddlICFAppMonth.SelectedValue = dateVal.Month.ToString()
                            ddlICFAppDay.SelectedValue = dateVal.Day.ToString()
                        End If

                        If Not IsDBNull(reader("VersionDate")) Then
                            Dim dateVal As Date = Convert.ToDateTime(reader("VersionDate"))
                            ddlVersionYear.SelectedValue = dateVal.Year.ToString()
                            ddlVersionMonth.SelectedValue = dateVal.Month.ToString()
                            ddlVersionDay.SelectedValue = dateVal.Day.ToString()
                        End If
                    End If
                End Using
            End Using
        End Using
    End Sub


    Private Sub PopulateDateDropdowns()
        For year As Integer = 2000 To DateTime.Now.Year + 10
            ddlProtSubYear.Items.Add(year.ToString())
            ddlProtAppYear.Items.Add(year.ToString())
            ddlICFSubYear.Items.Add(year.ToString())
            ddlICFAppYear.Items.Add(year.ToString())
            ddlVersionYear.Items.Add(year.ToString())
        Next

        For month As Integer = 1 To 12
            ddlProtSubMonth.Items.Add(month.ToString())
            ddlProtAppMonth.Items.Add(month.ToString)
            ddlICFSubMonth.Items.Add(month.ToString())
            ddlICFAppMonth.Items.Add(month.ToString())
            ddlVersionMonth.Items.Add(month.ToString())
        Next

        For day As Integer = 1 To 31
            ddlProtSubDay.Items.Add(day.ToString())
            ddlProtAppDay.Items.Add(day.ToString)
            ddlICFSubDay.Items.Add(day.ToString())
            ddlICFAppDay.Items.Add(day.ToString())
            ddlVersionDay.Items.Add(day.ToString())
        Next
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim projectID As String = txtProjectID.Text
        Dim regBody As String = txtRegBody.Text

        Dim fields As New List(Of String)()
        Dim parameters As New List(Of SqlParameter)()

        If Not String.IsNullOrWhiteSpace(txtProtocolSubmission.Text) Then
            fields.Add("ProtocolTitle = @ProtocolTitle")
            parameters.Add(New SqlParameter("@ProtocolTitle", txtProtocolSubmission.Text))
        End If

        If ddlProtSubYear.SelectedIndex > -1 AndAlso ddlProtSubMonth.SelectedIndex > -1 AndAlso ddlProtSubDay.SelectedIndex > -1 Then
            Dim psDate As String = ddlProtSubYear.SelectedValue & "-" & ddlProtSubMonth.SelectedValue.PadLeft(2, "0"c) & "-" & ddlProtSubDay.SelectedValue.PadLeft(2, "0"c)
            fields.Add("PS_SubmissionDate = @PS_SubmissionDate")
            parameters.Add(New SqlParameter("@PS_SubmissionDate", psDate))
        End If

        If ddlProtAppYear.SelectedIndex > -1 AndAlso ddlProtAppMonth.SelectedIndex > -1 AndAlso ddlProtAppDay.SelectedIndex > -1 Then
            Dim psAppDate As String = ddlProtAppYear.SelectedValue & "-" & ddlProtAppMonth.SelectedValue.PadLeft(2, "0"c) & "-" & ddlProtAppDay.SelectedValue.PadLeft(2, "0"c)
            fields.Add("PS_ApprovalDate = @PS_ApprovalDate")
            parameters.Add(New SqlParameter("@PS_ApprovalDate", psAppDate))
        End If

        If ddlICFAppYear.SelectedIndex > -1 AndAlso ddlICFAppMonth.SelectedIndex > -1 AndAlso ddlICFAppDay.SelectedIndex > -1 Then
            Dim icfAppDate As String = ddlICFAppYear.SelectedValue & "-" & ddlICFAppMonth.SelectedValue.PadLeft(2, "0"c) & "-" & ddlICFAppDay.SelectedValue.PadLeft(2, "0"c)
            fields.Add("ICF_ApprovalDate = @ICF_ApprovalDate")
            parameters.Add(New SqlParameter("@ICF_ApprovalDate", icfAppDate))
        End If

        If Not String.IsNullOrWhiteSpace(txtICF.Text) Then
            fields.Add("ICFTitle = @ICFTitle")
            parameters.Add(New SqlParameter("@ICFTitle", txtICF.Text))
        End If

        If ddlICFSubYear.SelectedIndex > -1 AndAlso ddlICFSubMonth.SelectedIndex > -1 AndAlso ddlICFSubDay.SelectedIndex > -1 Then
            Dim icfSubDate As String = ddlICFSubYear.SelectedValue & "-" & ddlICFSubMonth.SelectedValue.PadLeft(2, "0"c) & "-" & ddlICFSubDay.SelectedValue.PadLeft(2, "0"c)
            fields.Add("ICF_SubmissionDate = @ICF_SubmissionDate")
            parameters.Add(New SqlParameter("@ICF_SubmissionDate", icfSubDate))
        End If

        If ddlICFAppYear.SelectedIndex > -1 AndAlso ddlICFAppMonth.SelectedIndex > -1 AndAlso ddlICFAppDay.SelectedIndex > -1 Then
            Dim icfAppDate As String = ddlICFAppYear.SelectedValue & "-" & ddlICFAppMonth.SelectedValue.PadLeft(2, "0"c) & "-" & ddlICFAppDay.SelectedValue.PadLeft(2, "0"c)
            fields.Add("ICF_ApprovalDate = @ICF_ApprovalDate")
            parameters.Add(New SqlParameter("@ICF_ApprovalDate", icfAppDate))
        End If

        If ddlVersionYear.SelectedIndex > -1 AndAlso ddlVersionMonth.SelectedIndex > -1 AndAlso ddlVersionDay.SelectedIndex > -1 Then
            Dim verDate As String = ddlVersionYear.SelectedValue & "-" & ddlVersionMonth.SelectedValue.PadLeft(2, "0"c) & "-" & ddlVersionDay.SelectedValue.PadLeft(2, "0"c)
            fields.Add("VersionDate = @VersionDate")
            parameters.Add(New SqlParameter("@VersionDate", verDate))
        End If


        If fields.Count = 0 Then
            lblMessage.Text = "No fields to update."
            Return
        End If

        Dim updateQuery As String = "UPDATE projectbodies SET " & String.Join(", ", fields) & " WHERE project = @ProjectID AND regbody = @RegBody"
        parameters.Add(New SqlParameter("@ProjectID", projectID))
        parameters.Add(New SqlParameter("@RegBody", regBody))

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString


        Using con As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(updateQuery, con)
                cmd.Parameters.AddRange(parameters.ToArray())
                con.Open()
                cmd.ExecuteNonQuery()
                lblMessage.Text = "Update successful. Refresh page!"
            End Using
        End Using
    End Sub
End Class
