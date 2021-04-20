using AutoMapper;
using RetryPattern.Core.ServiceModels;
using RetryPattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetryPattern.Core.MappingProfile
{
    public class PostMappingProfile:Profile
    {
        public PostMappingProfile()
        {
            CreateMap<PostEntityModel, PostServiceModel>()
              .ForMember(dest => dest.PostId, opts => opts.MapFrom(source => source.Id))
              .ReverseMap();
        }
    }
}
