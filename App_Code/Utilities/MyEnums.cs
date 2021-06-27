using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEnums
{
    public enum DateType
    {
        Short = 1,
        ShortWithTime = 2,
        Medium = 3,
        MediumWithTime = 4
    }

    public enum FormAction
    {
        New = 1,
        Edit = 2
    }

    public enum AdvancedSearchCondition
    {
        Equal = 1,
        Fewer = 2,
        Greater = 3,
        Like = 4
    }

    public enum AdvancedSearchFieldType
    {
        Text = 1,
        Digit = 2,
        Date = 3,
        Bool = 4
    }

    

    public enum PassNameStatus
    {
        Unused = 1,
        Used = 2
    }

    public enum MapShapeType
    {
        Line = 1,
        Polygon = 2
    }

}