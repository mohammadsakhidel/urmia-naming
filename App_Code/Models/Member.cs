using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public partial class Member
    {
        public bool IsApproved
        {
            get
            {
                return System.Web.Security.Membership.GetUser(this.UserName).IsApproved;
            }

        }
    }
}