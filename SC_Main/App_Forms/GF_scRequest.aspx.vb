Imports System.Web.Script.Serialization
Partial Class GF_scRequest
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/SC_Main/App_Display/DF_scRequest.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RequestID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVscRequest_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVscRequest.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RequestID As Int32 = GVscRequest.DataKeys(e.CommandArgument).Values("RequestID")  
        Dim RedirectUrl As String = TBLscRequest.EditUrl & "?RequestID=" & RequestID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim RequestID As Int32 = GVscRequest.DataKeys(e.CommandArgument).Values("RequestID")  
        SIS.SC.scRequest.InitiateWF(RequestID)
        GVscRequest.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVscRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVscRequest.Init
    DataClassName = "GscRequest"
    SetGridView = GVscRequest
  End Sub
  Protected Sub TBLscRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscRequest.Init
    SetToolBar = TBLscRequest
  End Sub
  Protected Sub F_RequestID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RequestID.TextChanged
    Session("F_RequestID") = F_RequestID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
