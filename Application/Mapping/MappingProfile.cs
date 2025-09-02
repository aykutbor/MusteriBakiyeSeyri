using Application.DTOs;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<MusteriTanim, MusteriTanimDto>().ReverseMap();
            CreateMap<MusteriFatura, MusteriFaturaDto>().ReverseMap();
        }

    }
}
