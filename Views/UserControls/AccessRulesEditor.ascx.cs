using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_UserControls_AccessRulesEditor : System.Web.UI.UserControl
{
    //***************************** properties:
    public int MemberID
    {
        get
        {
            return Convert.ToInt32(hid_MemberID.Value);
        }
        set
        {
            hid_MemberID.Value = value.ToString();
        }
    }
    //***************************** methods:
    public void LoadData()
    {
        MembersRepository mr = new MembersRepository();
        AccessRule accessRule = mr.GetAccessRule(MemberID);
        ///// passways:
        chl_AccessToPassways.Items[0].Selected = accessRule.AccessToPasswaysObj.Create;
        chl_AccessToPassways.Items[1].Selected = accessRule.AccessToPasswaysObj.Edit;
        chl_AccessToPassways.Items[2].Selected = accessRule.AccessToPasswaysObj.Delete;
        chl_AccessToPassways.Items[3].Selected = accessRule.AccessToPasswaysObj.Search;
        chl_AccessToPassways.Items[4].Selected = accessRule.AccessToPasswaysObj.Details;
        chl_AccessToPassways.Items[5].Selected = accessRule.AccessToPasswaysObj.Photos;
        chl_AccessToPassways.Items[6].Selected = accessRule.AccessToPasswaysObj.AddPhoto;
        chl_AccessToPassways.Items[7].Selected = accessRule.AccessToPasswaysObj.DeletePhoto;
        ///// mosavabs:
        chl_AccessToMosavabs.Items[0].Selected = accessRule.AccessToMosavabsObj.Create;
        chl_AccessToMosavabs.Items[1].Selected = accessRule.AccessToMosavabsObj.Edit;
        chl_AccessToMosavabs.Items[2].Selected = accessRule.AccessToMosavabsObj.Delete;
        chl_AccessToMosavabs.Items[3].Selected = accessRule.AccessToMosavabsObj.Search;
        chl_AccessToMosavabs.Items[4].Selected = accessRule.AccessToMosavabsObj.Details;
        chl_AccessToMosavabs.Items[5].Selected = accessRule.AccessToMosavabsObj.Photos;
        chl_AccessToMosavabs.Items[6].Selected = accessRule.AccessToMosavabsObj.AddPhoto;
        chl_AccessToMosavabs.Items[7].Selected = accessRule.AccessToMosavabsObj.DeletePhoto;
        ///// passNames:
        chl_AccessToPassNames.Items[0].Selected = accessRule.AccessToPassNamesObj.Create;
        chl_AccessToPassNames.Items[1].Selected = accessRule.AccessToPassNamesObj.Edit;
        chl_AccessToPassNames.Items[2].Selected = accessRule.AccessToPassNamesObj.Delete;
        chl_AccessToPassNames.Items[3].Selected = accessRule.AccessToPassNamesObj.Search;
        chl_AccessToPassNames.Items[4].Selected = accessRule.AccessToPassNamesObj.Details;
        ///// members:
        chl_AccessToMembers.Items[0].Selected = accessRule.AccessToMembersObj.Create;
        chl_AccessToMembers.Items[1].Selected = accessRule.AccessToMembersObj.Edit;
        chl_AccessToMembers.Items[2].Selected = accessRule.AccessToMembersObj.Delete;
        chl_AccessToMembers.Items[3].Selected = accessRule.AccessToMembersObj.List;
        chl_AccessToMembers.Items[4].Selected = accessRule.AccessToMembersObj.AccessRules;
        ///// reports:
        chl_AccessToReports.Items[0].Selected = accessRule.AccessToReportsObj.View;
    }

    private string CheckBoxListValuesToString(CheckBoxList list)
    {
        string val = "";
        foreach (ListItem ch in list.Items)
        {
            val += (ch.Selected ? "1" : "0");
        }
        return val;
    }
    //***************************** event handlers:
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            MembersRepository mr = new MembersRepository();
            AccessRule rule = new AccessRule();
            rule.MemberID = MemberID;
            rule.AccessToPassways = CheckBoxListValuesToString(chl_AccessToPassways);
            rule.AccessToMosavabs = CheckBoxListValuesToString(chl_AccessToMosavabs);
            rule.AccessToPassNames = CheckBoxListValuesToString(chl_AccessToPassNames);
            rule.AccessToMembers = CheckBoxListValuesToString(chl_AccessToMembers);
            rule.AccessToReports = CheckBoxListValuesToString(chl_AccessToReports);
            mr.AddAccessRule(rule);
            /////////
            MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender);
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
}