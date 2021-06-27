using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public partial class AccessRule
    {
        public AccessRule()
        {
        }

        public AccessRule(string passways, string mosavabs, string passNames, string members)
        {
            AccessToPassways = passways;
            AccessToMosavabs = mosavabs;
            AccessToPassNames = passNames;
            AccessToMembers = members;
        }

        public AccessToPassways AccessToPasswaysObj
        {
            get
            {
                return new AccessToPassways(this.AccessToPassways);
            }
        }

        public AccessToMosavabs AccessToMosavabsObj
        {
            get
            {
                return new AccessToMosavabs(this.AccessToMosavabs);
            }
        }

        public AccessToPassNames AccessToPassNamesObj
        {
            get
            {
                return new AccessToPassNames(this.AccessToPassNames);
            }
        }

        public AccessToMembers AccessToMembersObj
        {
            get
            {
                return new AccessToMembers(this.AccessToMembers);
            }
        }

        public AccessToReports AccessToReportsObj {
            get {
                return new AccessToReports(this.AccessToReports);
            }
        }
    }

    public class AccessToPassways
    {
        public AccessToPassways(string rule)
        {
            Create = rule[0].ToString() == "1";
            Edit = rule[1].ToString() == "1";
            Delete = rule[2].ToString() == "1";
            Search = rule[3].ToString() == "1";
            Details = rule[4].ToString() == "1";
            Photos = rule[5].ToString() == "1";
            AddPhoto = rule[6].ToString() == "1";
            DeletePhoto = rule[7].ToString() == "1";
        }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Search { get; set; }
        public bool Details { get; set; }
        public bool Photos { get; set; }
        public bool AddPhoto { get; set; }
        public bool DeletePhoto { get; set; }
        public bool ShowSection
        {
            get
            {
                return this.Create || this.Search ? true : false;
            }
        }
        public string GetString()
        {
            string st = "";
            st += this.Create ? "1" : "0";
            st += this.Edit ? "1" : "0";
            st += this.Delete ? "1" : "0";
            st += this.Search ? "1" : "0";
            st += this.Details ? "1" : "0";
            st += this.Photos ? "1" : "0";
            st += this.AddPhoto ? "1" : "0";
            st += this.DeletePhoto ? "1" : "0";
            return st;
        }
    }

    public class AccessToMosavabs
    {
        public AccessToMosavabs(string rule)
        {
            Create = rule[0].ToString() == "1";
            Edit = rule[1].ToString() == "1";
            Delete = rule[2].ToString() == "1";
            Search = rule[3].ToString() == "1";
            Details = rule[4].ToString() == "1";
            Photos = rule[5].ToString() == "1";
            AddPhoto = rule[6].ToString() == "1";
            DeletePhoto = rule[7].ToString() == "1";
        }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Search { get; set; }
        public bool Details { get; set; }
        public bool Photos { get; set; }
        public bool AddPhoto { get; set; }
        public bool DeletePhoto { get; set; }
        public bool ShowSection
        {
            get
            {
                return this.Create || this.Search ? true : false;
            }
        }
        public string GetString()
        {
            string st = "";
            st += this.Create ? "1" : "0";
            st += this.Edit ? "1" : "0";
            st += this.Delete ? "1" : "0";
            st += this.Search ? "1" : "0";
            st += this.Details ? "1" : "0";
            st += this.Photos ? "1" : "0";
            st += this.AddPhoto ? "1" : "0";
            st += this.DeletePhoto ? "1" : "0";
            return st;
        }
    }

    public class AccessToPassNames
    {
        public AccessToPassNames(string rule)
        {
            Create = rule[0].ToString() == "1";
            Edit = rule[1].ToString() == "1";
            Delete = rule[2].ToString() == "1";
            Search = rule[3].ToString() == "1";
            Details = rule[4].ToString() == "1";
        }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Search { get; set; }
        public bool Details { get; set; }
        public bool ShowSection
        {
            get
            {
                return this.Create || this.Search ? true : false;
            }
        }
        public string GetString()
        {
            string st = "";
            st += this.Create ? "1" : "0";
            st += this.Edit ? "1" : "0";
            st += this.Delete ? "1" : "0";
            st += this.Search ? "1" : "0";
            st += this.Details ? "1" : "0";
            return st;
        }
    }

    public class AccessToMembers
    {
        public AccessToMembers(string rule)
        {
            Create = rule[0].ToString() == "1";
            Edit = rule[1].ToString() == "1";
            Delete = rule[2].ToString() == "1";
            List = rule[3].ToString() == "1";
            AccessRules = rule[4].ToString() == "1";
        }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool List { get; set; }
        public bool AccessRules { get; set; }
        public bool ShowSection
        {
            get
            {
                return this.Create || this.List ? true : false;
            }
        }
        public string GetString()
        {
            string st = "";
            st += this.Create ? "1" : "0";
            st += this.Edit ? "1" : "0";
            st += this.Delete ? "1" : "0";
            st += this.List ? "1" : "0";
            st += this.AccessRules ? "1" : "0";
            return st;
        }
    }

    public class AccessToReports {
        public AccessToReports(string rule) {
            View = rule[0].ToString() == "1";
        }
        public bool View { get; set; }
        public bool ShowSection {
            get {
                return this.View;
            }
        }
        public string GetString() {
            string st = "";
            st += this.View ? "1" : "0";
            return st;
        }
    }
}