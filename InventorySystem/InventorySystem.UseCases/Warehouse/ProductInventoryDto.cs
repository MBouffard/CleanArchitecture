using System;

namespace InventorySystem.UseCases.Warehouse
{
    public class ProductInventoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public DateTime LastArrival { get; set; }
    }
}