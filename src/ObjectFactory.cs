using System;
using System.Linq;
using System.Reflection;
using PowerUtils.xUnit.Extensions.Exceptions;

namespace PowerUtils.xUnit.Extensions
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public static class ObjectFactory
    {
        [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
        public static TObject Create<TObject>(params object[] inputParameters)
        {
            var constructorList = typeof(TObject).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).ToList();

            ConstructorInfo currectConstructor;
            while(true)
            {
                currectConstructor = constructorList.FirstOrDefault();
                if(currectConstructor is null)
                {
                    // Returns null when not found any valid constructor,
                    // when does not have any non public constructor or all constructor does not match with `inputParameters`
                    break;
                }

                var currectParameters = currectConstructor.GetParameters();

                if(inputParameters.Length == 0 && currectParameters.Length == 0)
                {  // Found a constructor without parameters when the `inputParameters` is empty
                    break;
                }

                if(inputParameters.Length != currectParameters.Length)
                { // The `inputParameters` and current constructor parameters number does not match

                    // Remove current constructor from list to in next `while` interaction analyse the next constructor
                    constructorList.Remove(currectConstructor);

                    continue; // Go to next constructor. It is not valid constructor
                }

                var validConstructor = true;
                for(var index = 0; index < inputParameters.Length; index++)
                {
                    if(inputParameters[index].GetType() != currectParameters[index].ParameterType)
                    { // The type of the `inputParameters` and parameters type of the currenct constructor does not match
                        validConstructor = false;
                        break;
                    }
                }

                // When the "for" comes to an end, it's because all the parameters match. Found a valid constructor
                if(validConstructor)
                {
                    break;
                }

                // Remove current constructor from list to in next `while` interaction analyse the next constructor
                constructorList.Remove(currectConstructor);
            }

            // When it gets here and it's `null`, it's because no valid constructor was found
            if(currectConstructor is null)
            {
                throw new ConstructorNotFoundException();
            }

            return (TObject)currectConstructor.Invoke(inputParameters);
        }
    }
}
