<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_scProject.aspx.vb" Inherits="AF_scProject" title="Add: Projects Involved" %>
<asp:Content ID="CPHscProject" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelscProject" runat="server" Text="&nbsp;Add: Projects Involved"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLscProject" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLscProject"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "scProject"
    runat = "server" />
<asp:FormView ID="FVscProject"
  runat = "server"
  DataKeyNames = "RequestID,SerialNo"
  DataSourceID = "ODSscProject"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgscProject" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RequestID" ForeColor="#CC6633" runat="server" Text="Request ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_RequestID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("RequestID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Request ID."
            ValidationGroup = "scProject"
            onblur= "script_scProject.validate_RequestID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRequestID"
            runat = "server"
            ControlToValidate = "F_RequestID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "scProject"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_RequestID_Display"
            Text='<%# Eval("SC_Request3_RequestRefNo") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERequestID"
            BehaviorID="B_ACERequestID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RequestIDCompletionList"
            TargetControlID="F_RequestID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_scProject.ACERequestID_Selected"
            OnClientPopulating="script_scProject.ACERequestID_Populating"
            OnClientPopulated="script_scProject.ACERequestID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
            ValidationGroup = "scProject"
            onblur= "script_scProject.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "scProject"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_scProject.ACEProjectID_Selected"
            OnClientPopulating="script_scProject.ACEProjectID_Populating"
            OnClientPopulated="script_scProject.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsFromProject" runat="server" Text="Is From Project :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_IsFromProject"
           Checked='<%# Bind("IsFromProject") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSscProject"
  DataObjectTypeName = "SIS.SC.scProject"
  InsertMethod="UZ_scProjectInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.SC.scProject"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
