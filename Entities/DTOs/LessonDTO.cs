using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class LessonDTO
    {
        public string Name { get; set; } = null!;
        public virtual List<LessonVideo>? LessonVideos { get; set; }
    }
}
