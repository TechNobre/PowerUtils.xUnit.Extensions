using System;

namespace PowerUtils.xUnit.Extensions.Exceptions
{
    [Serializable]
    public class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException(string propertyName)
            : base($"'{propertyName}' not found") { }
    }
}