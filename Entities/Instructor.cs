using Core.Abstract;

namespace Entities
{
    public class Instructor : IEntity
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string ProfilImage { get; set; } = null!;
        public virtual List<Course>? Courses { get; set; }

    }
}
