using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_UserControls_PasswayEditor : System.Web.UI.UserControl
{
    //************************** properties:
    public MyEnums.FormAction FormAction
    {
        get
        {
            return (MyEnums.FormAction)Convert.ToInt32(hid_FormAction.Value);
        }
        set
        {
            hid_FormAction.Value = ((int)value).ToString();
        }
    }
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
    //************************** methods:
    public void LoadForm()
    {
        if (PasswayID > 0)
        {
            FillCombos();
            PasswaysRepository pr = new PasswaysRepository();
            Passway pass = pr.Get(PasswayID);
            #region Basic Info:
            ch_HasName.Checked = !String.IsNullOrEmpty(pass.Name);
            tb_Name.Text = pass.Name;
            tb_RecordId.Text = pass.RecordId;
            cmb_Region.SelectedIndex = MyHelper.GetIndexOf(cmb_Region, pass.Region.ToString());
            cmb_Type.SelectedIndex = MyHelper.GetIndexOf(cmb_Type, pass.Type.ToString());
            tb_PrecedingRecordId.Text = pass.PrecedingRecordId;
            cmb_PrecedingType.SelectedIndex = MyHelper.GetIndexOf(cmb_PrecedingType, pass.PrecedingType.ToString());
            tb_PrecedingName.Text = pass.PrecedingName;
            tb_MosavabID.Text = pass.MosavabID.HasValue ? pass.MosavabID.Value.ToString() : String.Empty;
            tb_Width.Text = pass.Width.HasValue ? pass.Width.ToString() : String.Empty;
            cmb_FloorType.SelectedIndex = pass.FloorType.HasValue ? MyHelper.GetIndexOf(cmb_FloorType, pass.FloorType.Value.ToString()) : -1;
            ch_HasBoard.Checked = pass.HasBoard.HasValue && pass.HasBoard.Value;
            cmb_BoardType.SelectedIndex = pass.BoardType.HasValue ? MyHelper.GetIndexOf(cmb_BoardType, pass.BoardType.ToString()) : -1;
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
            cmb_ChannelType.SelectedIndex = pass.ChannelType.HasValue ? MyHelper.GetIndexOf(cmb_ChannelType, pass.ChannelType.ToString()) : -1;
            ch_HasPlanting.Checked = pass.HasPlanting.HasValue && pass.HasPlanting.Value;
            ch_HasSidewalk.Checked = pass.HasSidewalk.HasValue && pass.HasSidewalk.Value;
            cmb_SidewalkFloorType.SelectedIndex = pass.SidewalkFloorType.HasValue ? MyHelper.GetIndexOf(cmb_SidewalkFloorType, pass.SidewalkFloorType.ToString()) : -1;
            tb_SidewalkWidth.Text = pass.SidewalkWidth.HasValue ? pass.SidewalkWidth.Value.ToString() : String.Empty;
            ch_IsSidewalkIncomplete.Checked = pass.IsSidewalkIncomplete.HasValue && pass.IsSidewalkIncomplete.Value;
            tb_BeginingLatitude.Text = pass.BeginingLatitude.HasValue ? pass.BeginingLatitude.ToString() : String.Empty;
            tb_BeginingLongitude.Text = pass.BeginingLongitude.HasValue ? pass.BeginingLongitude.ToString() : String.Empty;
            tb_EndingLatitude.Text = pass.EndingLatitude.HasValue ? pass.EndingLatitude.ToString() : String.Empty;
            tb_EndingLongitude.Text = pass.EndingLongitude.HasValue ? pass.EndingLongitude.ToString() : String.Empty;
            tb_BeginingX.Text = pass.BeginingX.HasValue ? pass.BeginingX.ToString() : String.Empty;
            tb_BeginingY.Text = pass.BeginingY.HasValue ? pass.BeginingY.ToString() : String.Empty;
            tb_EndingX.Text = pass.EndingX.HasValue ? pass.EndingX.ToString() : String.Empty;
            tb_EndingY.Text = pass.EndingY.HasValue ? pass.EndingY.ToString() : String.Empty;
            tb_Explanation.Text = pass.Explanation;
            #endregion
        }
    }
    public void FillCombos()
    {
        //****** pass types:
        cmb_Type.Items.Clear();
        cmb_Type.Items.Add(new ListItem("", ""));
        cmb_PrecedingType.Items.Clear();
        cmb_PrecedingType.Items.Add(new ListItem("", ""));
        var passTypes = Pairs.PasswayTypes;
        foreach (KeyValuePair<int, string> pair in passTypes)
        {
            cmb_Type.Items.Add(new ListItem(pair.Value, pair.Key.ToString()));
            cmb_PrecedingType.Items.Add(new ListItem(pair.Value, pair.Key.ToString()));
        }
        //****** regions:
        cmb_Region.Items.Clear();
        cmb_Region.Items.Add(new ListItem("", ""));
        var regions = Pairs.Regions;
        foreach (KeyValuePair<int, string> pair in regions)
        {
            cmb_Region.Items.Add(new ListItem(pair.Value, pair.Key.ToString()));
        }
        //****** floorTypes:
        cmb_FloorType.Items.Clear();
        cmb_FloorType.Items.Add(new ListItem("", ""));
        var floors = Pairs.FloorTypes;
        foreach (var pair in floors)
        {
            cmb_FloorType.Items.Add(new ListItem(pair.Value, pair.Key.ToString()));
        }
        //****** board types:
        cmb_BoardType.Items.Clear();
        cmb_BoardType.Items.Add(new ListItem("", ""));
        var boards = Pairs.BoardTypes;
        foreach (var pair in boards)
        {
            cmb_BoardType.Items.Add(new ListItem(pair.Value, pair.Key.ToString()));
        }
        //****** channel types:
        cmb_ChannelType.Items.Clear();
        cmb_ChannelType.Items.Add(new ListItem("", ""));
        var channels = Pairs.ChannelTypes;
        foreach (var pair in channels)
        {
            cmb_ChannelType.Items.Add(new ListItem(pair.Value, pair.Key.ToString()));
        }
        //****** channel types:
        cmb_SidewalkFloorType.Items.Clear();
        cmb_SidewalkFloorType.Items.Add(new ListItem("", ""));
        var sidewalks = Pairs.SidewalkFloorTypes;
        foreach (var pair in sidewalks)
        {
            cmb_SidewalkFloorType.Items.Add(new ListItem(pair.Value, pair.Key.ToString()));
        }
    }
    //************************** event handlers:
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (FormAction == MyEnums.FormAction.New)
                FillCombos();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                var pr = new PasswaysRepository();
                var mr = new MosavabsRepository();
                var pnr = new PassNamesRepository();

                #region Validate Form:
                // validate passway name:
                if (ch_HasName.Checked && String.IsNullOrEmpty(tb_Name.Text))
                    throw new Exception("نام معبر وارد نشده است.");
                // validate mosaveb number:
                string mosavabShomare = tb_MosavabID.Text;
                if (!String.IsNullOrEmpty(mosavabShomare) && !mr.Exists(mosavabShomare))
                    throw new Exception("شماره مصوبه وارد شده صحیح نمی باشد");
                #endregion

                #region Check Duplicate Name:
                Passway passway = (FormAction == MyEnums.FormAction.Edit ? pr.Get(PasswayID) : new Passway());
                var oldName = (FormAction == MyEnums.FormAction.Edit ? passway.Name : String.Empty);
                if (FormAction == MyEnums.FormAction.New && ch_HasName.Checked)
                {
                    if (pr.PassWayExists(tb_Name.Text, Convert.ToByte(cmb_Type.SelectedValue)))
                        throw new Exception("نام وارد شده قبلاً برای معبری از این نوع ثبت شده است.");
                }
                else if (FormAction == MyEnums.FormAction.Edit && ch_HasName.Checked)
                {
                    if (tb_Name.Text.Trim() != oldName.Trim() && pr.PassWayExists(tb_Name.Text, Convert.ToByte(cmb_Type.SelectedValue)))
                        throw new Exception("نام وارد شده قبلاً برای معبری از این نوع ثبت شده است.");
                }
                #endregion

                #region Create Passway Model::::BASIC INFORMATION
                Mosavab mosavabe = (!String.IsNullOrEmpty(tb_MosavabID.Text) ? mr.Get(tb_MosavabID.Text) : null);
                passway.RecordId = tb_RecordId.Text;
                passway.Region = (cmb_Region.SelectedIndex > 0 ? Convert.ToByte(cmb_Region.SelectedValue) : (byte?)null);
                passway.Name = ch_HasName.Checked ? tb_Name.Text : String.Empty;
                passway.Type = Convert.ToByte(cmb_Type.SelectedValue);
                passway.PrecedingRecordId = tb_PrecedingRecordId.Text;
                passway.PrecedingType = (cmb_PrecedingType.SelectedIndex > 0 ? Convert.ToByte(cmb_PrecedingType.SelectedValue) : (byte?)null);
                passway.PrecedingName = tb_PrecedingName.Text;
                passway.MosavabID = (mosavabe != null ? mosavabe.ID : (int?)null);
                passway.Width = (!String.IsNullOrEmpty(tb_Width.Text) && MyHelper.IsDouble(tb_Width.Text) ? Convert.ToDouble(tb_Width.Text) : (double?)null);
                passway.FloorType = (cmb_FloorType.SelectedIndex > 0 ? Convert.ToByte(cmb_FloorType.SelectedValue) : (byte?)null);
                passway.HasBoard = ch_HasBoard.Checked;
                passway.BoardType = (ch_HasBoard.Checked && cmb_BoardType.SelectedIndex > 0 ? Convert.ToByte(cmb_BoardType.SelectedValue) : (byte?)null);
                passway.BoardSize = (ch_HasBoard.Checked ? tb_BoardSize.Text : String.Empty);
                passway.PostArea = tb_PostArea.Text;
                passway.HasLighting = ch_HasLighting.Checked;
                #endregion

                #region Create Passway Model::::UNITS
                passway.CountOfCondominiums =
                    (!String.IsNullOrEmpty(tb_CountOfCondominiums.Text) && MyHelper.IsInteger(tb_CountOfCondominiums.Text) ?
                    Convert.ToInt32(tb_CountOfCondominiums.Text) : (int?)null);
                passway.CountOfHouses =
                    (!String.IsNullOrEmpty(tb_CountOfHouses.Text) && MyHelper.IsInteger(tb_CountOfHouses.Text) ?
                    Convert.ToInt32(tb_CountOfHouses.Text) : (int?)null);
                passway.CountOfOfficeBuildings =
                    (!String.IsNullOrEmpty(tb_CountOfOfficeBuildings.Text) && MyHelper.IsInteger(tb_CountOfOfficeBuildings.Text) ?
                    Convert.ToInt32(tb_CountOfOfficeBuildings.Text) : (int?)null);
                passway.CountOfOfficeComplexes =
                    (!String.IsNullOrEmpty(tb_CountOfOfficeComplexes.Text) && MyHelper.IsInteger(tb_CountOfOfficeComplexes.Text) ?
                    Convert.ToInt32(tb_CountOfOfficeComplexes.Text) : (int?)null);
                passway.CountOfOthers =
                    (!String.IsNullOrEmpty(tb_CountOfOthers.Text) && MyHelper.IsInteger(tb_CountOfOthers.Text) ?
                    Convert.ToInt32(tb_CountOfOthers.Text) : (int?)null);
                passway.CountOfShoppingCenters =
                    (!String.IsNullOrEmpty(tb_CountOfShoppingCenters.Text) && MyHelper.IsInteger(tb_CountOfShoppingCenters.Text) ?
                    Convert.ToInt32(tb_CountOfShoppingCenters.Text) : (int?)null);
                passway.CountOfStores =
                    (!String.IsNullOrEmpty(tb_CountOfStores.Text) && MyHelper.IsInteger(tb_CountOfStores.Text) ?
                    Convert.ToInt32(tb_CountOfStores.Text) : (int?)null);
                #endregion

                #region Create Passway Model::::FURNITURE
                passway.HasFur = ch_HasFur.Checked;
                passway.HasFurAbkhori = ch_HasFurAbkhori.Checked;
                passway.HasFurAdv = ch_HasFurAdv.Checked;
                passway.HasFurBodyBuilding = ch_HasFurBodyBuilding.Checked;
                passway.HasFurLamps = ch_HasFurLamps.Checked;
                passway.HasFurNimkat = ch_HasFurNimkat.Checked;
                passway.HasFurToys = ch_HasFurToys.Checked;
                passway.HasFurTrash = ch_HasFurTrash.Checked;
                #endregion

                #region Create Passway Model::::OTHER INFO
                passway.HasChannel = ch_HasChannel.Checked;
                passway.ChannelType = (ch_HasChannel.Checked && cmb_ChannelType.SelectedIndex > 0 ? Convert.ToByte(cmb_ChannelType.SelectedValue) : (byte?)null);
                passway.HasPlanting = ch_HasPlanting.Checked;
                passway.HasSidewalk = ch_HasSidewalk.Checked;
                passway.SidewalkFloorType = (ch_HasSidewalk.Checked && cmb_SidewalkFloorType.SelectedIndex > 0 ? Convert.ToByte(cmb_SidewalkFloorType.SelectedValue) : (byte?)null);
                passway.SidewalkWidth = (ch_HasSidewalk.Checked && !String.IsNullOrEmpty(tb_SidewalkWidth.Text) && MyHelper.IsDouble(tb_SidewalkWidth.Text) ? Convert.ToDouble(tb_SidewalkWidth.Text) : (double?)null);
                passway.IsSidewalkIncomplete = ch_HasSidewalk.Checked && ch_IsSidewalkIncomplete.Checked;
                
                double? begLat = (!String.IsNullOrEmpty(tb_BeginingLatitude.Text) && MyHelper.IsDouble(tb_BeginingLatitude.Text) ?
                    Convert.ToDouble(tb_BeginingLatitude.Text) : (double?)null);
                double? begLng = (!String.IsNullOrEmpty(tb_BeginingLongitude.Text) && MyHelper.IsDouble(tb_BeginingLongitude.Text) ?
                    Convert.ToDouble(tb_BeginingLongitude.Text) : (double?)null);
                double? endLat = (!String.IsNullOrEmpty(tb_EndingLatitude.Text) && MyHelper.IsDouble(tb_EndingLatitude.Text) ?
                    Convert.ToDouble(tb_EndingLatitude.Text) : (double?)null);
                double? endLng = (!String.IsNullOrEmpty(tb_EndingLongitude.Text) && MyHelper.IsDouble(tb_EndingLongitude.Text) ?
                    Convert.ToDouble(tb_EndingLongitude.Text) : (double?)null);
                int? begX = (!String.IsNullOrEmpty(tb_BeginingX.Text) && MyHelper.IsDouble(tb_BeginingX.Text) ?
                    Convert.ToInt32(tb_BeginingX.Text) : (int?)null);
                int? begY = (!String.IsNullOrEmpty(tb_BeginingY.Text) && MyHelper.IsDouble(tb_BeginingY.Text) ?
                    Convert.ToInt32(tb_BeginingY.Text) : (int?)null);
                int? endX = (!String.IsNullOrEmpty(tb_EndingX.Text) && MyHelper.IsDouble(tb_EndingX.Text) ?
                    Convert.ToInt32(tb_EndingX.Text) : (int?)null);
                int? endY = (!String.IsNullOrEmpty(tb_EndingY.Text) && MyHelper.IsDouble(tb_EndingY.Text) ?
                    Convert.ToInt32(tb_EndingY.Text) : (int?)null);

                // Begining Coordination:
                if (begLat.HasValue && begLng.HasValue) {
                    passway.BeginingLatitude = begLat;
                    passway.BeginingLongitude = begLng;
                    if (!begX.HasValue && !begY.HasValue) {
                        var utm = GeoCodeCalc.ToUTM(begLat.Value, begLng.Value);
                        passway.BeginingX = utm.Item1;
                        passway.BeginingY = utm.Item2;
                    }
                } else if (begX.HasValue && begY.HasValue) {
                    passway.BeginingX = begX;
                    passway.BeginingY = begY;
                    if (!begLat.HasValue && !begLng.HasValue) {
                        var coord = GeoCodeCalc.ToLatLng(begX.Value, begY.Value);
                        passway.BeginingLatitude = coord.Item1;
                        passway.BeginingLongitude = coord.Item2;
                    }
                } else {
                    passway.BeginingLatitude = null;
                    passway.BeginingLongitude = null;
                    passway.BeginingX = null;
                    passway.BeginingY = null;
                }

                // Ending Coordination:
                if (endLat.HasValue && endLng.HasValue) {
                    passway.EndingLatitude = endLat;
                    passway.EndingLongitude = endLng;
                    if (!endX.HasValue && !endY.HasValue) {
                        var utm = GeoCodeCalc.ToUTM(endLat.Value, endLng.Value);
                        passway.EndingX = utm.Item1;
                        passway.EndingY = utm.Item2;
                    }
                } else if (endX.HasValue && endY.HasValue) {
                    passway.EndingX = endX;
                    passway.EndingY = endY;
                    if (!endLat.HasValue && !endLng.HasValue) {
                        var coord = GeoCodeCalc.ToLatLng(endX.Value, endY.Value);
                        passway.EndingLatitude = coord.Item1;
                        passway.EndingLongitude = coord.Item2;
                    }
                } else {
                    passway.EndingLatitude = null;
                    passway.EndingLongitude = null;
                    passway.EndingX = null;
                    passway.EndingY = null;
                }

                var hasBegEndCoords = passway.BeginingLatitude.HasValue && passway.BeginingLongitude.HasValue &&
                    passway.EndingLatitude.HasValue && passway.EndingLongitude.HasValue;
                passway.Length = (hasBegEndCoords ? GeoCodeCalc.CalcDistance(passway.BeginingLatitude.Value, passway.BeginingLongitude.Value, passway.EndingLatitude.Value, passway.EndingLongitude.Value, GeoCodeCalcMeasurement.Kilometers) * 1000 : (double?)null);
                passway.Explanation = tb_Explanation.Text;
                #endregion

                #region Create Passway Model::::ADITIONAL FIELDS
                if (FormAction == MyEnums.FormAction.New)
                {
                    passway.DateOfAdd = MyHelper.Now;
                    passway.AddedBy = HttpContext.Current.User.Identity.Name;
                }
                #endregion

                #region Submit To Database:
                if (FormAction == MyEnums.FormAction.New)
                {
                    pr.Add(passway);
                    pnr.SetAsUsed(passway.Name);
                }
                else
                {
                    pr.Save();
                    pnr.SetAsUnused(oldName);
                    pnr.SetAsUsed(passway.Name);
                }
                MyHelper.MessageBoxShow("با موفقیت انجام شد", (Control)sender);
                #endregion
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
    protected void btnCalcPasswayLength_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(3000);
        double lengthInMeters = 0.0;

        var hasBegEnd = !String.IsNullOrEmpty(tb_BeginingLatitude.Text) && MyHelper.IsDouble(tb_BeginingLatitude.Text) &&
            !String.IsNullOrEmpty(tb_BeginingLongitude.Text) && MyHelper.IsDouble(tb_BeginingLongitude.Text) &&
            !String.IsNullOrEmpty(tb_EndingLatitude.Text) && MyHelper.IsDouble(tb_EndingLatitude.Text) &&
            !String.IsNullOrEmpty(tb_EndingLongitude.Text) && MyHelper.IsDouble(tb_EndingLongitude.Text);

        if (hasBegEnd)
            lengthInMeters = GeoCodeCalc.CalcDistance(Double.Parse(tb_BeginingLatitude.Text), Double.Parse(tb_BeginingLongitude.Text), Double.Parse(tb_EndingLatitude.Text), Double.Parse(tb_EndingLongitude.Text), GeoCodeCalcMeasurement.Kilometers) * 1000;

        lblPasswayLength.Text = lengthInMeters.ToString("F1") + (lengthInMeters > 0 ? " متر" : "");
    }
}