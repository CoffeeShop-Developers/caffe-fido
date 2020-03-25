using System;
using CaffeFido.Core.Attribute;

namespace CaffeFido.Core.Entities
{
    public class CareManagement_ResidentNeedsReviewResidentReviewInsert
    {
        public class Parameters
        {
            public string UserName { get; set; }

            public int? ApplicationID { get; set; }

            public string CustomerID { get; set; }

            public int? ResidentReviewID { get; set; }

            public DateTime? EffectiveDT { get; set; }

            [OutPut]
            public int? OutputResidentReviewID { get; }

        }

        public class Results
        {
        }

    }
}
