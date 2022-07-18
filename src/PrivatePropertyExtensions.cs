using System;
using System.Reflection;
using PowerUtils.xUnit.Extensions.Exceptions;

namespace PowerUtils.xUnit.Extensions
{
    public static class PrivatePropertyExtensions
    { // DONE
        /// <summary>
        /// Set a private field
        /// </summary>
        /// <param name="source">Object with field</param>
        /// <param name="fieldName">Name of target field</param>
        /// <param name="newValue">Value for field</param>
        /// <exception cref="ArgumentNullException">When the <paramref name="source">source</paramref> is null</exception>
        /// <exception cref="FieldNotFoundException">When the <paramref name="fieldName">propertyName</paramref> not found</exception>
        [Obsolete("This method is deprecated. It will be removed on 2022/05/31. Use the new method 'SetNonPublicField'")]
        public static void SetPrivateField<TSource, TField>(this TSource source, string fieldName, TField newValue)
        {
            if(source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var fieldInfo = source.GetType()
                .GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);

            if(fieldInfo == null)
            {
                throw new FieldNotFoundException(fieldName);
            }

            fieldInfo.SetValue(source, newValue);
        }
    }
}
