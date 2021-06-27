using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Reflection;

namespace Models
{
    public class PasswaysRepository : IDisposable
    {
        NamgozariDBEntities db = new NamgozariDBEntities(MyHelper.EntitiesConnectionString);
        //**********************************************************************************
        public void Add(Passway passway)
        {
            db.Passways.AddObject(passway);
            Save();
        }

        public Passway Get(int Id)
        {
            try
            {
                return db.Passways.Single(pass => pass.ID == Id);
            }
            catch
            {
                return null;
            }
        }

        public Passway GetByRecordId(string recId)
        {
            try
            {
                return db.Passways.SingleOrDefault(pass => pass.RecordId == recId);
            }
            catch
            {
                return null;
            }
        }

        public PasswayPhoto GetPhoto(int pId)
        {
            try
            {
                return db.PasswayPhotoes.Single(pp => pp.ID == pId);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Passway> GetAll()
        {
            return db.Passways.OrderBy(pass => pass.Name);
        }

        public int GetNameTypeUsage(int type, DateTime begin, DateTime end, int region)
        {
            if (region == 0)
            {
                return db.Passways.Where(pw => pw.NameType == type && pw.DateOfAdd >= begin && pw.DateOfAdd <= end).Count();
            }
            else
            {
                return db.Passways.Where(pw => pw.NameType == type && pw.DateOfAdd >= begin && pw.DateOfAdd <= end && (pw.Region.HasValue && pw.Region.Value == region)).Count();
            }
        }

        public int GetTypeUsage(int type, DateTime begin, DateTime end, int region)
        {
            if (region == 0)
            {
                return db.Passways.Where(pw => pw.Type == type && pw.DateOfAdd >= begin && pw.DateOfAdd <= end).Count();
            }
            else
            {
                return db.Passways.Where(pw => pw.Type == type && pw.DateOfAdd >= begin && pw.DateOfAdd <= end && (pw.Region.HasValue && pw.Region.Value == region)).Count();
            }
        }

        public bool PassWayExists(string name, int passwayType)
        {
            name = name.Replace(" ", "");
            //int[] kooyGroup = Pairs.PasswayGroups.First();
            //if (kooyGroup.Contains(passwayType)) return false;
            int[] group = Pairs.PasswayGroups.Single(g => g.Contains(passwayType));
            return db.Passways
                .Where(obj => group.Contains(obj.Type) && obj.Name.Replace(" ", "") == name)
                .Count() > 0 ? true : false;
        }

        public bool PassWayExists(int exceptFor, string name, int passwayType)
        {
            name = name.Replace(" ", "");
            int[] kooyGroup = Pairs.PasswayGroups.First();
            if (kooyGroup.Contains(passwayType)) return false;
            int[] group = Pairs.PasswayGroups.Single(g => g.Contains(passwayType));
            return db.Passways.Where(obj => group.Contains(obj.Type) &&  obj.ID != exceptFor && obj.Name.Replace(" ", "") == name).Count() > 0 ? true : false;
        }

        public bool PassWayExists(string recordId)
        {
            return db.Passways.Where(p => p.RecordId == recordId).Any();
        }

        public IEnumerable<Passway> Search(List<Hashtable> conditions)
        {
            SqlQuery query = Models.Helper.GetSqlQuery(conditions, "[Passways]");
            var recs = db.ExecuteStoreQuery<Passway>(query.CommandText, query.CommandParameters).OrderBy(p => p.Name).ToList();
            return recs;
        }

        public IEnumerable<Passway> ExecuteQuery(string query) {
            var recs = db.ExecuteStoreQuery<Passway>(query).ToList();
            return recs;
        }

        public void Delete(int Id)
        {
            //************* delete photos:
            Passway pass = Get(Id);
            foreach (PasswayPhoto ph in pass.PasswayPhotoes)
            {
                DeletePhotoFiles(ph);
            }
            pass.PasswayPhotoes.ToList().ForEach(db.PasswayPhotoes.DeleteObject);
            //************* set passName as Unused:
            PassNamesRepository pr = new PassNamesRepository();
            pr.SetAsUnused(pass.Name);
            //************* delete passway:
            db.Passways.DeleteObject(pass);
            Save();
        }
        public void DeletePhoto(int photoId)
        {
            PasswayPhoto photo = GetPhoto(photoId);
            string fileName = photo.FileName;
            //***** delete in db:
            db.PasswayPhotoes.DeleteObject(photo);
            //***** delete files:
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(Urls.PasswayThumbnails + fileName));
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(Urls.PasswayPhotos + fileName));
            Save();
        }

