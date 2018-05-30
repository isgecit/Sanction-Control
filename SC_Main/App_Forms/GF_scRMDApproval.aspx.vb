Imports System.Web.Script.Serialization
Partial Class GF_scRMDApproval
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/SC_Main/App_Display/DF_scRMDApproval.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RequestID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVscRMDApproval_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVscRMDApproval.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RequestID As Int32 = GVscRMDApproval.DataKeys(e.CommandArgument).Values("RequestID")  
        Dim RedirectUrl As String = TBLscRMDApproval.EditUrl & "?RequestID=" & RequestID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim MDRemarks As String = CType(GVscRMDApproval.Rows(e.CommandArgument).FindControl("F_MDRemarks"),TextBox).Text
        Dim RequestID As Int32 = GVscRMDApproval.DataKeys(e.CommandArgument).Values("RequestID")  
        SIS.SC.scRMDApproval.ApproveWF(RequestID, MDRemarks)
        GVscRMDApproval.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim MDRemarks As String = CType(GVscRMDApproval.Rows(e.CommandArgument).FindControl("F_MDRemarks"),TextBox).Text
        Dim RequestID As Int32 = GVscRMDApproval.DataKeys(e.CommandArgument).Values("RequestID")  
        SIS.SC.scRMDApproval.RejectWF(RequestID, MDRemarks)
        GVscRMDApproval.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVscRMDApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVscRMDApproval.Init
    DataClassName = "GscRMDApproval"
    SetGridView = GVscRMDApproval
  End Sub
  Protected Sub TBLscRMDApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscRMDApproval.Init
    SetToolBar = TBLscRMDApproval
  End Sub
  Protected Sub F_RequestID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RequestID.TextChanged
    Session("F_RequestID") = F_RequestID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub

End Class
