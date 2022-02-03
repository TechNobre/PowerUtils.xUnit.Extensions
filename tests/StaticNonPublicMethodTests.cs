using System;
using PowerUtils.xUnit.Extensions.Exceptions;
using PowerUtils.xUnit.Extensions.Tests.Fakes;

namespace PowerUtils.xUnit.Extensions.Tests;

public class StaticNonPublicMethodTests
{
    [Fact(DisplayName = "Call of a static method of the null type - Should return a 'ArgumentNullException'")]
    [Trait("Category", "Call private static methods")]
    public void PrivateMethod_NullType_Exception()
    {
        // Arrange
        var input = 32;


        // Act
        Action act = () => ObjectInvoker.
            Invoke<int>(null, "_method11", input);


        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("The 'obj' cannot be null (Parameter 'obj')");
    }

    [Fact(DisplayName = "Call of a static method with parameters and returns a value")]
    [Trait("Category", "Call private static methods")]
    public void PrivateMethod_WithReturnAndParameters_ReturnsValue()
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

    [Fact(DisplayName = "Call of a static method with parameters and return an exception")]
    [Trait("Category", "Call private static methods")]
    public void PrivateMethod_WithReturnAndParameters_Exception()
    {
        // Arrange
        var input = 32;


        // Act
        Action act = () => ObjectInvoker.Invoke<int>(typeof(FakeStaticClass), "_method12", input);


        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Message exception 12");
    }

    [Fact(DisplayName = "Call of a static method only with returns a value")]
    [Trait("Category", "Call static private methods")]
    public void PrivateMethod_WithReturn_ReturnsValue()
    {
        // Arrange & Act
        var act = ObjectInvoker.Invoke<int>(typeof(FakeStaticClass), "_method21");


        // Assert
        act.Should()
            .Be(101);
    }

    [Fact(DisplayName = "Call of a static method only with returns an exception")]
    [Trait("Category", "Call static private methods")]
    public void PrivateMethod_WithReturn_Exception()
    {
        // Arrange && Act
        Action act = () => ObjectInvoker.Invoke<int>(typeof(FakeStaticClass), "_method22");


        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Message exception 22");
    }

    [Fact(DisplayName = "Call of a static void method of the null type - Should return a 'ArgumentNullException'")]
    [Trait("Category", "Call private static methods")]
    public void VoidPrivateMethod_NullType_Exception()
    {
        // Arrange
        var input = 32;


        // Act
        Action act = () => ObjectInvoker.
            Invoke(null, "_method11", input);


        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("The 'obj' cannot be null (Parameter 'obj')");
    }

    [Fact(DisplayName = "Call of a static method with parameters and without returns")]
    [Trait("Category", "Call static private methods")]
    public void PrivateMethod_WithParameters_WithoutReturn()
    {
        // Arrange
        var input = 32;


        // Act & Assert
        ObjectInvoker.Invoke(typeof(FakeStaticClass), "_method31", input);
    }

    [Fact(DisplayName = "Call of a method with parameters and return an exception")]
    [Trait("Category", "Call private methods")]
    public void PrivateMethod_WithParameters_ReturnsException()
    {
        // Arrange
        var input = 32;


        // Act
        Action act = () => ObjectInvoker.
            Invoke(typeof(FakeStaticClass), "_method32", input);


        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Message exception 32");
    }

    [Fact(DisplayName = "Call of a static method without parameters and without returns")]
    [Trait("Category", "Call private static methods")]
    public void PrivateMethod_WithoutParametersAndRetun_OnlyCall()
        // Arrange & Act & Assert
        => ObjectInvoker.Invoke(typeof(FakeStaticClass), "_method41");

    [Fact(DisplayName = "Call of a static method without parameters and returns an exception")]
    [Trait("Category", "Call private static methods")]
    public void PrivateMethod_WithoutParametersAndRetun_ReturnsException()
    {
        // Arrange & Act
        Action act = () => ObjectInvoker.
            Invoke(typeof(FakeStaticClass), "_method42");


        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Message exception 42");
    }

    [Fact(DisplayName = "Try calling an unexisting static method without parameters and without returns - Should return MethodNotFoundException")]
    [Trait("Category", "Call private static methods")]
    public void PrivateMethod_UnexistingMethodWithoutParametersAndRetun_ReturnsMethodNotFoundException()
    {
        // Arrange & Act
        Action act = () => ObjectInvoker.
            Invoke(typeof(FakeStaticClass), "_method_unexisting_1");


        // Assert
        act.Should()
            .Throw<MethodNotFoundException>()
            .WithMessage("'_method_unexisting_1' not found");
    }

