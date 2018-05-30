<script type="text/javascript"> 
var script_scApproval = {
    ACERequestID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('RequestID','');
      var F_RequestID = $get(sender._element.id);
      var F_RequestID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_RequestID.value = p[0];
      F_RequestID_Display.innerHTML = e.get_text();
    },
    ACERequestID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('RequestID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACERequestID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEApproverID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ApproverID','');
      var F_ApproverID = $get(sender._element.id);
      var F_ApproverID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ApproverID.value = p[0];
      F_ApproverID_Display.innerHTML = e.get_text();
    },
    ACEApproverID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ApproverID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEApproverID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ApproverID: function(sender) {
      var Prefix = sender.id.replace('ApproverID','');
      this.validated_FK_SC_Approval_ApproverID_main = true;
      this.validate_FK_SC_Approval_ApproverID(sender,Prefix);
      },
    validate_FK_SC_Approval_ApproverID: function(o,Prefix) {
      var value = o.id;
      var ApproverID = $get(Prefix + 'ApproverID');
      if(ApproverID.value==''){
        if(this.validated_FK_SC_Approval_ApproverID_main){
          var o_d = $get(Prefix + 'ApproverID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ApproverID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_SC_Approval_ApproverID(value, this.validated_FK_SC_Approval_ApproverID);
      },
    validated_FK_SC_Approval_ApproverID_main: false,
    validated_FK_SC_Approval_ApproverID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_scApproval.validated_FK_SC_Approval_ApproverID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
