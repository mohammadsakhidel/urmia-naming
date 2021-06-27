using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Members_MosavabPhotos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MembersRepository mr = new MembersRepository();
            AccessRule rule = mr.GetAccessRule(HttpContext.Current.User.Identity.Name);
            if (!rule.AccessToMosavabsObj.Photos)
                throw new Exception("شما دارای حق دسترسی لازم نمی باشید");
            uc_MosavabPhotos.Access = rule.AccessToMosavabsObj;
            //////////////////////////////
            if (!Page.IsPostBack)
            {
                uc_MosavabPhotos.MosavabID = Convert.ToInt32(Request.QueryString["id"]);
                uc_MosavabPhotos.LoadData();
            }
        }
    }
}