using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace Models
{
    public class MosavabsRepository
    {
        NamgozariDBEntities db = new NamgozariDBEntities(MyHelper.EntitiesConnectionString);
        //**********************************************************************************
        public void Add(Mosavab newObj)
        {
            db.Mosavabs.AddObject(newObj);
            Save();
        }

        public Mosavab Get(int Id)
        {
            try
            {
                return db.Mosavabs.Single(obj => obj.ID == Id);
            }
            catch
            {
                return null;
            }
        }

        public Mosavab Get(string shomare)
        {
            try
            {
                return db.Mosavabs.Single(obj => obj.Shomare == shomare);
            }
            catch
            {
                return null;
            }
        }

        public MosavabPhoto GetPhoto(int pId)
        {
            try
            {
                return db.MosavabPhotos.Single(pp => pp.ID == pId);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Mosavab> GetAll()
        {
            return db.Mosavabs.OrderBy(obj => obj.Shomare);
        }

        public IEnumerable<Mosavab> Search(List<Hashtable> conditions)
        {
            SqlQuery query = Models.Helper.GetSqlQuery(conditions, "[Mosavabs]");
            var recs = db.ExecuteStoreQuery<Mosavab>(query.CommandText, query.CommandParameters).OrderByDescending(m => m.Shomare).ToList();
            return recs;
        }

        public void Delete(int Id)
        {
            //************* delete photos:
            Mosavab mos = Get(Id);
            foreach (MosavabPhoto ph in mos.MosavabPhotos)
            {
                DeletePhotoFiles(ph);
            }
            mos.MosavabPhotos.ToList().ForEach(db.MosavabPhotos.DeleteObject);
            //*******
            db.Mosavabs.DeleteObject(Get(Id));
            Save();
        }

        public void DeletePhotoFiles(MosavabPhoto photo)
        {
            string fileName = photo.FileName;
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(Urls.MosavabThumbnails + fileName));
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(Urls.MosavabPhotos + fileName));
        }

        public void DeletePhoto(int photoId)
        {
            MosavabPhoto photo = GetPhoto(photoId);
            string fileName = photo.FileName;
            //***** delete in db:
            db.MosavabPhotos.DeleteObject(photo);
            //***** delete files:
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(Urls.MosavabThumbnails + fileName));
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(Urls.MosavabPhotos + fileName));
            Save();
        }

        public bool Exists(int Id)
        {
            return db.Mosavabs.Where(obj => obj.ID == Id).Count() > 0 ? true : false;
        }

        public bool Exists(int exceptFor, string shomare)
        {
            shomare = shomare.Replace(" ", "");
            return db.Mosavabs.Where(obj => obj.ID != exceptFor && obj.Shomare.Replace(" ", "") == shomare).Count() > 0 ? true : false;
        }

        public bool Exists(string shomare)
        {
            shomare = shomare.Replace(" ", "");
            return db.Mosavabs.Where(obj => obj.Shomare.Replace(" ", "") == shomare).Count() > 0 ? true : false;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}