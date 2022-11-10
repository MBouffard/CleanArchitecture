using System;

namespace InventorySystem.Domain.Inventory
{
    public class Money
    {
        public decimal Value { get; }

        public Money(decimal value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString("C");
        }

        public override bool Equals(object obj)
        {
            return obj is Money money &&
                   Value == money.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}