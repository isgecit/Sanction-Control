Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SC
  <DataObject()> _
  Partial Public Class scProject
    Private Shared _RecordCount As Integer
    Private _RequestID As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _ProjectID As String = ""
    Private _ElementID As String = ""
    Private _Amount As Decimal = 0
    Private _IsFromProject As Boolean = False
    Private _IDM_Projects1_Description As String = ""
    Private _IDM_WBS2_Description As String = ""
    Private _SC_Request3_RequestRefNo As String = ""
    Private _FK_SC_Project_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_SC_Project_ElementID As SIS.QCM.qcmWBS = Nothing
    Private _FK_SC_Project_RequestID As SIS.SC.scRequest = Nothing
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
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectID = ""
         Else
           _ProjectID = value
         End If
      End Set
    End Property
    Public Property ElementID() As String
      Get
        Return _ElementID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ElementID = ""
         Else
           _ElementID = value
         End If
      End Set
    End Property
    Public Property Amount() As Decimal
      Get
        Return _Amount
      End Get
      Set(ByVal value As Decimal)
        _Amount = value
      End Set
    End Property
    Public Property IsFromProject() As Boolean
      Get
        Return _IsFromProject
      End Get
      Set(ByVal value As Boolean)
        _IsFromProject = value
      End Set
    End Property
    Public Property IDM_Projects1_Description() As String
      Get
        Return _IDM_Projects1_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects1_Description = value
      End Set
    End Property
    Public Property IDM_WBS2_Description() As String
      Get
        Return _IDM_WBS2_Description
      End Get
      Set(ByVal value As String)
        _IDM_WBS2_Description = value
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
    Public Class PKscProject
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
    Public ReadOnly Property FK_SC_Project_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_SC_Project_ProjectID Is Nothing Then
          _FK_SC_Project_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_SC_Project_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_SC_Project_ElementID() As SIS.QCM.qcmWBS
      Get
        If _FK_SC_Project_ElementID Is Nothing Then
          _FK_SC_Project_ElementID = SIS.QCM.qcmWBS.qcmWBSGetByID(_ElementID)
        End If
        Return _FK_SC_Project_ElementID
      End Get
    End Property
    Public ReadOnly Property FK_SC_Project_RequestID() As SIS.SC.scRequest
      Get
        If _FK_SC_Project_RequestID Is Nothing Then
          _FK_SC_Project_RequestID = SIS.SC.scRequest.scRequestGetByID(_RequestID)
        End If
        Return _FK_SC_Project_RequestID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scProjectGetNewRecord() As SIS.SC.scProject
      Return New SIS.SC.scProject()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scProjectGetByID(ByVal RequestID As Int32, ByVal SerialNo As Int32) As SIS.SC.scProject
      Dim Results As SIS.SC.scProject = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscProjectSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.SC.scProject(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scProjectSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As List(Of SIS.SC.scProject)
      Dim Results As List(Of SIS.SC.scProject) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spscProjectSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spscProjectSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestID",SqlDbType.Int,10, IIf(RequestID = Nothing, 0,RequestID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SC.scProject)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SC.scProject(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function scProjectSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequestID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function scProjectGetByID(ByVal RequestID As Int32, ByVal SerialNo As Int32, ByVal Filter_RequestID As Int32) As SIS.SC.scProject
      Return scProjectGetByID(RequestID, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function scProjectInsert(ByVal Record As SIS.SC.scProject) As SIS.SC.scProject
      Dim _Rec As SIS.SC.scProject = SIS.SC.scProject.scProjectGetNewRecord()
      With _Rec
        .RequestID = Record.RequestID
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .Amount = Record.Amount
        .IsFromProject = Record.IsFromProject
      End With
      Return SIS.SC.scProject.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.SC.scProject) As SIS.SC.scProject
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscProjectInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,21, Record.Amount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsFromProject",SqlDbType.Bit,3, Record.IsFromProject)
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
    Public Shared Function scProjectUpdate(ByVal Record As SIS.SC.scProject) As SIS.SC.scProject
      Dim _Rec As SIS.SC.scProject = SIS.SC.scProject.scProjectGetByID(Record.RequestID, Record.SerialNo)
      With _Rec
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .Amount = Record.Amount
        .IsFromProject = Record.IsFromProject
      End With
      Return SIS.SC.scProject.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.SC.scProject) As SIS.SC.scProject
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscProjectUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,21, Record.Amount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsFromProject",SqlDbType.Bit,3, Record.IsFromProject)
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
    Public Shared Function scProjectDelete(ByVal Record As SIS.SC.scProject) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spscProjectDelete"
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
