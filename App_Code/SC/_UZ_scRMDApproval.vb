Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SC
  Partial Public Class scRMDApproval
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case scStates.UnderMDApproval
          mRet = True
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
    Public Shared Function ApproveWF(ByVal RequestID As Int32, ByVal MDRemarks As String) As SIS.SC.scRMDApproval
      Dim Results As SIS.SC.scRMDApproval = scRMDApprovalGetByID(RequestID)
      With Results
        .MDApprovalBy = HttpContext.Current.Session("LoginID")
        .MDApprovalOn = Now
        .MDRemarks = MDRemarks
        .StatusID = scStates.UnderAuditClearance
      End With
      Results = SIS.SC.scRMDApproval.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal RequestID As Int32, ByVal MDRemarks As String) As SIS.SC.scRMDApproval
      Dim Results As SIS.SC.scRMDApproval = scRMDApprovalGetByID(RequestID)
      With Results
        .MDApprovalBy = HttpContext.Current.Session("LoginID")
        .MDApprovalOn = Now
        .MDRemarks = MDRemarks
        .StatusID = scStates.Returned
      End With
      Results = SIS.SC.scRMDApproval.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_scRMDApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As List(Of SIS.SC.scRMDApproval)
      Dim Results As List(Of SIS.SC.scRMDApproval) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spsc_LG_RMDApprovalSelectListSearch"
            'Cmd.CommandText = "spscRMDApprovalSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spsc_LG_RMDApprovalSelectListFilteres"
            'Cmd.CommandText = "spscRMDApprovalSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestID",SqlDbType.Int,10, IIf(RequestID = Nothing, 0,RequestID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.SC.scRMDApproval)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SC.scRMDApproval(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_scRMDApprovalUpdate(ByVal Record As SIS.SC.scRMDApproval) As SIS.SC.scRMDApproval
      Dim _Result As SIS.SC.scRMDApproval = scRMDApprovalUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
