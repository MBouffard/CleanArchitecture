using System;

namespace InventorySystem.Persistence.InventoryData
{
    public class InventoryEntryEntity
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public ProductInfoEntity ProductInfo { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime DateRemoved { get; set; }
    }
}
