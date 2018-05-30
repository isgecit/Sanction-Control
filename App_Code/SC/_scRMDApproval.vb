Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SC
  <DataObject()> _
  Partial Public Class scRMDApproval
    Inherits SIS.SC.scRequest
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRMDApprovalGetNewRecord() As SIS.SC.scRMDApproval
      Return New SIS.SC.scRMDApproval()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRMDApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As List(Of SIS.SC.scRMDApproval)
      Dim Results As List(Of SIS.SC.scRMDApproval) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spscRMDApprovalSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spscRMDApprovalSelectListFilteres"
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
    Public Shared Function scRMDApprovalSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRMDApprovalGetByID(ByVal RequestID As Int32) As SIS.SC.scRMDApproval
      Dim Results As SIS.SC.scRMDApproval = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.SC.scRMDApproval(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRMDApprovalGetByID(ByVal RequestID As Int32, ByVal Filter_RequestID As Int32) As SIS.SC.scRMDApproval
      Dim Results As SIS.SC.scRMDApproval = SIS.SC.scRMDApproval.scRMDApprovalGetByID(RequestID)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function scRMDApprovalUpdate(ByVal Record As SIS.SC.scRMDApproval) As SIS.SC.scRMDApproval
      Dim _Rec As SIS.SC.scRMDApproval = SIS.SC.scRMDApproval.scRMDApprovalGetByID(Record.RequestID)
      With _Rec
        .Remarks = Record.Remarks
        .MDApprovalRequired = Record.MDApprovalRequired
        .AuditedBy = Record.AuditedBy
        .MDRemarks = Record.MDRemarks
        .MDApprovalBy = Record.MDApprovalBy
        .AuditedOn = Record.AuditedOn
        .MDDiskFileName = Record.MDDiskFileName
        .MDFileName = Record.MDFileName
        .AuditorRemarks = Record.AuditorRemarks
        .SubmittedBy = Record.SubmittedBy
        .DiskFileName = Record.DiskFileName
        .FileName = Record.FileName
        .SubmittedOn = Record.SubmittedOn
        .MDApprovalOn = Record.MDApprovalOn
        .RequestRefNo = Record.RequestRefNo
        .StatusID = Record.StatusID
      End With
      Return SIS.SC.scRMDApproval.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
