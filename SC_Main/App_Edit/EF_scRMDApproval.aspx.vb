Imports System.Web.Script.Serialization
Partial Class EF_scRMDApproval
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
  Protected Sub ODSscRMDApproval_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSscRMDApproval.Selected
    Dim tmp As SIS.SC.scRMDApproval = CType(e.ReturnValue, SIS.SC.scRMDApproval)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVscRMDApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscRMDApproval.Init
    DataClassName = "EscRMDApproval"
    SetFormView = FVscRMDApproval
  End Sub
  Protected Sub TBLscRMDApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscRMDApproval.Init
    SetToolBar = TBLscRMDApproval
  End Sub
  Protected Sub FVscRMDApproval_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscRMDApproval.PreRender
    TBLscRMDApproval.EnableSave = Editable
    TBLscRMDApproval.EnableDelete = Deleteable
    TBLscRMDApproval.PrintUrl &= Request.QueryString("RequestID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/SC_Main/App_Edit") & "/EF_scRMDApproval.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptscRMDApproval") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptscRMDApproval", mStr)
    End If
  End Sub

End Class
