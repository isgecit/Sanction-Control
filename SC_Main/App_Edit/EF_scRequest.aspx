<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_scRequest.aspx.vb" Inherits="EF_scRequest" title="Edit: Create Sanction Request" %>
<asp:Content ID="CPHscRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelscRequest" runat="server" Text="&nbsp;Edit: Create Sanction Request"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLscRequest" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLscRequest"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_scRequest.aspx?pk="
    ValidationGroup = "scRequest"
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
<asp:FormView ID="FVscRequest"
  runat = "server"
  DataKeyNames = "RequestID"
  DataSourceID = "ODSscRequest"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RequestID" runat="server" ForeColor="#CC6633" Text="Request ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RequestID"
            Text='<%# Bind("RequestID") %>'
            ToolTip="Value of Request ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td colspan="4" style="border-top: solid 1pt LightGrey" >
          <asp:UpdatePanel ID="tmpPnl1" runat="server">
            <ContentTemplate>
              <table>
                <tr>
                  <td class="alignright">
                    <asp:Label ID="L_RequestRefNo" runat="server" Text="Agenda Ref. No :" />
<%--                    <br />
                    <asp:Label ID="LabelTemp" runat="server" Text="Will be generate when submitted"></asp:Label>--%>
                  </td>
                  <td colspan="3">
                    <asp:TextBox ID="F_RequestRefNo"
                      Text='<%# Bind("RequestRefNo") %>'
                      Width="408px"
                      CssClass = "dmytxt"
                      Enabled="false"
                      MaxLength="50"
                      runat="server" />
                  </td>
                </tr>
                <tr>
                  <td class="alignright" style="vertical-align:top;">
                    <asp:Label ID="Label1" runat="server" Text="Selected Project(s) :" />
                  </td>
                  <td style="min-width:300px !important; vertical-align:top;" id="mp1" runat="server" clientidmode="static" >
                    <asp:TextBox
                      ID = "F_ProjectID"
                      CssClass = "myfktxt"
                      Text=""
                      AutoCompleteType = "None"
                      Width="56px"
                      onfocus = "return this.select();"
                      ToolTip="Enter value for Project ID."
                      ValidationGroup = "scProject"
                      onblur= "script_scProject.validate_ProjectID(this);"
                      Runat="Server" />
                    <asp:Label
                      ID = "F_ProjectID_Display"
                      Text=""
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
                    <br>
                    </br>
                    <br>
                    </br>
                    <asp:Button ID="cmdAddF" runat="server" Text="ADD IN FROM LIST" />
                    <asp:Button ID="cmdAddT" runat="server" Text="ADD IN TO LIST" />
                  </td>
                  <td style="vertical-align:top;">
                    <table style="border: 1pt solid grey;min-width:100px !important;">
                      <tr>
                        <td>
                          <asp:Label ID="L_FromList" runat="server" Font-Bold="true" Text="FROM PROJECT(s)"></asp:Label>
                        </td>
                      </tr>
                      <tr>
                        <td style="min-height:60px !important">
                          <asp:CheckBoxList 
                            ID="fromList" 
                            runat="server" 
                            DataSourceID="ODSFscProject" 
                            DataValueField="PrimaryKey" 
                            DataTextField="ProjectID" 
                            CssClass="mytxt" 
                            Height="60px" 
                            Width="100px" >
                          </asp:CheckBoxList>
                          <asp:ObjectDataSource 
                            ID = "ODSFscProject"
                            runat = "server"
                            DataObjectTypeName = "SIS.SC.scProject"
                            OldValuesParameterFormatString = "original_{0}"
                            SelectMethod = "UZ_FscProjectSelectList"
                            TypeName = "SIS.SC.scProject"
                            SelectCountMethod = "scProjectSelectCount"
                            SortParameterName="OrderBy" EnablePaging="True">
                            <SelectParameters >
                              <asp:ControlParameter ControlID="F_RequestID" PropertyName="Text" Name="RequestID" Type="Int32" Size="10" />
                              <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                              <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                            </SelectParameters>
                          </asp:ObjectDataSource>
                        </td>
                      </tr>
                    </table>
                    <br>
                    </br>
                    <asp:Button ID="cmdDelF" runat="server" Text="Delete" ForeColor="Red" />
                  </td>
                  <td style="vertical-align:top;">
                    <table  style="border: 1pt solid grey;min-width:100px !important;">
                      <tr>
                        <td>
                          <asp:Label ID="L_ToList" runat="server" Font-Bold="true" Text="TO PROJECT(s)"></asp:Label>
                        </td>
                      </tr>
                      <tr>
                        <td style="min-height:60px !important">
                          <asp:CheckBoxList 
                            ID="toList" 
                            runat="server" 
                            DataSourceID="ODSTscProject" 
                            DataValueField="PrimaryKey" 
                            DataTextField="ProjectID" 
                            CssClass="mytxt" 
                            Height="60px" 
                            Width="100px" >
                          </asp:CheckBoxList>
                          <asp:ObjectDataSource 
                            ID = "ODSTscProject"
                            runat = "server"
                            DataObjectTypeName = "SIS.SC.scProject"
                            OldValuesParameterFormatString = "original_{0}"
                            SelectMethod = "UZ_TscProjectSelectList"
                            TypeName = "SIS.SC.scProject"
                            SelectCountMethod = "scProjectSelectCount"
                            SortParameterName="OrderBy" EnablePaging="True">
                            <SelectParameters >
                              <asp:ControlParameter ControlID="F_RequestID" PropertyName="Text" Name="RequestID" Type="Int32" Size="10" />
                              <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                              <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                            </SelectParameters>
                          </asp:ObjectDataSource>
                        </td>
                      </tr>
                    </table>
                    <br>
                    </br>
                    <asp:Button ID="cmdDelT" runat="server" Text="Delete" ForeColor="Red" />
                  </td>
                </tr>
              </table>
            </ContentTemplate>
            <Triggers>
              <asp:AsyncPostBackTrigger ControlID="cmdAddF" EventName="Click" />
              <asp:AsyncPostBackTrigger ControlID="cmdAddT" EventName="Click" />
              <asp:AsyncPostBackTrigger ControlID="cmdDelF" EventName="Click" />
              <asp:AsyncPostBackTrigger ControlID="cmdDelT" EventName="Click" />
            </Triggers>
          </asp:UpdatePanel>
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="scRequest"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td colspan="4">
          <asp:UpdatePanel runat="server">
            <ContentTemplate>
              <table style="width: 100%;">
                <tr>
                  <td class="alignright" style="vertical-align: top;">
                    <asp:Label ID="Label2" runat="server" Text="Select Approvers :" />&nbsp;
                  </td>
                  <td style="vertical-align: top;" id="ma1" runat="server" clientidmode="static">
                    <asp:TextBox
                      ID="F_ApproverID"
                      CssClass="myfktxt"
                      Text=""
                      AutoCompleteType="None"
                      Width="72px"
                      onfocus="return this.select();"
                      ToolTip="Enter value for Approver."
                      ValidationGroup="scApproval"
                      onblur="script_scApproval.validate_ApproverID(this);"
                      runat="Server" />
                    <asp:Label
                      ID="F_ApproverID_Display"
                      Text=""
                      CssClass="myLbl"
                      runat="Server" />
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
                      CompletionListCssClass="autocomplete_completionListElement"
                      CompletionListItemCssClass="autocomplete_listItem"
                      CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                      runat="Server" />
                    <br />
                    <br />
                    <asp:Button ID="CmdAddA" runat="server" Text="ADD IN APPROVER LIST" />
                  </td>
                  <td style="vertical-align: top;">
                    <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="APPROVERS LIST"></asp:Label>
                    <br />
                    <asp:CheckBoxList
                      ID="ApproverList"
                      runat="server"
                      DataSourceID="ODSscApproval"
                      DataValueField="PrimaryKey"
                      DataTextField="aspnet_Users1_UserFullName"
                      CssClass="mytxt"
                      Height="20px"
                      Width="200px">
                    </asp:CheckBoxList>
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
                    <br />
                    <asp:Button ID="CmdDelA" runat="server" Text="Delete" ForeColor="Red" />
                  </td>
                </tr>
              </table>
            </ContentTemplate>
            <Triggers>
              <asp:AsyncPostBackTrigger ControlID="CmdAddA" EventName="Click" />
              <asp:AsyncPostBackTrigger ControlID="CmdDelA" EventName="Click" />
            </Triggers>
          </asp:UpdatePanel>
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="Label3" runat="server" Text="Attach Agenda Paper :" /><span style="color:red">*</span>
        </td>
        <td style="text-align:center">
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              <asp:FileUpload ID="F_FileUpload" runat="server" Width="250px" ToolTip="Browse File" />
              <asp:Button ID="cmdTmplUpload" Text="Upload" runat="server" ToolTip="Click to upload File." CommandName="tmplUpload" CommandArgument='<%# Eval("PrimaryKey") %>'  />
            </ContentTemplate>
            <Triggers>
              <asp:PostBackTrigger ControlID="cmdTmplUpload" />
            </Triggers>
          </asp:UpdatePanel>
        </td> 
        <td>
          <asp:LinkButton ID="cmdDownLoad" runat="server" Visible='<%# Eval("DownloadVisible") %>' Font-Bold="true" Text='<%# Eval("FileName") %>' style="cursor:pointer;" OnClientClick='<%# Eval("GetDownLoadLink") %>'></asp:LinkButton>
        </td>
        <td>
          <asp:Button ID="cmdDelAttach" runat="server" Visible='<%# Eval("DeleteAgendaVisible") %>' ForeColor="Red" Text="Delete Attachment" CommandName="tmpDelete" CommandArgument='<%# Eval("PrimaryKey") %>' />
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
            Text='<%# Bind("SubmittedBy") %>'
            Enabled = "False"
            ToolTip="Value of Submitted By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SubmittedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SubmittedOn" runat="server" Text="Submitted On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SubmittedOn"
            Text='<%# Bind("SubmittedOn") %>'
            ToolTip="Value of Submitted On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
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
            Text='<%# Eval("SC_Status4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_FileName" runat="server" Text="File Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FileName"
            Text='<%# Bind("FileName") %>'
            ToolTip="Value of File Name."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MDApprovalBy" runat="server" Text="MD Approval By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_MDApprovalBy"
            Width="72px"
            Text='<%# Bind("MDApprovalBy") %>'
            Enabled = "False"
            ToolTip="Value of MD Approval By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_MDApprovalBy_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MDApprovalOn" runat="server" Text="MD Approval On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MDApprovalOn"
            Text='<%# Bind("MDApprovalOn") %>'
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
            Text='<%# Bind("MDRemarks") %>'
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
            Text='<%# Bind("AuditedBy") %>'
            Enabled = "False"
            ToolTip="Value of Audited By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_AuditedBy_Display"
            Text='<%# Eval("aspnet_users3_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_AuditedOn" runat="server" Text="Audited On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AuditedOn"
            Text='<%# Bind("AuditedOn") %>'
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
            Text='<%# Bind("AuditorRemarks") %>'
            ToolTip="Value of Auditor Remarks."
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
  ID = "ODSscRequest"
  DataObjectTypeName = "SIS.SC.scRequest"
  SelectMethod = "scRequestGetByID"
  UpdateMethod="UZ_scRequestUpdate"
  DeleteMethod="UZ_scRequestDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.SC.scRequest"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestID" Name="RequestID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
