using AutoMapper;
using CaffeFido.Core.Entities;
using CaffeFido.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeFido.Web.AutoMapper
{
    public class GenderDetailGetMapperProfile : Profile
    {
        public GenderDetailGetMapperProfile()
        {
            CreateMap<Common_GenderDetailGet.Results, GenderDetailGetViewModel>()
                .ForMember(d => d.GenderID, a => a.MapFrom(s => s.GenderID))
                .ForMember(d => d.Gender, a => a.MapFrom(s => s.Gender))
                .ForMember(d => d.Sort, a => a.MapFrom(s => s.Sort))
                .ForMember(d => d.CreateBy, a => a.MapFrom(s => s.CreateBy))
                .ForMember(d => d.CreateDT, a => a.MapFrom(s => s.CreateDT))
                .ForMember(d => d.ModifyBy, a => a.MapFrom(s => s.ModifyBy))
                .ForMember(d => d.ModifyDT, a => a.MapFrom(s => s.ModifyDT))
                .ForMember(d => d.ApplicationID, a => a.MapFrom(s => s.ApplicationID));
        }
    }
}
