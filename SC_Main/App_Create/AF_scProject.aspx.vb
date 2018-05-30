Partial Class AF_scProject
  Inherits SIS.SYS.InsertBase
  Protected Sub FVscProject_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscProject.Init
    DataClassName = "AscProject"
    SetFormView = FVscProject
  End Sub
  Protected Sub TBLscProject_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscProject.Init
    SetToolBar = TBLscProject
  End Sub
  Protected Sub FVscProject_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscProject.DataBound
    SIS.SC.scProject.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVscProject_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscProject.PreRender
    Dim oF_RequestID_Display As Label  = FVscProject.FindControl("F_RequestID_Display")
    oF_RequestID_Display.Text = String.Empty
    If Not Session("F_RequestID_Display") Is Nothing Then
      If Session("F_RequestID_Display") <> String.Empty Then
        oF_RequestID_Display.Text = Session("F_RequestID_Display")
      End If
    End If
    Dim oF_RequestID As TextBox  = FVscProject.FindControl("F_RequestID")
    oF_RequestID.Enabled = True
    oF_RequestID.Text = String.Empty
    If Not Session("F_RequestID") Is Nothing Then
      If Session("F_RequestID") <> String.Empty Then
        oF_RequestID.Text = Session("F_RequestID")
      End If
    End If
    Dim oF_ProjectID_Display As Label  = FVscProject.FindControl("F_ProjectID_Display")
    Dim oF_ProjectID As TextBox  = FVscProject.FindControl("F_ProjectID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/SC_Main/App_Create") & "/AF_scProject.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptscProject") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptscProject", mStr)
    End If
    If Request.QueryString("RequestID") IsNot Nothing Then
      CType(FVscProject.FindControl("F_RequestID"), TextBox).Text = Request.QueryString("RequestID")
      CType(FVscProject.FindControl("F_RequestID"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVscProject.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVscProject.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequestIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SC.scRequest.SelectscRequestAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_SC_Project_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_SC_Project_RequestID(ByVal value As String) As String
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
