using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    public class CourseManager : ICourseManager
    {
        private readonly ICourseDal _dal;

        public CourseManager(ICourseDal dal)
        {
            _dal = dal;
        }

        public async Task<Course> CourseId(int id)
        {
           return await _dal.GetCourseById(id);
        }

        public async Task CourseAdd(Course course)
        {
            await _dal.AddCourse(course);
        }

        public async Task<List<Course>> PopularCourses()
        {
            return  await _dal.GetPopularCourses();
        }

        public async Task<IEnumerable<Course>> GetCoursesByCategory(int? categoryId)
        {
            var courses = await _dal.GetAllInclude(x=>x.CategoryId==categoryId);
            return  courses;
        }

        public async Task<IEnumerable<Course>> GetCoursesByInstructor(int? instructorId)
        {
            var courses = await _dal.GetAllInclude(x => x.InstructorId == instructorId);
            return  courses;
        }

        public Task<IEnumerable<Course>> FilterCourses(FilterCourseItem item)
        {
            return _dal.FilterCourse(item);
        }

        public List<Course> GetAll()
        {
            return _dal.ListCourse();
        }
    }
}
