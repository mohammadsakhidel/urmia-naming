using Models;
using Stimulsoft.Report;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Reports_ReportOfPassways : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var conditionsCookie = Request.Cookies["conditions"];
        var conditionsBytes = Convert.FromBase64String(conditionsCookie.Value);
        var conditions = (List<Hashtable>)RamancoLibrary.Utilities.IOUtils.ByteArrayToObject(conditionsBytes);
        var rep = new PasswaysRepository();
        var recs = rep.Search(conditions);
        var report = new StiReport();
        report.Load(Server.MapPath("~/Reports/rep_Passways.mrt"));
        var repTitle = Server.HtmlEncode(Request.QueryString["title"]);
        report.Dictionary.Variables["Title"].Value = repTitle;
        report.RegData("ds_Passways", recs.Select(p => new {
            ID = p.ID,
            MosavabID = p.MosavabID,
            Name = p.Name,
            Type = p.TypeText,
            PrecedingName = p.PrecedingName,
            PrecedingType = p.PrecedingTypeText,
            Region = p.RegionText,
            Width = (p.Width.HasValue ? p.Width + " متر" : ""),
            FloorType = p.FloorType,
            HasBoard = p.HasBoard.HasValue && p.HasBoard.Value,
            HasLighting = p.HasLighting.HasValue && p.HasLighting.Value,
            HasChannel = p.HasChannel.HasValue && p.HasChannel.Value,
            HasPlanting = p.HasPlanting.HasValue && p.HasPlanting.Value,
            HasSidewalk = p.HasSidewalk.HasValue && p.HasSidewalk.Value,
            HasFur = p.HasFur.HasValue && p.HasFur.Value,
            HasFurNimkat = p.HasFurNimkat.HasValue && p.HasFurNimkat.Value,
            HasFurAbkhori = p.HasFurAbkhori.HasValue && p.HasFurAbkhori.Value,
            HasFurTrash = p.HasFurTrash.HasValue && p.HasFurTrash.Value,
            HasFurBodyBuilding = p.HasFurBodyBuilding.HasValue && p.HasFurBodyBuilding.Value,
            HasFurToys = p.HasFurToys.HasValue && p.HasFurToys.Value,
            HasFurLamps = p.HasFurLamps.HasValue && p.HasFurLamps.Value,
            HasFurAdv = p.HasFurAdv.HasValue && p.HasFurAdv.Value
        }));
        rep_viewer.Report = report;
    }
}