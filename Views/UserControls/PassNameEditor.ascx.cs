using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_UserControls_PassNameEditor : System.Web.UI.UserControl
{
    //***************************** properties:
    public MyEnums.FormAction FormAction
    {
        get
        {
            return (MyEnums.FormAction)Convert.ToInt32(hid_FormAction.Value);
        }
        set
        {
            hid_FormAction.Value = ((int)value).ToString();
        }
    }
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
    //***************************** methods:
    public void LoadData()
    {
        FillCombos();
        PassNamesRepository pr = new PassNamesRepository();
        PassName passName = pr.Get(PassNameID);
        tb_Name.Text = passName.Name;
        cmb_Type.SelectedIndex = MyHelper.GetIndexOf(cmb_Type, passName.Type.ToString());
        tb_Description.Text = passName.Description;
        ch_IsSuggestion.Checked = passName.IsSuggestion;
        hid_ShapeInfo.Value = passName.ShapeInfo;
        if (passName.IsSuggestion)
        {
            tb_SuggestedBy.Text = passName.SuggestedBy;
            if (passName.DateOfSuggest.HasValue) uc_DateOfSuggest.SelectedDate_Miladi = passName.DateOfSuggest.Value;
            tb_LetterNo.Text = passName.LetterNo;
            tb_SuggestedBy.Enabled = true;
            uc_DateOfSuggest.Enabled = true;
            tb_LetterNo.Enabled = true;
        }
        else
        {
            tb_SuggestedBy.Enabled = false;
            uc_DateOfSuggest.Enabled = false;
            tb_LetterNo.Enabled = false;
        }
    }
    public void FillCombos()
    {
        cmb_Type.Items.Clear();
        cmb_Type.Items.Add(new ListItem("", ""));
        //****** pass types:
        var nameTypes = Pairs.PassNameTypes;
        foreach (KeyValuePair<int, string> pair in nameTypes)
        {
            cmb_Type.Items.Add(new ListItem(pair.Value, pair.Key.ToString()));
        }
    }
    //***************************** handlers:
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (FormAction == MyEnums.FormAction.New)
            {
                FillCombos();
            }
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            PassNamesRepository pr = new PassNamesRepository();
            if (FormAction == MyEnums.FormAction.New)
            {
                if (pr.PassNameExists(tb_Name.Text)) throw new Exception("این نام قبلاً در بانک اسامی ثبت شده است");
                PassName passName = new PassName();
                passName.Name = tb_Name.Text;
                passName.Type = Convert.ToInt32(cmb_Type.SelectedValue);
                passName.Description = (!String.IsNullOrEmpty(tb_Description.Text) ? tb_Description.Text : null);
                passName.Status = (int)MyEnums.PassNameStatus.Unused;
                passName.DateOfAdd = MyHelper.Now;
                passName.AddedBy = HttpContext.Current.User.Identity.Name;
                passName.IsSuggestion = ch_IsSuggestion.Checked;
                passName.ShapeInfo = hid_ShapeInfo.Value;
                if (passName.IsSuggestion)
                {
                    passName.SuggestedBy = (!String.IsNullOrEmpty(tb_SuggestedBy.Text) ? tb_SuggestedBy.Text : null);
                    passName.DateOfSuggest = uc_DateOfSuggest.IsDateSelected ? uc_DateOfSuggest.SelectedDate_Miladi : (DateTime?)null;
                    passName.LetterNo = (!String.IsNullOrEmpty(tb_LetterNo.Text) ? tb_LetterNo.Text : null);
                }
                pr.Add(passName);
                ////////
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender);
            }
            else if (FormAction == MyEnums.FormAction.Edit)
            {
                if (pr.PassNameExists(PassNameID, tb_Name.Text)) throw new Exception("این نام قبلاً در بانک اسامی ثبت شده است");
                PassName passName = pr.Get(PassNameID);
                passName.Name = tb_Name.Text;
                passName.Type = Convert.ToInt32(cmb_Type.SelectedValue);
                passName.Description = (!String.IsNullOrEmpty(tb_Description.Text) ? tb_Description.Text : null);
                passName.IsSuggestion = ch_IsSuggestion.Checked;
                passName.ShapeInfo = hid_ShapeInfo.Value;
                if (passName.IsSuggestion)
                {
                    passName.SuggestedBy = (!String.IsNullOrEmpty(tb_SuggestedBy.Text) ? tb_SuggestedBy.Text : null);
                    passName.DateOfSuggest = uc_DateOfSuggest.IsDateSelected ? uc_DateOfSuggest.SelectedDate_Miladi : (DateTime?)null;
                    passName.LetterNo = (!String.IsNullOrEmpty(tb_LetterNo.Text) ? tb_LetterNo.Text : null);
                }
                else
                {
                    passName.SuggestedBy = null;
                    passName.DateOfSuggest = (DateTime?)null;
                    passName.LetterNo = null;
                }
                pr.Save();
                ////////
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender);
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
}