using System;

namespace PowerUtils.xUnit.Extensions.Exceptions
{
    [Serializable]
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public class MethodNotFoundException : Exception
    {
        public MethodNotFoundException(string methodName)
            : base($"'{methodName}' not found") { }
    }
}
