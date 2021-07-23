using FluentAssertions;
using PowerUtils.xUnit.Extensions.Tests.Fakes;
using System;
using Xunit;
namespace PowerUtils.xUnit.Extensions.Tests
{
    public class PrivateMethodTests
    {
        [Fact(DisplayName = "Call of a method with parameters and returns a value")]
        [Trait("Category", "Call private methods")]
        public void PrivateMethod_WithReturnAndParameters_ReturnsValue()
        {
            // Arrange
            var obj = new FakeClass();
            var input = 32;


            // Act
            var act = obj.InvokePrivateMethod<int>("_method1_1", input);


            // Assert
            act.Should()
                .Be(input * 2);
        }

        [Fact(DisplayName = "Call of a method with parameters and return an exception")]
        [Trait("Category", "Call private methods")]
        public void PrivateMethod_WithReturnAndParameters_ReturnsException()
        {
            // Arrange
            var obj = new FakeClass();
            var input = 32;


            // Act
            Action act = () => obj.InvokePrivateMethod<int>("_method1_2", input);


            // Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Message exception 1_2");
        }

        [Fact(DisplayName = "Call of a method only with returns a value")]
        [Trait("Category", "Call private methods")]
        public void PrivateMethod_WithReturn_ReturnsValue()
        {
            // Arrange
            var obj = new FakeClass();


            // Act
            var act = obj.InvokePrivateMethod<int>("_method2_1");


            // Assert
            act.Should()
                .Be(101);
        }

        [Fact(DisplayName = "Call of a method only with returns an exception")]
        [Trait("Category", "Call private methods")]
        public void PrivateMethod_WithReturn_ReturnsException()
        {
            // Arrange
            var obj = new FakeClass();


            // Act
            Action act = () => obj.InvokePrivateMethod<int>("_method2_2");


            // Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Message exception 2_2");
        }

        [Fact(DisplayName = "Call of a method with parameters and without returns")]
        [Trait("Category", "Call private methods")]
        public void PrivateMethod_WithParameters_WithoutReturn()
        {
            // Arrange
            var obj = new FakeClass();
            var input = 32;


            // Act & Assert
            obj.InvokePrivateMethod("_method3_1", input);
        }

        [Fact(DisplayName = "Call of a method with parameters and return an exception")]
        [Trait("Category", "Call private methods")]
        public void PrivateMethod_WithParameters_ReturnsException()
        {
            // Arrange
            var obj = new FakeClass();
            var input = 32;


            // Act
            Action act = () => obj.InvokePrivateMethod("_method3_2", input);


            // Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Message exception 3_2");
        }

        [Fact(DisplayName = "Call of a method without parameters and without returns")]
        [Trait("Category", "Call private methods")]
        public void PrivateMethod_WithoutParametersAndRetun()
        {
            // Arrange
            var obj = new FakeClass();


            // Act & Assert
            obj.InvokePrivateMethod("_method4_1");
        }

        [Fact(DisplayName = "Call of a method without parameters and returns an exception")]
        [Trait("Category", "Call private methods")]
        public void PrivateMethod_WithoutParametersAndRetun_ReturnsException()
        {
            // Arrange
            var obj = new FakeClass();


            // Act
            Action act = () => obj.InvokePrivateMethod("_method4_2");


            // Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Message exception 4_2");
        }

        [Fact(DisplayName = "Try calling an unexisting method without parameters and without returns - Should return MethodNotFoundException")]
        [Trait("Category", "Call private methods")]
        public void PrivateMethod_UnexistingMethodWithoutParametersAndRetun_ReturnsMethodNotFoundException()
        {
            // Arrange
            var obj = new FakeClass();


            // Act
            Action act = () => obj.InvokePrivateMethod("_method_unexisting_1");


            // Assert
            act.Should()
                .Throw<MethodNotFoundException>()
                .WithMessage("'_method_unexisting_1' not found");
        }

        [Fact(DisplayName = "Try calling an unexisting method without returns - Should return MethodNotFoundException")]
        [Trait("Category", "Call private methods")]
        public void PrivateMethod_UnexistingMethodWitRetun_ReturnsMethodNotFoundException()
        {
            // Arrange
            var obj = new FakeClass();


            // Act
            Action act = () => obj.InvokePrivateMethod<string>("_method_unexisting_1");


            // Assert
            act.Should()
                .Throw<MethodNotFoundException>()
                .WithMessage("'_method_unexisting_1' not found");
        }
    }
}