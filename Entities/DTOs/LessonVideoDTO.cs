using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class LessonVideoDTO
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string VideoUrl { get; set; } = null!;
    }
}
