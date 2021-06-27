using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Models
{
    public class Helper
    {
        public static SqlQuery GetSqlQuery(List<Hashtable> conditions, string tableName)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string query = "SELECT * FROM " + tableName;
            if (conditions.Count > 0)
            {
                query += " WHERE ";
                for (int i = 0; i < conditions.Count; i++)
                {
                    Hashtable condition = conditions[i];
                    MyEnums.AdvancedSearchCondition asc = (MyEnums.AdvancedSearchCondition)(Convert.ToInt32(condition["condition"]));
                    MyEnums.AdvancedSearchFieldType fieldType = (MyEnums.AdvancedSearchFieldType)(Convert.ToInt32(condition["field_type"]));
                    string fieldName = (fieldType != MyEnums.AdvancedSearchFieldType.Date ? condition["field"].ToString() : "CAST(" + condition["field"].ToString() + " AS DATE)");
                    string op = (asc == MyEnums.AdvancedSearchCondition.Equal ? "=" : (asc == MyEnums.AdvancedSearchCondition.Fewer ? "<=" : (asc == MyEnums.AdvancedSearchCondition.Greater ? ">=" : "LIKE")));
                    string val = "";
                    if (fieldType == MyEnums.AdvancedSearchFieldType.Text)
                    {
                        val = 
                            "N'" + 
                            (op == "LIKE" ? "%" : "") + 
                            condition["value"].ToString() + 
                            (op == "LIKE" ? "%" : "") + 
                            "'";
                    }
                    else if (fieldType == MyEnums.AdvancedSearchFieldType.Digit)
                    {
                        val = condition["value"].ToString();
                    }
                    else if (fieldType == MyEnums.AdvancedSearchFieldType.Date)
                    {
                        string paramName = "param" + i.ToString();
                        val = "@" + paramName;
                        parameters.Add(new SqlParameter(paramName, Utilities.ShamsiDateTime.FromText(condition["value"].ToString()).MiladyDate));
                    }
                    else if (fieldType == MyEnums.AdvancedSearchFieldType.Bool)
                    {
                        string paramName = "param" + i.ToString();
                        val = "@" + paramName;
                        parameters.Add(new SqlParameter(paramName, Convert.ToBoolean(condition["value"])));
                    }
                    string condition_text = fieldName + " " + op + " " + val;
                    query += (i == 0 ? condition_text : " AND " + condition_text);
                }
            }
            return new SqlQuery(query, parameters.ToArray());
        }
    }
}