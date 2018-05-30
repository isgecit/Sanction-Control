<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_scApprovalStatus.aspx.vb" Inherits="AF_scApprovalStatus" title="Add: SC Approval Status" %>
<asp:Content ID="CPHscApprovalStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelscApprovalStatus" runat="server" Text="&nbsp;Add: SC Approval Status"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLscApprovalStatus" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLscApprovalStatus"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "scApprovalStatus"
    runat = "server" />
<asp:FormView ID="FVscApprovalStatus"
  runat = "server"
  DataKeyNames = "StatusID"
  DataSourceID = "ODSscApprovalStatus"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgscApprovalStatus" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_StatusID" ForeColor="#CC6633" runat="server" Text="StatusID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_StatusID"
            Text='<%# Bind("StatusID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="scApprovalStatus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for StatusID."
            MaxLength="2"
            Width="24px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVStatusID"
            runat = "server"
            ControlToValidate = "F_StatusID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "scApprovalStatus"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="scApprovalStatus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "scApprovalStatus"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSscApprovalStatus"
  DataObjectTypeName = "SIS.SC.scApprovalStatus"
  InsertMethod="scApprovalStatusInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.SC.scApprovalStatus"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
