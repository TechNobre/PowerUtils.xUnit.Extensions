using System;

namespace PowerUtils.xUnit.Extensions.Exceptions
{
    [Serializable]
    public class MethodNotFoundException : Exception
    {
        public MethodNotFoundException(string methodName)
            : base($"'{methodName}' not found") { }
    }
}