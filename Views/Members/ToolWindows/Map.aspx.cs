using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Admins_ToolWindows_Map : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["shape"] == null)
                uc_MapShapeEditor.SetCenter(new Models.Location(45.076056718826294, 37.55293040654811), 13, Subgurim.Controles.GMapType.GTypes.Normal);
            else
            {
                string shapeInfo = Request.QueryString["shape"].ToString();
                uc_MapShapeEditor.SaveShapeInfo(shapeInfo);
                uc_MapShapeEditor.DrawShape();
                Models.MapShape shape = new Models.MapShape(shapeInfo);
                Models.Location avgCenter = shape.AverageCenter;
                uc_MapShapeEditor.SetCenter(new Models.Location(avgCenter.Longitude, avgCenter.Latitude), 14, Subgurim.Controles.GMapType.GTypes.Normal);
            }

            if (Request.QueryString["type"] != null)
            {
                uc_MapShapeEditor.Type = Request.QueryString["type"].ToString();
            }
        }
    }
}