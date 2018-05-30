<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_scRMDApproval.ascx.vb" Inherits="LC_scRMDApproval" %>
<asp:DropDownList 
  ID = "DDLscRMDApproval"
  DataSourceID = "OdsDdlscRMDApproval"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorscRMDApproval"
  Runat = "server" 
  ControlToValidate = "DDLscRMDApproval"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlscRMDApproval"
  TypeName = "SIS.SC.scRMDApproval"
  SortParameterName = "OrderBy"
  SelectMethod = "scRMDApprovalSelectList"
  Runat="server" />
