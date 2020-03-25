using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaffeFido.Core.Entities;
using CaffeFido.Web.Models;
using CaffeFido.Web.Services;

namespace CaffeFido.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            //Define Parameters
            var snpCommunityDetailGetParameters = new CareManagement_snpCommunityDetailGet.Parameters
            {
                CommunityNumber = "10743"
            };

            //Call Service
            var vm = _dashboardService.GetDashboardViewModel(snpCommunityDetailGetParameters);

            //Return viewmodel
            return View(vm);
        }       
    }
}
