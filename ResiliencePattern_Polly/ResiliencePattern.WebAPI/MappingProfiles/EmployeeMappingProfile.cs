using AutoMapper;
using ResiliencePattern.Core.ServiceModels;
using ResiliencePattern_Polly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResiliencePattern_Polly.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeServiceModel, EmployeeVM>()
                .ReverseMap();
        }
    }
}