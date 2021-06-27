using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_UserControls_MosavabPhotos : System.Web.UI.UserControl
{
    //********************* Properties:
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
    public AccessToMosavabs Access
    {
        get
        {
            return new AccessToMosavabs(hid_Access.Value);
        }
        set
        {
            hid_Access.Value = value.GetString();
        }
    }
    //********************* methods:
    public void LoadData()
    {
        MosavabsRepository pr = new MosavabsRepository();
        Mosavab mos = pr.Get(MosavabID);
        var photos = mos.MosavabPhotos;
        list_MosavabPhotos.DataSource = photos;
        list_MosavabPhotos.DataBind();
        pnl_UploadFile.Visible = (Access.AddPhoto ? true : false);
        pnl_Photos.Visible = (photos.Count() > 0 ? true : false);
    }
    //*********************
    protected void list_MosavabPhotos_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "DeleteMosavabPhoto")
        {
            if (!Access.DeletePhoto) throw new Exception("شما دارای حق دسترسی لازم نمی باشید");
            int photoId = Convert.ToInt32(e.CommandArgument);
            MosavabsRepository mr = new MosavabsRepository();
            mr.DeletePhoto(photoId);
            /////
            LoadData();
        }
    }
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
            string urlOfPhoto = Urls.MosavabPhotos + picName;
            string urlOfThumbnail = Urls.MosavabThumbnails + picName;
            //get uploaded raw image:
            System.Drawing.Image uploadedImage = System.Drawing.Image.FromStream(fileUploader.FileContent);
            int uploadedLonger = uploadedImage.Width > uploadedImage.Height ? uploadedImage.Width : uploadedImage.Height;
            //get photo image:
            Utilities.Resizer photoResizer = new Utilities.Resizer(uploadedImage.Width, uploadedImage.Height, Utilities.ResizeType.LongerFix, Digits.MosavabPhotoMaxWidth < uploadedLonger ? Digits.MosavabPhotoMaxWidth : uploadedLonger);
            System.Drawing.Image photoImage = MyHelper.GetThumbnailImage(uploadedImage, photoResizer.NewWidth, photoResizer.NewHeight);
            //get thumb image:
            Utilities.Resizer thumbResizer = new Utilities.Resizer(photoImage.Width, photoImage.Height, Utilities.ResizeType.WidthFix, Digits.MosavabThumbWith);
            System.Drawing.Bitmap thumbImage = MyHelper.GetThumbnailImage(uploadedImage, thumbResizer.NewWidth, thumbResizer.NewHeight);
            System.Drawing.Bitmap rectImage = MyHelper.GetRectangleFromBitmapImage(thumbImage, Digits.MosavabThumbWith, (thumbImage.Height > Digits.MosavabThumbHeight ? Digits.MosavabThumbHeight : thumbImage.Height));
            //********************************* saving data:
            MosavabsRepository mr = new MosavabsRepository();
            Mosavab mos = mr.Get(MosavabID);
            MosavabPhoto photo = new MosavabPhoto();
            photo.FileName = picName;
            photo.DateOfAdd = MyHelper.Now;
            photo.AddedBy = HttpContext.Current.User.Identity.Name;
            mos.MosavabPhotos.Add(photo);
            //********************************* saving photo:
            photoImage.Save(HttpContext.Current.Server.MapPath(urlOfPhoto));
            rectImage.Save(HttpContext.Current.Server.MapPath(urlOfThumbnail));
            mr.Save();
            LoadData();
        }
    }
}