    [Fact(DisplayName = "Try calling an unexisting static method without returns - Should return MethodNotFoundException")]
    [Trait("Category", "Call private static methods")]
    public void PrivateMethod_UnexistingMethodWitRetun_ReturnsMethodNotFoundException()
    {
        // Arrange & Act
        Action act = () => ObjectInvoker
            .Invoke<string>(typeof(FakeStaticClass), "_method_unexisting_1");


        // Assert
        act.Should()
            .Throw<MethodNotFoundException>()
            .WithMessage("'_method_unexisting_1' not found");
    }

    [Fact(DisplayName = "Call of a async static method with parameters and returns a value")]
    [Trait("Category", "Call private static methods")]
    public void PrivateAsyncMethod_WithReturnAndParameters_ReturnsValue()
    {
        // Arrange
        var input = 10;


        // Act
        var act = ObjectInvoker
            .InvokeAsync<int>(typeof(FakeStaticClass), "_method51Async", input)
            .Result;


        // Assert
        act.Should()
            .Be(input * 2);
    }

    [Fact(DisplayName = "Call of a async static method with parameters and return an exception")]
    [Trait("Category", "Call private static methods")]
    public void PrivateAsyncMethod_WithReturnAndParameters_ReturnsException()
    {
        // Arrange
        var input = 32;


        // Act
        Exception act = null;
        try
        {
            _ = ObjectInvoker
                .InvokeAsync<int>(typeof(FakeStaticClass), "_method52Async", input).Result;
        }
        catch(AggregateException exception)
        {
            act = exception.InnerExceptions[0];
        }

        // Assert
        act.Should()
            .BeOfType<ArgumentException>();

        act.Message.Should()
            .Be("Message exception 52");
    }

    [Fact(DisplayName = "Call of a async static method without parameters and without returns")]
    [Trait("Category", "Call private static methods")]
    public void PrivateAsyncMethod_WithoutParametersAndRetun_OnlyCall()
        // Arrange & Act & Assert
        => ObjectInvoker
            .InvokeAsync(typeof(FakeStaticClass), "_method61Async").Wait();

    [Fact(DisplayName = "Call of a async static method without parameters and returns an exception")]
    [Trait("Category", "Call private static methods")]
    public void PrivateAsyncMethod_WithoutParametersAndRetun_ReturnsException()
    {
        // Arrange & Act
        Exception act = null;
        try
        {
            ObjectInvoker
                .InvokeAsync(typeof(FakeStaticClass), "_method62Async").Wait();
        }
        catch(AggregateException exception)
        {
            act = exception.InnerExceptions[0];
        }


        // Assert
        act.Should()
            .BeOfType<ArgumentException>();

        act.Message.Should()
            .Be("Message exception 62");
    }

    [Fact(DisplayName = "Try calling a static method is not async with utils 'InvokePrivateMethodAsync' - Should returns 'CallMethodException'")]
    [Trait("Category", "Call private static methods")]
    public void PrivateAsyncMethod_CallWithAsyncInvoke_ReturnsException1()
    {
        // Arrange & Act
        Exception act = null;
        try
        {
            ObjectInvoker
                .InvokeAsync(typeof(FakeStaticClass), "_method41")
                .Wait();
        }
        catch(AggregateException exception)
        {
            act = exception.InnerExceptions[0];
        }


        // Assert
        act.Should()
            .BeOfType<CallMethodException>();

        act.Message.Should()
            .Be("It was not possible to call the method '_method41'");
    }

    [Fact(DisplayName = "Try calling a static method is not async with utils 'InvokePrivateMethodAsync' - Should returns 'CallMethodException'")]
    [Trait("Category", "Call private static methods")]
    public void PrivateAsyncMethod_CallWithAsyncInvoke_ReturnsException2()
    {
        // Arrange & Act
        Exception act = null;
        try
        {
            var response = ObjectInvoker
                .InvokeAsync<bool>(typeof(FakeStaticClass), "_method41")
                .GetAwaiter().GetResult();
        }
        catch(AggregateException exception)
        {
            act = exception.InnerExceptions[0];
        }
        catch(CallMethodException exception)
        {
            act = exception;
        }


        // Assert
        act.Should()
            .BeOfType<CallMethodException>();

        act.Message.Should()
            .Be("It was not possible to call the method '_method41'");
    }
}
