using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseManager
    {
        public Task<List<Course>> PopularCourses();
        List<Course> GetAll();
        public Task<Course> CourseId(int id);
       public Task<IEnumerable<Course>> GetCoursesByCategory(int? categoryId);
       public Task<IEnumerable<Course>> FilterCourses(FilterCourseItem item);
        public Task<IEnumerable<Course>> GetCoursesByInstructor(int? instructorId);
        Task CourseAdd(Course course);
    }
}
