Imports System.IO
Imports System.Web.Script.Serialization
Partial Class EF_scRequest
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
  Protected Sub ODSscRequest_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSscRequest.Selected
    Dim tmp As SIS.SC.scRequest = CType(e.ReturnValue, SIS.SC.scRequest)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVscRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscRequest.Init
    DataClassName = "EscRequest"
    SetFormView = FVscRequest
  End Sub
  Protected Sub TBLscRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLscRequest.Init
    SetToolBar = TBLscRequest
  End Sub
  Protected Sub FVscRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVscRequest.PreRender
    TBLscRequest.EnableSave = Editable
    TBLscRequest.EnableDelete = Deleteable
    TBLscRequest.PrintUrl &= Request.QueryString("RequestID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/SC_Main/App_Edit") & "/EF_scRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptscRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptscRequest", mStr)
    End If
    If Not Editable Then
      mp1.Visible = False
      cmdDelF.Visible = False
      cmdDelT.Visible = False
      ma1.Visible = False
      CmdAddA.Visible = False
      CmdDelA.Visible = False
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_SC_Project_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Private Sub cmdAddF_Click(sender As Object, e As EventArgs) Handles cmdAddF.Click
    Dim ProjectID As String = F_ProjectID.Text
    If ProjectID <> "" Then
      Dim tmpProjs As List(Of SIS.SC.scProject) = SIS.SC.scProject.UZ_FscProjectSelectList(0, 99, "", False, "", PrimaryKey)
      Dim Found As Boolean = False
      For Each tmpP As SIS.SC.scProject In tmpProjs
        If tmpP.ProjectID = ProjectID Then
          Found = True
          Exit For
        End If
      Next
      If Not Found Then
        Dim tmpP As New SIS.SC.scProject
        With tmpP
          .RequestID = PrimaryKey
          .ProjectID = ProjectID
          .ElementID = ""
          .Amount = 0
          .IsFromProject = True
        End With
        tmpP = SIS.SC.scProject.InsertData(tmpP)
        fromList.DataBind()
      End If
    End If
  End Sub



  Private Sub cmdAddT_Click(sender As Object, e As EventArgs) Handles cmdAddT.Click
    Dim ProjectID As String = F_ProjectID.Text
    If ProjectID <> "" Then
      Dim tmpProjs As List(Of SIS.SC.scProject) = SIS.SC.scProject.UZ_TscProjectSelectList(0, 99, "", False, "", PrimaryKey)
      Dim Found As Boolean = False
      For Each tmpP As SIS.SC.scProject In tmpProjs
        If tmpP.ProjectID = ProjectID Then
          Found = True
          Exit For
        End If
      Next
      If Not Found Then
        Dim tmpP As New SIS.SC.scProject
        With tmpP
          .RequestID = PrimaryKey
          .ProjectID = ProjectID
          .ElementID = ""
          .Amount = 0
          .IsFromProject = False
        End With
        tmpP = SIS.SC.scProject.InsertData(tmpP)
        toList.DataBind()
      End If
    End If

  End Sub
  Private Sub cmdDelF_Click(sender As Object, e As EventArgs) Handles cmdDelF.Click
    Dim isDeleted As Boolean = False
    For Each itm As ListItem In fromList.Items
      If itm.Selected Then
        Dim aVal() As String = itm.Value.Split("|".ToCharArray)
        Dim tmp As New SIS.SC.scProject
        With tmp
          .RequestID = aVal(0)
          .SerialNo = aVal(1)
        End With
        isDeleted = True
        SIS.SC.scProject.scProjectDelete(tmp)
      End If
    Next
    If isDeleted Then
      fromList.DataBind()
    End If
  End Sub

  Private Sub cmdDelT_Click(sender As Object, e As EventArgs) Handles cmdDelT.Click
    Dim isDeleted As Boolean = False
    For Each itm As ListItem In toList.Items
      If itm.Selected Then
        Dim aVal() As String = itm.Value.Split("|".ToCharArray)
        Dim tmp As New SIS.SC.scProject
        With tmp
          .RequestID = aVal(0)
          .SerialNo = aVal(1)
        End With
        isDeleted = True
        SIS.SC.scProject.scProjectDelete(tmp)
      End If
    Next
    If isDeleted Then
      toList.DataBind()
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ApproverIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_SC_Approval_ApproverID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ApproverID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(ApproverID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Private Sub CmdAddA_Click(sender As Object, e As EventArgs) Handles CmdAddA.Click
    Dim ApproverID As String = F_ApproverID.Text
    If ApproverID <> "" Then
      Dim tmpAs As List(Of SIS.SC.scApproval) = SIS.SC.scApproval.UZ_scApprovalSelectList(0, 99, "", False, "", PrimaryKey)
      Dim Found As Boolean = False
      For Each tmpA As SIS.SC.scApproval In tmpAs
        If tmpA.ApproverID = ApproverID Then
          Found = True
          Exit For
        End If
      Next
      If Not Found Then
        Dim tmpA As New SIS.SC.scApproval
        With tmpA
          .RequestID = PrimaryKey
          .ApproverID = ApproverID
          .StatusID = scAprStates.Free
        End With
        tmpA = SIS.SC.scApproval.InsertData(tmpA)
        ApproverList.DataBind()
      End If
    End If
  End Sub

  Private Sub CmdDelA_Click(sender As Object, e As EventArgs) Handles CmdDelA.Click
    Dim isDeleted As Boolean = False
    For Each itm As ListItem In ApproverList.Items
      If itm.Selected Then
        Dim aVal() As String = itm.Value.Split("|".ToCharArray)
        Dim tmp As New SIS.SC.scApproval
        With tmp
          .RequestID = aVal(0)
          .SerialNo = aVal(1)
        End With
        isDeleted = True
        SIS.SC.scApproval.scApprovalDelete(tmp)
      End If
    Next
    If isDeleted Then
      ApproverList.DataBind()
    End If
  End Sub
  Private Sub FVscRequest_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVscRequest.ItemCommand
    If e.CommandName.ToLower = "tmplupload" Then
      Try
        Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
        Dim RequestID As String = aVal(0)
        With F_FileUpload
          If .HasFile Then
            Dim tmpPath As String = ConfigurationManager.AppSettings("SanctionRequestPath")
            If Not IO.Directory.Exists(tmpPath) Then
              tmpPath = ConfigurationManager.AppSettings("SanctionRequestPath1")
            End If
            Dim tmpName As String = IO.Path.GetRandomFileName()
            .SaveAs(tmpPath & "\\" & tmpName)
            Dim oReq As SIS.SC.scRequest = SIS.SC.scRequest.scRequestGetByID(RequestID)
            oReq.FileName = .FileName
            oReq.DiskFileName = tmpPath & "\\" & tmpName
            SIS.SC.scRequest.UpdateData(oReq)
            FVscRequest.DataBind()
          End If
        End With
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "tmpdelete" Then
      Try
        Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
        Dim RequestID As String = aVal(0)
        Dim oReq As SIS.SC.scRequest = SIS.SC.scRequest.scRequestGetByID(RequestID)
        If oReq.FileName <> "" Then
          If IO.File.Exists(oReq.DiskFileName) Then
            Try
              IO.File.Delete(oReq.DiskFileName)
            Catch ex As Exception
            End Try
          End If
          oReq.FileName = ""
          SIS.SC.scRequest.UpdateData(oReq)
          FVscRequest.DataBind()
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
End Class
