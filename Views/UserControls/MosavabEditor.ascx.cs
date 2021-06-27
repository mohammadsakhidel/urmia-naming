using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_UserControls_MosavabEditor : System.Web.UI.UserControl
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
    public int MosavabID
    {
        get
        {
            return Convert.ToInt32(hid_MosavabID.Value);
        }
        set
        {
            hid_MosavabID.Value = value.ToString();
        }
    }
    //***************************** methods:
    public void LoadData()
    {
        MosavabsRepository mr = new MosavabsRepository();
        Mosavab mosavab = mr.Get(MosavabID);
        tb_Subject.Text = mosavab.Subject;
        tb_Shomare.Text = mosavab.Shomare;
        tb_Explanation.Text = mosavab.Explanation;
        tb_MeetingNo.Text = mosavab.MeetingNo;
        if (mosavab.DateOfMeeting.HasValue) 
            uc_DateOfMeeting.SelectedDate_Miladi = mosavab.DateOfMeeting.Value;
        tb_Participants.Text = mosavab.Participants;
    }
    //***************************** event handlers:
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (FormAction == MyEnums.FormAction.New)
            {
                MosavabsRepository mr = new MosavabsRepository();
                if (mr.Exists(tb_Shomare.Text)) throw new Exception("مصوبه ای با این شماره قبلاً ثبت شده است");
                Mosavab mosavab = new Mosavab();
                mosavab.Subject = tb_Subject.Text;
                mosavab.Shomare = tb_Shomare.Text;
                mosavab.Explanation = (!String.IsNullOrEmpty(tb_Explanation.Text) ? tb_Explanation.Text : null);
                mosavab.MeetingNo = (!String.IsNullOrEmpty(tb_MeetingNo.Text) ? tb_MeetingNo.Text : null);
                mosavab.DateOfMeeting = (uc_DateOfMeeting.IsDateSelected ? uc_DateOfMeeting.SelectedDate_Miladi : (DateTime?)null);
                mosavab.Participants = (!String.IsNullOrEmpty(tb_Participants.Text) ? tb_Participants.Text : null);
                mosavab.DateOfCreate = MyHelper.Now;
                mosavab.CreatedBy = HttpContext.Current.User.Identity.Name;
                mr.Add(mosavab);
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender);
            }
            else if (FormAction == MyEnums.FormAction.Edit)
            {
                MosavabsRepository mr = new MosavabsRepository();
                if (mr.Exists(MosavabID, tb_Shomare.Text)) throw new Exception("مصوبه ای با این شماره قبلاً ثبت شده است");
                Mosavab mosavab = mr.Get(MosavabID);
                mosavab.Subject = tb_Subject.Text;
                mosavab.Shomare = tb_Shomare.Text;
                mosavab.Explanation = (!String.IsNullOrEmpty(tb_Explanation.Text) ? tb_Explanation.Text : null);
                mosavab.MeetingNo = (!String.IsNullOrEmpty(tb_MeetingNo.Text) ? tb_MeetingNo.Text : null);
                mosavab.DateOfMeeting = (uc_DateOfMeeting.IsDateSelected ? uc_DateOfMeeting.SelectedDate_Miladi : (DateTime?)null);
                mosavab.Participants = (!String.IsNullOrEmpty(tb_Participants.Text) ? tb_Participants.Text : null);
                mr.Save();
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender);
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
}