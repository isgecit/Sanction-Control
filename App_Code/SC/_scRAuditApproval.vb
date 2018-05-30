Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SC
  <DataObject()> _
  Partial Public Class scRAuditApproval
    Inherits SIS.SC.scRequest
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRAuditApprovalGetNewRecord() As SIS.SC.scRAuditApproval
      Return New SIS.SC.scRAuditApproval()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRAuditApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As List(Of SIS.SC.scRAuditApproval)
      Dim Results As List(Of SIS.SC.scRAuditApproval) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spscRAuditApprovalSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spscRAuditApprovalSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestID",SqlDbType.Int,10, IIf(RequestID = Nothing, 0,RequestID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.SC.scRAuditApproval)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SC.scRAuditApproval(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function scRAuditApprovalSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRAuditApprovalGetByID(ByVal RequestID As Int32) As SIS.SC.scRAuditApproval
      Dim Results As SIS.SC.scRAuditApproval = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.SC.scRAuditApproval(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRAuditApprovalGetByID(ByVal RequestID As Int32, ByVal Filter_RequestID As Int32) As SIS.SC.scRAuditApproval
      Dim Results As SIS.SC.scRAuditApproval = SIS.SC.scRAuditApproval.scRAuditApprovalGetByID(RequestID)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function scRAuditApprovalUpdate(ByVal Record As SIS.SC.scRAuditApproval) As SIS.SC.scRAuditApproval
      Dim _Rec As SIS.SC.scRAuditApproval = SIS.SC.scRAuditApproval.scRAuditApprovalGetByID(Record.RequestID)
      With _Rec
        .Remarks = Record.Remarks
        .MDApprovalRequired = Record.MDApprovalRequired
        .MDApprovalBy = Record.MDApprovalBy
        .MDApprovalOn = Record.MDApprovalOn
        .StatusID = Record.StatusID
        .DiskFileName = Record.DiskFileName
        .MDFileName = Record.MDFileName
        .MDDiskFileName = Record.MDDiskFileName
        .AuditorRemarks = Record.AuditorRemarks
        .FileName = Record.FileName
        .MDRemarks = Record.MDRemarks
        .RequestRefNo = Record.RequestRefNo
        .SubmittedOn = Record.SubmittedOn
        .AuditedOn = Record.AuditedOn
        .AuditedBy = Record.AuditedBy
        .SubmittedBy = Record.SubmittedBy
      End With
      Return SIS.SC.scRAuditApproval.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
