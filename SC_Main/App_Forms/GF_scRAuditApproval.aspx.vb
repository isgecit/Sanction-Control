Imports System.Web.Script.Serialization
Partial Class GF_scRAuditApproval
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/SC_Main/App_Display/DF_scRAuditApproval.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RequestID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVscRAuditApproval_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVscRAuditApproval.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RequestID As Int32 = GVscRAuditApproval.DataKeys(e.CommandArgument).Values("RequestID")  
        Dim RedirectUrl As String = TBLscRAuditApproval.EditUrl & "?RequestID=" & RequestID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim AuditorRemarks As String = CType(GVscRAuditApproval.Rows(e.CommandArgument).FindControl("F_AuditorRemarks"),TextBox).Text
        Dim RequestID As Int32 = GVscRAuditApproval.DataKeys(e.CommandArgument).Values("RequestID")  
        SIS.SC.scRAuditApproval.ApproveWF(RequestID, AuditorRemarks)
        GVscRAuditApproval.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim AuditorRemarks As String = CType(GVscRAuditApproval.Rows(e.CommandArgument).FindControl("F_AuditorRemarks"),TextBox).Text
        Dim RequestID As Int32 = GVscRAuditApproval.DataKeys(e.CommandArgument).Values("RequestID")  
        SIS.SC.scRAuditApproval.RejectWF(RequestID, AuditorRemarks)
        GVscRAuditApproval.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVscRAuditApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVscRAuditApproval.Init
    DataClassName = "GscRAuditApproval"
    SetGridView = GVscRAuditApproval
  End Sub
  Protected Sub TBLscRAuditApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscRAuditApproval.Init
    SetToolBar = TBLscRAuditApproval
  End Sub
  Protected Sub F_RequestID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RequestID.TextChanged
    Session("F_RequestID") = F_RequestID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub

End Class
