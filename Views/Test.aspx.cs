using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Test : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        RadMap1.CenterSettings.Latitude = 37.546211;
        RadMap1.CenterSettings.Longitude = 45.067703;
        RadMap1.Zoom = 16;
    }
}