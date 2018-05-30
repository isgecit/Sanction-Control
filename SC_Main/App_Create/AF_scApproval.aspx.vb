Partial Class AF_scApproval
  Inherits SIS.SYS.InsertBase
  Protected Sub FVscApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscApproval.Init
    DataClassName = "AscApproval"
    SetFormView = FVscApproval
  End Sub
  Protected Sub TBLscApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscApproval.Init
    SetToolBar = TBLscApproval
  End Sub
  Protected Sub FVscApproval_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscApproval.DataBound
    SIS.SC.scApproval.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVscApproval_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscApproval.PreRender
    Dim oF_RequestID_Display As Label  = FVscApproval.FindControl("F_RequestID_Display")
    oF_RequestID_Display.Text = String.Empty
    If Not Session("F_RequestID_Display") Is Nothing Then
      If Session("F_RequestID_Display") <> String.Empty Then
        oF_RequestID_Display.Text = Session("F_RequestID_Display")
      End If
    End If
    Dim oF_RequestID As TextBox  = FVscApproval.FindControl("F_RequestID")
    oF_RequestID.Enabled = True
    oF_RequestID.Text = String.Empty
    If Not Session("F_RequestID") Is Nothing Then
      If Session("F_RequestID") <> String.Empty Then
        oF_RequestID.Text = Session("F_RequestID")
      End If
    End If
    Dim oF_ApproverID_Display As Label  = FVscApproval.FindControl("F_ApproverID_Display")
    Dim oF_ApproverID As TextBox  = FVscApproval.FindControl("F_ApproverID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/SC_Main/App_Create") & "/AF_scApproval.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptscApproval") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptscApproval", mStr)
    End If
    If Request.QueryString("RequestID") IsNot Nothing Then
      CType(FVscApproval.FindControl("F_RequestID"), TextBox).Text = Request.QueryString("RequestID")
      CType(FVscApproval.FindControl("F_RequestID"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVscApproval.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVscApproval.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequestIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SC.scRequest.SelectscRequestAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ApproverIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_SC_Approval_ApproverID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ApproverID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(ApproverID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_SC_Approval_RequestID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim RequestID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.SC.scRequest = SIS.SC.scRequest.scRequestGetByID(RequestID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
