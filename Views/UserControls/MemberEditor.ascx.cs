using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Models;

public partial class Views_UserControls_MemberEditor : System.Web.UI.UserControl
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
        var user = Membership.GetUser();
        if (user.IsLockedOut)
            user.UnlockUser();

        MembersRepository mr = new MembersRepository();
        Member member = mr.Get(MemberID);
        tb_FullName.Text = member.FullName;
        tb_Organization.Text = member.Organization;
        tb_Position.Text = member.Position;
        tb_UserName.Text = member.UserName;

        tb_Password.Text = user.GetPassword();
    }
    //***************************** event handlers:
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (FormAction == MyEnums.FormAction.New)
            {
                if (!MyHelper.IsValidUserName(tb_UserName.Text)) throw new Exception("خطا: نام کاربری وارد شده دارای فرمت صحیح نیست");
                if (!MyHelper.IsValidPassword(tb_Password.Text)) throw new Exception("خطا: رمز عبور وارد شده دارای فرمت صحیح نیست");
                /////////// create object:
                Member member = new Member();
                member.FullName = tb_FullName.Text;
                member.Organization = (!String.IsNullOrEmpty(tb_Organization.Text) ? tb_Organization.Text : null);
                member.Position = (!String.IsNullOrEmpty(tb_Position.Text) ? tb_Position.Text : null);
                member.UserName = tb_UserName.Text;
                member.DateOfCreate = MyHelper.Now;
                member.CreatedBy = HttpContext.Current.User.Identity.Name;
                /////////// create membership acount & save:
                MembershipUser newUser = Membership.CreateUser(tb_UserName.Text, tb_Password.Text);
                if (newUser != null)
                {
                    newUser.IsApproved = true;
                    Roles.AddUserToRole(newUser.UserName, MyRoles.Member);
                    Membership.UpdateUser(newUser);
                    MembersRepository mr = new MembersRepository();
                    mr.Add(member);
                    MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender);
                }
                else
                {
                    throw new Exception("خطا در ایجاد حساب کاربری");
                }
            }
            else if (FormAction == MyEnums.FormAction.Edit)
            {
                if (!MyHelper.IsValidUserName(tb_UserName.Text)) throw new Exception("خطا: نام کاربری وارد شده دارای فرمت صحیح نیست");
                if (!MyHelper.IsValidPassword(tb_Password.Text)) throw new Exception("خطا: رمز عبور وارد شده دارای فرمت صحیح نیست");
                /////////// create object:
                MembersRepository mr = new MembersRepository();
                Member member = mr.Get(MemberID);
                string oldUserName = member.UserName;
                member.FullName = tb_FullName.Text;
                member.Organization = (!String.IsNullOrEmpty(tb_Organization.Text) ? tb_Organization.Text : null);
                member.Position = (!String.IsNullOrEmpty(tb_Position.Text) ? tb_Position.Text : null);
                member.UserName = tb_UserName.Text;
                /////////// create membership acount & save:
                Membership.DeleteUser(oldUserName);
                MembershipUser newUser = Membership.CreateUser(tb_UserName.Text, tb_Password.Text);
                if (newUser != null)
                {
                    newUser.IsApproved = true;
                    Roles.AddUserToRole(newUser.UserName, MyRoles.Member);
                    Membership.UpdateUser(newUser);
                    mr.Save();
                    MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender);
                }
                else
                {
                    throw new Exception("خطا در ایجاد حساب کاربری");
                }
            }
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
}