<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_scApprovalStatus.aspx.vb" Inherits="EF_scApprovalStatus" title="Edit: SC Approval Status" %>
<asp:Content ID="CPHscApprovalStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelscApprovalStatus" runat="server" Text="&nbsp;Edit: SC Approval Status"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLscApprovalStatus" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLscApprovalStatus"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "scApprovalStatus"
    runat = "server" />
<asp:FormView ID="FVscApprovalStatus"
  runat = "server"
  DataKeyNames = "StatusID"
  DataSourceID = "ODSscApprovalStatus"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_StatusID" runat="server" ForeColor="#CC6633" Text="StatusID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_StatusID"
            Text='<%# Bind("StatusID") %>'
            ToolTip="Value of StatusID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="24px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="scApprovalStatus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSscApprovalStatus"
  DataObjectTypeName = "SIS.SC.scApprovalStatus"
  SelectMethod = "scApprovalStatusGetByID"
  UpdateMethod="scApprovalStatusUpdate"
  DeleteMethod="scApprovalStatusDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.SC.scApprovalStatus"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="StatusID" Name="StatusID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
