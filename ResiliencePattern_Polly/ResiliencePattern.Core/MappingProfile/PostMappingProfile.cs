using AutoMapper;
using ResiliencePattern.Core.ServiceModels;
using ResiliencePattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResiliencePattern.Core.MappingProfile
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
