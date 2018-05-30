<script type="text/javascript"> 
var script_scRApproval = {
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
    temp: function() {
    }
    }
</script>
