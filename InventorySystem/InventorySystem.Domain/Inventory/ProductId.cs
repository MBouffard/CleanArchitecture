using System;

namespace InventorySystem.Domain.Inventory
{
    public class ProductId
    {
        public int Value { get; }

        public ProductId(int value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is ProductId id &&
                   Value == id.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public static bool operator== (ProductId obj1, ProductId obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(ProductId obj1, ProductId obj2)
        {
            return !obj1.Equals(obj2);
        }
    }
}