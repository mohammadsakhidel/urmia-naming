using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Subgurim.Controles;
using Telerik.Web.UI;

public partial class Views_UserControls_GoogleMap : System.Web.UI.UserControl
{
    //****************************** properties:
    public Unit Width
    {
        get
        {
            return radMap.Width;
        }
        set
        {
            radMap.Width = value;
        }
    }

    public Unit Height
    {
        get
        {
            return radMap.Height;
        }
        set
        {
            radMap.Height = value;
        }
    }

    public bool Visible
    {
        set
        {
            pnl_Map.Visible = value;
        }
    }
    //****************************** methods:
    public void SetCenter(Models.Location loc, int zoom, GMapType.GTypes type)
    {
        //urmia: 37.54675499755641, 45.06523132324219
        GLatLng centerLatLng = new GLatLng(loc.Latitude, loc.Longitude);
        radMap.CenterSettings.Latitude = loc.Latitude;
        radMap.CenterSettings.Longitude = loc.Longitude;
        radMap.Zoom = zoom;
    }
    public void ShowCity()
    {
        GLatLng centerLatLng = new GLatLng(37.54675499755641, 45.06523132324219);
        radMap.CenterSettings.Latitude = centerLatLng.lat;
        radMap.CenterSettings.Longitude = centerLatLng.lng;
        radMap.Zoom = 13;
    }
    public Models.Location GetCenter()
    {
        return new Models.Location(radMap.CenterSettings.Longitude, radMap.CenterSettings.Latitude);
    }
    public void DrawShape(string formula) {
        var shape = new MapShape(formula);
        for (int i = 0; i < shape.Points.Count; i++) {
            CreateMarker(new Models.Location(shape.Points[i].Longitude, shape.Points[i].Latitude));
        }
    }
    public void CreateMarker(Models.Location location)
    {
        var marker = new MapMarker();
        marker.Shape = "myMarker";
        marker.LocationSettings.Latitude = location.Latitude;
        marker.LocationSettings.Longitude = location.Longitude;

        radMap.MarkersCollection.Add(marker);
    }
    public void ClearShape()
    {
        radMap.MarkersCollection.Clear();
    }





    // ****** OBSOLETE ******
    public void DrawCircle(Models.Location center, int rMeters) {
        //Obsolete
    }
    public void ZoomToBounds(Models.MapShape shape)
    {
        // Obsolete
    }
    public void CreatePolygon(List<Models.Location> locations, string borderColor, int borderWidth, string fillColor, double fillOpacity) {
        //Obsolete
    }
    public void CreateLine(List<Models.Location> locations, string color, int width) {
        // Obsolete
        /*
        var start = locations[0];
        var end = locations[1];
        var shapeData = "[{" +
                    "\"type\": \"Polygon\"," +
                    "\"coordinates\": [" +
                        String.Format("[[{0}, {1}], [{2}, {3}]]", start.Latitude, start.Longitude, end.Latitude, end.Longitude) +
                    "]" +
                "}]";
        hidGeoJson.Value = shapeData;
        */
    }
    //****************************** handlers:

}