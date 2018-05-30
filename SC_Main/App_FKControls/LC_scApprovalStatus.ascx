<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_scApprovalStatus.ascx.vb" Inherits="LC_scApprovalStatus" %>
<asp:DropDownList 
  ID = "DDLscApprovalStatus"
  DataSourceID = "OdsDdlscApprovalStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorscApprovalStatus"
  Runat = "server" 
  ControlToValidate = "DDLscApprovalStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlscApprovalStatus"
  TypeName = "SIS.SC.scApprovalStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "scApprovalStatusSelectList"
  Runat="server" />
