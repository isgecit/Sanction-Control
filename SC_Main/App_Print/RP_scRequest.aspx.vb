Partial Class RP_scRequest
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/SC_Main/App_Display/DF_scRequest.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RequestID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim RequestID As Int32 = CType(aVal(0),Int32)
    Dim oVar As SIS.SC.scRequest = SIS.SC.scRequest.scRequestGetByID(RequestID)
    Dim oTblscRequest As New Table
    oTblscRequest.Width = 1000
    oTblscRequest.GridLines = GridLines.Both
    oTblscRequest.Style.Add("margin-top", "15px")
    oTblscRequest.Style.Add("margin-left", "10px")
    Dim oColscRequest As TableCell = Nothing
    Dim oRowscRequest As TableRow = Nothing
    oRowscRequest = New TableRow
    oColscRequest = New TableCell
    oColscRequest.Text = "Request ID"
    oColscRequest.Font.Bold = True
    oRowscRequest.Cells.Add(oColscRequest)
    oColscRequest = New TableCell
    oColscRequest.Text = oVar.RequestID
      oColscRequest.Style.Add("text-align","right")
    oColscRequest.ColumnSpan = "2"
    oRowscRequest.Cells.Add(oColscRequest)
    oColscRequest = New TableCell
    oColscRequest.Text = "Request Ref. No"
    oColscRequest.Font.Bold = True
    oRowscRequest.Cells.Add(oColscRequest)
    oColscRequest = New TableCell
    oColscRequest.Text = oVar.RequestRefNo
      oColscRequest.Style.Add("text-align","left")
    oColscRequest.ColumnSpan = "2"
    oRowscRequest.Cells.Add(oColscRequest)
    oTblscRequest.Rows.Add(oRowscRequest)
    form1.Controls.Add(oTblscRequest)
      Dim oTblscProject As Table = Nothing
      Dim oRowscProject As TableRow = Nothing
      Dim oColscProject As TableCell = Nothing
    Dim oscProjects As List(Of SIS.SC.scProject) = SIS.SC.scProject.UZ_FscProjectSelectList(0, 999, "", False, "", oVar.RequestID)
    If oscProjects.Count > 0 Then
      Dim oTblhscProject As Table = New Table
      oTblhscProject.Width = 1000
      oTblhscProject.Style.Add("margin-top", "15px")
      oTblhscProject.Style.Add("margin-left", "10px")
      oTblhscProject.Style.Add("margin-right", "10px")
      Dim oRowhscProject As TableRow = New TableRow
      Dim oColhscProject As TableCell = New TableCell
      oColhscProject.Font.Bold = True
      oColhscProject.Font.UnderLine = True
      oColhscProject.Font.Size = 10
      oColhscProject.CssClass = "grpHD"
      oColhscProject.Text = "Projects Involved"
      oRowhscProject.Cells.Add(oColhscProject)
      oTblhscProject.Rows.Add(oRowhscProject)
      form1.Controls.Add(oTblhscProject)
      oTblscProject = New Table
      oTblscProject.Width = 1000
      oTblscProject.GridLines = GridLines.Both
      oTblscProject.Style.Add("margin-left", "10px")
      oTblscProject.Style.Add("margin-right", "10px")
      oRowscProject = New TableRow
      oColscProject = New TableCell
      oColscProject.Text = "Request ID"
      oColscProject.Font.Bold = True
      oColscProject.CssClass = "colHD"
      oColscProject.Style.Add("text-align","right")
      oRowscProject.Cells.Add(oColscProject)
      oColscProject = New TableCell
      oColscProject.Text = "Serial No"
      oColscProject.Font.Bold = True
      oColscProject.CssClass = "colHD"
      oColscProject.Style.Add("text-align","right")
      oRowscProject.Cells.Add(oColscProject)
      oColscProject = New TableCell
      oColscProject.Text = "Project ID"
      oColscProject.Font.Bold = True
      oColscProject.CssClass = "colHD"
      oColscProject.Style.Add("text-align","left")
      oRowscProject.Cells.Add(oColscProject)
      oColscProject = New TableCell
      oColscProject.Text = "Element ID"
      oColscProject.Font.Bold = True
      oColscProject.CssClass = "colHD"
      oColscProject.Style.Add("text-align","left")
      oRowscProject.Cells.Add(oColscProject)
      oColscProject = New TableCell
      oColscProject.Text = "Amount"
      oColscProject.Font.Bold = True
      oColscProject.CssClass = "colHD"
      oColscProject.Style.Add("text-align","right")
      oRowscProject.Cells.Add(oColscProject)
      oColscProject = New TableCell
      oColscProject.Text = "Is From Project"
      oColscProject.Font.Bold = True
      oColscProject.CssClass = "colHD"
      oColscProject.Style.Add("text-align","center")
      oRowscProject.Cells.Add(oColscProject)
      oTblscProject.Rows.Add(oRowscProject)
      For Each oscProject As SIS.SC.scProject In oscProjects
        oRowscProject = New TableRow
        oColscProject = New TableCell
        oColscProject.Text = oscProject.SC_Request3_RequestRefNo
        oColscProject.CssClass = "rowHD"
      oColscProject.Style.Add("text-align","right")
        oRowscProject.Cells.Add(oColscProject)
        oColscProject = New TableCell
        oColscProject.CssClass = "rowHD"
        oColscProject.Text = oscProject.SerialNo
      oColscProject.Style.Add("text-align","right")
        oRowscProject.Cells.Add(oColscProject)
        oColscProject = New TableCell
        oColscProject.Text = oscProject.IDM_Projects1_Description
        oColscProject.CssClass = "rowHD"
      oColscProject.Style.Add("text-align","left")
        oRowscProject.Cells.Add(oColscProject)
        oColscProject = New TableCell
        oColscProject.Text = oscProject.IDM_WBS2_Description
        oColscProject.CssClass = "rowHD"
      oColscProject.Style.Add("text-align","left")
        oRowscProject.Cells.Add(oColscProject)
        oColscProject = New TableCell
        oColscProject.CssClass = "rowHD"
        oColscProject.Text = oscProject.Amount
      oColscProject.Style.Add("text-align","right")
        oRowscProject.Cells.Add(oColscProject)
        oColscProject = New TableCell
        oColscProject.CssClass = "rowHD"
        oColscProject.Text = IIf(oscProject.IsFromProject, "YES", "NO")
      oColscProject.Style.Add("text-align","center")
        oRowscProject.Cells.Add(oColscProject)
        oTblscProject.Rows.Add(oRowscProject)
      Next
      form1.Controls.Add(oTblscProject)
    End If
      Dim oTblscApproval As Table = Nothing
      Dim oRowscApproval As TableRow = Nothing
      Dim oColscApproval As TableCell = Nothing
    Dim oscApprovals As List(Of SIS.SC.scApproval) = SIS.SC.scApproval.UZ_scApprovalSelectList(0, 999, "", False, "", oVar.RequestID)
    If oscApprovals.Count > 0 Then
      Dim oTblhscApproval As Table = New Table
      oTblhscApproval.Width = 1000
      oTblhscApproval.Style.Add("margin-top", "15px")
      oTblhscApproval.Style.Add("margin-left", "10px")
      oTblhscApproval.Style.Add("margin-right", "10px")
      Dim oRowhscApproval As TableRow = New TableRow
      Dim oColhscApproval As TableCell = New TableCell
      oColhscApproval.Font.Bold = True
      oColhscApproval.Font.UnderLine = True
      oColhscApproval.Font.Size = 10
      oColhscApproval.CssClass = "grpHD"
      oColhscApproval.Text = "Required Approvals"
      oRowhscApproval.Cells.Add(oColhscApproval)
      oTblhscApproval.Rows.Add(oRowhscApproval)
      form1.Controls.Add(oTblhscApproval)
      oTblscApproval = New Table
      oTblscApproval.Width = 1000
      oTblscApproval.GridLines = GridLines.Both
      oTblscApproval.Style.Add("margin-left", "10px")
      oTblscApproval.Style.Add("margin-right", "10px")
      oRowscApproval = New TableRow
      oColscApproval = New TableCell
      oColscApproval.Text = "Request ID"
      oColscApproval.Font.Bold = True
      oColscApproval.CssClass = "colHD"
      oColscApproval.Style.Add("text-align","right")
      oRowscApproval.Cells.Add(oColscApproval)
      oColscApproval = New TableCell
      oColscApproval.Text = "Serial No"
      oColscApproval.Font.Bold = True
      oColscApproval.CssClass = "colHD"
      oColscApproval.Style.Add("text-align","right")
      oRowscApproval.Cells.Add(oColscApproval)
      oColscApproval = New TableCell
      oColscApproval.Text = "Approver"
      oColscApproval.Font.Bold = True
      oColscApproval.CssClass = "colHD"
      oColscApproval.Style.Add("text-align","left")
      oRowscApproval.Cells.Add(oColscApproval)
      oColscApproval = New TableCell
      oColscApproval.Text = "Status"
      oColscApproval.Font.Bold = True
      oColscApproval.CssClass = "colHD"
      oColscApproval.Style.Add("text-align","left")
      oRowscApproval.Cells.Add(oColscApproval)
      oColscApproval = New TableCell
      oColscApproval.Text = "Approver Remarks"
      oColscApproval.Font.Bold = True
      oColscApproval.CssClass = "colHD"
      oColscApproval.Style.Add("text-align","left")
      oRowscApproval.Cells.Add(oColscApproval)
      oColscApproval = New TableCell
      oColscApproval.Text = "Approved On"
      oColscApproval.Font.Bold = True
      oColscApproval.CssClass = "colHD"
      oColscApproval.Style.Add("text-align","center")
      oRowscApproval.Cells.Add(oColscApproval)
      oTblscApproval.Rows.Add(oRowscApproval)
      For Each oscApproval As SIS.SC.scApproval In oscApprovals
        oRowscApproval = New TableRow
        oColscApproval = New TableCell
        oColscApproval.Text = oscApproval.SC_Request3_RequestRefNo
        oColscApproval.CssClass = "rowHD"
      oColscApproval.Style.Add("text-align","right")
        oRowscApproval.Cells.Add(oColscApproval)
        oColscApproval = New TableCell
        oColscApproval.CssClass = "rowHD"
        oColscApproval.Text = oscApproval.SerialNo
      oColscApproval.Style.Add("text-align","right")
        oRowscApproval.Cells.Add(oColscApproval)
        oColscApproval = New TableCell
        oColscApproval.Text = oscApproval.aspnet_users1_UserFullName
        oColscApproval.CssClass = "rowHD"
      oColscApproval.Style.Add("text-align","left")
        oRowscApproval.Cells.Add(oColscApproval)
        oColscApproval = New TableCell
        oColscApproval.Text = oscApproval.SC_ApprovalStatus2_Description
        oColscApproval.CssClass = "rowHD"
      oColscApproval.Style.Add("text-align","left")
        oRowscApproval.Cells.Add(oColscApproval)
        oColscApproval = New TableCell
        oColscApproval.CssClass = "rowHD"
        oColscApproval.Text = oscApproval.ApproverRemarks
      oColscApproval.Style.Add("text-align","left")
        oRowscApproval.Cells.Add(oColscApproval)
        oColscApproval = New TableCell
        oColscApproval.CssClass = "rowHD"
        oColscApproval.Text = oscApproval.ApprovedOn
      oColscApproval.Style.Add("text-align","center")
        oRowscApproval.Cells.Add(oColscApproval)
        oTblscApproval.Rows.Add(oRowscApproval)
      Next
      form1.Controls.Add(oTblscApproval)
    End If
  End Sub
End Class
