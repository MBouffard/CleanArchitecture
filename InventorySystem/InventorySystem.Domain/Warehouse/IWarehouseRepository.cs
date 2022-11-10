namespace InventorySystem.Domain.Warehouse
{
    public interface IWarehouseRepository
    {
        public WarehouseInventory GetById(WarehouseId warehouseId);
        void Save(WarehouseInventory warehouseInventory);
    }
}
