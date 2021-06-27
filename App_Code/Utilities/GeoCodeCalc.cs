using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class GeoCodeCalc
{
    public const double EarthRadiusInMiles = 3956.0;
    public const double EarthRadiusInKilometers = 6367.0;

    public static double DiffRadian(double val1, double val2) { return DegreesToRadians(val2) - DegreesToRadians(val1); }
    public static double CalcDistance(double lat1, double lng1, double lat2, double lng2)
    {
        return CalcDistance(lat1, lng1, lat2, lng2, GeoCodeCalcMeasurement.Kilometers);
    }
    public static double CalcDistance(double lat1, double lng1, double lat2, double lng2, GeoCodeCalcMeasurement m)
    {
        double radius = GeoCodeCalc.EarthRadiusInMiles;

        if (m == GeoCodeCalcMeasurement.Kilometers) { radius = GeoCodeCalc.EarthRadiusInKilometers; }
        return radius * 2 * Math.Asin(Math.Min(1, Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2)) / 2.0), 2.0) + Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) * Math.Pow(Math.Sin((DiffRadian(lng1, lng2)) / 2.0), 2.0)))));
    }
    public static bool IsWithinArea(double topLeftLat, double topLeftLong, double bottomRightLat, double bottomRightLong, double testLat, double testLong)
    {
        return (testLat >= topLeftLat && testLat <= bottomRightLat && testLong >= topLeftLong && testLong <= bottomRightLong);
    }
    public static double DegreesToRadians(double degrees)
    {
        const double degToRadFactor = Math.PI / 180;
        return degrees * degToRadFactor;
    }
    public static double RadiansToDegrees(double radians)
    {
        const double radToDegFactor = 180 / Math.PI;
        return radians * radToDegFactor;
    }
    public static GeoLocation FindPointAtDistanceFrom(GeoLocation startPoint, double initialBearingRadians, double distanceKilometres)
    {
        const double radiusEarthKilometres = 6371.01;
        var distRatio = distanceKilometres / radiusEarthKilometres;
        var distRatioSine = Math.Sin(distRatio);
        var distRatioCosine = Math.Cos(distRatio);

        var startLatRad = DegreesToRadians(startPoint.Latitude);
        var startLonRad = DegreesToRadians(startPoint.Longitude);

        var startLatCos = Math.Cos(startLatRad);
        var startLatSin = Math.Sin(startLatRad);

        var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));

        var endLonRads = startLonRad
            + Math.Atan2(
                Math.Sin(initialBearingRadians) * distRatioSine * startLatCos,
                distRatioCosine - startLatSin * Math.Sin(endLatRads));

        return new GeoLocation
        {
            Latitude = RadiansToDegrees(endLatRads),
            Longitude = RadiansToDegrees(endLonRads)
        };
    }
    public static Tuple<double, double> ToLatLng(double utmX, double utmY, string utmZone = "38N") {
        bool isNorthHemisphere = utmZone.Last() >= 'N';
        var zone = int.Parse(utmZone.Remove(utmZone.Length - 1));
        var c_sa = 6378137.000000;
        var c_sb = 6356752.314245;
        var e2 = Math.Pow((Math.Pow(c_sa, 2) - Math.Pow(c_sb, 2)), 0.5) / c_sb;
        var e2cuadrada = Math.Pow(e2, 2);
        var c = Math.Pow(c_sa, 2) / c_sb;
        var x = utmX - 500000;
        var y = isNorthHemisphere ? utmY : utmY - 10000000;
        var s = ((zone * 6.0) - 183.0);
        var lat = y / (6366197.724 * 0.9996); // Change c_sa for 6366197.724
        var v = (c / Math.Pow(1 + (e2cuadrada * Math.Pow(Math.Cos(lat), 2)), 0.5)) * 0.9996;
        var a = x / v;
        var a1 = Math.Sin(2 * lat);
        var a2 = a1 * Math.Pow((Math.Cos(lat)), 2);
        var j2 = lat + (a1 / 2.0);
        var j4 = ((3 * j2) + a2) / 4.0;
        var j6 = (5 * j4 + a2 * Math.Pow((Math.Cos(lat)), 2)) / 3.0; // saque a2 de multiplicar por el coseno de lat y elevar al cuadrado
        var alfa = (3.0 / 4.0) * e2cuadrada;
        var beta = (5.0 / 3.0) * Math.Pow(alfa, 2);
        var gama = (35.0 / 27.0) * Math.Pow(alfa, 3);
        var bm = 0.9996 * c * (lat - alfa * j2 + beta * j4 - gama * j6);
        var b = (y - bm) / v;
        var epsi = ((e2cuadrada * Math.Pow(a, 2)) / 2.0) * Math.Pow((Math.Cos(lat)), 2);
        var eps = a * (1 - (epsi / 3.0));
        var nab = (b * (1 - epsi)) + lat;
        var senoheps = (Math.Exp(eps) - Math.Exp(-eps)) / 2.0;
        var delt = Math.Atan(senoheps / (Math.Cos(nab)));
        var tao = Math.Atan(Math.Cos(delt) * Math.Tan(nab));
        double longitude = delt / Math.PI * 180 + s;
        double latitude = (lat + (1 + e2cuadrada * Math.Pow(Math.Cos(lat), 2) - 3.0 / 2.0 * e2cuadrada * Math.Sin(lat) * Math.Cos(lat) * (tao - lat)) * (tao - lat)) / Math.PI * 180;
        return new Tuple<double, double>(latitude, longitude);
    }
    public static Tuple<int, int> ToUTM(double lat, double lng) {
        var l = new DotNetCoords.LatLng(lat, lng);
        var utm = l.ToUtmRef();
        return new Tuple<int, int>((int)Math.Round(utm.Easting), (int)Math.Round(utm.Northing));
    }
}

public enum GeoCodeCalcMeasurement : int
{
    Miles = 0,
    Kilometers = 1
}

public class GeoLocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}