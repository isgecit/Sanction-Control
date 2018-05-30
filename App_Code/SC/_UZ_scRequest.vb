Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SC
  Partial Public Class scRequest
    Public Shadows ReadOnly Property GetDownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/SC_Main/App_Downloads/scdownload.aspx?req=" & PrimaryKey & "', 'win" & RequestID & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public ReadOnly Property DownloadVisible As Boolean
      Get
        Dim mRet As Boolean = False
        If FileName <> "" Then
          mRet = True
        End If
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteAgendaVisible As Boolean
      Get
        Return GetEditable()
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case scStates.UnderApproval
          mRet = Drawing.Color.DarkGoldenrod
        Case scStates.Returned
          mRet = Drawing.Color.Red
        Case scStates.UnderMDApproval
        Case scStates.UnderAuditClearance
      End Select
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case scStates.Free, scStates.Returned
          mRet = True
      End Select
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Return GetEditable()
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal RequestID As Int32) As SIS.SC.scRequest
      Dim Results As SIS.SC.scRequest = scRequestGetByID(RequestID)
      If Results.FileName = "" Then
        Throw New Exception("Agenda paper NOT Attached, can not forward.")
      End If
      Dim tmpAprs As List(Of SIS.SC.scApproval) = SIS.SC.scApproval.UZ_scApprovalSelectList(0, 99, "", False, "", RequestID)
      Dim tmpFPrjs As List(Of SIS.SC.scProject) = SIS.SC.scProject.UZ_FscProjectSelectList(0, 99, "", False, "", RequestID)
      If tmpFPrjs.Count <= 0 Then
        Throw New Exception("From PROJECT NOT Selected, can not forward.")
      End If

      Dim tmpTPrjs As List(Of SIS.SC.scProject) = SIS.SC.scProject.UZ_TscProjectSelectList(0, 99, "", False, "", RequestID)
      If tmpTPrjs.Count <= 0 Then
        Throw New Exception("To PROJECT NOT Selected, can not forward.")
      End If
      If tmpAprs.Count <= 0 Then
        Throw New Exception("Approvers NOT Selected, can not forward.")
      End If
      For Each tmpA As SIS.SC.scApproval In tmpAprs
        tmpA.StatusID = scAprStates.UnderApproval
        SIS.SC.scApproval.UpdateData(tmpA)
      Next
      With Results
        .RequestRefNo = "<>/" & Now.ToString("ddMMyyyy") & "/" & RequestID
        .StatusID = scStates.UnderApproval
        .SubmittedBy = HttpContext.Current.Session("LoginID")
        .SubmittedOn = Now
      End With
      Results = SIS.SC.scRequest.UpdateData(Results)
      'Email Alerts to approvers
      Return Results
    End Function
    Public Shared Function UZ_scRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As List(Of SIS.SC.scRequest)
      Dim Results As List(Of SIS.SC.scRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spsc_LG_RequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spsc_LG_RequestSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestID", SqlDbType.Int, 10, IIf(RequestID = Nothing, 0, RequestID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SC.scRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SC.scRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_scRequestInsert(ByVal Record As SIS.SC.scRequest) As SIS.SC.scRequest
      Dim _Result As SIS.SC.scRequest = scRequestInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_scRequestUpdate(ByVal Record As SIS.SC.scRequest) As SIS.SC.scRequest
      Dim _Result As SIS.SC.scRequest = scRequestUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_scRequestDelete(ByVal Record As SIS.SC.scRequest) As Integer
      Dim _Result as Integer = scRequestDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_RequestID"), TextBox).Text = ""
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        CType(.FindControl("F_MDApprovalRequired"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
