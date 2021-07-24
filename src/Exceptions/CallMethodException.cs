using System;

namespace PowerUtils.xUnit.Extensions.Exceptions
{
    [Serializable]
    public class CallMethodException : Exception
    {
        public CallMethodException(string methodName)
            : base($"It was not possible to call the method '{methodName}'") { }
    }
}