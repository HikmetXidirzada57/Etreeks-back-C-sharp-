using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CourseListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PhotoUrl { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public bool IsFeatured { get; set; }
        public decimal? Rating { get; set; }
        public string? TrailerUrl { get; set; }
        public string InstructorName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
    }
}
