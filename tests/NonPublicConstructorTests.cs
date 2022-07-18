using System;
using PowerUtils.xUnit.Extensions.Exceptions;
using PowerUtils.xUnit.Extensions.Tests.Fakes;

namespace PowerUtils.xUnit.Extensions.Tests;

public class NonPublicConstructorTests
{
    [Fact]
    public void PrivateConstructorWithoutParameters_Create_Instance()
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

    [Fact]
    public void NonPublicConstructorWithParametersNotMatch_Create_ConstructorNotFoundException()
    {
        // Arrange & Act
        Action act = () => ObjectFactory.Create<FakeClassWithNonPubliceConstructor>(1, 2, 3);


        // Assert
        act.Should()
            .Throw<ConstructorNotFoundException>()
            .WithMessage("Constructor not found");
    }

    [Fact]
    public void ProtectedConstructorWithProperties_Create_Instance()
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

    [Fact]
    public void ProtectedConstructorWithPropertiesDifferentOrder_Create_Instance()
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

    [Fact]
    public void UnexistentNonPublicConstructor_Create_ConstructorNotFoundException()
    {
        // Arrange & Act
        Action act = () => ObjectFactory.Create<FakeClassWithoutNonPubliceConstructor>();


        // Assert
        act.Should()
            .Throw<ConstructorNotFoundException>()
            .WithMessage("Constructor not found");
    }
}
