using System;
using System.Collections.Generic;
using System.Linq;
using InventorySystem.Domain.Inventory;
using InventorySystem.Domain.Warehouse;
using InventorySystem.Persistence.InventoryData;

namespace InventorySystem.Persistence.Warehouse
{
    public class WarehouseInMemoryRepository : IWarehouseRepository
    {
        private static IList<InventoryEntryEntity> inventoryEntriesData = new List<InventoryEntryEntity>();
        private static InventoryModes currentInventoryModeConfigured = InventoryModes.FIFO;

        public WarehouseInventory GetById(WarehouseId warehouseId)
        {
            IList<InventoryEntryEntity> inventoryEntriesDataInTheLastYear = 
                inventoryEntriesData.Where(x => x.WarehouseId == warehouseId.Value && x.DateRemoved >= DateTime.Today.AddYears(-1)).ToList();
            
            IList<InventoryEntry> inventoryEntries = new List<InventoryEntry>();

            foreach (InventoryEntryEntity inventoryEntryData in inventoryEntriesDataInTheLastYear)
            {
                ProductInfo productInfo = new ProductInfo(
                    new ProductId(inventoryEntryData.ProductInfo.Id),
                    inventoryEntryData.ProductInfo.Name,
                    inventoryEntryData.ProductInfo.Description,
                    new Money(inventoryEntryData.ProductInfo.Price)
                );

                InventoryEntry inventoryEntry = new InventoryEntry(new InventoryEntryId(inventoryEntryData.Id), productInfo, inventoryEntryData.DateRegistered, inventoryEntryData.DateRemoved);
                inventoryEntries.Add(inventoryEntry);
            }

            return new WarehouseInventory(warehouseId, inventoryEntries, currentInventoryModeConfigured);
        }

        public void Save(WarehouseInventory warehouseInventory)
        {
            foreach (InventoryEntry productInventory in warehouseInventory.Products)
            {
                InventoryEntryEntity productInventoryEntity = inventoryEntriesData.First(x => x.Id == productInventory.Id.Value);
                productInventoryEntity.DateRemoved = productInventoryEntity.DateRemoved;
            }
        }
    }
}
