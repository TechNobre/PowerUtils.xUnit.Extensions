using System;

namespace PowerUtils.xUnit.Extensions.Exceptions
{
    [Serializable]
    public class FieldNotFoundException : Exception
    {
        public FieldNotFoundException(string fieldName)
            : base($"'{fieldName}' not found") { }
    }
}