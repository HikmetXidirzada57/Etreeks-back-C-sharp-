using Core.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICourseDal:IEntityRepository<Course>
    {
        public Task<List<Course>> GetPopularCourses();
        public Task<Course>GetCourseById(int? id);
        public Task<IEnumerable<Course>> FilterCourse(FilterCourseItem item);
        public Task<IEnumerable<Course>> GetAllInclude(Expression<Func<Course, bool>>? filters);
        public List<Course> ListCourse();

        Task AddCourse(Course course);
        Task UpdateCourse(Course course);
    }
}
