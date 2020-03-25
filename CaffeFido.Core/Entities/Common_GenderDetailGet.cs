using CaffeFido.Core.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaffeFido.Core.Entities
{
    public class Common_GenderDetailGet
    {
        public class Parameters
        {          
            public int GenderID { get; set; }
        }

        public class Results
        {
            public int? GenderID { get; set; }

            public string Gender { get; set; }

            public int? Sort { get; set; }

            public string CreateBy { get; set; }

            public DateTime? CreateDT { get; set; }

            public string ModifyBy { get; set; }

            public DateTime? ModifyDT { get; set; }

            public int? ApplicationID { get; set; }
        }
    }
}
