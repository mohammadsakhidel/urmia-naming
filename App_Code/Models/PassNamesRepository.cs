using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace Models
{
    public class PassNamesRepository
    {
        NamgozariDBEntities db = new NamgozariDBEntities(MyHelper.EntitiesConnectionString);
        //**********************************************************************************
        public void Add(PassName newObj)
        {
            db.PassNames.AddObject(newObj);
            Save();
        }

        public PassName Get(int Id)
        {
            try
            {
                return db.PassNames.Single(obj => obj.ID == Id);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<PassName> GetAll()
        {
            return db.PassNames.OrderBy(obj => obj.Name);
        }

        public IEnumerable<PassName> Search(List<Hashtable> conditions)
        {
            SqlQuery query = Models.Helper.GetSqlQuery(conditions, "[PassNames]");
            var recs = db.ExecuteStoreQuery<PassName>(query.CommandText, query.CommandParameters).OrderByDescending(p => p.Name).ToList();
            return recs;
        }

        public void Delete(int Id)
        {
            db.PassNames.DeleteObject(Get(Id));
            Save();
        }

        public bool PassNameExists(string name)
        {
            name = name.Replace(" ", "");
            return db.PassNames.Where(obj => obj.Name.Replace(" ", "") == name).Count() > 0 ? true : false;
        }

        public bool PassNameExists(int exceptFor, string name)
        {
            name = name.Replace(" ", "");
            return db.PassNames.Where(obj => obj.ID != exceptFor && obj.Name.Replace(" ", "") == name).Count() > 0 ? true : false;
        }

        public void SetAsUsed(string name)
        {
            name = name.Replace(" ", "");
            var names = db.PassNames.Where(obj => obj.Name.Replace(" ", "") == name).ToList();
            foreach (PassName pName in names)
            {
                pName.Status = (int)MyEnums.PassNameStatus.Used;
            }
            Save();
        }

        public void SetAsUnused(string name)
        {
            name = name.Replace(" ", "");
            var names = db.PassNames.Where(obj => obj.Name.Replace(" ", "") == name).ToList();
            foreach (PassName pName in names)
            {
                pName.Status = (int)MyEnums.PassNameStatus.Unused;
            }
            Save();
        }

        public byte GetNameType(string name)
        {
            try
            {
                return (byte)db.PassNames.Single(p => p.Name == name).Type;
            }
            catch
            {
                return (byte)Pairs.PassNameTypes.Last().Key;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}