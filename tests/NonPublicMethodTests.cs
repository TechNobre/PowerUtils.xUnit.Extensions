using FluentAssertions;
using PowerUtils.xUnit.Extensions.Exceptions;
using PowerUtils.xUnit.Extensions.Tests.Fakes;
using System;
using Xunit;

namespace PowerUtils.xUnit.Extensions.Tests;

public class NonPublicMethodTests
{


    [Fact(DisplayName = "Call of a void method of the null type - Should return a 'ArgumentNullException'")]
    [Trait("Category", "Call private methods")]
    public void VoidPrivateMethod_NullType_Exception()
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

    [Fact(DisplayName = "Call of a method of the null type - Should return a 'ArgumentNullException'")]
    [Trait("Category", "Call private methods")]
    public void PrivateMethod_NullType_Exception()
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

    [Fact(DisplayName = "Call of a method with parameters and returns a value")]
    [Trait("Category", "Call private methods")]
    public void PrivateMethod_WithReturnAndParameters_ReturnsValue()
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

    [Fact(DisplayName = "Call of a method with parameters and return an exception")]
    [Trait("Category", "Call private methods")]
    public void PrivateMethod_WithReturnAndParameters_ReturnsException()
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

    [Fact(DisplayName = "Call of a method only with returns a value")]
    [Trait("Category", "Call private methods")]
    public void PrivateMethod_WithReturn_ReturnsValue()
    {
        // Arrange
        var obj = new FakeClassNonPublicMethods();


        // Act
        var act = obj.InvokeNonPublicMethod<int>("_method21");


        // Assert
        act.Should()
            .Be(101);
    }

    [Fact(DisplayName = "Call of a method only with returns an exception")]
    [Trait("Category", "Call private methods")]
    public void PrivateMethod_WithReturn_ReturnsException()
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

    [Fact(DisplayName = "Call of a method with parameters and without returns")]
    [Trait("Category", "Call private methods")]
    public void PrivateMethod_WithParameters_WithoutReturn()
    {
        // Arrange
        var obj = new FakeClassNonPublicMethods();
        var input = 32;


        // Act & Assert
        obj.InvokeNonPublicMethod("_method31", input);
    }

    [Fact(DisplayName = "Call of a method with parameters and return an exception")]
    [Trait("Category", "Call private methods")]
    public void PrivateMethod_WithParameters_ReturnsException()
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

    [Fact(DisplayName = "Call of a method without parameters and without returns")]
    [Trait("Category", "Call private methods")]
    public void PrivateMethod_WithoutParametersAndRetun_OnlyCall()
    {
        // Arrange
        var obj = new FakeClassNonPublicMethods();


        // Act & Assert
        obj.InvokeNonPublicMethod("_method41");
    }

    [Fact(DisplayName = "Call of a method without parameters and returns an exception")]
    [Trait("Category", "Call private methods")]
    public void PrivateMethod_WithoutParametersAndRetun_ReturnsException()
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

    [Fact(DisplayName = "Try calling an unexisting method without parameters and without returns - Should return MethodNotFoundException")]
    [Trait("Category", "Call private methods")]
    public void PrivateMethod_UnexistingMethodWithoutParametersAndRetun_ReturnsMethodNotFoundException()
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

    [Fact(DisplayName = "Try calling an unexisting method without returns - Should return MethodNotFoundException")]
    [Trait("Category", "Call private methods")]
    public void PrivateMethod_UnexistingMethodWitRetun_ReturnsMethodNotFoundException()
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



    [Fact(DisplayName = "Call of a async method with parameters and returns a value")]
    [Trait("Category", "Call private methods")]
    public void PrivateAsyncMethod_WithReturnAndParameters_ReturnsValue()
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

    [Fact(DisplayName = "Call of a async method with parameters and return an exception")]
    [Trait("Category", "Call private methods")]
    public void PrivateAsyncMethod_WithReturnAndParameters_ReturnsException()
    {
        // Arrange
        var obj = new FakeClassNonPublicMethods();
        var input = 32;


        // Act
        Exception act = null;
        try
        {
            _ = obj.InvokeNonPublicMethodAsync<int>("_method52Async", input).Result;
        }
        catch (AggregateException exception)
        {
            act = exception.InnerExceptions[0];
        }

        // Assert
        act.Should()
            .BeOfType<ArgumentException>();

        act.Message.Should()
            .Be("Message exception 5_2");
    }

    [Fact(DisplayName = "Call of a async method without parameters and without returns")]
    [Trait("Category", "Call private methods")]
    public void PrivateAsyncMethod_WithoutParametersAndRetun_OnlyCall()
    {
        // Arrange
        var obj = new FakeClassNonPublicMethods();


        // Act & Assert
        obj.InvokeNonPublicMethodAsync("_method61Async").Wait();
    }

    [Fact(DisplayName = "Call of a async method without parameters and returns an exception")]
    [Trait("Category", "Call private methods")]
    public void PrivateAsyncMethod_WithoutParametersAndRetun_ReturnsException()
    {
        // Arrange
        var obj = new FakeClassNonPublicMethods();


        // Act
        Exception act = null;
        try
        {
            obj.InvokeNonPublicMethodAsync("_method62Async").Wait();
        }
        catch (AggregateException exception)
        {
            act = exception.InnerExceptions[0];
        }


        // Assert
        act.Should()
            .BeOfType<ArgumentException>();

        act.Message.Should()
            .Be("Message exception 6_2");
    }


    [Fact(DisplayName = "Try calling a method is not async with utils 'InvokePrivateMethodAsync' - Should returns 'CallMethodException'")]
    [Trait("Category", "Call private methods")]
    public void PrivateAsyncMethod_CallWithAsyncInvoke_ReturnsException1()
    {
        // Arrange
        var obj = new FakeClassNonPublicMethods();


        // Act
        Exception act = null;
        try
        {
            obj.InvokeNonPublicMethodAsync("_method41").Wait();
        }
        catch (AggregateException exception)
        {
            act = exception.InnerExceptions[0];
        }


        // Assert
        act.Should()
            .BeOfType<CallMethodException>();

        act.Message.Should()
            .Be("It was not possible to call the method '_method41'");
    }

    [Fact(DisplayName = "Try calling a method is not async with utils 'InvokePrivateMethodAsync' - Should returns 'CallMethodException'")]
    [Trait("Category", "Call private methods")]
    public void PrivateAsyncMethod_CallWithAsyncInvoke_ReturnsException2()
    {
        // Arrange
        var obj = new FakeClassNonPublicMethods();


        // Act
        Exception act = null;
        try
        {
            var response = obj.InvokeNonPublicMethodAsync<bool>("_method41")
                .GetAwaiter().GetResult();
        }
        catch (AggregateException exception)
        {
            act = exception.InnerExceptions[0];
        }
        catch (CallMethodException exception)
        {
            act = exception;
        }


        // Assert
        act.Should()
            .BeOfType<CallMethodException>();

        act.Message.Should()
            .Be("It was not possible to call the method '_method41'");
    }

    [Fact(DisplayName = "Call of a method only with returns a value")]
    [Trait("Category", "Call protected methods")]
    public void ProtectedMethod_WithReturn_ReturnsValue()
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
