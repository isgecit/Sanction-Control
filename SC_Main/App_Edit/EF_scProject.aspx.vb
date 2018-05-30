Imports System.Web.Script.Serialization
Partial Class EF_scProject
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
  Protected Sub ODSscProject_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSscProject.Selected
    Dim tmp As SIS.SC.scProject = CType(e.ReturnValue, SIS.SC.scProject)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVscProject_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscProject.Init
    DataClassName = "EscProject"
    SetFormView = FVscProject
  End Sub
  Protected Sub TBLscProject_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscProject.Init
    SetToolBar = TBLscProject
  End Sub
  Protected Sub FVscProject_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscProject.PreRender
    TBLscProject.EnableSave = Editable
    TBLscProject.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/SC_Main/App_Edit") & "/EF_scProject.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptscProject") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptscProject", mStr)
    End If
  End Sub
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

End Class
