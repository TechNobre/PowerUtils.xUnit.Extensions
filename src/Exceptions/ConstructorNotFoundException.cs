using System;

namespace PowerUtils.xUnit.Extensions.Exceptions
{
    [Serializable]
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public class ConstructorNotFoundException : Exception
    {
        public ConstructorNotFoundException()
            : base("Constructor not found") { }
    }
}
