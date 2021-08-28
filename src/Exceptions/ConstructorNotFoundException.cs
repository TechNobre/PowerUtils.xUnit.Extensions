using System;

namespace PowerUtils.xUnit.Extensions.Exceptions
{
    [Serializable]
    public class ConstructorNotFoundException : Exception
    {
        public ConstructorNotFoundException()
            : base("Constructor not found") { }
    }
}