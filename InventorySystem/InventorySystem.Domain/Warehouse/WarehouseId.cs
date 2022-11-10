using System;

namespace InventorySystem.Domain.Warehouse
{
    public class WarehouseId
    {
        public int Value { get; }

        public WarehouseId(int value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is WarehouseId id &&
                   Value == id.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
