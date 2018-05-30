Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization

Partial Class scdownload
  Inherits System.Web.UI.Page
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim docPK As String = ""
    Dim filePK As String = ""
    Dim downloadType As Integer = 0
    '0=Template
    '1=Attachement
    Dim val() As String = Nothing
    Dim Value As String = ""
    If Request.QueryString("req") IsNot Nothing Then
      Value = Request.QueryString("req")
      DownloadAgenda(Value)
    End If
  End Sub

#Region " AGENDA "

  Private Sub DownloadAgenda(ByVal Value As String)

    Dim aVal() As String = Value.Split("|".ToCharArray)

    Dim RequestID As String = ""

    Try
      RequestID = aVal(0)
    Catch ex As Exception
    End Try
    If RequestID = String.Empty Then
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Request ID Not Found.") & "');", True)
      HttpContext.Current.Server.ScriptTimeout = st
      Exit Sub
    End If
    Dim oReq As SIS.SC.scRequest = SIS.SC.scRequest.scRequestGetByID(RequestID)
    If oReq.FileName <> "" Then
      If IO.File.Exists(oReq.DiskFileName) Then
        Response.Clear()
        Response.AppendHeader("content-disposition", "attachment; filename=" & oReq.FileName)
        Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(oReq.FileName)
        Response.WriteFile(oReq.DiskFileName)
        HttpContext.Current.Server.ScriptTimeout = st
        Response.End()
      Else
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("File NOT Present in Vault.") & "');", True)
        HttpContext.Current.Server.ScriptTimeout = st
        Exit Sub
      End If
    End If
  End Sub
#End Region
End Class
