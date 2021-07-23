using System.Reflection;

namespace PowerUtils.xUnit.Extensions
{
    public static class PrivateMethodExtensions
    {
        /// <summary>
        /// Invoke private methods
        /// </summary>
        /// <typeparam name="TResult">Returns type</typeparam>
        /// <param name="obj">Object containing the method/param>
        /// <param name="methodName">Name of the private method you want to call</param>
        /// <param name="parameters">Petermeters to send to private method</param>
        /// <returns>Value returned from method</returns>
        public static TResult InvokePrivateMethod<TResult>(this object obj, string methodName, params object[] parameters)
        {
            var objType = obj.GetType();
            var methodInfo = objType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if(methodInfo == null)
            {
                throw new MethodNotFoundException(methodName);
            }

            try
            {
                var result = methodInfo.Invoke(obj, parameters);
                return (TResult)result;
            }
            catch(TargetInvocationException exception)
            {
                throw exception?.InnerException ?? exception;
            }
        }

        /// <summary>
        /// Invoke private methods
        /// </summary>
        /// <param name="obj">Object containing the method/param>
        /// <param name="methodName">Name of the private method you want to call</param>
        /// <param name="parameters">Petermeters to send to private method</param>
        public static void InvokePrivateMethod(this object obj, string methodName, params object[] parameters)
        {
            var objType = obj.GetType();
            var methodInfo = objType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if(methodInfo == null)
            {
                throw new MethodNotFoundException(methodName);
            }

            try
            {
                methodInfo.Invoke(obj, parameters);
            }
            catch(TargetInvocationException exception)
            {
                throw exception?.InnerException ?? exception;
            }
        }
    }
}