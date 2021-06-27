using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyEnums;

namespace Models
{
    public class MapShape
    {
        public MapShape(MapShapeType type, List<Models.Location> points)
        {
            Type = type;
            Points = points;
        }
        public MapShape(string formula)
        {
            List<string> sections = MyHelper.SplitString(formula, ":");
            Type = (sections[0] == "line" ? MyEnums.MapShapeType.Line : MyEnums.MapShapeType.Polygon);
            if (sections.Count > 1)
            {
                for (int i = 1; i < sections.Count; i++)
                {
                    string pointString = sections[i];
                    string id = MyHelper.SplitString(pointString, ",")[0];
                    double lng = Convert.ToDouble(MyHelper.SplitString(pointString, ",")[1]);
                    double lat = Convert.ToDouble(MyHelper.SplitString(pointString, ",")[2]);
                    if ((int)lng > 0 && (int)lat > 0)
                    {
                        List<Models.Location> points = (Points == null ? new List<Models.Location>() : Points);
                        points.Add(new Models.Location(id, lng, lat));
                        Points = points;
                    }
                }
            }
            else
            {
                Points = new List<Location>();
            }
        }
        //*********************************
        public MapShapeType Type { get; set; }
        public List<Models.Location> Points { get; set; }
        public Location AverageCenter
        {
            get
            {
                double avgLng = Points.Select(point => point.Longitude).Sum() / Points.Count;
                double avgLat = Points.Select(point => point.Latitude).Sum() / Points.Count;
                return new Location(avgLng, avgLat);
            }
        }
        public string Formula
        {
            get
            {
                string f = "";
                f += (Type == MapShapeType.Line ? "line:" : "polygon:");
                if (Points != null && Points.Count > 0)
                {
                    for (int i = 0; i < Points.Count; i++)
                    {
                        Models.Location point = Points[i];
                        f += point.ID + "," + point.Longitude.ToString() + "," + point.Latitude + (i < Points.Count - 1 ? ":" : "");
                    }
                }
                return f;
            }
        }
        //*********************************
        public List<Models.Location> RemovePoint(string id)
        {
            List<Models.Location> points = new List<Location>();
            foreach (Models.Location point in Points)
            {
                if (point.ID != id)
                    points.Add(point);
            }
            return points;
        }
    }
}