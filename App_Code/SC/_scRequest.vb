Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SC
  <DataObject()> _
  Partial Public Class scRequest
    Private Shared _RecordCount As Integer
    Private _RequestID As Int32 = 0
    Private _Remarks As String = ""
    Private _MDApprovalRequired As Boolean = False
    Private _MDApprovalBy As String = ""
    Private _AuditedBy As String = ""
    Private _AuditedOn As String = ""
    Private _MDRemarks As String = ""
    Private _MDFileName As String = ""
    Private _AuditorRemarks As String = ""
    Private _MDDiskFileName As String = ""
    Private _StatusID As String = ""
    Private _SubmittedOn As String = ""
    Private _SubmittedBy As String = ""
    Private _FileName As String = ""
    Private _MDApprovalOn As String = ""
    Private _RequestRefNo As String = ""
    Private _DiskFileName As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _aspnet_Users3_UserFullName As String = ""
    Private _SC_Status4_Description As String = ""
    Private _FK_SC_Request_SubmittedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_SC_Request_MDApprovalBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_SC_Request_AuditedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_SC_Request_StatusID As SIS.SC.scStatus = Nothing
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
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Remarks = ""
         Else
           _Remarks = value
         End If
      End Set
    End Property
    Public Property MDApprovalRequired() As Boolean
      Get
        Return _MDApprovalRequired
      End Get
      Set(ByVal value As Boolean)
        _MDApprovalRequired = value
      End Set
    End Property
    Public Property MDApprovalBy() As String
      Get
        Return _MDApprovalBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDApprovalBy = ""
         Else
           _MDApprovalBy = value
         End If
      End Set
    End Property
    Public Property AuditedBy() As String
      Get
        Return _AuditedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AuditedBy = ""
         Else
           _AuditedBy = value
         End If
      End Set
    End Property
    Public Property AuditedOn() As String
      Get
        If Not _AuditedOn = String.Empty Then
          Return Convert.ToDateTime(_AuditedOn).ToString("dd/MM/yyyy")
        End If
        Return _AuditedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AuditedOn = ""
         Else
           _AuditedOn = value
         End If
      End Set
    End Property
    Public Property MDRemarks() As String
      Get
        Return _MDRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDRemarks = ""
         Else
           _MDRemarks = value
         End If
      End Set
    End Property
    Public Property MDFileName() As String
      Get
        Return _MDFileName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDFileName = ""
         Else
           _MDFileName = value
         End If
      End Set
    End Property
    Public Property AuditorRemarks() As String
      Get
        Return _AuditorRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AuditorRemarks = ""
         Else
           _AuditorRemarks = value
         End If
      End Set
    End Property
    Public Property MDDiskFileName() As String
      Get
        Return _MDDiskFileName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDDiskFileName = ""
         Else
           _MDDiskFileName = value
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
    Public Property SubmittedOn() As String
      Get
        If Not _SubmittedOn = String.Empty Then
          Return Convert.ToDateTime(_SubmittedOn).ToString("dd/MM/yyyy")
        End If
        Return _SubmittedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SubmittedOn = ""
         Else
           _SubmittedOn = value
         End If
      End Set
    End Property
    Public Property SubmittedBy() As String
      Get
        Return _SubmittedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SubmittedBy = ""
         Else
           _SubmittedBy = value
         End If
      End Set
    End Property
    Public Property FileName() As String
      Get
        Return _FileName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _FileName = ""
         Else
           _FileName = value
         End If
      End Set
    End Property
    Public Property MDApprovalOn() As String
      Get
        If Not _MDApprovalOn = String.Empty Then
          Return Convert.ToDateTime(_MDApprovalOn).ToString("dd/MM/yyyy")
        End If
        Return _MDApprovalOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDApprovalOn = ""
         Else
           _MDApprovalOn = value
         End If
      End Set
    End Property
    Public Property RequestRefNo() As String
      Get
        Return _RequestRefNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RequestRefNo = ""
         Else
           _RequestRefNo = value
         End If
      End Set
    End Property
    Public Property DiskFileName() As String
      Get
        Return _DiskFileName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DiskFileName = ""
         Else
           _DiskFileName = value
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
    Public Property aspnet_Users2_UserFullName() As String
      Get
        Return _aspnet_Users2_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users2_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users3_UserFullName() As String
      Get
        Return _aspnet_Users3_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users3_UserFullName = value
      End Set
    End Property
    Public Property SC_Status4_Description() As String
      Get
        Return _SC_Status4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SC_Status4_Description = ""
         Else
           _SC_Status4_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _RequestRefNo.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _RequestID
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
    Public Class PKscRequest
      Private _RequestID As Int32 = 0
      Public Property RequestID() As Int32
        Get
          Return _RequestID
        End Get
        Set(ByVal value As Int32)
          _RequestID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_SC_Request_SubmittedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_SC_Request_SubmittedBy Is Nothing Then
          _FK_SC_Request_SubmittedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_SubmittedBy)
        End If
        Return _FK_SC_Request_SubmittedBy
      End Get
    End Property
    Public ReadOnly Property FK_SC_Request_MDApprovalBy() As SIS.QCM.qcmUsers
      Get
        If _FK_SC_Request_MDApprovalBy Is Nothing Then
          _FK_SC_Request_MDApprovalBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_MDApprovalBy)
        End If
        Return _FK_SC_Request_MDApprovalBy
      End Get
    End Property
    Public ReadOnly Property FK_SC_Request_AuditedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_SC_Request_AuditedBy Is Nothing Then
          _FK_SC_Request_AuditedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_AuditedBy)
        End If
        Return _FK_SC_Request_AuditedBy
      End Get
    End Property
    Public ReadOnly Property FK_SC_Request_StatusID() As SIS.SC.scStatus
      Get
        If _FK_SC_Request_StatusID Is Nothing Then
          _FK_SC_Request_StatusID = SIS.SC.scStatus.scStatusGetByID(_StatusID)
        End If
        Return _FK_SC_Request_StatusID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRequestSelectList(ByVal OrderBy As String) As List(Of SIS.SC.scRequest)
      Dim Results As List(Of SIS.SC.scRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscRequestSelectList"
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRequestGetNewRecord() As SIS.SC.scRequest
      Return New SIS.SC.scRequest()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRequestGetByID(ByVal RequestID As Int32) As SIS.SC.scRequest
      Dim Results As SIS.SC.scRequest = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.SC.scRequest(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As List(Of SIS.SC.scRequest)
      Dim Results As List(Of SIS.SC.scRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spscRequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spscRequestSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestID",SqlDbType.Int,10, IIf(RequestID = Nothing, 0,RequestID))
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
    Public Shared Function scRequestSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scRequestGetByID(ByVal RequestID As Int32, ByVal Filter_RequestID As Int32) As SIS.SC.scRequest
      Return scRequestGetByID(RequestID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function scRequestInsert(ByVal Record As SIS.SC.scRequest) As SIS.SC.scRequest
      Dim _Rec As SIS.SC.scRequest = SIS.SC.scRequest.scRequestGetNewRecord()
      With _Rec
        .Remarks = Record.Remarks
        .MDApprovalRequired = Record.MDApprovalRequired
        .MDApprovalBy = Record.MDApprovalBy
        .AuditedBy = Record.AuditedBy
        .AuditedOn = Record.AuditedOn
        .MDRemarks = Record.MDRemarks
        .MDFileName = Record.MDFileName
        .AuditorRemarks = Record.AuditorRemarks
        .MDDiskFileName = Record.MDDiskFileName
        .StatusID = scStates.Free
        .SubmittedOn = Now
        .SubmittedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .FileName = Record.FileName
        .MDApprovalOn = Record.MDApprovalOn
        .RequestRefNo = Record.RequestRefNo
        .DiskFileName = Record.DiskFileName
      End With
      Return SIS.SC.scRequest.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.SC.scRequest) As SIS.SC.scRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscRequestInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDApprovalRequired",SqlDbType.Bit,3, Record.MDApprovalRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDApprovalBy",SqlDbType.NVarChar,9, Iif(Record.MDApprovalBy= "" ,Convert.DBNull, Record.MDApprovalBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AuditedBy",SqlDbType.NVarChar,9, Iif(Record.AuditedBy= "" ,Convert.DBNull, Record.AuditedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AuditedOn",SqlDbType.DateTime,21, Iif(Record.AuditedOn= "" ,Convert.DBNull, Record.AuditedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDRemarks",SqlDbType.NVarChar,501, Iif(Record.MDRemarks= "" ,Convert.DBNull, Record.MDRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDFileName",SqlDbType.NVarChar,251, Iif(Record.MDFileName= "" ,Convert.DBNull, Record.MDFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AuditorRemarks",SqlDbType.NVarChar,501, Iif(Record.AuditorRemarks= "" ,Convert.DBNull, Record.AuditorRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDDiskFileName",SqlDbType.NVarChar,251, Iif(Record.MDDiskFileName= "" ,Convert.DBNull, Record.MDDiskFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.NVarChar,3, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubmittedOn",SqlDbType.DateTime,21, Iif(Record.SubmittedOn= "" ,Convert.DBNull, Record.SubmittedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubmittedBy",SqlDbType.NVarChar,9, Iif(Record.SubmittedBy= "" ,Convert.DBNull, Record.SubmittedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Iif(Record.FileName= "" ,Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDApprovalOn",SqlDbType.DateTime,21, Iif(Record.MDApprovalOn= "" ,Convert.DBNull, Record.MDApprovalOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestRefNo",SqlDbType.NVarChar,51, Iif(Record.RequestRefNo= "" ,Convert.DBNull, Record.RequestRefNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFileName",SqlDbType.NVarChar,251, Iif(Record.DiskFileName= "" ,Convert.DBNull, Record.DiskFileName))
          Cmd.Parameters.Add("@Return_RequestID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RequestID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.RequestID = Cmd.Parameters("@Return_RequestID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function scRequestUpdate(ByVal Record As SIS.SC.scRequest) As SIS.SC.scRequest
      Dim _Rec As SIS.SC.scRequest = SIS.SC.scRequest.scRequestGetByID(Record.RequestID)
      With _Rec
        .Remarks = Record.Remarks
        .MDApprovalRequired = Record.MDApprovalRequired
        .MDApprovalBy = Record.MDApprovalBy
        .AuditedBy = Record.AuditedBy
        .AuditedOn = Record.AuditedOn
        .MDRemarks = Record.MDRemarks
        .MDFileName = Record.MDFileName
        .AuditorRemarks = Record.AuditorRemarks
        .MDDiskFileName = Record.MDDiskFileName
        .StatusID = Record.StatusID
        .SubmittedOn = Now
        .SubmittedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .FileName = Record.FileName
        .MDApprovalOn = Record.MDApprovalOn
        .RequestRefNo = Record.RequestRefNo
        .DiskFileName = Record.DiskFileName
      End With
      Return SIS.SC.scRequest.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.SC.scRequest) As SIS.SC.scRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscRequestUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDApprovalRequired",SqlDbType.Bit,3, Record.MDApprovalRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDApprovalBy",SqlDbType.NVarChar,9, Iif(Record.MDApprovalBy= "" ,Convert.DBNull, Record.MDApprovalBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AuditedBy",SqlDbType.NVarChar,9, Iif(Record.AuditedBy= "" ,Convert.DBNull, Record.AuditedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AuditedOn",SqlDbType.DateTime,21, Iif(Record.AuditedOn= "" ,Convert.DBNull, Record.AuditedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDRemarks",SqlDbType.NVarChar,501, Iif(Record.MDRemarks= "" ,Convert.DBNull, Record.MDRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDFileName",SqlDbType.NVarChar,251, Iif(Record.MDFileName= "" ,Convert.DBNull, Record.MDFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AuditorRemarks",SqlDbType.NVarChar,501, Iif(Record.AuditorRemarks= "" ,Convert.DBNull, Record.AuditorRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDDiskFileName",SqlDbType.NVarChar,251, Iif(Record.MDDiskFileName= "" ,Convert.DBNull, Record.MDDiskFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.NVarChar,3, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubmittedOn",SqlDbType.DateTime,21, Iif(Record.SubmittedOn= "" ,Convert.DBNull, Record.SubmittedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubmittedBy",SqlDbType.NVarChar,9, Iif(Record.SubmittedBy= "" ,Convert.DBNull, Record.SubmittedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Iif(Record.FileName= "" ,Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDApprovalOn",SqlDbType.DateTime,21, Iif(Record.MDApprovalOn= "" ,Convert.DBNull, Record.MDApprovalOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestRefNo",SqlDbType.NVarChar,51, Iif(Record.RequestRefNo= "" ,Convert.DBNull, Record.RequestRefNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFileName",SqlDbType.NVarChar,251, Iif(Record.DiskFileName= "" ,Convert.DBNull, Record.DiskFileName))
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
    Public Shared Function scRequestDelete(ByVal Record As SIS.SC.scRequest) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscRequestDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,Record.RequestID.ToString.Length, Record.RequestID)
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
'    Autocomplete Method
    Public Shared Function SelectscRequestAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscRequestAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.SC.scRequest = New SIS.SC.scRequest(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
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
