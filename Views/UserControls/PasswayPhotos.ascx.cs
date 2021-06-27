using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_UserControls_PasswayPhotos : System.Web.UI.UserControl
{
    //********************************* Properties:
    public int PasswayID
    {
        get
        {
            return Convert.ToInt32(hid_PasswayID.Value);
        }
        set
        {
            hid_PasswayID.Value = value.ToString();
        }
    }
    public AccessToPassways Access
    {
        get
        {
            return new AccessToPassways(hid_Access.Value);
        }
        set
        {
            hid_Access.Value = value.GetString();
        }
    }
    //********************************* Methods:
    public void LoadData()
    {
        PasswaysRepository pr = new PasswaysRepository();
        Passway pass = pr.Get(PasswayID);
        var photos = pass.PasswayPhotoes;
        list_PasswayPhotos.DataSource = photos;
        list_PasswayPhotos.DataBind();
        pnl_UploadFile.Visible = (Access.AddPhoto ? true : false);
        pnl_Photos.Visible = (photos.Count() > 0 ? true : false);
    }
    //********************************* Event Handlers:
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (!Access.AddPhoto) throw new Exception("شما دارای حق دسترسی لازم نمی باشید");
        bool hasPhoto = fileUploader.HasFile;
        bool isValidPhoto = hasPhoto && MyHelper.IsSupportedExtension(MyHelper.GetExtension(fileUploader.FileName));
        if (isValidPhoto)
        {
            string extension = "." + MyHelper.GetExtension(fileUploader.FileName);
            string randomName = MyHelper.GetRandomString(20, true);
            string picName = randomName + extension;
            string urlOfPhoto = Urls.PasswayPhotos + picName;
            string urlOfThumbnail = Urls.PasswayThumbnails + picName;
            //get uploaded raw image:
            System.Drawing.Image uploadedImage = System.Drawing.Image.FromStream(fileUploader.FileContent);
            int uploadedLonger = uploadedImage.Width > uploadedImage.Height ? uploadedImage.Width : uploadedImage.Height;
            //get photo image:
            Utilities.Resizer photoResizer = new Utilities.Resizer(uploadedImage.Width, uploadedImage.Height, Utilities.ResizeType.LongerFix, Digits.PasswayPhotoMaxWidth < uploadedLonger ? Digits.PasswayPhotoMaxWidth : uploadedLonger);
            System.Drawing.Image photoImage = MyHelper.GetThumbnailImage(uploadedImage, photoResizer.NewWidth, photoResizer.NewHeight);
            //get thumb image:
            Utilities.Resizer thumbResizer = new Utilities.Resizer(photoImage.Width, photoImage.Height, Utilities.ResizeType.WidthFix, Digits.PasswayThumbWith);
            System.Drawing.Bitmap thumbImage = MyHelper.GetThumbnailImage(uploadedImage, thumbResizer.NewWidth, thumbResizer.NewHeight);
            System.Drawing.Bitmap rectImage = MyHelper.GetRectangleFromBitmapImage(thumbImage, Digits.PasswayThumbWith, (thumbImage.Height > Digits.PasswayThumbHeight ? Digits.PasswayThumbHeight : thumbImage.Height));
            //********************************* saving data:
            PasswaysRepository pr = new PasswaysRepository();
            Passway pass = pr.Get(PasswayID);
            PasswayPhoto photo = new PasswayPhoto();
            photo.FileName = picName;
            photo.DateOfAdd = MyHelper.Now;
            photo.AddedBy = HttpContext.Current.User.Identity.Name;
            pass.PasswayPhotoes.Add(photo);
            //********************************* saving photo:
            photoImage.Save(HttpContext.Current.Server.MapPath(urlOfPhoto));
            rectImage.Save(HttpContext.Current.Server.MapPath(urlOfThumbnail));
            pr.Save();
            LoadData();
        }
    }

    protected void list_PasswayPhotos_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "DeletePasswayPhoto")
        {
            if (!Access.DeletePhoto) throw new Exception("شما دارای حق دسترسی لازم نمی باشید");
            int photoId = Convert.ToInt32(e.CommandArgument);
            PasswaysRepository pr = new PasswaysRepository();
            pr.DeletePhoto(photoId);
            /////
            LoadData();
        }
    }
}