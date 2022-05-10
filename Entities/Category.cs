using Core.Abstract;

namespace Entities
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsFeatured { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual Category? ParentCategory { get; set; }
    }
}
