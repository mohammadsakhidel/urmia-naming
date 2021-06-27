using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Location
    {
        public Location(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            ID = MyHelper.GetRandomString(8, true);
        }
        public Location(string id, double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            ID = id;
        }
        public Location(string latLngStr)
        {
            var splitted = MyHelper.SplitString(latLngStr, ",");
            this.Latitude = Convert.ToDouble(splitted[0]);
            this.Longitude = Convert.ToDouble(splitted[1]);
        }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string ID { get; private set; }
        public Subgurim.Controles.GLatLng GLatLng
        {
            get
            {
                return new Subgurim.Controles.GLatLng(Latitude, Longitude);
            }
        }
        public override string ToString()
        {
            return String.Format("{0},{1}", this.Latitude, this.Longitude);
        }
    }
}