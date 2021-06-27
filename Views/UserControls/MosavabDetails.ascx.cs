using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_UserControls_MosavabDetails : System.Web.UI.UserControl
{
    //*********************** Properties:
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
    //*********************** Methods:
    public void LoadData()
    {
        MosavabsRepository mr = new MosavabsRepository();
        Mosavab mosavab = mr.Get(MosavabID);
        //photos:
        var passPhotos = mosavab.MosavabPhotos;
        list_MosavabPhotos.DataSource = passPhotos;
        list_MosavabPhotos.DataBind();
        pnl_Photos.Visible = (passPhotos.Count() > 0 ? true : false);
        //
        tb_Subject.Text = mosavab.Subject;
        tb_Shomare.Text = mosavab.Shomare;
        tb_Explanation.Text = mosavab.Explanation;
        tb_MeetingNo.Text = mosavab.MeetingNo;
        tb_DateOfMeeting.Text = (mosavab.DateOfMeeting.HasValue ? MyHelper.DateToString(mosavab.DateOfMeeting.Value, MyEnums.DateType.Medium) : "");
        tb_Participants.Text = mosavab.Participants;
        tb_DateOfCreate.Text = MyHelper.DateToString(mosavab.DateOfCreate, MyEnums.DateType.Medium);
        tb_CreatedBy.Text = mosavab.CreatedBy;
    }
    //*********************** Event Handlers:
}