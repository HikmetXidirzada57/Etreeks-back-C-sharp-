using AutoMapper;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles
{
   public class LessonVideoProfile:Profile
    {
        public LessonVideoProfile()
        {
            CreateMap<LessonVideo, LessonVideoDTO>()
        .ForMember(
         dest => dest.Name,
         opt => opt.MapFrom(src => src.Name)
          )
          .ForMember(
         dest => dest.VideoUrl,
         opt => opt.MapFrom(src => src.VideoUrl)
          )
          .ForMember(
         dest => dest.Description,
         opt => opt.MapFrom(src => src.Description)
          );
        }
    }
}
