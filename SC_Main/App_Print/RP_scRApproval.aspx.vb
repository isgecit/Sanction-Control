Partial Class RP_scRApproval
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/SC_Main/App_Display/DF_scRApproval.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RequestID=" & aVal(0) & "&SerialNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim RequestID As Int32 = CType(aVal(0),Int32)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.SC.scRApproval = SIS.SC.scRApproval.scRApprovalGetByID(RequestID,SerialNo)
    Dim oTblscRApproval As New Table
    oTblscRApproval.Width = 1000
    oTblscRApproval.GridLines = GridLines.Both
    oTblscRApproval.Style.Add("margin-top", "15px")
    oTblscRApproval.Style.Add("margin-left", "10px")
    Dim oColscRApproval As TableCell = Nothing
    Dim oRowscRApproval As TableRow = Nothing
    oRowscRApproval = New TableRow
    oColscRApproval = New TableCell
    oColscRApproval.Text = "Request ID"
    oColscRApproval.Font.Bold = True
    oRowscRApproval.Cells.Add(oColscRApproval)
    oColscRApproval = New TableCell
    oColscRApproval.Text = oVar.RequestID
      oColscRApproval.Style.Add("text-align","right")
    oRowscRApproval.Cells.Add(oColscRApproval)
    oColscRApproval = New TableCell
    oColscRApproval.Text = oVar.SC_Request3_RequestRefNo
      oColscRApproval.Style.Add("text-align","right")
    oRowscRApproval.Cells.Add(oColscRApproval)
    oColscRApproval = New TableCell
    oColscRApproval.Text = "Serial No"
    oColscRApproval.Font.Bold = True
    oRowscRApproval.Cells.Add(oColscRApproval)
    oColscRApproval = New TableCell
    oColscRApproval.Text = oVar.SerialNo
      oColscRApproval.Style.Add("text-align","right")
    oColscRApproval.ColumnSpan = "2"
    oRowscRApproval.Cells.Add(oColscRApproval)
    oTblscRApproval.Rows.Add(oRowscRApproval)
    form1.Controls.Add(oTblscRApproval)
  End Sub
End Class
