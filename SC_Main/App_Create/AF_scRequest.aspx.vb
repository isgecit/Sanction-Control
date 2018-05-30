Partial Class AF_scRequest
  Inherits SIS.SYS.InsertBase
  Protected Sub FVscRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscRequest.Init
    DataClassName = "AscRequest"
    SetFormView = FVscRequest
  End Sub
  Protected Sub TBLscRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscRequest.Init
    SetToolBar = TBLscRequest
  End Sub
  Protected Sub ODSscRequest_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSscRequest.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.SC.scRequest = CType(e.ReturnValue,SIS.SC.scRequest)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&RequestID=" & oDC.RequestID
      TBLscRequest.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVscRequest_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscRequest.DataBound
    SIS.SC.scRequest.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVscRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscRequest.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/SC_Main/App_Create") & "/AF_scRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptscRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptscRequest", mStr)
    End If
    If Request.QueryString("RequestID") IsNot Nothing Then
      CType(FVscRequest.FindControl("F_RequestID"), TextBox).Text = Request.QueryString("RequestID")
      CType(FVscRequest.FindControl("F_RequestID"), TextBox).Enabled = False
    End If
  End Sub

End Class
