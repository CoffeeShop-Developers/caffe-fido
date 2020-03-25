using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeFido.Web.Models
{
    public class GenderDetailGetViewModel
    {
        public int GenderID { get; set; }
        public string Gender { get; set; }
        public int? Sort { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDT { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDT { get; set; }
        public int? ApplicationID { get; set; }
    }
}
