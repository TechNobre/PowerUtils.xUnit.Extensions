using System;
using System.Reflection;
using System.Threading.Tasks;
using PowerUtils.xUnit.Extensions.Exceptions;

namespace PowerUtils.xUnit.Extensions
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
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
        /// <exception cref="ArgumentNullException">When the <paramref name="obj">obj</paramref> is null</exception>
        [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
        public static TResult InvokeNonPublicMethod<TResult>(this object obj, string methodName, params object[] parameters)
        {
            if(obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $"The '{nameof(obj)}' cannot be null");
            }

            var objType = obj.GetType();
            var methodInfo = objType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if(methodInfo is null)
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
        /// Invoke non-public methods
        /// </summary>
        /// <param name="obj">Object containing the method/param>
        /// <param name="methodName">Name of the non-public method you want to call</param>
        /// <param name="parameters">Petermeters to send to non-public method</param>
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="obj">obj</paramref> is null</exception>
        [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
        public static void InvokeNonPublicMethod(this object obj, string methodName, params object[] parameters)
        {
            if(obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $"The '{nameof(obj)}' cannot be null");
            }

            var objType = obj.GetType();
            var methodInfo = objType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if(methodInfo is null)
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
        /// <exception cref="ArgumentNullException">When the <paramref name="obj">obj</paramref> is null</exception>
        [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
        public static async Task<TResult> InvokeNonPublicMethodAsync<TResult>(this object obj, string methodName, params object[] parameters)
        {
            if(obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $"The '{nameof(obj)}' cannot be null");
            }

            var objType = obj.GetType();
            var methodInfo = objType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if(methodInfo is null)
            {
                throw new MethodNotFoundException(methodName);
            }

            try
            {
                var response = (Task<TResult>)methodInfo.Invoke(obj, parameters);
                if(response is null)
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
        /// <exception cref="ArgumentNullException">When the <paramref name="obj">obj</paramref> is null</exception>
        [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
        public static async Task InvokeNonPublicMethodAsync(this object obj, string methodName, params object[] parameters)
        {
            if(obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $"The '{nameof(obj)}' cannot be null");
            }

            var objType = obj.GetType();
            var methodInfo = objType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if(methodInfo is null)
            {
                throw new MethodNotFoundException(methodName);
            }

            try
            {
                var response = (Task)methodInfo.Invoke(obj, parameters);
                if(response is null)
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
