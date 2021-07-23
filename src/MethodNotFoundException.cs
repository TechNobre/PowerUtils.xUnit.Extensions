using System;

namespace PowerUtils.xUnit.Extensions
{
    [Serializable]
    public class MethodNotFoundException : Exception
    {
        public MethodNotFoundException(string methodName)
            : base($"'{methodName}' not found") { }
    }
}