using PowerUtils.xUnit.Extensions.Exceptions;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace PowerUtils.xUnit.Extensions
{
    public static class PrivatePropertyExtensions
    { // DONE
        /// <summary>
        /// Set a property with private set
        /// </summary>
        /// <param name="source">Object with property</param>
        /// <param name="property">Target property</param>
        /// <param name="newValue">Value for property</param>
        /// <exception cref="ArgumentNullException">When the <paramref name="source">source</paramref> is null</exception>
        public static void SetPrivateProperty<TSource, TProperty>(
            this TSource source,
            Expression<Func<TSource, TProperty>> property,
            TProperty newValue
        )
        {
            // https://softwareengineering.stackexchange.com/questions/304635/stubbing-properties-with-private-setters-for-tests

            if(source == null)
            {
                throw new ArgumentNullException("source");
            }

            var propertyInfo = (PropertyInfo)((MemberExpression)property.Body).Member;
            propertyInfo.SetValue(source, newValue);
        }

        /// <summary>
        /// Set a private property
        /// </summary>
        /// <param name="source">Object with property</param>
        /// <param name="propertyName">Name of target property</param>
        /// <param name="newValue">Value for property</param>
        /// <exception cref="ArgumentNullException">When the <paramref name="source">source</paramref> is null</exception>
        /// <exception cref="PropertyNotFoundException">When the <paramref name="propertyName">propertyName</paramref> not found</exception>
        public static void SetPrivateProperty<TSource, TProperty>(this TSource source, string propertyName, TProperty newValue)
        {
            // https://stackoverflow.com/questions/1565734/is-it-possible-to-set-private-property-via-reflection

            if(source == null)
            {
                throw new ArgumentNullException("source");
            }

            var propertyInfo = source.GetType()
                .GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic);

            if(propertyInfo == null)
            {
                throw new PropertyNotFoundException(propertyName);
            }

            propertyInfo.SetValue(source, newValue, null);
        }

        /// <summary>
        /// Set a private field
        /// </summary>
        /// <param name="source">Object with field</param>
        /// <param name="fieldName">Name of target field</param>
        /// <param name="newValue">Value for field</param>
        /// <exception cref="ArgumentNullException">When the <paramref name="source">source</paramref> is null</exception>
        /// <exception cref="FieldNotFoundException">When the <paramref name="fieldName">propertyName</paramref> not found</exception>
        public static void SetPrivateField<TSource, TField>(this TSource source, string fieldName, TField newValue)
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
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