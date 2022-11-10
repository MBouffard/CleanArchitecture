using System;
using System.Runtime.Serialization;

namespace InventorySystem.Domain.Warehouse
{
    [Serializable]
    internal class InventoryModeNotSupportedException : Exception
    {
        public InventoryModeNotSupportedException()
        {
        }

        public InventoryModeNotSupportedException(string message) : base(message)
        {
        }

        public InventoryModeNotSupportedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InventoryModeNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}