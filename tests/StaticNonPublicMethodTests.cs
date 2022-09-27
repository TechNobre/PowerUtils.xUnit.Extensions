using System;
using System.Threading.Tasks;
using FluentAssertions;
using PowerUtils.xUnit.Extensions.Exceptions;
using PowerUtils.xUnit.Extensions.Tests.Fakes;
using Xunit;

namespace PowerUtils.xUnit.Extensions.Tests
{
    public class StaticNonPublicMethodTests
    {
        [Fact]
        public void PrivateMethodAndNullType_Invoke_ArgumentNullException()
        {
            // Arrange
            var input = 32;


            // Act
            var act = Record.Exception(() =>
                ObjectInvoker.Invoke<int>(null, "_method11", input)
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentNullException>();
            act.Message.Should()
                .Be("The 'obj' cannot be null (Parameter 'obj')");
        }

        [Fact]
        public void PrivateMethodWithReturnAndParameters_Invoke_ReturnsValue()
        {
            // Arrange
            var input = 32;


            // Act
            var act = ObjectInvoker.
                Invoke<int>(typeof(FakeStaticClass), "_method11", input);


            // Assert
            act.Should()
                .Be(input * 2);
        }

        [Fact]
        public void PrivateMethodWithReturnAndParameters_Invoke_ArgumentException()
        {
            // Arrange
            var input = 32;


            // Act
            var act = Record.Exception(() =>
                ObjectInvoker.Invoke<int>(typeof(FakeStaticClass), "_method12", input)
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentException>();
            act.Message.Should()
                .Be("Message exception 12");
        }

        [Fact]
        public void PrivateMethodWithReturn_Invoke_ReturnsValue()
        {
            // Arrange & Act
            var act = ObjectInvoker.Invoke<int>(typeof(FakeStaticClass), "_method21");


            // Assert
            act.Should()
                .Be(101);
        }

        [Fact]
        public void PrivateMethodWithReturn_Invoke_ArgumentException()
        {
            // Arrange && Act
            var act = Record.Exception(() =>
                ObjectInvoker.Invoke<int>(typeof(FakeStaticClass), "_method22")
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentException>();
            act.Message.Should()
                .Be("Message exception 22");
        }

        [Fact]
        public void VoidPrivateMethodAndNullObject_Invoke_ArgumentNullException()
        {
            // Arrange
            var input = 32;


            // Act
            var act = Record.Exception(() =>
                ObjectInvoker.Invoke(null, "_method11", input)
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentNullException>();
            act.Message.Should()
                .Be("The 'obj' cannot be null (Parameter 'obj')");
        }

        [Fact]
        public void PrivateMethodWithParameters_Invoke_WithoutReturn()
        {
            // Arrange
            var input = 32;


            // Act & Assert
            ObjectInvoker.Invoke(typeof(FakeStaticClass), "_method31", input);
        }

        [Fact]
        public void PrivateMethodWithParameters_Invoke_ArgumentException()
        {
            // Arrange
            var input = 32;


            // Act
            var act = Record.Exception(() =>
                ObjectInvoker.Invoke(typeof(FakeStaticClass), "_method32", input)
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentException>();
            act.Message.Should()
                .Be("Message exception 32");
        }

        [Fact]
        public void PrivateMethodWithoutParametersAndRetun_Invoke_OnlyCall()
            // Arrange & Act & Assert
            => ObjectInvoker.Invoke(typeof(FakeStaticClass), "_method41");

        [Fact]
        public void PrivateMethodWithoutParametersAndRetun_Invoke_ArgumentException()
        {
            // Arrange & Act
            var act = Record.Exception(() =>
                ObjectInvoker.Invoke(typeof(FakeStaticClass), "_method42")
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentException>();
            act.Message.Should()
                .Be("Message exception 42");
        }

        [Fact]
        public void PrivateMethodAndUnexistentMethodWithoutParametersAndRetun_Invoke_MethodNotFoundException()
        {
            // Arrange & Act
            var act = Record.Exception(() =>
                ObjectInvoker.Invoke(typeof(FakeStaticClass), "_method_unexisting_1")
            );


            // Assert
            act.Should()
                .BeOfType<MethodNotFoundException>();
            act.Message.Should()
                .Be("'_method_unexisting_1' not found");
        }

        [Fact]
        public void PrivateMethodAndUnexistentMethodWitRetun_Invoke_MethodNotFoundException()
        {
            // Arrange & Act
            var act = Record.Exception(() =>
                ObjectInvoker.Invoke<string>(typeof(FakeStaticClass), "_method_unexisting_1")
            );


            // Assert
            act.Should()
                .BeOfType<MethodNotFoundException>();
            act.Message.Should()
                .Be("'_method_unexisting_1' not found");
        }

        [Fact]
        public async Task PrivateAsyncMethodWithReturnAndParameters_InvokeAsync_ReturnsValue()
        {
            // Arrange
            var input = 10;


            // Act
            var act = await ObjectInvoker.InvokeAsync<int>(typeof(FakeStaticClass), "_method51Async", input);


            // Assert
            act.Should()
                .Be(input * 2);
        }

        [Fact]
        public async Task PrivateAsyncMethodWithReturnAndParameters_InvokeAsync_ArgumentException()
        {
            // Arrange
            var input = 32;


            // Act
            var act = await Record.ExceptionAsync(async () =>
                await ObjectInvoker.InvokeAsync<int>(typeof(FakeStaticClass), "_method52Async", input)
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentException>();
            act.Message.Should()
                .Be("Message exception 52");
        }

        [Fact]
        public void PrivateAsyncMethodWithoutParametersAndRetun_InvokeAsync_OnlyCall()
            // Arrange & Act & Assert
            => ObjectInvoker
                .InvokeAsync(typeof(FakeStaticClass), "_method61Async").Wait();

        [Fact]
        public async Task PrivateAsyncMethodWithoutParametersAndRetun_InvokeAsync_ArgumentException()
        {
            // Arrange & Act
            var act = await Record.ExceptionAsync(async () =>
                await ObjectInvoker.InvokeAsync(typeof(FakeStaticClass), "_method62Async")
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentException>();
            act.Message.Should()
                .Be("Message exception 62");
        }

        [Fact]
        public async Task PrivateAsyncMethodWithoutReturn_InvokeAsync_CallMethodException()
        {
            // Arrange & Act
            var act = await Record.ExceptionAsync(async () =>
                await ObjectInvoker.InvokeAsync(typeof(FakeStaticClass), "_method41")
            );


            // Assert
            act.Should()
                .BeOfType<CallMethodException>();
            act.Message.Should()
                .Be("It was not possible to call the method '_method41'");
        }

        [Fact]
        public async Task PrivateAsyncMethodWithReturn_InvokeAsync_CallMethodException()
        {
            // Arrange & Act
            var act = await Record.ExceptionAsync(async () =>
                await ObjectInvoker.InvokeAsync<bool>(typeof(FakeStaticClass), "_method41")
            );


            // Assert
            act.Should()
                .BeOfType<CallMethodException>();
            act.Message.Should()
                .Be("It was not possible to call the method '_method41'");
        }
    }
}
