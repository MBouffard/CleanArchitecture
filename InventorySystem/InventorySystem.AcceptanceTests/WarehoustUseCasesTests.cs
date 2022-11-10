using InventorySystem.Domain.Inventory;
using InventorySystem.Domain.Warehouse;
using InventorySystem.UseCases.Warehouse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem.AcceptanceTests
{
    [TestClass]
    public class WarehoustUseCasesTests
    {
        private WarehouseInventory warehouseInventory;
        private Mock<IWarehouseRepository> warehouseRepository;
        private WarehouseUseCases warehouseUseCases;

        [TestInitialize]
        public void Intialize()
        {
            ProductInventoryAssembler productInventoryAssembler = new ProductInventoryAssembler();
            warehouseRepository = new Mock<IWarehouseRepository>();
            warehouseUseCases = new WarehouseUseCases(warehouseRepository.Object, productInventoryAssembler);
        }

        [TestMethod]
        public void GivenExistingProduct_WhenGettingWarehouseInventory_ThenInventoryShouldBeReturned()
        {
            ProductId someProductId = new ProductId(1);
            ProductInfo productInfo = new ProductInfo(someProductId, "Some Name", "Some Description", new Money(1.99M));
            warehouseInventory = GetWarehouseInventory(productInfo);
            warehouseRepository.Setup(x => x.GetById(warehouseInventory.WarehouseId)).Returns(warehouseInventory);

            IList<ProductInventoryDto> productsInventory = warehouseUseCases.GetWarehouseInventory(warehouseInventory.WarehouseId);

            Assert.IsTrue(productsInventory.Any(x => x.Id == someProductId.Value));
        }

        [TestMethod]
        public void GivenExistingProduct_WhenRemovingProduct_ThenInventoryShouldBeSaved()
        {
            warehouseInventory = GetSomeWarehouseInventory();
            warehouseRepository.Setup(x => x.GetById(warehouseInventory.WarehouseId)).Returns(warehouseInventory);

            warehouseUseCases.RemoveProductFromInventory(new ProductId(1), warehouseInventory.WarehouseId);

            warehouseRepository.Verify(x => x.Save(warehouseInventory), Times.Once);
        }

        private WarehouseInventory GetSomeWarehouseInventory()
        {
            ProductInfo productInfo = new ProductInfo(new ProductId(1), "Product A", "Some Product", new Money(1.99M));
            return GetWarehouseInventory(productInfo);
        }

        private static WarehouseInventory GetWarehouseInventory(ProductInfo productInfo)
        {
            InventoryEntry inventoryEntry = new InventoryEntry(new InventoryEntryId(1), productInfo, DateTime.Now, null);
            return new WarehouseInventory(new WarehouseId(1), new List<InventoryEntry> { inventoryEntry }, InventoryModes.FIFO);
        }
    }
}
