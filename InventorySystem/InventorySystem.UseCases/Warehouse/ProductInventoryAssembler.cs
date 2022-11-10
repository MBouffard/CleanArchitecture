using InventorySystem.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem.UseCases.Warehouse
{
    public class ProductInventoryAssembler
    {
        public IList<ProductInventoryDto> ToDto(IList<InventoryEntry> inventoryEntries)
        {
            IList<ProductId> productIds = inventoryEntries.Select(x => x.ProductInfo.Id).Distinct().ToList();
            IList<ProductInventoryDto> productInventoryDtos = new List<ProductInventoryDto>();

            foreach (ProductId productId in productIds)
            {
                ProductInfo productInfo = inventoryEntries.Where(x => x.ProductInfo.Id == productId).Select(x => x.ProductInfo).First();
                int quantity = inventoryEntries.Where(x => x.ProductInfo.Id == productId).Count();
                DateTime lastArrival = inventoryEntries.Where(x => x.ProductInfo.Id == productId).Select(x => x.DateRegistered).Max();
                
                productInventoryDtos.Add(ToDto(productInfo, quantity, lastArrival));
            }

            return productInventoryDtos;
        }

        public ProductInventoryDto ToDto(ProductInfo productInfo, int quantity, DateTime lastArrival)
        {
            ProductInventoryDto productInventoryDto = new ProductInventoryDto();

            productInventoryDto.Id = productInfo.Id.Value;
            productInventoryDto.Name = productInfo.Name;
            productInventoryDto.Price = productInfo.Price.ToString();
            productInventoryDto.Quantity = quantity;
            productInventoryDto.LastArrival = lastArrival;

            return productInventoryDto;
        }
    }
}
