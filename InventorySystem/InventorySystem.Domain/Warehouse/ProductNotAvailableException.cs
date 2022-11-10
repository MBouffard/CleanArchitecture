using InventorySystem.Domain.Inventory;
using System;
using System.Runtime.Serialization;

namespace InventorySystem.Domain.Warehouse
{
    [Serializable]
    internal class ProductNotAvailableException : Exception
    {
        public ProductNotAvailableException(ProductId productId) : base($"The product #{productId.Value} is currently unavailable.")
        {
        }
    }
}