using InventorySystem.Domain.Inventory;
using InventorySystem.Domain.Warehouse;
using System.Collections.Generic;

namespace InventorySystem.UseCases.Warehouse
{
    public class WarehouseUseCases
    {
        private readonly IWarehouseRepository warehouseInventoryRepository;
        private readonly ProductInventoryAssembler productInventoryAssembler;

        public WarehouseUseCases(IWarehouseRepository warehouseInventoryRepository, ProductInventoryAssembler productInventoryAssembler)
        {
            this.warehouseInventoryRepository = warehouseInventoryRepository;
            this.productInventoryAssembler = productInventoryAssembler;
        }

        public void RemoveProductFromInventory(ProductId productId, WarehouseId warehouseId)
        {
            WarehouseInventory warehouseInventory = warehouseInventoryRepository.GetById(warehouseId);
            warehouseInventory.RemoveProduct(productId);
            warehouseInventoryRepository.Save(warehouseInventory);
        }

        public IList<ProductInventoryDto> GetWarehouseInventory(WarehouseId warehouseId)
        {
            WarehouseInventory warehouseInventory = warehouseInventoryRepository.GetById(warehouseId);
            return productInventoryAssembler.ToDto(warehouseInventory.AvailableProducts);
        }
    }
}
