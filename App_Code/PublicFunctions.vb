Imports System.Data.SqlClient
Imports System.Data
Imports System.Security.Principal

Public Class PublicFunctions




    'this function generates the string to populate the top row of tabs
    Public Shared Function PopulateTopTabs(ByVal fname As String) As String
        Dim top_tab_content As String
        Dim strSQL As String
        Dim TopTab_link As String = ""
        Dim NavTab_link As String
        Dim NumTopTabs As Integer



        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
        Dim sqlConnection As New SqlConnection(ConnectionString)


        'get username and access level
        'Dim username As String = HttpContext.Current.User.Identity.Name.ToString()
        Dim username As String = WindowsIdentity.GetCurrent().Name
        'Dim username As String = System.Environment.UserName
        Dim userlevel As String '1 = data viewer; 2 = data editor; 3 = data entrant; 4 = administrator

        userlevel = ""

        strSQL = "select accesslevel from tblusers where logon = '" & username & "'"
        Dim ds0 As DataSet = New DataSet()
        Dim adapter As New SqlDataAdapter(strSQL, sqlConnection)
        adapter.Fill(ds0)

        Dim dt0 As DataTable
        dt0 = ds0.Tables(0)

        For Each row As DataRow In dt0.Rows
            userlevel = row.Item(0)
        Next row


        strSQL = "select t.hlink as TopLink, n.hlink AS NavLink from tblTopTabs t INNER JOIN tblNaviTabs n ON t.hlink = n.mother_link" &
                        " where n.hlink = '" & fname & "'"

        Dim cmd As SqlDataAdapter = New SqlDataAdapter(strSQL, sqlConnection)
        Dim ds As DataSet = New DataSet()
        cmd.Fill(ds)

        Dim num_tables As Integer = 0
        Dim dt As DataTable
        dt = ds.Tables(0)

        For Each row As DataRow In dt.Rows
            TopTab_link = row.Item(0)
            NavTab_link = row.Item(1)
        Next row


        'If userlevel <> 3 Then
        '    strSQL = "select display_text, hlink from tblTopTabs where access_level <= '" & userlevel & "' order by torder"
        'Else
        '    strSQL = "select display_text, hlink from tblTopTabs where access_level = 3 or access_level = 1 order by torder"
        'End If



        Select Case userlevel
            Case Is = 1
                strSQL = "select display_text, hlink from tblTopTabs where access_level = 1 order by torder"
            Case Is = 2
                strSQL = "select display_text, hlink from tblTopTabs where access_level = 1 or access_level = 2 order by torder"
            Case Is = 3
                strSQL = "select display_text, hlink from tblTopTabs where access_level = 1 or access_level = 3 order by torder"
            Case Is = 4
                strSQL = "select display_text, hlink from tblTopTabs where access_level = 1 or access_level = 2 or access_level = 3 or access_level = 4 order by torder"
            Case Else
                HttpContext.Current.Response.Redirect("http://www.mu-ucsf.org/muucsf/access_denied.html")
        End Select



        Dim cmdTopTab As SqlDataAdapter = New SqlDataAdapter(strSQL, sqlConnection)
        Dim dsTopTab As New DataSet
        cmdTopTab.Fill(dsTopTab)

        Dim dtTopTab As New DataTable
        dtTopTab = dsTopTab.Tables(0)

        NumTopTabs = dsTopTab.Tables(0).Rows.Count - 1


        'build toptab div contents
        Dim i As Integer = 0
        top_tab_content = "<p>"
        For Each row As DataRow In dtTopTab.Rows
            top_tab_content = top_tab_content & "<a class='"
            If TopTab_link = row.Item(1) Then
                top_tab_content = top_tab_content & "activetoptab' href='"
            Else
                top_tab_content = top_tab_content & "toptab' href='"
            End If
            top_tab_content = top_tab_content & row.Item(1) & "'> " & row.Item(0) & "</a>"
            If i = NumTopTabs Then
                top_tab_content = top_tab_content & "</p>"
            Else
                top_tab_content = top_tab_content & "<span class='hide'> | </span>"
            End If
            i = i + 1
        Next row

        PopulateTopTabs = top_tab_content



    End Function





    'this function generate a string to populate the navigation tabs
    Public Shared Function PopulateNaviTabs(ByVal fname As String) As String
        Dim top_tab_content As String = ""
        Dim nav_tab_content As String
        Dim strSQL As String
        Dim TopTab_link As String
        Dim NavTab_link As String = ""
        Dim NumTopTabs As Integer = 0
        Dim NumNavTabs As Integer
        'populate navigation tabs

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
        Dim sqlConnection As New SqlConnection(ConnectionString)


        strSQL = "select t.hlink as TopLink, n.hlink AS NavLink from tblTopTabs t INNER JOIN tblNaviTabs n ON t.hlink = n.mother_link" &
                        " where n.hlink = '" & fname & "'"

        Dim cmd As SqlDataAdapter = New SqlDataAdapter(strSQL, sqlConnection)
        Dim ds As DataSet = New DataSet()
        cmd.Fill(ds)

        Dim num_tables As Integer = 0
        Dim dt As DataTable
        dt = ds.Tables(0)

        For Each row As DataRow In dt.Rows
            TopTab_link = row.Item(0)
            NavTab_link = row.Item(1)
        Next row



        strSQL = "select display_text,hlink from tblNaviTabs where mother_link = (select mother_link from tblNaviTabs where hlink = '" & fname & "') order by torder"


        Dim cmdNavTab As SqlDataAdapter = New SqlDataAdapter(strSQL, sqlConnection)
        Dim dsNavTab As New DataSet
        cmdNavTab.Fill(dsNavTab)

        Dim dtNavTab As New DataTable
        dtNavTab = dsNavTab.Tables(0)

        NumNavTabs = dsNavTab.Tables(0).Rows.Count - 1


        'build navtab div contents
        nav_tab_content = ""
        For Each row As DataRow In dtNavTab.Rows
            If Not (IsDBNull(row.Item(0))) Then
                nav_tab_content = nav_tab_content & "<a class='"
                If NavTab_link = row.Item(1) Then
                    'If (IsDBNull(row.Item(0))) Then
                    nav_tab_content = nav_tab_content & "activenavitab' href='"
                    'End If
                Else
                    nav_tab_content = nav_tab_content & "navitab' href='"
                End If
                nav_tab_content = nav_tab_content & row.Item(1) & "'> " & row.Item(0) & "</a><span class='hide'> | </span>"
            End If

        Next row
        PopulateNaviTabs = nav_tab_content
        'navitabs.InnerHtml = nav_tab_content

    End Function



    Public Shared Function GetPostQueryDataset(ByVal recid As Integer, ByVal form As String) As DataSet
        Dim strSQL As String
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ProjectConnectionString").ConnectionString
        Dim sqlConnection As New SqlConnection(ConnectionString)


        strSQL = "Select dvarname, ddescrip from tblDD where dform = '" & form & "' order by dorder"

        Dim cmd As SqlDataAdapter = New SqlDataAdapter(strSQL, ConnectionString)
        Dim ds As DataSet = New DataSet()
        cmd.Fill(ds)

        Dim dt As DataTable
        dt = ds.Tables(0)

        Dim Table1 As DataTable
        Table1 = New DataTable("SpecificData")

        Dim dvarname As DataColumn = New DataColumn("Variable Name") With {
            .DataType = System.Type.GetType("System.String")
        }
        Table1.Columns.Add(dvarname)

        Dim ddescrip As DataColumn = New DataColumn("Question") With {
            .DataType = System.Type.GetType("System.String")
        }
        Table1.Columns.Add(ddescrip)

        Dim CurrentValue As DataColumn = New DataColumn("Current Value") With {
            .DataType = System.Type.GetType("System.String")
        }
        Table1.Columns.Add(CurrentValue)

        For Each row As DataRow In dt.Rows
            Dim Row1 As DataRow

            strSQL = "Select " & row.Item(0) & " as CurrentValue from " & form & " where recordid = " & recid

            Dim cmd2 As SqlDataAdapter = New SqlDataAdapter(strSQL, ConnectionString)
            Dim ds2 As DataSet = New DataSet()
            cmd2.Fill(ds2)
            Dim dt2 As DataTable
            dt2 = ds2.Tables(0)

            Row1 = Table1.NewRow()
            Row1.Item("Variable Name") = row.Item(0)
            Row1.Item("Question") = row.Item(1)
            For Each row2 As DataRow In dt2.Rows
                Row1.Item("Current Value") = row2.Item(0)
            Next row2

            Table1.Rows.Add(Row1)
        Next row

        Dim ds3 As New DataSet()
        ds3.Tables.Add(Table1)
        Return ds3
    End Function


End Class
