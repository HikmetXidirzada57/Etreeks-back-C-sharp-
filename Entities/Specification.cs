using Core.Abstract;

namespace Entities
{
    public class Specification : IEntity
    {
        public int Id { get; set; }
        public string? Icon { get; set; }
        public string Value { get; set; } = null!;
    }
}
