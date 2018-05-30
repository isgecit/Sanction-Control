Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SC
  <DataObject()> _
  Partial Public Class scRApproval
    Inherits SIS.SC.scApproval
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRApprovalGetNewRecord() As SIS.SC.scRApproval
      Return New SIS.SC.scRApproval()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As List(Of SIS.SC.scRApproval)
      Dim Results As List(Of SIS.SC.scRApproval) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spscRApprovalSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spscRApprovalSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestID",SqlDbType.Int,10, IIf(RequestID = Nothing, 0,RequestID))
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
    Public Shared Function scRApprovalSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRApprovalGetByID(ByVal RequestID As Int32, ByVal SerialNo As Int32) As SIS.SC.scRApproval
      Dim Results As SIS.SC.scRApproval = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscApprovalSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.SC.scRApproval(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRApprovalGetByID(ByVal RequestID As Int32, ByVal SerialNo As Int32, ByVal Filter_RequestID As Int32) As SIS.SC.scRApproval
      Dim Results As SIS.SC.scRApproval = SIS.SC.scRApproval.scRApprovalGetByID(RequestID, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function scRApprovalUpdate(ByVal Record As SIS.SC.scRApproval) As SIS.SC.scRApproval
      Dim _Rec As SIS.SC.scRApproval = SIS.SC.scRApproval.scRApprovalGetByID(Record.RequestID, Record.SerialNo)
      With _Rec
        .ApproverID = Record.ApproverID
        .StatusID = Record.StatusID
        .ApproverRemarks = Record.ApproverRemarks
        .ApprovedOn = Record.ApprovedOn
      End With
      Return SIS.SC.scRApproval.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
