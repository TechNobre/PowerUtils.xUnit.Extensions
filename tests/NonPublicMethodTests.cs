using System;
using System.Threading.Tasks;
using FluentAssertions;
using PowerUtils.xUnit.Extensions.Exceptions;
using PowerUtils.xUnit.Extensions.Tests.Fakes;
using Xunit;

namespace PowerUtils.xUnit.Extensions.Tests
{
    public class NonPublicMethodTests
    {
        [Fact]
        public void VoidPrivateMethodAndNullObject_InvokeNonPublicMethod_ArgumentNullException()
        {
            // Arrange
            FakeClassNonPublicMethods obj = null;
            var input = 32;


            // Act
            Action act = () => obj.InvokeNonPublicMethod("_method11", input);


            // Assert
            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("The 'obj' cannot be null (Parameter 'obj')");
        }

        [Fact]
        public void PrivateMethodAndNullObject_InvokeNonPublicMethod_ArgumentNullException()
        {
            // Arrange
            FakeClassNonPublicMethods obj = null;
            var input = 32;


            // Act
            Action act = () => obj.InvokeNonPublicMethod<int>("_method11", input);


            // Assert
            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("The 'obj' cannot be null (Parameter 'obj')");
        }

        [Fact]
        public void PrivateMethodWithReturnAndParameters_InvokeNonPublicMethod_ReturnsValue()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();
            var input = 32;


            // Act
            var act = obj.InvokeNonPublicMethod<int>("_method11", input);


            // Assert
            act.Should()
                .Be(input * 2);
        }

        [Fact]
        public void PrivateMethodWithReturnAndParameters_InvokeNonPublicMethod_ReturnsException()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();
            var input = 32;


            // Act
            Action act = () => obj.InvokeNonPublicMethod<int>("_method12", input);


            // Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Message exception 1_2");
        }

        [Fact]
        public void PrivateMethodWithReturn_InvokeNonPublicMethod_ReturnsValue()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();


            // Act
            var act = obj.InvokeNonPublicMethod<int>("_method21");


            // Assert
            act.Should()
                .Be(101);
        }

        [Fact]
        public void PrivateMethodWithReturn_InvokeNonPublicMethod_ReturnsException()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();


            // Act
            Action act = () => obj.InvokeNonPublicMethod<int>("_method22");


            // Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Message exception 2_2");
        }

        [Fact]
        public void PrivateMethodWithParameters_InvokeNonPublicMethod_WithoutReturn()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();
            var input = 32;


            // Act & Assert
            obj.InvokeNonPublicMethod("_method31", input);
        }

        [Fact]
        public void PrivateMethodWithParameters_InvokeNonPublicMethod_ReturnsException()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();
            var input = 32;


            // Act
            Action act = () => obj.InvokeNonPublicMethod("_method32", input);


            // Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Message exception 3_2");
        }

        [Fact]
        public void PrivateMethodWithoutParametersAndRetun_InvokeNonPublicMethod_OnlyCall()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();


            // Act & Assert
            obj.InvokeNonPublicMethod("_method41");
        }

        [Fact]
        public void PrivateMethodWithoutParametersAndRetun_InvokeNonPublicMethod_ArgumentException()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();


            // Act
            Action act = () => obj.InvokeNonPublicMethod("_method42");


            // Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Message exception 4_2");
        }

        [Fact]
        public void PrivateMethodUnexistingMethodWithoutParametersAndRetun_InvokeNonPublicMethod_MethodNotFoundException()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();


            // Act
            Action act = () => obj.InvokeNonPublicMethod("_method_unexisting_1");


            // Assert
            act.Should()
                .Throw<MethodNotFoundException>()
                .WithMessage("'_method_unexisting_1' not found");
        }

        [Fact]
        public void PrivateMethodUnexistingMethodWitRetun_InvokeNonPublicMethod_MethodNotFoundException()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();


            // Act
            Action act = () => obj.InvokeNonPublicMethod<string>("_method_unexisting_1");


            // Assert
            act.Should()
                .Throw<MethodNotFoundException>()
                .WithMessage("'_method_unexisting_1' not found");
        }

        [Fact]
        public void PrivateAsyncMethodWithReturnAndParameters_InvokeNonPublicMethodAsync_ReturnsValue()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();
            var input = 10;


            // Act
            var act = obj
                .InvokeNonPublicMethodAsync<int>("_method51Async", input)
                .Result;


            // Assert
            act.Should()
                .Be(input * 2);
        }

        [Fact]
        public async Task PrivateAsyncMethodWithReturnAndParameters_InvokeNonPublicMethodAsync_ArgumentException()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();
            var input = 32;


            // Act
            var act = await Record.ExceptionAsync(async () =>
                await obj.InvokeNonPublicMethodAsync<int>("_method52Async", input)
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentException>();

            act.Message.Should()
                .Be("Message exception 5_2");
        }

        [Fact]
        public void PrivateAsyncMethod_WithoutParametersAndRetun_OnlyCall()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();


            // Act & Assert
            obj.InvokeNonPublicMethodAsync("_method61Async").Wait();
        }

        [Fact]
        public async Task PrivateAsyncMethodWithoutParametersAndRetun_InvokeNonPublicMethodAsync_ArgumentException()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();


            // Act
            var act = await Record.ExceptionAsync(async () =>
                await obj.InvokeNonPublicMethodAsync("_method62Async")
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentException>();

            act.Message.Should()
                .Be("Message exception 6_2");
        }

        [Fact]
        public async Task PrivateAsyncMethod_InvokeNonPublicMethodAsync_CallMethodException()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();


            // Act
            var act = await Record.ExceptionAsync(async () =>
                await obj.InvokeNonPublicMethodAsync("_method41")
            );


            // Assert
            act.Should()
                .BeOfType<CallMethodException>();

            act.Message.Should()
                .Be("It was not possible to call the method '_method41'");
        }

        [Fact]
        public async Task PrivateAsyncMethod_InvokeNonPublicMethodAsync_ReturnsException2()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();


            // Act
            var act = await Record.ExceptionAsync(async () =>
                 await obj.InvokeNonPublicMethodAsync<bool>("_method41")
            );


            // Assert
            act.Should()
                .BeOfType<CallMethodException>();
            act.Message.Should()
                .Be("It was not possible to call the method '_method41'");
        }

        [Fact]
        public void ProtectedMethodWithReturn_InvokeNonPublicMethod_ReturnsValue()
        {
            // Arrange
            var obj = new FakeClassNonPublicMethods();


            // Act
            var act = obj.InvokeNonPublicMethod<int>("Method71");


            // Assert
            act.Should()
                .Be(102);
        }
    }
}
