Partial Class AF_scApprovalStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVscApprovalStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscApprovalStatus.Init
    DataClassName = "AscApprovalStatus"
    SetFormView = FVscApprovalStatus
  End Sub
  Protected Sub TBLscApprovalStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscApprovalStatus.Init
    SetToolBar = TBLscApprovalStatus
  End Sub
  Protected Sub FVscApprovalStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscApprovalStatus.DataBound
    SIS.SC.scApprovalStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVscApprovalStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscApprovalStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/SC_Main/App_Create") & "/AF_scApprovalStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptscApprovalStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptscApprovalStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVscApprovalStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVscApprovalStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
