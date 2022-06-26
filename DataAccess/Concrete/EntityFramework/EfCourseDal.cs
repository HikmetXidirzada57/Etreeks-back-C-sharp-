using Core.Abstract;
using Core.Concrete.Entityframework;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCourseDal : EfEntityRepoBase<UdemyDbContext, Course>, ICourseDal
    {
        public async Task AddCourse(Course course)
        {
            using UdemyDbContext context = new UdemyDbContext();
            await context.Courses.AddAsync(course);
            await context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<Course>> FilterCourse(FilterCourseItem item)
        {
            using UdemyDbContext context = new UdemyDbContext();
            var courses = context.Courses.
                Include(c=>c.Instructor).
                Include(c=>c.Category).
                AsQueryable();

            if (!string.IsNullOrWhiteSpace(item.Q) && item.Q != null)
            {
                courses = courses.Where(c => c.Name.Contains(item.Q)
                  || c.Category.Name.Contains(item.Q)
                  || c.Instructor.Fullname.Contains(item.Q  ));
            }
            if (item.MinPrice.HasValue && item.MaxPrice.HasValue)
            {
                courses=courses.Where(c => c.Price >= item.MinPrice && c.Price <= item.MaxPrice);
            }
            if (item.Rating.HasValue)
            {
                courses = item.Rating.Value switch
                {
                    1 => courses.Where(c => c.Rating >= 1 && c.Rating <= 2),
                    2 => courses.Where(c => c.Rating >= 2 && c.Rating <= 3),
                    3 => courses.Where(c => c.Rating >= 3 && c.Rating <= 4),
                    4 => courses.Where(c => c.Rating >= 4 && c.Rating <= 5),
                    _ => courses.Where(c => c.Rating >= 1 && c.Rating <= 5),


                };

                if (item.InstructorIds.Count>0)
                {
                    courses=courses.Where((c) => item.InstructorIds.Contains(c.InstructorId));
                }
                if (item.SortBy.HasValue)
                {
                    courses = item.SortBy.Value switch
                    {
                        0 => courses.OrderByDescending(c => c.Price),
                        1 => courses.OrderBy(c => c.Price),
                        _ => courses.OrderBy(c => c.PublishDate),
                    };
                }
                return await courses.ToListAsync();
            }
            return courses;
        }

   

        public async Task<IEnumerable<Course>> GetAllInclude(Expression<Func<Course, bool>>? filters)
        {
            using UdemyDbContext context = new();
            var course = context.Courses
                .Where(x => !x.IsDeleted)
                .Include(x => x.Category)
                .Include(x => x.Instructor)
                .Include(x => x.CourseSpecifications)
                .Include(x => x.Lessons).ThenInclude(x => x.LessonVideos)
                .AsQueryable();

            if (filters != null)
            {
                course = course.Where(filters);
            }
            return await course.ToListAsync();
        }

        public async Task<Course> GetCourseById(int? id)
        {
            using UdemyDbContext context = new UdemyDbContext();
            return await context.Courses.Where(c => !c.IsDeleted)
                .Include(c => c.Category).
                Include(c => c.Instructor).
                Include(c => c.Lessons)
                 .ThenInclude(c => c.LessonVideos)
                .Include(c => c.CourseSpecifications).
                FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<List<Course>> GetPopularCourses()
        {
            using UdemyDbContext context = new();
            return await context.Courses.Where(c => !c.IsDeleted).
                Include(c => c.Instructor).
                Include(c => c.Category).Include(c => c.Lessons).
                ThenInclude(c => c.LessonVideos)
                .OrderByDescending(x => x.Rating).
                ToListAsync();
        }

        public List<Course> ListCourse()
        {
                using UdemyDbContext context = new();
                var myCourses = context.Courses.Where(c => !c.IsDeleted)
                  .Include(c => c.Instructor)
                  .Include(c => c.Category)
                  .Include(c => c.Lessons)
                  .Include(c => c.CourseSpecifications)
                  .ThenInclude(c => c.Specification)
                  .ToList();
                return myCourses;
            
        }

        public async Task UpdateCourse(Course course)
        {
            using UdemyDbContext context = new();
            context.Courses.Update(course);
            await context.SaveChangesAsync();
        }
    }
    }
