using AutoMapper;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles
{
   public class InstructorProfile:Profile
    {
        public InstructorProfile()
        {
            CreateMap<Instructor, InstructorDTO>()
                 .ForMember(
             dest => dest.Id,
             opt => opt.MapFrom(src => src.Id)
              )
            .ForMember(
             dest => dest.Fullname,
             opt => opt.MapFrom(src => src.Fullname)
              )
            .ForMember(
             dest => dest.ProfilImage,
             opt => opt.MapFrom(src => src.ProfilImage)
              );
        }
    }
}
