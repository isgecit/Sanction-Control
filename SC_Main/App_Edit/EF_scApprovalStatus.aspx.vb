Imports System.Web.Script.Serialization
Partial Class EF_scApprovalStatus
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSscApprovalStatus_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSscApprovalStatus.Selected
    Dim tmp As SIS.SC.scApprovalStatus = CType(e.ReturnValue, SIS.SC.scApprovalStatus)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVscApprovalStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscApprovalStatus.Init
    DataClassName = "EscApprovalStatus"
    SetFormView = FVscApprovalStatus
  End Sub
  Protected Sub TBLscApprovalStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscApprovalStatus.Init
    SetToolBar = TBLscApprovalStatus
  End Sub
  Protected Sub FVscApprovalStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscApprovalStatus.PreRender
    TBLscApprovalStatus.EnableSave = Editable
    TBLscApprovalStatus.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/SC_Main/App_Edit") & "/EF_scApprovalStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptscApprovalStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptscApprovalStatus", mStr)
    End If
  End Sub

End Class
