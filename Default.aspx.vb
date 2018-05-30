Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class LGDefault
  Inherits System.Web.UI.Page

  Public Property abcd As String = ""


  'Private Sub LGDefault_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
  '  If Page.User.Identity.IsAuthenticated Then

  '    Dim str As String = ""
  '    str &= "|~/TA Bill Entry Process Ver_1.pdf|TA Bill Entry HELP"
  '    str &= "|~/TA_Main/App_Forms/GF_taBH.aspx|TA Claim Form"
  '    str &= "|~/Perks Claim Process Ver_1.pdf|Perks Claim HELP"
  '    str &= "|~/NPRK_Main/App_Forms/GF_nprkUserClaims.aspx|Perks Claim Form"
  '    'str &= "|~/NPRK_Main/App_Print/RP_nprkUserEntitlementSheet.aspx'|Entitlement Sheet"
  '    'str &= "|#alert('hi');return false;|Entitlement Sheet"
  '    str &= "|#show_entitlement();|Entitlement Sheet"
  '    str &= "|#show_perkref();|PERK OPENING BALANCE REFERENCE"
  '    str &= "|#show_imprest('" & HttpContext.Current.Session("LoginID") & "');|Imprest Detail"
  '    'str &= "|~/ATN_Main/App_Forms/GT_atnRegularizeTSAttendance.aspx|Regularize TS"
  '    'str &= "|~/ATN_Main/App_View/GD_atnTimeShort.aspx|Time Short"
  '    'str &= "|~/ATN_Main/App_View/GD_atnAppliedApplications.aspx|My Application"
  '    'str &= "|~/ATN_Main/App_Forms/GF_atnApproverChangeRequest.aspx|Change Approver"
  '    'str &= "|~/ATN_Main/App_Reports/GP_atnPrintLeavecard.aspx|Leave Card"
  '    'str &= "|~/ATN_Main/App_View/GD_atnRules.aspx|Leave Rules"
  '    'str &= "|~/TA_Main/App_Forms/GF_taTPUserInvoicing.aspx|Travel Invoice"

  '    str = str.Replace("~", HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath)
  '    Dim astr() As String = str.Split("|".ToCharArray)

  '    abcd &= "<ul class='dashboardIcons'>"
  '    For i As Integer = 1 To astr.Length - 1 Step 2
  '      abcd &= "<fieldset id='fs" & i & "' class='ui-widget-content wp_page'>"
  '      'abcd &= "<legend>"
  '      'abcd &= "    <span>&nbsp;" & astr(i + 1) & "</span>"
  '      'abcd &= "</legend>"
  '      abcd &= "<div class='wp_pagedata'>"
  '      abcd &= "  <li title='" & astr(i + 1) & "'>"
  '      abcd &= "    <div class='frame'>"
  '      If astr(i).StartsWith("#") Then
  '        abcd &= "      <div onclick=""" & astr(i).Substring(1) & """>"
  '        abcd &= "        <img src='Images/mnu_" & i & ".jpg' width='50' height='50' alt=''>"
  '        abcd &= "        <span>" & astr(i + 1) & "</span>"
  '        abcd &= "      </div>"
  '      Else
  '        abcd &= "      <a href='" & astr(i) & "'>"
  '        abcd &= "        <img src='Images/mnu_" & i & ".jpg' width='50' height='50' alt=''>"
  '        abcd &= "        <span>" & astr(i + 1) & "</span>"
  '        abcd &= "      </a>"
  '      End If
  '      abcd &= "     </div>"
  '      abcd &= "  </li>"
  '      abcd &= "</div>"
  '      abcd &= "</fieldset>"
  '    Next
  '    abcd &= "</ul>"
  '  End If

  'End Sub
End Class
