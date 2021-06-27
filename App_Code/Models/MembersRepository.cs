using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace Models
{
    public class MembersRepository
    {
        NamgozariDBEntities db = new NamgozariDBEntities(MyHelper.EntitiesConnectionString);
        //**********************************************************************************
        public void Add(Member newObj)
        {
            db.Members.AddObject(newObj);
            Save();
        }

        public void AddAccessRule(AccessRule rule)
        {
            db.AccessRules.Where(r => r.MemberID == rule.MemberID).ToList().ForEach(db.AccessRules.DeleteObject);
            db.AccessRules.AddObject(rule);
            Save();
        }

        public Member Get(int Id)
        {
            try
            {
                return db.Members.Single(obj => obj.ID == Id);
            }
            catch
            {
                return null;
            }
        }

        public Member Get(string userName)
        {
            try
            {
                return db.Members.Single(obj => obj.UserName == userName);
            }
            catch
            {
                return null;
            }
        }

        public AccessRule GetAccessRule(int memberId)
        {
            try
            {
                if (db.AccessRules.Where(rule => rule.MemberID == memberId).Count() == 1)
                    return db.AccessRules.Single(rule => rule.MemberID == memberId);
                else
                    throw new Exception("error: more or less access rules!");
            }
            catch
            {
                AccessRule rule = GetDefaultAccessRule();
                rule.MemberID = memberId;
                db.AccessRules.AddObject(rule);
                Save();
                return rule;
            }
        }

        public AccessRule GetAccessRule(string userName)
        {
            try
            {
                return db.AccessRules.Single(rule => rule.Member.UserName == userName);
            }
            catch
            {
                AccessRule rule = GetDefaultAccessRule();
                rule.MemberID = Get(userName).ID;
                db.AccessRules.AddObject(rule);
                Save();
                return rule;
            }
        }

        public AccessRule GetDefaultAccessRule()
        {
            return new AccessRule("00011100", "00011100", "00011", "000000");
        }

        public IEnumerable<Member> GetAll()
        {
            return db.Members.OrderBy(obj => obj.FullName);
        }

        public IEnumerable<Member> Search(List<Hashtable> conditions)
        {
            SqlQuery query = Models.Helper.GetSqlQuery(conditions, "[Members]");
            var recs = db.ExecuteStoreQuery<Member>(query.CommandText, query.CommandParameters).OrderBy(p => p.FullName).ToList();
            return recs;
        }

        public void Delete(int Id)
        {
            db.Members.DeleteObject(Get(Id));
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}