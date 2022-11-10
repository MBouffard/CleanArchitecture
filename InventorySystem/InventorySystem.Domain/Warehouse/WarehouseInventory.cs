using InventorySystem.Domain.Inventory;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem.Domain.Warehouse
{
    public class WarehouseInventory
    {
        public WarehouseId WarehouseId { get; }
        public IList<InventoryEntry> Products { get; }
        public InventoryModes InventoryMode { get; }
        public IList<InventoryEntry> AvailableProducts => Products.Where(x => x.IsAvailable()).ToList();

        public WarehouseInventory(WarehouseId warehouseId, IList<InventoryEntry> products, InventoryModes inventoryMode)
        {
            WarehouseId = warehouseId;
            Products = products.OrderBy(x => x.DateRegistered).ToList();
            InventoryMode = inventoryMode;
        }

        public void RemoveProduct(ProductId productId)
        {
            switch (InventoryMode)
            {
                case InventoryModes.FIFO:
                    RemoveFifo(productId);
                    break;
                case InventoryModes.LIFO:
                    RemoveLifo(productId);
                    break;
                default:
                    throw new InventoryModeNotSupportedException();
            }

        }

        private void RemoveFifo(ProductId productId)
        {
            InventoryEntry productInventory = Products.OrderByDescending(x => x.DateRegistered).First(product => product.ProductInfo.Id == productId);
            productInventory.RemoveFromInventory();
        }

        private void RemoveLifo(ProductId productId)
        {
            InventoryEntry productInventory = Products.OrderBy(x => x.DateRegistered).First(product => product.ProductInfo.Id == productId);
            productInventory.RemoveFromInventory();
        }
    }
}
