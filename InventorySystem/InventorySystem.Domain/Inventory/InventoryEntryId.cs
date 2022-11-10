using System;

namespace InventorySystem.Domain.Inventory
{
    public class InventoryEntryId
    {
        public int Value { get; }

        public InventoryEntryId(int value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is InventoryEntryId id &&
                   Value == id.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}