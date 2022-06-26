using AutoMapper;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles
{
    public class LessonProfile:Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson, LessonDTO>()
            .ForMember(
             dest => dest.Name,
            opt => opt.MapFrom(src => src.Name)
            )
           .ForMember(
            dest => dest.LessonVideos,
            opt => opt.MapFrom(src => src.LessonVideos)
            );
         
        }
    }
}
