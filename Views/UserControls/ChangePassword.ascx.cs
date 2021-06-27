using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Views_UserControls_ChangePassword : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void LoadData()
    {
        MembershipUser user = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        tb_UserName.Text = user.UserName;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            MembershipUser user = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string oldPassword = tb_OldPassword.Text;
            if (user.GetPassword() == oldPassword)
            {
                if (MyHelper.IsValidUserName(tb_UserName.Text) && MyHelper.IsValidPassword(tb_NewPassword.Text))
                {
                    user.ChangePassword(oldPassword, tb_NewPassword.Text);
                    Membership.UpdateUser(user);
                    MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender);
                }
                else if (!MyHelper.IsValidUserName(tb_UserName.Text))
                {
                    throw new Exception("فرمت نام کاربری وارد شده صحیح نیست");
                }
                else if (!MyHelper.IsValidPassword(tb_NewPassword.Text))
                {
                    throw new Exception("فرمت رمط عبور وارد شده صحیح نیست");
                }
            }
            else
            {
                throw new Exception("رمز عبور قبلی اشتباه است");
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
}