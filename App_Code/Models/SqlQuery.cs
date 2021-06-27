using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Models
{
    public class SqlQuery
    {
        public SqlQuery(string commandText, SqlParameter[] commandParameters)
        {
            CommandText = commandText;
            CommandParameters = commandParameters;
        }
        //************************ prop:
        public string CommandText { get; set; }
        public SqlParameter[] CommandParameters { get; set; }
    }
}