<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_scProject.aspx.vb" Inherits="GF_scProject" title="Maintain List: Projects Involved" %>
<asp:Content ID="CPHscProject" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelscProject" runat="server" Text="&nbsp;List: Projects Involved"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLscProject" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLscProject"
      ToolType = "lgNMGrid"
      EditUrl = "~/SC_Main/App_Edit/EF_scProject.aspx"
      AddUrl = "~/SC_Main/App_Create/AF_scProject.aspx"
      AddPostBack = "True"
      ValidationGroup = "scProject"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSscProject" runat="server" AssociatedUpdatePanelID="UPNLscProject" DisplayAfter="100">
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
          <asp:TextBox
            ID = "F_RequestID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_RequestID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_RequestID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERequestID"
            BehaviorID="B_ACERequestID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RequestIDCompletionList"
            TargetControlID="F_RequestID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACERequestID_Selected"
            OnClientPopulating="ACERequestID_Populating"
            OnClientPopulated="ACERequestID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVscProject" SkinID="gv_silver" runat="server" DataSourceID="ODSscProject" DataKeyNames="RequestID,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects1_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSscProject"
      runat = "server"
      DataObjectTypeName = "SIS.SC.scProject"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_scProjectSelectList"
      TypeName = "SIS.SC.scProject"
      SelectCountMethod = "scProjectSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVscProject" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_RequestID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
