﻿using AutoMapper;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseListDTO>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(dest => dest.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(dest => dest.Name)
                )
                .ForMember(
                    dest => dest.Summary,
                    opt => opt.MapFrom(dest => $"{dest.Summary}")
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(dest => $"{ dest.Description}")
                )

                .ForMember(
                    dest => dest.ModifiedOn,
                    opt => opt.MapFrom(src => $"{src.ModifiedOn}")
                    )
                .ForMember(
                    dest => dest.PhotoUrl,
                    opt => opt.MapFrom(src => $"{src.PhotoUrl}")
                )

                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.Price)
                )
                .ForMember(
                    dest => dest.Discount,
                    opt => opt.MapFrom(src => src.Discount)
                )

                .ForMember(
                    dest => dest.InstructorName,
                    opt => opt.MapFrom(dest => $"{dest.Instructor.Fullname}")
                )

                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(dest => $"{dest.Category.Name}")
                )

                .ForMember(
                    dest => dest.TrailerUrl,
                    opt => opt.MapFrom(dest => $"{dest.TrailerUrl}")
                )

                .ForMember(
                    dest => dest.Rating,
                    opt => opt.MapFrom(dest => $"{dest.Rating}")
                );
        }
    }
}
