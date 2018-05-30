Imports System.Web.Script.Serialization
Partial Class GF_scApproval
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/SC_Main/App_Display/DF_scApproval.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RequestID=" & aVal(0) & "&SerialNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVscApproval_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVscApproval.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RequestID As Int32 = GVscApproval.DataKeys(e.CommandArgument).Values("RequestID")  
        Dim SerialNo As Int32 = GVscApproval.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLscApproval.EditUrl & "?RequestID=" & RequestID & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVscApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVscApproval.Init
    DataClassName = "GscApproval"
    SetGridView = GVscApproval
  End Sub
  Protected Sub TBLscApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscApproval.Init
    SetToolBar = TBLscApproval
  End Sub
  Protected Sub F_RequestID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RequestID.TextChanged
    Session("F_RequestID") = F_RequestID.Text
    Session("F_RequestID_Display") = F_RequestID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequestIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SC.scRequest.SelectscRequestAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_RequestID_Display.Text = String.Empty
    If Not Session("F_RequestID_Display") Is Nothing Then
      If Session("F_RequestID_Display") <> String.Empty Then
        F_RequestID_Display.Text = Session("F_RequestID_Display")
      End If
    End If
    F_RequestID.Text = String.Empty
    If Not Session("F_RequestID") Is Nothing Then
      If Session("F_RequestID") <> String.Empty Then
        F_RequestID.Text = Session("F_RequestID")
      End If
    End If
    Dim strScriptRequestID As String = "<script type=""text/javascript""> " & _
      "function ACERequestID_Selected(sender, e) {" & _
      "  var F_RequestID = $get('" & F_RequestID.ClientID & "');" & _
      "  var F_RequestID_Display = $get('" & F_RequestID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_RequestID.value = p[0];" & _
      "  F_RequestID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequestID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequestID", strScriptRequestID)
      End If
    Dim strScriptPopulatingRequestID As String = "<script type=""text/javascript""> " & _
      "function ACERequestID_Populating(o,e) {" & _
      "  var p = $get('" & F_RequestID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACERequestID_Populated(o,e) {" & _
      "  var p = $get('" & F_RequestID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequestIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequestIDPopulating", strScriptPopulatingRequestID)
      End If
    Dim validateScriptRequestID As String = "<script type=""text/javascript"">" & _
      "  function validate_RequestID(o) {" & _
      "    validated_FK_SC_Approval_RequestID_main = true;" & _
      "    validate_FK_SC_Approval_RequestID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateRequestID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateRequestID", validateScriptRequestID)
    End If
    Dim validateScriptFK_SC_Approval_RequestID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_SC_Approval_RequestID(o) {" & _
      "    var value = o.id;" & _
      "    var RequestID = $get('" & F_RequestID.ClientID & "');" & _
      "    try{" & _
      "    if(RequestID.value==''){" & _
      "      if(validated_FK_SC_Approval_RequestID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + RequestID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_SC_Approval_RequestID(value, validated_FK_SC_Approval_RequestID);" & _
      "  }" & _
      "  validated_FK_SC_Approval_RequestID_main = false;" & _
      "  function validated_FK_SC_Approval_RequestID(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_SC_Approval_RequestID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_SC_Approval_RequestID", validateScriptFK_SC_Approval_RequestID)
    End If
  End Sub
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
