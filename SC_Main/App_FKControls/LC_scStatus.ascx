<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_scStatus.ascx.vb" Inherits="LC_scStatus" %>
<asp:DropDownList 
  ID = "DDLscStatus"
  DataSourceID = "OdsDdlscStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorscStatus"
  Runat = "server" 
  ControlToValidate = "DDLscStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlscStatus"
  TypeName = "SIS.SC.scStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "scStatusSelectList"
  Runat="server" />
