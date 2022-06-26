using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CourseListFilter
    {
        public decimal MaxPrice { get; set; }
        public List<CourseListDTO> Courses { get; set; }
    }
}
