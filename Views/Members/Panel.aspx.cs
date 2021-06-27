using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Members_Panel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MembersRepository mr = new MembersRepository();
        AccessRule rules = mr.GetAccessRule(HttpContext.Current.User.Identity.Name);
        LimitMenuAccess(rules);
    }

    private void LimitMenuAccess(AccessRule rule)
    {
        //// PassNames:
        pi_PassNames.Visible = rule.AccessToPassNamesObj.ShowSection;
        smi_CreatePassName.Visible = rule.AccessToPassNamesObj.Create;
        smi_SearchPassName.Visible = rule.AccessToPassNamesObj.Search;
        //// Mosavabs:
        pi_Mosavabs.Visible = rule.AccessToMosavabsObj.ShowSection;
        smi_CreateMosavab.Visible = rule.AccessToMosavabsObj.Create;
        smi_SearchMosavab.Visible = rule.AccessToMosavabsObj.Search;
        //// Passways:
        smi_CreatePassway.Visible = rule.AccessToPasswaysObj.Create;
        smi_SearchPassway.Visible = rule.AccessToPasswaysObj.Search;
        smi_SearchArea.Visible = rule.AccessToPasswaysObj.Search;
        //// Users:
        pi_Members.Visible = rule.AccessToMembersObj.ShowSection;
        smi_CreateMember.Visible = rule.AccessToMembersObj.Create;
        smi_ListMember.Visible = rule.AccessToMembersObj.List;
    }
}