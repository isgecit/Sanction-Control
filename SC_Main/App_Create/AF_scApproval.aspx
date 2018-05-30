<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_scApproval.aspx.vb" Inherits="AF_scApproval" title="Add: Required Approvals" %>
<asp:Content ID="CPHscApproval" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelscApproval" runat="server" Text="&nbsp;Add: Required Approvals"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLscApproval" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLscApproval"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "scApproval"
    runat = "server" />
<asp:FormView ID="FVscApproval"
  runat = "server"
  DataKeyNames = "RequestID,SerialNo"
  DataSourceID = "ODSscApproval"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgscApproval" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "scApproval"
            onblur= "script_scApproval.validate_RequestID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRequestID"
            runat = "server"
            ControlToValidate = "F_RequestID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "scApproval"
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
            OnClientItemSelected="script_scApproval.ACERequestID_Selected"
            OnClientPopulating="script_scApproval.ACERequestID_Populating"
            OnClientPopulated="script_scApproval.ACERequestID_Populated"
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
          <asp:Label ID="L_ApproverID" runat="server" Text="Approver :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ApproverID"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("ApproverID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Approver."
            ValidationGroup = "scApproval"
            onblur= "script_scApproval.validate_ApproverID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVApproverID"
            runat = "server"
            ControlToValidate = "F_ApproverID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "scApproval"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ApproverID_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEApproverID"
            BehaviorID="B_ACEApproverID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ApproverIDCompletionList"
            TargetControlID="F_ApproverID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_scApproval.ACEApproverID_Selected"
            OnClientPopulating="script_scApproval.ACEApproverID_Populating"
            OnClientPopulated="script_scApproval.ACEApproverID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSscApproval"
  DataObjectTypeName = "SIS.SC.scApproval"
  InsertMethod="UZ_scApprovalInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.SC.scApproval"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
