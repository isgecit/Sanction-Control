<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_scRequest.ascx.vb" Inherits="LC_scRequest" %>
<asp:DropDownList 
  ID = "DDLscRequest"
  DataSourceID = "OdsDdlscRequest"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorscRequest"
  Runat = "server" 
  ControlToValidate = "DDLscRequest"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlscRequest"
  TypeName = "SIS.SC.scRequest"
  SortParameterName = "OrderBy"
  SelectMethod = "scRequestSelectList"
  Runat="server" />
