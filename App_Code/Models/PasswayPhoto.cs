using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Models
{
    public partial class PasswayPhoto
    {
        public int Width
        {
            get
            {
                string filePath = HttpContext.Current.Server.MapPath(Urls.PasswayPhotos + this.FileName);
                if (System.IO.File.Exists(filePath))
                    return System.Drawing.Image.FromFile(filePath).Width;
                else return 0;
            }
        }

        public int Height
        {
            get
            {
                string filePath = HttpContext.Current.Server.MapPath(Urls.PasswayPhotos + this.FileName);
                if (System.IO.File.Exists(filePath))
                    return System.Drawing.Image.FromFile(filePath).Height;
                else return 0;
            }
        }

        public int ThumbWidth
        {
            get
            {
                string filePath = HttpContext.Current.Server.MapPath(Urls.PasswayThumbnails + this.FileName);
                if (System.IO.File.Exists(filePath))
                    return System.Drawing.Image.FromFile(filePath).Width;
                else return 0;
            }
        }

        public int ThumbHeight
        {
            get
            {
                string filePath = HttpContext.Current.Server.MapPath(Urls.PasswayThumbnails + this.FileName);
                if (System.IO.File.Exists(filePath))
                    return System.Drawing.Image.FromFile(filePath).Height;
                else return 0;
            }
        }
    }
}