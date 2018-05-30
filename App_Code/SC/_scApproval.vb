Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SC
  <DataObject()> _
  Partial Public Class scApproval
    Private Shared _RecordCount As Integer
    Private _RequestID As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _ApproverID As String = ""
    Private _StatusID As String = ""
    Private _ApproverRemarks As String = ""
    Private _ApprovedOn As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _SC_ApprovalStatus2_Description As String = ""
    Private _SC_Request3_RequestRefNo As String = ""
    Private _FK_SC_Approval_ApproverID As SIS.QCM.qcmUsers = Nothing
    Private _FK_SC_Approval_StatusID As SIS.SC.scApprovalStatus = Nothing
    Private _FK_SC_Approval_RequestID As SIS.SC.scRequest = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property RequestID() As Int32
      Get
        Return _RequestID
      End Get
      Set(ByVal value As Int32)
        _RequestID = value
      End Set
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property ApproverID() As String
      Get
        Return _ApproverID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApproverID = ""
         Else
           _ApproverID = value
         End If
      End Set
    End Property
    Public Property StatusID() As String
      Get
        Return _StatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _StatusID = ""
         Else
           _StatusID = value
         End If
      End Set
    End Property
    Public Property ApproverRemarks() As String
      Get
        Return _ApproverRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApproverRemarks = ""
         Else
           _ApproverRemarks = value
         End If
      End Set
    End Property
    Public Property ApprovedOn() As String
      Get
        If Not _ApprovedOn = String.Empty Then
          Return Convert.ToDateTime(_ApprovedOn).ToString("dd/MM/yyyy")
        End If
        Return _ApprovedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovedOn = ""
         Else
           _ApprovedOn = value
         End If
      End Set
    End Property
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property SC_ApprovalStatus2_Description() As String
      Get
        Return _SC_ApprovalStatus2_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SC_ApprovalStatus2_Description = ""
         Else
           _SC_ApprovalStatus2_Description = value
         End If
      End Set
    End Property
    Public Property SC_Request3_RequestRefNo() As String
      Get
        Return _SC_Request3_RequestRefNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SC_Request3_RequestRefNo = ""
         Else
           _SC_Request3_RequestRefNo = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _RequestID & "|" & _SerialNo
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKscApproval
      Private _RequestID As Int32 = 0
      Private _SerialNo As Int32 = 0
      Public Property RequestID() As Int32
        Get
          Return _RequestID
        End Get
        Set(ByVal value As Int32)
          _RequestID = value
        End Set
      End Property
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_SC_Approval_ApproverID() As SIS.QCM.qcmUsers
      Get
        If _FK_SC_Approval_ApproverID Is Nothing Then
          _FK_SC_Approval_ApproverID = SIS.QCM.qcmUsers.qcmUsersGetByID(_ApproverID)
        End If
        Return _FK_SC_Approval_ApproverID
      End Get
    End Property
    Public ReadOnly Property FK_SC_Approval_StatusID() As SIS.SC.scApprovalStatus
      Get
        If _FK_SC_Approval_StatusID Is Nothing Then
          _FK_SC_Approval_StatusID = SIS.SC.scApprovalStatus.scApprovalStatusGetByID(_StatusID)
        End If
        Return _FK_SC_Approval_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_SC_Approval_RequestID() As SIS.SC.scRequest
      Get
        If _FK_SC_Approval_RequestID Is Nothing Then
          _FK_SC_Approval_RequestID = SIS.SC.scRequest.scRequestGetByID(_RequestID)
        End If
        Return _FK_SC_Approval_RequestID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scApprovalGetNewRecord() As SIS.SC.scApproval
      Return New SIS.SC.scApproval()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scApprovalGetByID(ByVal RequestID As Int32, ByVal SerialNo As Int32) As SIS.SC.scApproval
      Dim Results As SIS.SC.scApproval = Nothing
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
            Results = New SIS.SC.scApproval(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As List(Of SIS.SC.scApproval)
      Dim Results As List(Of SIS.SC.scApproval) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spscApprovalSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spscApprovalSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestID",SqlDbType.Int,10, IIf(RequestID = Nothing, 0,RequestID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SC.scApproval)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SC.scApproval(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function scApprovalSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scApprovalGetByID(ByVal RequestID As Int32, ByVal SerialNo As Int32, ByVal Filter_RequestID As Int32) As SIS.SC.scApproval
      Return scApprovalGetByID(RequestID, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function scApprovalInsert(ByVal Record As SIS.SC.scApproval) As SIS.SC.scApproval
      Dim _Rec As SIS.SC.scApproval = SIS.SC.scApproval.scApprovalGetNewRecord()
      With _Rec
        .RequestID = Record.RequestID
        .ApproverID = Record.ApproverID
        .StatusID = scAprStates.Free
        .ApproverRemarks = Record.ApproverRemarks
        .ApprovedOn = Record.ApprovedOn
      End With
      Return SIS.SC.scApproval.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.SC.scApproval) As SIS.SC.scApproval
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscApprovalInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverID",SqlDbType.NVarChar,9, Iif(Record.ApproverID= "" ,Convert.DBNull, Record.ApproverID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.NVarChar,3, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,501, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          Cmd.Parameters.Add("@Return_RequestID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RequestID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.RequestID = Cmd.Parameters("@Return_RequestID").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function scApprovalUpdate(ByVal Record As SIS.SC.scApproval) As SIS.SC.scApproval
      Dim _Rec As SIS.SC.scApproval = SIS.SC.scApproval.scApprovalGetByID(Record.RequestID, Record.SerialNo)
      With _Rec
        .ApproverID = Record.ApproverID
        .StatusID = Record.StatusID
        .ApproverRemarks = Record.ApproverRemarks
        .ApprovedOn = Record.ApprovedOn
      End With
      Return SIS.SC.scApproval.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.SC.scApproval) As SIS.SC.scApproval
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscApprovalUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverID",SqlDbType.NVarChar,9, Iif(Record.ApproverID= "" ,Convert.DBNull, Record.ApproverID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.NVarChar,3, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,501, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function scApprovalDelete(ByVal Record As SIS.SC.scApproval) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscApprovalDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,Record.RequestID.ToString.Length, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
