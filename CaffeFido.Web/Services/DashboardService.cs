using AutoMapper;
using CaffeFido.Core.Entities;
using CaffeFido.Core.Interfaces;
using CaffeFido.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeFido.Web.Services
{
    public class DashboardService
    {
        private readonly IRepository<CareManagement_snpCommunityDetailGet.Results> _snpCommunityDetailGetRepository;
        private readonly IRepository<Common_GenderDetailGet.Results> _commonGenderDetailGetRepository;
        private readonly IMapper _mapper;

        public DashboardService(IRepository<CareManagement_snpCommunityDetailGet.Results> snpCommunityDetailGetRepository, IRepository<Common_GenderDetailGet.Results> commonGenderDetailGetRepository,
            IMapper mapper)
        {
            _snpCommunityDetailGetRepository = snpCommunityDetailGetRepository;
            _commonGenderDetailGetRepository = commonGenderDetailGetRepository;
            _mapper = mapper;
        }

        public DashboardViewModel GetDashboardViewModel(CareManagement_snpCommunityDetailGet.Parameters snpCommunityDetailGetParameters)
        {
            var dashboardViewModel = new DashboardViewModel();

            //Get StoredProc Results
            var snpCommunityDetailGetResults = _snpCommunityDetailGetRepository.StoredProcedure("[CareManagement].[snpCommunityDetailGet]", snpCommunityDetailGetParameters).Result.ToList();

            //Map Results to ViewModel Using AutoMapper
            var snpCommunityDetailGetViewModel = _mapper.Map<List<snpCommunityDetailGetViewModel>>(snpCommunityDetailGetResults);

            //Set Parameters
            var commonGenderDetailGetParameters = new Common_GenderDetailGet.Parameters
            {
                GenderID = 1
            };
           
            //Get StoredProc Results
            var commonGenderDetailGetResults = _commonGenderDetailGetRepository.StoredProcedure("[Common].[GenderDetailGet]", commonGenderDetailGetParameters).Result.FirstOrDefault();

            //Map Results to ViewModel Using AutoMapper
            var commonGenderDetailGetViewModel = _mapper.Map<GenderDetailGetViewModel>(commonGenderDetailGetResults);


            dashboardViewModel.genderDetailViewModel = commonGenderDetailGetViewModel;
            dashboardViewModel.snpCommunityDetailGetViewModel = snpCommunityDetailGetViewModel;
            return dashboardViewModel;

        }

    }
}