        public void DeletePhotoFiles(PasswayPhoto photo)
        {
            string fileName = photo.FileName;
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(Urls.PasswayThumbnails + fileName));
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(Urls.PasswayPhotos + fileName));
        }

        public void SaveEditedRecord(Passway passway)
        {
            var dbPass = GetByRecordId(passway.RecordId);
            if (dbPass != null)
            {
                dbPass = applyChanges(dbPass, passway);
                //////shape info:
                var points = new List<Location>();
                if (dbPass.BeginingLongitude.HasValue && dbPass.BeginingLatitude.HasValue)
                {
                    points.Add(new Location(dbPass.BeginingLongitude.Value, dbPass.BeginingLatitude.Value));
                }
                if (dbPass.EndingLongitude.HasValue && dbPass.EndingLatitude.HasValue)
                {
                    points.Add(new Location(dbPass.EndingLongitude.Value, dbPass.EndingLatitude.Value));
                }
                var shape = points.Any() ? new MapShape(MyEnums.MapShapeType.Line, points) : null;
                dbPass.ShapeInfo = shape != null ? shape.Formula : "";
                //--- length:
                dbPass.Length = points.Count >= 2 ? (int)(GeoCodeCalc.CalcDistance(points[0].Latitude, points[0].Longitude, points[1].Latitude, points[1].Longitude) * 1000) : 0;
                ///// save
                Save();
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        private Passway applyChanges(Passway dbPass, Passway editedPass)
        {
            dbPass.Name = editedPass.Name;
            dbPass.Type = editedPass.Type;
            dbPass.PrecedingType = editedPass.PrecedingType;
            dbPass.Region = editedPass.Region;
            dbPass.Width = editedPass.Width;
            dbPass.Explanation = editedPass.Explanation;
            dbPass.RecordId = editedPass.RecordId;
            dbPass.PrecedingRecordId = editedPass.PrecedingRecordId;
            dbPass.FloorType = editedPass.FloorType;
            dbPass.HasBoard = editedPass.HasBoard;
            dbPass.BoardType = editedPass.BoardType;
            dbPass.BoardSize = editedPass.BoardSize;
            dbPass.HasLighting = editedPass.HasLighting;
            dbPass.CountOfStores = editedPass.CountOfStores;
            dbPass.CountOfShoppingCenters = editedPass.CountOfShoppingCenters;
            dbPass.CountOfCondominiums = editedPass.CountOfCondominiums;
            dbPass.CountOfOfficeComplexes = editedPass.CountOfOfficeComplexes;
            dbPass.CountOfHouses = editedPass.CountOfHouses;
            dbPass.CountOfOfficeBuildings = editedPass.CountOfOfficeBuildings;
            dbPass.CountOfOthers = editedPass.CountOfOthers;
            dbPass.HasChannel = editedPass.HasChannel;
            dbPass.ChannelType = editedPass.ChannelType;
            dbPass.HasPlanting = editedPass.HasPlanting;
            dbPass.HasSidewalk = editedPass.HasSidewalk;
            dbPass.SidewalkFloorType = editedPass.SidewalkFloorType;
            dbPass.SidewalkWidth = editedPass.SidewalkWidth;
            dbPass.IsSidewalkIncomplete = editedPass.IsSidewalkIncomplete;
            dbPass.BeginingLongitude = editedPass.BeginingLongitude;
            dbPass.BeginingLatitude = editedPass.BeginingLatitude;
            dbPass.EndingLongitude = editedPass.EndingLongitude;
            dbPass.EndingLatitude = editedPass.EndingLatitude;
            dbPass.HasFur = editedPass.HasFur;
            dbPass.HasFurNimkat = editedPass.HasFurNimkat;
            dbPass.HasFurAbkhori = editedPass.HasFurAbkhori;
            dbPass.HasFurTrash = editedPass.HasFurTrash;
            dbPass.HasFurBodyBuilding = editedPass.HasFurBodyBuilding;
            dbPass.HasFurToys = editedPass.HasFurToys;
            dbPass.HasFurLamps = editedPass.HasFurLamps;
            dbPass.HasFurAdv = editedPass.HasFurAdv;
            dbPass.DateOfAdd = editedPass.DateOfAdd;
            dbPass.AddedBy = editedPass.AddedBy;
            return dbPass;
        }

        public IEnumerable<Passway> SearchInArea(Location topLeft, Location bottomRight, int? passwayTyp, bool hasName, int pageSize)
        {
            var q = from p in db.Passways
                    where (((p.BeginingLatitude <= topLeft.Latitude && p.BeginingLatitude >= bottomRight.Latitude && p.BeginingLongitude >= topLeft.Longitude && p.BeginingLongitude <= bottomRight.Longitude) ||
                           (p.EndingLatitude <= topLeft.Latitude && p.EndingLatitude >= bottomRight.Latitude && p.EndingLongitude >= topLeft.Longitude && p.EndingLongitude <= bottomRight.Longitude)) &&
                           (hasName && !String.IsNullOrEmpty(p.Name) || (!hasName && String.IsNullOrEmpty(p.Name))) &&
                           (!passwayTyp.HasValue || passwayTyp.Value == (int)p.Type))
                    select p;
            return q.OrderBy(p => Guid.NewGuid()).Take(pageSize);
        }
    }
}