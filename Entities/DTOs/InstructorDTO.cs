using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class InstructorDTO
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string ProfilImage { get; set; } = null!;
    }
}
