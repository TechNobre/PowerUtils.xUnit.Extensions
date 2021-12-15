using PowerUtils.xUnit.Extensions.Exceptions;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace PowerUtils.xUnit.Extensions
{
    public class ObjectInvoker
    {
        /// <summary>
        /// Invoke static non-public methods
        /// </summary>
        /// <typeparam name="TResult">Returns type</typeparam>
        /// <param name="obj">Object containing the method</typeparam>
        /// <param name="methodName">Name of the non-public method you want to call</param>
        /// <param name="parameters">Petermeters to send to non-public method</param>
        /// <returns>Value returned from method</returns>
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="obj">obj</paramref> is null</exception>
        public static TResult Invoke<TResult>(Type obj, string methodName, params object[] parameters)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj), $"The '{nameof(obj)}' cannot be null");
            }

            var methodInfo = obj.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);

            if (methodInfo == null)
            {
                throw new MethodNotFoundException(methodName);
            }

            try
            {
                object result = methodInfo.Invoke(null, parameters);
                return (TResult)result;
            }
            catch (TargetInvocationException exception)
            {
                throw exception?.InnerException ?? exception;
            }
        }

        /// <summary>
        /// Invoke static non-public methods
        /// </summary>
        /// <param name="obj">Object containing the method/param>
        /// <param name="methodName">Name of the non-public method you want to call</param>
        /// <param name="parameters">Petermeters to send to non-public method</param>
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="obj">obj</paramref> is null</exception>
        public static void Invoke(Type obj, string methodName, params object[] parameters)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), $"The '{nameof(obj)}' cannot be null");
            }

            var methodInfo = obj.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);

            if (methodInfo == null)
            {
                throw new MethodNotFoundException(methodName);
            }

            try
            {
                methodInfo.Invoke(null, parameters);
            }
            catch (TargetInvocationException exception)
            {
                throw exception?.InnerException ?? exception;
            }
        }

        /// <summary>
        /// Invoke asynchronously static non-public methods
        /// </summary>
        /// <typeparam name="TResult">Returns type</typeparam>
        /// <param name="obj">Object containing the method/param>
        /// <param name="methodName">Name of the non-public method you want to call</param>
        /// <param name="parameters">Petermeters to send to non-public method</param>
        /// <returns>Value returned from method</returns>
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        /// <exception cref="CallMethodException">When it is not possible to call the method <paramref name="methodName">methodName</paramref></exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="obj">obj</paramref> is null</exception>
        public static async Task<TResult> InvokeAsync<TResult>(Type obj, string methodName, params object[] parameters)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), $"The '{nameof(obj)}' cannot be null");
            }

            var methodInfo = obj.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);

            if (methodInfo == null)
            {
                throw new MethodNotFoundException(methodName);
            }

            try
            {
                var response = (Task<TResult>)methodInfo.Invoke(obj, parameters);
                if (response == null)
                {
                    throw new CallMethodException(methodName);
                }

                return await response;
            }
            catch (TargetInvocationException exception)
            {
                throw exception?.InnerException ?? exception;
            }
        }

        /// <summary>
        /// Invoke asynchronously static non-public methods
        /// </summary>
        /// <param name="obj">Object containing the method/param>
        /// <param name="methodName">Name of the non-public method you want to call</param>
        /// <param name="parameters">Petermeters to send to non-public method</param>
        /// <exception cref="MethodNotFoundException">When the <paramref name="methodName">methodName</paramref> not found</exception>
        /// <exception cref="CallMethodException">When it is not possible to call the method <paramref name="methodName">methodName</paramref></exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="obj">obj</paramref> is null</exception>
        public static async Task InvokeAsync(Type obj, string methodName, params object[] parameters)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), $"The '{nameof(obj)}' cannot be null");
            }

            var methodInfo = obj.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);

            if (methodInfo == null)
            {
                throw new MethodNotFoundException(methodName);
            }

            try
            {
                var response = (Task)methodInfo.Invoke(obj, parameters);
                if (response == null)
                {
                    throw new CallMethodException(methodName);
                }
                await response;
            }
            catch (TargetInvocationException exception)
            {
                throw exception?.InnerException ?? exception;
            }
        }
    }
}