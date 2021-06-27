using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;

public class InputPasswaysService : IInputPasswaysService
{
    public Tuple<bool, string> AddPasswayRecord(Passway serverRecord)
    {
        try
        {
            using (var pr = new PasswaysRepository())
            {
                ////// exists:
                if (pr.PassWayExists(serverRecord.RecordId))
                    throw new Exception(String.Format("{0}: {1}", serverRecord.RecordId, "رکوردی با این شناسه قبلاً در سرور ثبت شده است"));
                //////
                //////shape info:
                var points = new List<Location>();
                if (serverRecord.BeginingLongitude.HasValue && serverRecord.BeginingLatitude.HasValue)
                {
                    points.Add(new Location(serverRecord.BeginingLongitude.Value, serverRecord.BeginingLatitude.Value));
                }
                if (serverRecord.EndingLongitude.HasValue && serverRecord.EndingLatitude.HasValue)
                {
                    points.Add(new Location(serverRecord.EndingLongitude.Value, serverRecord.EndingLatitude.Value));
                }
                var shape = points.Any() ? new MapShape(MyEnums.MapShapeType.Line, points) : null;
                serverRecord.ShapeInfo = shape != null ? shape.Formula : "";
                //--- length:
                serverRecord.Length = points.Count >= 2 ? (int)(GeoCodeCalc.CalcDistance(points[0].Latitude, points[0].Longitude, points[1].Latitude, points[1].Longitude) * 1000) : 0;
                //////
                pr.Add(serverRecord);
                pr.Save();
                return new Tuple<bool, string>(true, "");
            }
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string>(false, ex.Message);
        }
    }
    public Tuple<bool, string> UpdatePasswayRecord(Passway serverEditedRecord)
    {
        try
        {
            using (var pr = new PasswaysRepository())
            {
                ///////// record exists?
                if (!pr.PassWayExists(serverEditedRecord.RecordId))
                    throw new Exception(String.Format("{0}: {1}", serverEditedRecord.RecordId, "رکورد مورد نظر در دیتابیس سرور یافت نشد"));
                /////////
                pr.SaveEditedRecord(serverEditedRecord);
                return new Tuple<bool, string>(true, "");
            }
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string>(false, ex.Message);
        }
    }
}
