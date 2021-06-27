using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using System.Drawing;

public class MyHelper
{
    #region Theme And Language related:

    public static string GetCurrentSiteLanguage()
    {
        return GetCookie()["site_language"];
    }

    public static string GetCurrentSiteLanguageName()
    {
        string lang = GetCurrentSiteLanguage();
        return lang == "fa-IR" ? "Persian" : "English";
    }

    public static string GetCurrentTheme()
    {
        return GetCookie()["theme"];
    }

    public static string GetCurrentThemeRootUrl()
    {
        string language = GetCurrentSiteLanguageName();
        string theme = GetCurrentTheme();
        return "~/Content/Themes/" + language + "/" + theme + "/";
    }

    public static HttpCookie GetCookie()
    {
        HttpCookie cookie = null;
        if (HttpContext.Current.Request.Cookies["user_settings"] == null)
        {
            cookie = new HttpCookie("user_settings");
            cookie.Values["site_language"] = DefaultSiteLanguage;
            cookie.Values["theme"] = DefaultTheme;
            cookie.Expires = Now.AddYears(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        else
            cookie = HttpContext.Current.Request.Cookies["user_settings"];
        return cookie;
    }

    public static string DefaultSiteLanguage
    {
        get
        {
            return "fa-IR";
        }
    }

    public static string DefaultTheme
    {
        get
        {
            return "Default";
        }
    }

    #endregion

    #region Date and time related:

    public static DateTime Now
    {
        get
        {
            return DateTime.Now;
        }
    }

    public static DateTime ChangeTime(DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
    {
        return new DateTime(
            dateTime.Year,
            dateTime.Month,
            dateTime.Day,
            hours,
            minutes,
            seconds,
            milliseconds,
            dateTime.Kind);
    }

    public static string DateToString(DateTime date, MyEnums.DateType type)
    {
        string text = "";
        Utilities.ShamsiDateTime shamsi = Utilities.ShamsiDateTime.MiladyToShamsi(date);
        ////step1:
        if (type == MyEnums.DateType.Short || type == MyEnums.DateType.ShortWithTime)
            text = shamsi.ToString();
        else if (type == MyEnums.DateType.Medium || type == MyEnums.DateType.MediumWithTime)
            text = shamsi.ToMediumString();
        ////step2:
        if (type == MyEnums.DateType.ShortWithTime)
            text += " - " + date.Hour.ToString("D2") + ":" + date.Minute.ToString("D2");
        else if (type == MyEnums.DateType.MediumWithTime)
            text += " " + "ساعت" + " " + date.Hour.ToString("D2") + ":" + date.Minute.ToString("D2");
        return text;
    }

    #endregion

    #region Url related:

    public static string Url(string AspUrl)
    {
        return VirtualPathUtility.ToAbsolute(AspUrl);
    }

    public static string GetFolderUrl()
    {
        string userName = HttpContext.Current.User.Identity.Name;
        string folder = "";
        if (Roles.IsUserInRole(userName, MyRoles.Administrator))
            folder = "~/Views/Admins/";
        else if (Roles.IsUserInRole(userName, MyRoles.Member))
            folder = "~/Views/Members/";
        else
            folder = "~/Views/";
        return folder;
    }

    public static string GetFolderUrl(string userName)
    {
        string folder = "";
        if (Roles.IsUserInRole(userName, MyRoles.Administrator))
            folder = "~/Views/Admins/";
        else if (Roles.IsUserInRole(userName, MyRoles.Member))
            folder = "~/Views/Members/";
        else
            folder = "~/Views/";
        return folder;
    }

    #endregion

    #region Web.Config related:

    public static string ConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        }
    }

    public static string EntitiesConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["NamgozariDBEntities"].ConnectionString;
        }
    }


    #endregion

    #region Text related:

    public static string CutString(object text, int maxLenght)
    {
        string res = "";
        if (text.ToString().Length < maxLenght)
        {
            res = text.ToString();
        }
        else
        {
            res = text.ToString().Substring(0, maxLenght) + " ...";
        }
        return res;
    }

    public static List<string> SplitString(string text, string splitter)
    {
        Regex rgx = new Regex(splitter);
        string[] array = rgx.Split(text);
        List<string> list = new List<string>();
        foreach (string st in array)
        {
            if (st.Trim().Length > 0)
                list.Add(st);
        }
        return list;
    }

    public static string ExtractMobNumber(string rawNumber)
    {
        string res = "";
        if (rawNumber.Length >= 10)
            res = rawNumber.Substring(rawNumber.Length - 10, 10);
        return res;
    }

    public static bool IsValidMobNumber(string rawNumber)
    {
        bool res = false;
        if (rawNumber.Length >= 10 && ExtractMobNumber(rawNumber).StartsWith("9"))
        {
            res = true;
        }
        return res;
    }

    public static List<string> GetLines(string text)
    {
        Regex rgx = new Regex(Environment.NewLine);
        string[] array = rgx.Split(text);
        List<string> list = new List<string>();
        foreach (string st in array)
        {
            if (st.Trim().Length > 0)
                list.Add(st);
        }
        return list;
    }

    public static bool IsInteger(string text)
    {
        bool res = false;
        int outInt = 0;
        res = Int32.TryParse(text, out outInt);
        return res;
    }

    public static bool IsDouble(string text)
    {
        bool res = false;
        double outDouble = 0.0;
        res = double.TryParse(text, out outDouble);
        return res;
    }

    public static bool IsEmailAddress(string emailAddress)
    {
        string pattern = @"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
        Regex rgx = new Regex(pattern);
        bool isMatch = rgx.IsMatch(emailAddress);
        return isMatch;
    }

    public static string ToUrlText(string text)
    {
        return text.Replace(' ', '-');
    }

    public static string GetRandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }

    public static string Erase(string text, string eraseText)
    {
        return text.Replace(eraseText, "");
    }
    #endregion

    #region Membership related:
    public static bool IsValidUserName(string userName)
    {
        return true;
    }

    public static bool IsValidPassword(string password)
    {
        return true;
    }
    #endregion

    #region Image related:
    public static bool IsSupportedExtension(string Ext)
    {
        if ((Ext.ToLower() == "jpeg") || (Ext.ToLower() == "png") || (Ext.ToLower() == "jpg") || (Ext.ToLower() == "gif"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static System.Drawing.Bitmap GetThumbnailImage(System.Drawing.Image image, int Thumb_Width, int Thumb_Height)
    {
        Bitmap bmp = new Bitmap(Thumb_Width, Thumb_Height);
        System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, Thumb_Width, Thumb_Height);
        gr.DrawImage(image, rectDestination, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
        return bmp;
    }

    public static System.Drawing.Bitmap GetRectangleFromBitmapImage(System.Drawing.Bitmap image, int width, int height)
    {
        Rectangle rect = new Rectangle(0, 0, width, height);
        return image.Clone(rect, System.Drawing.Imaging.PixelFormat.DontCare);
    }

    public System.Drawing.Image GetThumbnailImage_MediumQuality(System.Drawing.Image image, int Thumb_Width, int Thumb_Height)
    {
        return image.GetThumbnailImage(Thumb_Width, Thumb_Height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
    }

    public bool ThumbnailCallback()
    {
        return true;
    }

    public static string GetExtension(string FileName)
    {
        return FileName.Substring(FileName.LastIndexOf('.') + 1);
    }
    #endregion

    #region Other methods:
    public static Control FindControl(ControlCollection collection, Type type)
    {
        Control control = null;
        foreach (Control c in collection)
        {
            if (c.GetType() == type)
                return c;
        }
        return control;
    }

    public static int GetIndexOf(System.Web.UI.WebControls.DropDownList combo, string val)
    {
        int index = -1;
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Value == val)
            {
                index = i;
                return i;
            }
        }
        return index;
    }

    public static void MessageBoxShow(string MessageText, System.Web.UI.Control ctrl)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(ctrl, typeof(Control), "click", @"alert('" + MessageText + "');", true);
    }

    public static System.Drawing.Color GetRandomColor()
    {
        Random random = new Random(Guid.NewGuid().GetHashCode());
        System.Drawing.Color color = System.Drawing.Color.FromArgb(240, (byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255));
        return color;
    }
    #endregion
}