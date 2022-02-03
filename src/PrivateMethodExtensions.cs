using System;
using System.Reflection;
using System.Threading.Tasks;
using PowerUtils.xUnit.Extensions.Exceptions;

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
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        [Obsolete("This method is deprecated. It will be removed on 2022/05/31. Use the new method 'InvokeNonPublicMethod'")]
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
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        [Obsolete("This method is deprecated. It will be removed on 2022/05/31. Use the new method 'InvokeNonPublicMethod'")]
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

        /// <summary>
        /// Invoke asynchronously private methods
        /// </summary>
        /// <typeparam name="TResult">Returns type</typeparam>
        /// <param name="obj">Object containing the method/param>
        /// <param name="methodName">Name of the private method you want to call</param>
        /// <param name="parameters">Petermeters to send to private method</param>
        /// <returns>Value returned from method</returns>
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        /// <exception cref="CallMethodException">When it is not possible to call the method <paramref name="methodName">methodName</paramref></exception>
        [Obsolete("This method is deprecated. It will be removed on 2022/05/31. Use the new method 'InvokeNonPublicMethodAsync'")]
        public static async Task<TResult> InvokePrivateMethodAsync<TResult>(this object obj, string methodName, params object[] parameters)
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
        /// Invoke asynchronously private methods
        /// </summary>
        /// <param name="obj">Object containing the method/param>
        /// <param name="methodName">Name of the private method you want to call</param>
        /// <param name="parameters">Petermeters to send to private method</param>
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        /// <exception cref="CallMethodException">When it is not possible to call the method <paramref name="methodName">methodName</paramref></exception>
        [Obsolete("This method is deprecated. It will be removed on 2022/05/31. Use the new method 'InvokeNonPublicMethodAsync'")]
        public static async Task InvokePrivateMethodAsync(this object obj, string methodName, params object[] parameters)
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
