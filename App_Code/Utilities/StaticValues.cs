using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class MyRoles
{
    public const string Administrator = "Administrator";
    public const string Member = "Member";
}

public class Pairs
{
    public static List<KeyValuePair<int, string>> PasswayTypes
    {
        get
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            list.Add(new KeyValuePair<int, string>(1, "کوچه"));
            list.Add(new KeyValuePair<int, string>(2, "خیابان"));
            list.Add(new KeyValuePair<int, string>(3, "کوی"));
            list.Add(new KeyValuePair<int, string>(4, "بن بست"));
            list.Add(new KeyValuePair<int, string>(5, "بلوار"));
            list.Add(new KeyValuePair<int, string>(6, "بزرگراه"));
            list.Add(new KeyValuePair<int, string>(7, "اتوبان"));
            list.Add(new KeyValuePair<int, string>(8, "میدان"));
            list.Add(new KeyValuePair<int, string>(9, "تقاطع غیرهمسطح"));
            list.Add(new KeyValuePair<int, string>(10, "پارک"));
            list.Add(new KeyValuePair<int, string>(11, "بوستان"));
            return list;
        }
    }
    public static List<int[]> PasswayGroups
    {
        get
        {
            List<int[]> list = new List<int[]>();
            list.Add(new int[] { 1, 3, 4 }); //kooche, kooy, bonbast
            list.Add(new int[] { 2, 5, 6, 7 }); //khiaban, bolvar, bozorgrah, otuban
            list.Add(new int[] { 8, 9 });//meydan, pol
            list.Add(new int[] { 10, 11 });//park, boostan
            return list;
        }
    }
    public static List<KeyValuePair<int, string>> Regions
    {
        get
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            list.Add(new KeyValuePair<int, string>(1, "منطقه 1"));
            list.Add(new KeyValuePair<int, string>(2, "منطقه 2"));
            list.Add(new KeyValuePair<int, string>(3, "منطقه 3"));
            list.Add(new KeyValuePair<int, string>(4, "منطقه 4"));
            list.Add(new KeyValuePair<int, string>(5, "منطقه 5"));
            list.Add(new KeyValuePair<int, string>(6, "منطقه 6"));
            return list;
        }
    }
    public static List<KeyValuePair<int, string>> PassNameTypes
    {
        get
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            list.Add(new KeyValuePair<int, string>(1, "شهید"));
            list.Add(new KeyValuePair<int, string>(2, "طبیعت"));
            list.Add(new KeyValuePair<int, string>(3, "بزرگان تاریخی"));
            list.Add(new KeyValuePair<int, string>(4, "بزرگان دینی"));
            list.Add(new KeyValuePair<int, string>(99, "سایر"));
            return list;
        }
    }
    public static Dictionary<byte, string> FloorTypes
    {
        get
        {
            var dic = new Dictionary<byte, string>();
            dic.Add(1, "خاکی");
            dic.Add(2, "شنی");
            dic.Add(3, "آسفالت");
            dic.Add(4, "سنگفرش");
            dic.Add(5, "سایر");
            return dic;
        }
    }
    public static Dictionary<byte, string> BoardTypes
    {
        get
        {
            var dic = new Dictionary<byte, string>();
            dic.Add(1, "دیواری");
            dic.Add(2, "پایه دار");
            return dic;
        }
    }
    public static Dictionary<byte, string> ChannelTypes
    {
        get
        {
            var dic = new Dictionary<byte, string>();
            dic.Add(1, "کانیوو");
            dic.Add(2, "جوب");
            dic.Add(3, "لوله بتنی");
            dic.Add(4, "سرپوشیده");
            dic.Add(5, "سایر");
            return dic;
        }
    }
    public static Dictionary<byte, string> SidewalkFloorTypes
    {
        get
        {
            var dic = new Dictionary<byte, string>();
            dic.Add(1, "خاکی");
            dic.Add(2, "شنی");
            dic.Add(3, "آسفالت");
            dic.Add(4, "سنگفرش");
            dic.Add(5, "سایر");
            return dic;
        }
    }
    public static List<KeyValuePair<bool, string>> BooleanExistence
    {
        get
        {
            List<KeyValuePair<bool, string>> list = new List<KeyValuePair<bool, string>>();
            list.Add(new KeyValuePair<bool, string>(true, "دارد"));
            list.Add(new KeyValuePair<bool, string>(false, "ندارد"));
            return list;
        }
    }
}

public class Urls
{
    public const string Images = "~/Content/Images/";
    public const string PasswayPhotos = "~/Content/Images/PasswayPhotos/";
    public const string PasswayThumbnails = PasswayPhotos + "Thumbnails/";
    public const string MosavabPhotos = "~/Content/Images/MosavabPhotos/";
    public const string MosavabThumbnails = MosavabPhotos + "Thumbnails/";
}

public class Digits
{
    public const int PasswayPhotoMaxWidth = 800;
    public const int PasswayThumbWith = 160;
    public const int PasswayThumbHeight = 90;
    public const int MosavabPhotoMaxWidth = 800;
    public const int MosavabThumbWith = 160;
    public const int MosavabThumbHeight = 90;
}