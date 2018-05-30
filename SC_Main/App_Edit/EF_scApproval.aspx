<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_scApproval.aspx.vb" Inherits="EF_scApproval" title="Edit: Required Approvals" %>
<asp:Content ID="CPHscApproval" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelscApproval" runat="server" Text="&nbsp;Edit: Required Approvals"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLscApproval" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLscApproval"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "scApproval"
    runat = "server" />
<asp:FormView ID="FVscApproval"
  runat = "server"
  DataKeyNames = "RequestID,SerialNo"
  DataSourceID = "ODSscApproval"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RequestID" runat="server" ForeColor="#CC6633" Text="Request ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_RequestID"
            Width="88px"
            Text='<%# Bind("RequestID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Request ID."
            Runat="Server" />
          <asp:Label
            ID = "F_RequestID_Display"
            Text='<%# Eval("SC_Request3_RequestRefNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApproverID" runat="server" Text="Approver :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ApproverID"
            CssClass = "myfktxt"
            Text='<%# Bind("ApproverID") %>'
            AutoCompleteType = "None"
            Width="72px"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovedOn" runat="server" Text="Approved On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedOn"
            Text='<%# Bind("ApprovedOn") %>'
            ToolTip="Value of Approved On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_StatusID"
            Width="24px"
            Text='<%# Bind("StatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text='<%# Eval("SC_ApprovalStatus2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApproverRemarks" runat="server" Text="Approver Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApproverRemarks"
            Text='<%# Bind("ApproverRemarks") %>'
            ToolTip="Value of Approver Remarks."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSscApproval"
  DataObjectTypeName = "SIS.SC.scApproval"
  SelectMethod = "scApprovalGetByID"
  UpdateMethod="UZ_scApprovalUpdate"
  DeleteMethod="UZ_scApprovalDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.SC.scApproval"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestID" Name="RequestID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
