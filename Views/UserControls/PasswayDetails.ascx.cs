using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_UserControls_PasswayDetails : System.Web.UI.UserControl
{
    //*************************** Properties:
    public int PasswayID
    {
        get
        {
            return Convert.ToInt32(hid_PasswayID.Value);
        }
        set
        {
            hid_PasswayID.Value = value.ToString();
        }
    }
    //*************************** Methods:
    public void LoadData()
    {
        PasswaysRepository pr = new PasswaysRepository();
        Passway pass = pr.Get(PasswayID);
        #region Basic Info:
        ch_HasName.Checked = !String.IsNullOrEmpty(pass.Name);
        tb_Name.Text = pass.Name;
        tb_RecordId.Text = pass.RecordId;
        tb_Region.Text = pass.Region.HasValue ? Pairs.Regions.Single(kv => kv.Key == pass.Region.Value).Value : String.Empty;
        tb_Type.Text = Pairs.PasswayTypes.Single(kv => kv.Key == pass.Type).Value;
        tb_PrecedingRecordId.Text = pass.PrecedingRecordId;
        tb_PrecedingType.Text = pass.PrecedingType.HasValue ? Pairs.PasswayTypes.Single(kv => kv.Key == pass.PrecedingType.Value).Value : String.Empty;
        tb_PrecedingName.Text = pass.PrecedingName;
        tb_MosavabID.Text = pass.MosavabID.HasValue ? pass.MosavabID.Value.ToString() : String.Empty;
        tb_Width.Text = pass.Width.HasValue ? pass.Width.ToString() : String.Empty;
        tb_FloorType.Text = pass.FloorType.HasValue ? Pairs.FloorTypes.Single(kv => kv.Key == pass.FloorType.Value).Value : String.Empty;
        ch_HasBoard.Checked = pass.HasBoard.HasValue && pass.HasBoard.Value;
        tb_BoardType.Text = pass.BoardType.HasValue ? Pairs.BoardTypes.Single(kv => kv.Key == pass.BoardType.Value).Value : String.Empty;
        tb_BoardSize.Text = pass.BoardSize;
        tb_PostArea.Text = pass.PostArea;
        ch_HasLighting.Checked = pass.HasLighting.HasValue && pass.HasLighting.Value;
        #endregion
        #region Units:
        tb_CountOfStores.Text = pass.CountOfStores.HasValue ? pass.CountOfStores.ToString() : String.Empty;
        tb_CountOfShoppingCenters.Text = pass.CountOfShoppingCenters.HasValue ? pass.CountOfShoppingCenters.ToString() : String.Empty;
        tb_CountOfCondominiums.Text = pass.CountOfCondominiums.HasValue ? pass.CountOfCondominiums.ToString() : String.Empty;
        tb_CountOfOfficeComplexes.Text = pass.CountOfOfficeComplexes.HasValue ? pass.CountOfOfficeComplexes.ToString() : String.Empty;
        tb_CountOfHouses.Text = pass.CountOfHouses.HasValue ? pass.CountOfHouses.ToString() : String.Empty;
        tb_CountOfOfficeBuildings.Text = pass.CountOfOfficeBuildings.HasValue ? pass.CountOfOfficeBuildings.ToString() : String.Empty;
        tb_CountOfOthers.Text = pass.CountOfOthers.HasValue ? pass.CountOfOthers.ToString() : String.Empty;
        #endregion
        #region Furniture:
        ch_HasFur.Checked = pass.HasFur.HasValue && pass.HasFur.Value;
        ch_HasFurNimkat.Checked = pass.HasFurNimkat.HasValue && pass.HasFurNimkat.Value;
        ch_HasFurAbkhori.Checked = pass.HasFurAbkhori.HasValue && pass.HasFurAbkhori.Value;
        ch_HasFurTrash.Checked = pass.HasFurTrash.HasValue && pass.HasFurTrash.Value;
        ch_HasFurBodyBuilding.Checked = pass.HasFurBodyBuilding.HasValue && pass.HasFurBodyBuilding.Value;
        ch_HasFurToys.Checked = pass.HasFurToys.HasValue && pass.HasFurToys.Value;
        ch_HasFurLamps.Checked = pass.HasFurLamps.HasValue && pass.HasFurLamps.Value;
        ch_HasFurAdv.Checked = pass.HasFurAdv.HasValue && pass.HasFurAdv.Value;
        #endregion
        #region Other Information:
        ch_HasChannel.Checked = pass.HasChannel.HasValue && pass.HasChannel.Value;
        tb_ChannelType.Text = pass.ChannelType.HasValue ? Pairs.ChannelTypes.Single(kv => kv.Key == pass.ChannelType.Value).Value : String.Empty;
        ch_HasPlanting.Checked = pass.HasPlanting.HasValue && pass.HasPlanting.Value;
        ch_HasSidewalk.Checked = pass.HasSidewalk.HasValue && pass.HasSidewalk.Value;
        tb_SidewalkFloorType.Text = pass.SidewalkFloorType.HasValue ? Pairs.SidewalkFloorTypes.Single(kv => kv.Key == pass.SidewalkFloorType.Value).Value : String.Empty;
        tb_SidewalkWidth.Text = pass.SidewalkWidth.HasValue ? pass.SidewalkWidth.Value.ToString() : String.Empty;
        ch_IsSidewalkIncomplete.Checked = pass.IsSidewalkIncomplete.HasValue && pass.IsSidewalkIncomplete.Value;
        tb_BeginingLatitude.Text = pass.BeginingLatitude.HasValue ? pass.BeginingLatitude.ToString() : String.Empty;
        tb_BeginingLongitude.Text = pass.BeginingLongitude.HasValue ? pass.BeginingLongitude.ToString() : String.Empty;
        tb_BeginingX.Text = pass.BeginingX.HasValue ? pass.BeginingX.ToString() : String.Empty;
        tb_BeginingY.Text = pass.BeginingY.HasValue ? pass.BeginingY.ToString() : String.Empty;
        tb_EndingLatitude.Text = pass.EndingLatitude.HasValue ? pass.EndingLatitude.ToString() : String.Empty;
        tb_EndingLongitude.Text = pass.EndingLongitude.HasValue ? pass.EndingLongitude.ToString() : String.Empty;
        tb_EndingX.Text = pass.EndingX.HasValue ? pass.EndingX.ToString() : String.Empty;
        tb_EndingY.Text = pass.EndingY.HasValue ? pass.EndingY.ToString() : String.Empty;
        tb_Explanation.Text = pass.Explanation;
        #endregion
        #region Map:
        var points = new List<Location>();
        if (pass.BeginingLatitude.HasValue && pass.BeginingLongitude.HasValue)
            points.Add(new Location(pass.BeginingLongitude.Value, pass.BeginingLatitude.Value));
        if (pass.EndingLatitude.HasValue && pass.EndingLongitude.HasValue)
            points.Add(new Location(pass.EndingLongitude.Value, pass.EndingLatitude.Value));
        if (points.Any())
        {
            Models.MapShape shape = new MapShape(MyEnums.MapShapeType.Line, points);
            uc_GoogleMap.DrawShape(shape.Formula);
            Models.Location avgCenter = shape.AverageCenter;
            uc_GoogleMap.SetCenter(new Models.Location(avgCenter.Longitude, avgCenter.Latitude), 16, Subgurim.Controles.GMapType.GTypes.Normal);
            uc_GoogleMap.ZoomToBounds(shape);
            uc_GoogleMap.ShowCity();
            pnl_Map.Visible = true;
        }
        else
        {
            pnl_Map.Visible = false;
        }
        #endregion
        #region Photos:
        var passPhotos = pass.PasswayPhotoes;
        list_PasswayPhotos.DataSource = passPhotos;
        list_PasswayPhotos.DataBind();
        pnl_Photos.Visible = (passPhotos.Count() > 0 ? true : false);
        #endregion
    }
    //*************************** Event Handlers:
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}