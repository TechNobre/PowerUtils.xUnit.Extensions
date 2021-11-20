using PowerUtils.xUnit.Extensions.Exceptions;
using System.Reflection;
using System.Threading.Tasks;

namespace PowerUtils.xUnit.Extensions
{
    public static class NonPublicMethodExtensions
    {
        /// <summary>
        /// Invoke non-public methods
        /// </summary>
        /// <typeparam name="TResult">Returns type</typeparam>
        /// <param name="obj">Object containing the method/param>
        /// <param name="methodName">Name of the non-public method you want to call</param>
        /// <param name="parameters">Petermeters to send to non-public method</param>
        /// <returns>Value returned from method</returns>
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        public static TResult InvokeNonPublicMethod<TResult>(this object obj, string methodName, params object[] parameters)
        {
            var objType = obj.GetType();
            var methodInfo = objType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if(methodInfo == null)
            {
                throw new MethodNotFoundException(methodName);
            }

            try
            {
                object result = methodInfo.Invoke(obj, parameters);
                return (TResult)result;
            }
            catch(TargetInvocationException exception)
            {
                throw exception?.InnerException ?? exception;
            }
        }

        /// <summary>
        /// Invoke non-public methods
        /// </summary>
        /// <param name="obj">Object containing the method/param>
        /// <param name="methodName">Name of the non-public method you want to call</param>
        /// <param name="parameters">Petermeters to send to non-public method</param>
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        public static void InvokeNonPublicMethod(this object obj, string methodName, params object[] parameters)
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

        /// <summary>
        /// Invoke asynchronously non-public methods
        /// </summary>
        /// <typeparam name="TResult">Returns type</typeparam>
        /// <param name="obj">Object containing the method/param>
        /// <param name="methodName">Name of the non-public method you want to call</param>
        /// <param name="parameters">Petermeters to send to non-public method</param>
        /// <returns>Value returned from method</returns>
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        /// <exception cref="CallMethodException">When it is not possible to call the method <paramref name="methodName">methodName</paramref></exception>
        public static async Task<TResult> InvokeNonPublicMethodAsync<TResult>(this object obj, string methodName, params object[] parameters)
        {
            var objType = obj.GetType();
            var methodInfo = objType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if(methodInfo == null)
            {
                throw new MethodNotFoundException(methodName);
            }

            try
            {
                var response = (Task<TResult>)methodInfo.Invoke(obj, parameters);
                if(response == null)
                {
                    throw new CallMethodException(methodName);
                }

                return await response;
            }
            catch(TargetInvocationException exception)
            {
                throw exception?.InnerException ?? exception;
            }
        }

        /// <summary>
        /// Invoke asynchronously non-public methods
        /// </summary>
        /// <param name="obj">Object containing the method/param>
        /// <param name="methodName">Name of the non-public method you want to call</param>
        /// <param name="parameters">Petermeters to send to non-public method</param>
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        /// <exception cref="CallMethodException">When it is not possible to call the method <paramref name="methodName">methodName</paramref></exception>
        public static async Task InvokeNonPublicMethodAsync(this object obj, string methodName, params object[] parameters)
        {
            var objType = obj.GetType();
            var methodInfo = objType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if(methodInfo == null)
            {
                throw new MethodNotFoundException(methodName);
            }

            try
            {
                var response = (Task)methodInfo.Invoke(obj, parameters);
                if(response == null)
                {
                    throw new CallMethodException(methodName);
                }
                await response;
            }
            catch(TargetInvocationException exception)
            {
                throw exception?.InnerException ?? exception;
            }
        }
    }
}