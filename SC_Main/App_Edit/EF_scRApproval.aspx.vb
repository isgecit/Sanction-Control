Imports System.Web.Script.Serialization
Partial Class EF_scRApproval
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
  Protected Sub ODSscRApproval_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSscRApproval.Selected
    Dim tmp As SIS.SC.scRApproval = CType(e.ReturnValue, SIS.SC.scRApproval)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVscRApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscRApproval.Init
    DataClassName = "EscRApproval"
    SetFormView = FVscRApproval
  End Sub
  Protected Sub TBLscRApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscRApproval.Init
    SetToolBar = TBLscRApproval
  End Sub
  Protected Sub FVscRApproval_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscRApproval.PreRender
    TBLscRApproval.EnableSave = Editable
    TBLscRApproval.EnableDelete = Deleteable
    TBLscRApproval.PrintUrl &= Request.QueryString("RequestID") & "|"
    TBLscRApproval.PrintUrl &= Request.QueryString("SerialNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/SC_Main/App_Edit") & "/EF_scRApproval.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptscRApproval") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptscRApproval", mStr)
    End If
  End Sub

End Class
