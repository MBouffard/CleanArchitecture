namespace InventorySystem.Domain.Inventory
{
    public class ProductInfo
    {
        public ProductInfo(ProductId id, string name, string description, Money price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductId Id { get; }
        public string Name { get; }
        public string Description { get; }
        public Money Price { get; }
    }
}
