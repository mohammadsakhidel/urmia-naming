using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Admins_UrmiaMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            uc_GoogleMap.SetCenter(new Models.Location(45.076056718826294, 37.55293040654811), 12, Subgurim.Controles.GMapType.GTypes.Normal);
        }
    }
}