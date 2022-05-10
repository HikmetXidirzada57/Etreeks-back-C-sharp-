using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Course:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public string Summary { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PhotoUrl { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public bool IsFeatured { get; set; }
        public decimal? Rating { get; set; }
        public bool IsDeleted { get; set; }
        public string? TrailerUrl { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public int InstructorId { get; set; }
        public virtual Instructor? Instructor { get; set; }
        public virtual List<Lesson>?  Lessons { get; set; }
        public virtual  List<CourseSpecification>? CourseSpecifications{ get; set; }
    }
}
