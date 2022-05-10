using Core.Abstract;

namespace Entities
{
    public class Lesson : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public virtual List<LessonVideo>? LessonVideos { get; set; }

    }
}
