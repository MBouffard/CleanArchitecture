using System;

namespace InventorySystem.Domain.Inventory
{
    public class InventoryEntry
    {
        public InventoryEntryId Id { get; }
        public ProductInfo ProductInfo { get; }
        public DateTime DateRegistered { get; }
        public DateTime? DateRemoved { get; private set; }

        public InventoryEntry(InventoryEntryId id, ProductInfo productInfo, DateTime dateRegistered, DateTime? dateRemoved)
        {
            Id = id;
            ProductInfo = productInfo;
            DateRegistered = dateRegistered;
            DateRemoved = dateRemoved;
        }

        public bool IsAvailable()
        {
            return DateRemoved == null;
        }

        public void RemoveFromInventory()
        {
            DateRemoved = DateTime.Now;
        }
    }
}
