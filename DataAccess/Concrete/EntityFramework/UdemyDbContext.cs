using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class UdemyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.\;Database=K310UdemyDb;Trusted_Connection=true;MultipleActiveResultSets=true");
        }
        
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<CourseSpecification> CourseSpecifications { get; set; } = null!;
        public DbSet<Specification> Specification { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<Instructor> Instructors { get; set; } = null!;
        public DbSet<Lesson> Lessons { get; set; } = null!;
        public DbSet<LessonVideo> LessonVideos{ get; set; } = null!;
    }
}
