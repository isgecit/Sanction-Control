Imports System.Web.Script.Serialization
Partial Class EF_scRAuditApproval
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
  Protected Sub ODSscRAuditApproval_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSscRAuditApproval.Selected
    Dim tmp As SIS.SC.scRAuditApproval = CType(e.ReturnValue, SIS.SC.scRAuditApproval)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVscRAuditApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscRAuditApproval.Init
    DataClassName = "EscRAuditApproval"
    SetFormView = FVscRAuditApproval
  End Sub
  Protected Sub TBLscRAuditApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscRAuditApproval.Init
    SetToolBar = TBLscRAuditApproval
  End Sub
  Protected Sub FVscRAuditApproval_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscRAuditApproval.PreRender
    TBLscRAuditApproval.EnableSave = Editable
    TBLscRAuditApproval.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/SC_Main/App_Edit") & "/EF_scRAuditApproval.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptscRAuditApproval") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptscRAuditApproval", mStr)
    End If
  End Sub

End Class
