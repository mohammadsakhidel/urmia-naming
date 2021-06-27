using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;

public partial class Views_UserControls_MapShapeEditor : System.Web.UI.UserControl
{
    //******************************* Prop:
    public Unit Width
    {
        get
        {
            return GMap1.Width;
        }
        set
        {
            GMap1.Width = value;
        }
    }
    public Unit Height
    {
        get
        {
            return GMap1.Height;
        }
        set
        {
            GMap1.Height = value;
        }
    }
    public string Type
    {
        get
        {
            return hid_Type.Value;
        }
        set
        {
            hid_Type.Value = value;
        }
    }
    //******************************* Func:
    public void SetCenter(Models.Location loc, int zoom, GMapType.GTypes type)
    {
        GLatLng centerLatLng = new GLatLng(loc.Latitude, loc.Longitude);
        GMap1.setCenter(centerLatLng, zoom, type);
        GMap1.addControl(new GControl(GControl.preBuilt.LargeMapControl3D));
        GMap1.addControl(new GControl(GControl.preBuilt.MapTypeControl));
        GMap1.addControl(new GControl(GControl.extraBuilt.MarkCenter));
        GMap1.addCustomCursor(new GCustomCursor(cursor.crosshair, cursor.move));
    }
    public Models.Location GetCenter()
    {
        GLatLng centerPoint = GMap1.GCenter;
        return new Models.Location(centerPoint.lng, centerPoint.lat);
    }
    public void CreatePolygon(List<Models.Location> locations, string borderColor, int borderWidth, string fillColor, double fillOpacity)
    {
        GPolygon pol = new GPolygon(locations.Select(loc => loc.GLatLng).ToList(), borderColor, borderWidth, 0.9, fillColor, fillOpacity);
        pol.close();
        GMap1.Add(pol);
    }
    public void CreateMarker(Models.Location location)
    {
        GIcon icon = new GIcon();
        icon.image = MyHelper.Url(Urls.Images + "map-marker.png");
        icon.shadow = MyHelper.Url(Urls.Images + "map-marker-shadow.png");
        icon.iconSize = new GSize(12, 20);
        icon.shadowSize = new GSize(22, 20);
        icon.iconAnchor = new GPoint(6, 20);
        icon.infoWindowAnchor = new GPoint(5, 1);
        icon.infoWindowAnchor = new GPoint(0, 0);
        //******************
        GMarker marker = new GMarker(location.GLatLng, icon);
        marker.ID = location.ID;
        GMap1.Add(marker);
    }
    public void CreateLine(List<Models.Location> locations, string color, int width)
    {
        GPolyline line = new GPolyline(locations.Select(loc => loc.GLatLng).ToList(), color, width, 1);
        GMap1.Add(line);
    }
    public void DrawShape()
    {
        ClearShape();
        Models.MapShape shape = new Models.MapShape(GetShapeInfo());
        //add markers:
        foreach (Models.Location point in shape.Points)
        {
            CreateMarker(point);
        }
        //create shape:
        if (shape.Type == MyEnums.MapShapeType.Polygon)
        {
            CreatePolygon(shape.Points, "#274257", 2, "#00a0dc", 0.6);
        }
        else if (shape.Type == MyEnums.MapShapeType.Line)
        {
            CreateLine(shape.Points, "#009edb", 5);
        }
        // calculate distance:
        if (shape.Points.Count > (shape.Type == MyEnums.MapShapeType.Line ? 1 : 2)) 
        {
            double total_distance = 0;
            for (var i = 0; i < shape.Points.Count - 1; i++)
            {
                var point1 = shape.Points[i];
                var point2 = shape.Points[i + 1];
                var dist = GeoCodeCalc.CalcDistance(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude);
                total_distance += dist;
            }
            // calc mohit if shape = polygon:
            if (shape.Type == MyEnums.MapShapeType.Polygon)
            {
                total_distance += GeoCodeCalc.CalcDistance(shape.Points[0].Latitude, shape.Points[0].Longitude, shape.Points[shape.Points.Count - 1].Latitude, shape.Points[shape.Points.Count - 1].Longitude);
            }
            // show:
            var dist_meters = Math.Round(total_distance * 1000, 2);
            lbl_Distance.Text = (shape.Type == MyEnums.MapShapeType.Line ? "طول معبر: " : "محیط: ") + dist_meters.ToString() + " متر";
            hid_Distance.Value = dist_meters.ToString();
        }
    }
    public void ClearShape()
    {
        GMap1.resetMarkers();
        GMap1.resetPolygon();
        GMap1.resetPolylines();
        lbl_Distance.Text = "";
    }
    public void SaveShapeInfo(string text)
    {
        hid_Shape.Value = text;
    }
    public void SaveLastPoint(Models.Location loc)
    {
        hid_LastPoint.Value = String.Format("{0},{1}", loc.Latitude, loc.Longitude);
    }
    public string GetShapeInfo()
    {
        return hid_Shape.Value;
    }
    public void ResetShapeInfo()
    {
        Models.MapShape shape = new Models.MapShape(GetShapeInfo());
        Models.MapShape newShape = new Models.MapShape(shape.Type, new List<Models.Location>());
        SaveShapeInfo(newShape.Formula);
    }
    //********************************* Handlers:
    protected void btn_DrawLine_Click(object sender, EventArgs e)
    {
        try
        {
            Models.MapShape shape = new Models.MapShape(GetShapeInfo());
            shape.Type = MyEnums.MapShapeType.Line;
            SaveShapeInfo(shape.Formula);
            btn_DrawLine.CssClass = "map-tool map-tool-line-selected";
            btn_DrawPolygon.CssClass = "map-tool map-tool-polygon";
            DrawShape();
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
    protected void btn_DrawPolygon_Click(object sender, EventArgs e)
    {
        try
        {
            Models.MapShape shape = new Models.MapShape(GetShapeInfo());
            shape.Type = MyEnums.MapShapeType.Polygon;
            SaveShapeInfo(shape.Formula);
            btn_DrawPolygon.CssClass = "map-tool map-tool-polygon-selected";
            btn_DrawLine.CssClass = "map-tool map-tool-line";
            DrawShape();
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
    protected void btn_Mark_Click(object sender, EventArgs e)
    {
        try
        {
            Models.MapShape shape = new Models.MapShape(GetShapeInfo());
            var points = shape.Points;
            points.Add(GetCenter());
            shape.Points = points;
            SaveShapeInfo(shape.Formula);
            SaveLastPoint(GetCenter());
            DrawShape();
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        try
        {
            ClearShape();
            ResetShapeInfo();
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
}