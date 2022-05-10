using Core.Abstract;

namespace Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public List<OrderItem>? OrderItems { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal? TaxPrice { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
