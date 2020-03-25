using AutoMapper;
using CaffeFido.Core.Entities;
using CaffeFido.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeFido.Web.AutoMapper
{
    public class SnpCommunityDetailGetMapperProfile : Profile
    {
        public SnpCommunityDetailGetMapperProfile()
        {
            CreateMap<CareManagement_snpCommunityDetailGet.Results, snpCommunityDetailGetViewModel>()
               .ForMember(d => d.CommunityID, a => a.MapFrom(s => s.CommunityID))
               .ForMember(d => d.CommunityNumber, a => a.MapFrom(s => s.CommunityNumber))
               .ForMember(d => d.CommunityName, a => a.MapFrom(s => s.CommunityName))
               .ForMember(d => d.Community, a => a.MapFrom(s => s.Community))
               .ForMember(d => d.CommunityNameExternal, a => a.MapFrom(s => s.CommunityNameExternal))
               .ForMember(d => d.Address1, a => a.MapFrom(s => s.Address1))
               .ForMember(d => d.Address2, a => a.MapFrom(s => s.Address2))
               .ForMember(d => d.City, a => a.MapFrom(s => s.City))

               .ForMember(d => d.State, a => a.MapFrom(s => s.State))
               .ForMember(d => d.PostalCode, a => a.MapFrom(s => s.PostalCode))
               .ForMember(d => d.Country, a => a.MapFrom(s => s.Country))
               .ForMember(d => d.PhoneNumber1, a => a.MapFrom(s => s.PhoneNumber1))
               .ForMember(d => d.PhoneNumber1HREF, a => a.MapFrom(s => s.PhoneNumber1HREF))
               .ForMember(d => d.PhoneNumber2, a => a.MapFrom(s => s.PhoneNumber2))
               .ForMember(d => d.PhoneNumber2HREF, a => a.MapFrom(s => s.PhoneNumber2HREF))
               .ForMember(d => d.FaxNumber, a => a.MapFrom(s => s.FaxNumber))

               .ForMember(d => d.FaxNumberHREF, a => a.MapFrom(s => s.FaxNumberHREF))
               .ForMember(d => d.Region, a => a.MapFrom(s => s.Region))
               .ForMember(d => d.Country, a => a.MapFrom(s => s.Country))
               .ForMember(d => d.PhoneNumber1, a => a.MapFrom(s => s.PhoneNumber1))
               .ForMember(d => d.PhoneNumber1HREF, a => a.MapFrom(s => s.PhoneNumber1HREF))
               .ForMember(d => d.PhoneNumber2, a => a.MapFrom(s => s.PhoneNumber2))
               .ForMember(d => d.PhoneNumber2HREF, a => a.MapFrom(s => s.PhoneNumber2HREF))
               .ForMember(d => d.FaxNumber, a => a.MapFrom(s => s.FaxNumber));

        }
    }
}
