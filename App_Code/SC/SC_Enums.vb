Imports Microsoft.VisualBasic

Public Enum scStates
  Returned = 1
  Free = 2
  UnderApproval = 3
  UnderMDApproval = 4
  UnderAuditClearance = 5
  Closed = 6
End Enum
Public Enum scAprStates
  Returned = 1
  Free = 2
  UnderApproval = 3
  Approved = 4
  ApprovedWithComments = 5
End Enum