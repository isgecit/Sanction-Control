<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_scRApproval.aspx.vb" Inherits="EF_scRApproval" title="Edit: Sanction Request Approval" %>
<asp:Content ID="CPHscRApproval" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelscRApproval" runat="server" Text="&nbsp;Edit: Sanction Request Approval"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLscRApproval" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLscRApproval"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_scRApproval.aspx?pk="
    ValidationGroup = "scRApproval"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVscRApproval"
  runat = "server"
  DataKeyNames = "RequestID,SerialNo"
  DataSourceID = "ODSscRApproval"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RequestID" runat="server" ForeColor="#CC6633" Text="Request ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
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
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td>
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
          <asp:Label ID="L_ApproverRemarks" runat="server" Text="Approver Remarks :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApproverRemarks"
            Text='<%# Bind("ApproverRemarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="scRApproval"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Approver Remarks."
            MaxLength="500"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVApproverRemarks"
            runat = "server"
            ControlToValidate = "F_ApproverRemarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "scRApproval"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td colspan="2" style="vertical-align: top; text-align: center;">
          <table style="border: 1pt solid grey; min-width: 100px !important;">
            <tr>
              <td>
                <asp:Label ID="L_FromList" runat="server" Font-Bold="true" Text="FROM PROJECT(s)"></asp:Label>
              </td>
            </tr>
            <tr>
              <td style="min-height: 60px !important">
                <asp:CheckBoxList
                  ID="fromList"
                  runat="server"
                  DataSourceID="ODSFscProject"
                  DataValueField="PrimaryKey"
                  DataTextField="ProjectID"
                  CssClass="mytxt"
                  Height="60px"
                  Width="100px">
                </asp:CheckBoxList>
                <asp:ObjectDataSource
                  ID="ODSFscProject"
                  runat="server"
                  DataObjectTypeName="SIS.SC.scProject"
                  OldValuesParameterFormatString="original_{0}"
                  SelectMethod="UZ_FscProjectSelectList"
                  TypeName="SIS.SC.scProject"
                  SelectCountMethod="scProjectSelectCount"
                  SortParameterName="OrderBy" EnablePaging="True">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="F_RequestID" PropertyName="Text" Name="RequestID" Type="Int32" Size="10" />
                    <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                    <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                  </SelectParameters>
                </asp:ObjectDataSource>
              </td>
            </tr>
          </table>
        </td>
        <td colspan="2" style="vertical-align: top; text-align: center;">
          <table style="border: 1pt solid grey; min-width: 100px !important;">
            <tr>
              <td>
                <asp:Label ID="L_ToList" runat="server" Font-Bold="true" Text="TO PROJECT(s)"></asp:Label>
              </td>
            </tr>
            <tr>
              <td style="min-height: 60px !important">
                <asp:CheckBoxList
                  ID="toList"
                  runat="server"
                  DataSourceID="ODSTscProject"
                  DataValueField="PrimaryKey"
                  DataTextField="ProjectID"
                  CssClass="mytxt"
                  Height="60px"
                  Width="100px">
                </asp:CheckBoxList>
                <asp:ObjectDataSource
                  ID="ODSTscProject"
                  runat="server"
                  DataObjectTypeName="SIS.SC.scProject"
                  OldValuesParameterFormatString="original_{0}"
                  SelectMethod="UZ_TscProjectSelectList"
                  TypeName="SIS.SC.scProject"
                  SelectCountMethod="scProjectSelectCount"
                  SortParameterName="OrderBy" EnablePaging="True">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="F_RequestID" PropertyName="Text" Name="RequestID" Type="Int32" Size="10" />
                    <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                    <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                  </SelectParameters>
                </asp:ObjectDataSource>
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td colspan="4">
          <asp:GridView ID="GVscApproval" SkinID="gv_silverChild" runat="server" DataSourceID="ODSscApproval" DataKeyNames="RequestID,SerialNo">
            <Columns>
              <asp:TemplateField HeaderText="Approver" SortExpression="aspnet_users1_UserFullName">
                <ItemTemplate>
                  <asp:Label ID="L_ApproverID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("ApproverID") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="100px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Approved On" SortExpression="ApprovedOn">
                <ItemTemplate>
                  <asp:Label ID="LabelApprovedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApprovedOn") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle CssClass="alignCenter" Width="90px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Approver Remarks" SortExpression="ApproverRemarks">
                <ItemTemplate>
                  <asp:Label ID="LabelApproverRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ApproverRemarks") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle CssClass="alignCenter" Width="100px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Status" SortExpression="SC_ApprovalStatus2_Description">
                <ItemTemplate>
                  <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("SC_ApprovalStatus2_Description") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="100px" />
              </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
            </EmptyDataTemplate>
          </asp:GridView>
          <asp:ObjectDataSource
            ID="ODSscApproval"
            runat="server"
            DataObjectTypeName="SIS.SC.scApproval"
            OldValuesParameterFormatString="original_{0}"
            SelectMethod="UZ_scApprovalSelectList"
            TypeName="SIS.SC.scApproval"
            SelectCountMethod="scApprovalSelectCount"
            SortParameterName="OrderBy" EnablePaging="True">
            <SelectParameters>
              <asp:ControlParameter ControlID="F_RequestID" PropertyName="Text" Name="RequestID" Type="Int32" Size="10" />
              <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
              <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
            </SelectParameters>
          </asp:ObjectDataSource>
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SubmittedBy" runat="server" Text="Submitted By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SubmittedBy"
            Width="72px"
            Text='<%# Eval("FK_SC_Approval_RequestID.SubmittedBy") %>'
            Enabled = "False"
            ToolTip="Value of Submitted By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SubmittedBy_Display"
            Text='<%# Eval("FK_SC_Approval_RequestID.aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SubmittedOn" runat="server" Text="Submitted On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SubmittedOn"
            Text='<%# Eval("FK_SC_Approval_RequestID.SubmittedOn") %>'
            ToolTip="Value of Submitted On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MDApprovalBy" runat="server" Text="MD Approval By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_MDApprovalBy"
            Width="72px"
            Text='<%# Eval("FK_SC_Approval_RequestID.MDApprovalBy") %>'
            Enabled = "False"
            ToolTip="Value of MD Approval By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_MDApprovalBy_Display"
            Text='<%# Eval("FK_SC_Approval_RequestID.aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MDApprovalOn" runat="server" Text="MD Approval On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MDApprovalOn"
            Text='<%# Eval("FK_SC_Approval_RequestID.MDApprovalOn") %>'
            ToolTip="Value of MD Approval On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MDRemarks" runat="server" Text="MD Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_MDRemarks"
            Text='<%# Eval("FK_SC_Approval_RequestID.MDRemarks") %>'
            ToolTip="Value of MD Remarks."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AuditedBy" runat="server" Text="Audited By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_AuditedBy"
            Width="72px"
            Text='<%# Eval("FK_SC_Approval_RequestID.AuditedBy") %>'
            Enabled = "False"
            ToolTip="Value of Audited By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_AuditedBy_Display"
            Text='<%# Eval("FK_SC_Approval_RequestID.aspnet_users3_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_AuditedOn" runat="server" Text="Audited On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AuditedOn"
            Text='<%# Eval("FK_SC_Approval_RequestID.AuditedOn") %>'
            ToolTip="Value of Audited On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AuditorRemarks" runat="server" Text="Auditor Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AuditorRemarks"
            Text='<%# Eval("FK_SC_Approval_RequestID.AuditorRemarks") %>'
            ToolTip="Value of Auditor Remarks."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSscRApproval"
  DataObjectTypeName = "SIS.SC.scRApproval"
  SelectMethod = "scRApprovalGetByID"
  UpdateMethod="UZ_scRApprovalUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.SC.scRApproval"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestID" Name="RequestID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
