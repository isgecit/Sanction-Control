<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_scRAuditApproval.aspx.vb" Inherits="GF_scRAuditApproval" title="Maintain List: Sanction Request Audit Clearance" %>
<asp:Content ID="CPHscRAuditApproval" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelscRAuditApproval" runat="server" Text="&nbsp;List: Sanction Request Audit Clearance"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLscRAuditApproval" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLscRAuditApproval"
      ToolType = "lgNMGrid"
      EditUrl = "~/SC_Main/App_Edit/EF_scRAuditApproval.aspx"
      EnableAdd = "False"
      ValidationGroup = "scRAuditApproval"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSscRAuditApproval" runat="server" AssociatedUpdatePanelID="UPNLscRAuditApproval" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RequestID" runat="server" Text="Request ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_RequestID"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEERequestID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_RequestID" />
          <AJX:MaskedEditValidator 
            ID = "MEVRequestID"
            runat = "server"
            ControlToValidate = "F_RequestID"
            ControlExtender = "MEERequestID"
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <script type="text/javascript"> 
   var script_AuditorRemarks = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVscRAuditApproval" SkinID="gv_silver" runat="server" DataSourceID="ODSscRAuditApproval" DataKeyNames="RequestID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request Ref. No" SortExpression="RequestRefNo">
          <ItemTemplate>
            <asp:Label ID="LabelRequestRefNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestRefNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Justification" SortExpression="Remarks">
          <ItemTemplate>
            <asp:Label ID="LabelRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Remarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Submitted By" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_SubmittedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SubmittedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Submitted On" SortExpression="SubmittedOn">
          <ItemTemplate>
            <asp:Label ID="LabelSubmittedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SubmittedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="SC_Status4_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("SC_Status4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Auditor Remarks" SortExpression="AuditorRemarks">
          <ItemTemplate>
          <asp:TextBox ID="F_AuditorRemarks"
            Text='<%# Bind("AuditorRemarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Auditor Remarks."
            MaxLength="500"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVAuditorRemarks"
            runat = "server"
            ControlToValidate = "F_AuditorRemarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "Reject" & Container.DataItemIndex %>'
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approve">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Approve" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Approve record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reject">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Reject" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Reject record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSscRAuditApproval"
      runat = "server"
      DataObjectTypeName = "SIS.SC.scRAuditApproval"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_scRAuditApprovalSelectList"
      TypeName = "SIS.SC.scRAuditApproval"
      SelectCountMethod = "scRAuditApprovalSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_RequestID" PropertyName="Text" Name="RequestID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVscRAuditApproval" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_RequestID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
