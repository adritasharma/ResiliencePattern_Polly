using AutoMapper;
using RetryPattern.Core.ServiceModels;
using RetryPattern_Polly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetryPattern_Polly.MappingProfiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<PostServiceModel, PostVM>()
                .ReverseMap();
        }
    }
}