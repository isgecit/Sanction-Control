Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

<ValidationProperty("SelectedValue")> _
Partial Class LC_scRMDApproval
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public ReadOnly Property LCClientID() As String
    Get
      Return DDLscRMDApproval.ClientID
    End Get
  End Property
  Public Property AddAttributes() As String
    Get
      Return DDLscRMDApproval.Attributes.ToString
    End Get
    Set(ByVal value As String)
      Try
        Dim aVal() As String = value.Split(",".ToCharArray)
        DDLscRMDApproval.Attributes.Add(aVal(0), aVal(1))
      Catch ex As Exception
      End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLscRMDApproval.CssClass
    End Get
    Set(ByVal value As String)
      DDLscRMDApproval.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLscRMDApproval.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLscRMDApproval.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatorscRMDApproval.Text
    End Get
    Set(ByVal value As String)
      If value = String.Empty Then
        RequiredFieldValidatorscRMDApproval.Enabled = False
      Else
        RequiredFieldValidatorscRMDApproval.Text = value
      End If
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatorscRMDApproval.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorscRMDApproval.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLscRMDApproval.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLscRMDApproval.Enabled = value
      RequiredFieldValidatorscRMDApproval.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLscRMDApproval.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLscRMDApproval.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLscRMDApproval.DataTextField
    End Get
    Set(ByVal value As String)
      DDLscRMDApproval.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLscRMDApproval.DataValueField
    End Get
    Set(ByVal value As String)
      DDLscRMDApproval.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLscRMDApproval.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLscRMDApproval.SelectedValue = String.Empty
      Else
        DDLscRMDApproval.SelectedValue = value
      End If
    End Set
  End Property
  Public Property OrderBy() As String
    Get
      Return _OrderBy
    End Get
    Set(ByVal value As String)
      _OrderBy = value
    End Set
  End Property
  Public Property IncludeDefault() As Boolean
    Get
      Return _IncludeDefault
    End Get
    Set(ByVal value As Boolean)
      _IncludeDefault = value
    End Set
  End Property
  Public Property DefaultText() As String
    Get
      Return _DefaultText
    End Get
    Set(ByVal value As String)
      _DefaultText = value
    End Set
  End Property
  Public Property DefaultValue() As String
    Get
      Return _DefaultValue
    End Get
    Set(ByVal value As String)
      _DefaultValue = value
    End Set
  End Property
  Protected Sub OdsDdlscRMDApproval_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlscRMDApproval.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLscRMDApproval_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLscRMDApproval.DataBinding
    If _IncludeDefault Then
      DDLscRMDApproval.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLscRMDApproval_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLscRMDApproval.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
