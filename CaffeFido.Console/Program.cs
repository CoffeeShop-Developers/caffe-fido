using CaffeFido.Core.Entities;
using CaffeFido.Core.Interfaces;
using CaffeFido.Infrastructure.Configuration.Contexts;
using CaffeFido.Infrastructure.Repositories;
using System;
using System.Linq;

namespace CaffeFido.Console
{
    internal class Program
    {
        private static readonly ApplicationDbContext _ApplicationDbContext = new ApplicationDbContext();
        private static readonly IRepository<CareManagement_snpCommunityDetailGet.Results> _snpCommunityDetailGetRepository = new Repository<CareManagement_snpCommunityDetailGet.Results>(_ApplicationDbContext);
        private static readonly IRepository<Common_GenderDetailGet.Results> _commonGenderDetailGetRepository = new Repository<Common_GenderDetailGet.Results>(_ApplicationDbContext);

        private static readonly IRepository<CareManagement_ResidentNeedsReviewResidentReviewInsert.Results> _residentNeedsReviewResidentReviewInsertRepository = new Repository<CareManagement_ResidentNeedsReviewResidentReviewInsert.Results>(_ApplicationDbContext);

        private static void Main(string[] args)
        {
            var snpCommunityDetailGetParameters = new CareManagement_snpCommunityDetailGet.Parameters
            {
                CommunityNumber = "10743"
            };
            var snpCommunityDetailGetResults = _snpCommunityDetailGetRepository.StoredProcedure("[CareManagement].[snpCommunityDetailGet]", snpCommunityDetailGetParameters).Result;


            var commonGenderDetailGetParameters = new Common_GenderDetailGet.Parameters
            {
                GenderID = 1
            };
            var commonGenderDetailGetResults = _commonGenderDetailGetRepository.StoredProcedure("[Common].[GenderDetailGet]", commonGenderDetailGetParameters).Result;



            var residentNeedsReviewResidentReviewInsertParameters = new CareManagement_ResidentNeedsReviewResidentReviewInsert.Parameters
            {
                ApplicationID = 131,
                CustomerID = "1433348,1433263,1433218,1433502,1433274,1433213,1433205,1433391,1433368,1433290,1433390,1433430,1433321,1433331,1433259,1433210,1433439,1433258,1433354,1444224,1458033,1487284,1482892,1485274,1501199,1492172,1501560,1508085,1493905,1530376,1540253,1435167,1560237,1585152,1596008,1630672,1592245,1433226",
                EffectiveDT = new DateTime(2019,11,21),               
                ResidentReviewID  = 446,
                UserName = "Russell.Jones"
            };
            var outputParameters = _residentNeedsReviewResidentReviewInsertRepository.StoredProcedureWithOutput("[CareManagement].[ResidentNeedsReviewResidentReviewInsert]", residentNeedsReviewResidentReviewInsertParameters).Result;


            System.Console.ReadKey();
        }
    }
}
