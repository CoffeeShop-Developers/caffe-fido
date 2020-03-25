using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeFido.Web.Models
{
    public class snpCommunityDetailGetViewModel
    {
        public int? CommunityID { get; set; }

        public string CommunityNumber { get; set; }

        public string CommunityName { get; set; }

        public string Community { get; set; }

        public string CommunityNameExternal { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string PhoneNumber1 { get; set; }

        public string PhoneNumber1HREF { get; set; }

        public string PhoneNumber2 { get; set; }

        public string PhoneNumber2HREF { get; set; }

        public string FaxNumber { get; set; }

        public string FaxNumberHREF { get; set; }

        public string Region { get; set; }

        public int UnitCapacity { get; set; }

        public int UnitActualCurrent { get; set; }

        public int UnitActualPrevious { get; set; }

        public string MonthCurrent { get; set; }

        public string MonthPrevious { get; set; }

        public decimal UnitPercentage { get; set; }

        public string UnitGrowthIcon { get; set; }

        public int ResidentCapacity { get; set; }

        public int ResidentActualCurrent { get; set; }

        public int ResidentActualPrevious { get; set; }

        public decimal ResidentPercentage { get; set; }

        public string ResidentGrowthIcon { get; set; }
    }
}
