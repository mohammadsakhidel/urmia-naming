using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public partial class Passway
    {

        public string PrecedingTypeText
        {
            get
            {
                return PrecedingType.HasValue ? Pairs.PasswayTypes.Single(pair => pair.Key == PrecedingType).Value : "";
            }
        }

        public string TypeText
        {
            get
            {
                return Pairs.PasswayTypes.Single(pair => pair.Key == Type).Value;
            }
        }

        public string DateOfAddShamsi {
            get {
                return RamancoLibrary.Utilities.DateTimeUtils.ToShamsi(DateOfAdd).ToString();
            }
        }


        public string RegionText
        {
            get
            {
                return Region.HasValue ? Pairs.Regions.Single(pair => pair.Key == Region).Value : "";
            }
        }
    }
}