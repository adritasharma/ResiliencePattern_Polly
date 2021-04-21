using AutoMapper;
using ResiliencePattern.Core.ServiceModels;
using ResiliencePattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResiliencePattern.Core.MappingProfile
{
    public class EmployeeMappingProfile:Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeEntityModel, EmployeeServiceModel>()
              .ReverseMap();
        }
    }
}
