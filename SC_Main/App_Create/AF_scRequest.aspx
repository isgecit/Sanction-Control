<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_scRequest.aspx.vb" Inherits="AF_scRequest" title="Add: Create Sanction Request" %>
<asp:Content ID="CPHscRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelscRequest" runat="server" Text="&nbsp;Add: Create Sanction Request"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLscRequest" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLscRequest"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/SC_Main/App_Edit/EF_scRequest.aspx"
    ValidationGroup = "scRequest"
    runat = "server" />
<asp:FormView ID="FVscRequest"
  runat = "server"
  DataKeyNames = "RequestID"
  DataSourceID = "ODSscRequest"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgscRequest" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RequestID" ForeColor="#CC6633" runat="server" Text="Request ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RequestID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="scRequest"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRemarks"
            runat = "server"
            ControlToValidate = "F_Remarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "scRequest"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MDApprovalRequired" runat="server" Text="MD Approval Required :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_MDApprovalRequired"
           Checked='<%# Bind("MDApprovalRequired") %>'
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
  ID = "ODSscRequest"
  DataObjectTypeName = "SIS.SC.scRequest"
  InsertMethod="UZ_scRequestInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.SC.scRequest"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
