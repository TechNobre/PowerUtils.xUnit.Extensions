using FluentAssertions;
using PowerUtils.xUnit.Extensions.Exceptions;
using PowerUtils.xUnit.Extensions.Tests.Fakes;
using System;
using Xunit;

namespace PowerUtils.xUnit.Extensions.Tests
{
    public class NonPublicConstructorTests
    {
        [Fact(DisplayName = "Try to instance a class with private constructor without parameters - Should returns valid instance of the class")]
        [Trait("Category", "Non public constructor")]
        public void PrivateConstructor_WithoutParameters_ValidInstance()
        {
            // Arrange & Act
            var act = ObjectFactory.Create<FakeClassWithNonPubliceConstructor>();


            // Assert
            act.FirstName.Should()
                .Be("Fake first name");
            act.LasttName.Should()
                .Be("Fake last name");
            act.Age.Should()
                .Be(21);
        }

        [Fact(DisplayName = "Try to instance a class with non public constructor but the parameters does not match - Should returns an `ConstructorNotFoundException`")]
        [Trait("Category", "Non public constructor")]
        public void NonPublicConstructor_ParametersNotMatch_ReturnsException()
        {
            // Arrange & Act
            Action act = () => ObjectFactory.Create<FakeClassWithNonPubliceConstructor>(1, 2, 3);


            // Assert
            act.Should()
                .Throw<ConstructorNotFoundException>()
                .WithMessage("Constructor not found");
        }

        [Fact(DisplayName = "Try to instance a class with protected constructor with properties - Should returns valid instance of the class")]
        [Trait("Category", "Non public constructor")]
        public void ProtectedConstructor_WithProperties_ValidInstance()
        {
            // Arrange & Act
            var act = ObjectFactory.Create<FakeClassWithNonPubliceConstructor>("Test first name", "Test last name", 50);

            // Assert
            act.FirstName.Should()
                .Be("Test first name");
            act.LasttName.Should()
                .Be("Test last name");
            act.Age.Should()
                .Be(50);
        }

        [Fact(DisplayName = "Try to instance a class with protected constructor with properties in a different order - Should returns valid instance of the class")]
        [Trait("Category", "Non public constructor")]
        public void ProtectedConstructor_PropertiesDifferentOrder_ValidInstance()
        {
            // Arrange & Act
            var act = ObjectFactory.Create<FakeClassWithNonPubliceConstructor>(40, "Other first name", "Other last name");

            // Assert
            act.FirstName.Should()
                .Be("Other first name");
            act.LasttName.Should()
                .Be("Other last name");
            act.Age.Should()
                .Be(40);
        }

        [Fact(DisplayName = "Try to instance a class without non public constructor - Should returns valid instance of the class")]
        [Trait("Category", "Non public constructor")]
        public void NonPublicConstructor_NoNonPublicConstructor_ReturnsException()
        {
            // Arrange & Act
            Action act = () => ObjectFactory.Create<FakeClassWithoutNonPubliceConstructor>();


            // Assert
            act.Should()
                .Throw<ConstructorNotFoundException>()
                .WithMessage("Constructor not found");
        }
    }
}