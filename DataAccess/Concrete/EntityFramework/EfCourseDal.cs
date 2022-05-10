using Core.Abstract;
using Core.Concrete.Entityframework;
using DataAccess.Abstract;
using Entities;
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
        public async Task<IEnumerable<Course>> GetPopularCourses()
        {
            using UdemyDbContext context = new ();
            return await context.Courses.Include(c => c.Instructor).Include(c => c.Category).ToListAsync();
        }
    }
}
