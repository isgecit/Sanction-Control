Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SC
  Partial Public Class scRApproval
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case scAprStates.UnderApproval
          mRet = False
      End Select
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ApproveWF(ByVal RequestID As Int32, ByVal SerialNo As Int32, ByVal ApproverRemarks As String) As SIS.SC.scRApproval
      Dim Results As SIS.SC.scRApproval = scRApprovalGetByID(RequestID, SerialNo)
      With Results
        .ApprovedOn = Now
        .ApproverRemarks = ApproverRemarks
        .StatusID = scAprStates.ApprovedWithComments
      End With
      Results = SIS.SC.scRApproval.UpdateData(Results)
      CheckPercentageApproved(RequestID)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal RequestID As Int32, ByVal SerialNo As Int32, ByVal ApproverRemarks As String) As SIS.SC.scRApproval
      Dim Results As SIS.SC.scRApproval = scRApprovalGetByID(RequestID, SerialNo)
      With Results
        .ApprovedOn = Now
        .ApproverRemarks = ApproverRemarks
        .StatusID = scAprStates.Returned
      End With
      Results = SIS.SC.scRApproval.UpdateData(Results)
      CheckPercentageApproved(RequestID)
      Return Results
    End Function
    Public Shared Function CompleteWF(ByVal RequestID As Int32, ByVal SerialNo As Int32, ByVal ApproverRemarks As String) As SIS.SC.scRApproval
      Dim Results As SIS.SC.scRApproval = scRApprovalGetByID(RequestID, SerialNo)
      With Results
        .ApprovedOn = Now
        .ApproverRemarks = ApproverRemarks
        .StatusID = scAprStates.Approved
      End With
      Results = SIS.SC.scRApproval.UpdateData(Results)
      CheckPercentageApproved(RequestID)
      Return Results
    End Function
    Public Shared Function UZ_scRApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As List(Of SIS.SC.scRApproval)
      Dim Results As List(Of SIS.SC.scRApproval) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spsc_LG_RApprovalSelectListSearch"
            'Cmd.CommandText = "spscRApprovalSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spsc_LG_RApprovalSelectListFilteres"
            'Cmd.CommandText = "spscRApprovalSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestID", SqlDbType.Int, 10, IIf(RequestID = Nothing, 0, RequestID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.SC.scRApproval)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SC.scRApproval(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_scRApprovalUpdate(ByVal Record As SIS.SC.scRApproval) As SIS.SC.scRApproval
      Dim _Result As SIS.SC.scRApproval = scRApprovalUpdate(Record)
      Return _Result
    End Function
    Public Shared Sub CheckPercentageApproved(ByVal RequestID As Integer)
      Dim Req As SIS.SC.scRequest = SIS.SC.scRequest.scRequestGetByID(RequestID)

      Dim tmpAprs As List(Of SIS.SC.scApproval) = SIS.SC.scApproval.UZ_scApprovalSelectList(0, 99, "", False, "", RequestID)
      Dim tmpAPercent As Decimal = 0
      Dim tmpRPercent As Decimal = 0
      Dim tmpCount As Integer = tmpAprs.Count

      For Each tmpA As SIS.SC.scApproval In tmpAprs
        Select Case tmpA.StatusID
          Case scAprStates.Approved, scAprStates.ApprovedWithComments
            tmpAPercent += 1
          Case scAprStates.Returned
            tmpRPercent += 1
        End Select
      Next
      tmpAPercent = (tmpAPercent / tmpCount) * 100
      If tmpAPercent > 50 Then
        With Req
          If Req.MDApprovalRequired Then
            .StatusID = scStates.UnderMDApproval
          Else
            .StatusID = scStates.UnderAuditClearance
          End If
        End With
        Req = SIS.SC.scRequest.UpdateData(Req)
        'Email Alert to All 
      End If
      tmpRPercent = (tmpRPercent / tmpCount) * 100
      If tmpRPercent >= 50 Then
        With Req
          .StatusID = scStates.Returned
        End With
        Req = SIS.SC.scRequest.UpdateData(Req)
        'Email Alert to All 
      End If
    End Sub
  End Class
End Namespace
