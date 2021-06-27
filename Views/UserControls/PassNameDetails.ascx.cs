using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_UserControls_PassNameDetails : System.Web.UI.UserControl
{
    public int PassNameID
    {
        get
        {
            return Convert.ToInt32(hid_PassNameID.Value);
        }
        set
        {
            hid_PassNameID.Value = value.ToString();
        }
    }

    public void LoadData()
    {
        PassNamesRepository pr = new PassNamesRepository();
        PassName passName = pr.Get(PassNameID);
        tb_Name.Text = passName.Name;
        tb_Type.Text = passName.TypeText;
        tb_Description.Text = passName.Description;
        ch_IsSuggestion.Checked = passName.IsSuggestion;
        if (passName.IsSuggestion)
        {
            tb_SuggestedBy.Text = passName.SuggestedBy;
            tb_DateOfSuggest.Text = (passName.DateOfSuggest.HasValue ? MyHelper.DateToString(passName.DateOfSuggest.Value, MyEnums.DateType.Medium) : "");
            tb_LetterNo.Text = passName.LetterNo;
        }
        ////// map lnglat:
        if (!String.IsNullOrEmpty(passName.ShapeInfo))
        {
            Models.MapShape shape = new MapShape(passName.ShapeInfo);
            uc_GoogleMap.DrawShape(shape.Formula);
            Models.Location avgCenter = shape.AverageCenter;
            uc_GoogleMap.SetCenter(new Models.Location(avgCenter.Longitude, avgCenter.Latitude), 16, Subgurim.Controles.GMapType.GTypes.Normal);
            uc_GoogleMap.ZoomToBounds(shape);
        }
        else
        {
            uc_GoogleMap.Visible = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}