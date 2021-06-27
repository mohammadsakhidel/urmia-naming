using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public partial class PassName
    {
        public string TypeText
        {
            get
            {
                return Pairs.PassNameTypes.Single(pair => pair.Key == this.Type).Value;
            }
        }

        public string StatusText
        {
            get
            {
                string text = "";
                if (this.Status == (int)MyEnums.PassNameStatus.Unused)
                    text = "بلا استفاده";
                else if (this.Status == (int)MyEnums.PassNameStatus.Used)
                    text = "استفاده شده";
                return text;
            }
        }
    }
}