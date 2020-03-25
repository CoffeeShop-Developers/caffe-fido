using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeFido.Web.Models
{
    public class DashboardViewModel
    {
        public string Message { get; set; }

        public virtual GenderDetailGetViewModel genderDetailViewModel { get; set; }

        public virtual List<snpCommunityDetailGetViewModel> snpCommunityDetailGetViewModel { get; set; }

    }
}
