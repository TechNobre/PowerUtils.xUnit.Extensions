using System;
using PowerUtils.xUnit.Extensions.Exceptions;
using PowerUtils.xUnit.Extensions.Tests.Fakes;

namespace PowerUtils.xUnit.Extensions.Tests;

public class PrivatePropertyTests
{
    [Fact(DisplayName = "Try setting a private field with null object - Should returns an exception")]
    [Trait("Category", "Set private properties")]
    [Obsolete]
    public void PrivateField_NullObject_ReturnsException()
    {
        // Arrange
        var value = "Fake";
        FakeClassNonPublicProperties obj = null;


        // Act
        Action act = () => obj.SetPrivateField("_privateField", value);


        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'source')");
    }

    [Fact(DisplayName = "Try setting an unexisting field - Should returns an exception")]
    [Trait("Category", "Set private properties")]
    [Obsolete]
    public void PrivateField_UnexistingField_ReturnsException()
    {
        // Arrange
        var value = "Fake";
        var obj = new FakeClassNonPublicProperties();


        // Act
        Action act = () => obj.SetPrivateField("_private", value);


        // Assert
        act.Should()
            .Throw<FieldNotFoundException>()
            .WithMessage("'_private' not found");
    }

    [Fact(DisplayName = "Set an existing private field")]
    [Trait("Category", "Set private properties")]
    [Obsolete]
    public void PrivateField_ExistingValue_SetValue()
    {
        // Arrange
        var value = "Fake";
        var obj = new FakeClassNonPublicProperties();


        // Act
        obj.SetPrivateField("_privateField", value);
        var act = obj.GetValueOf_privateField();


        // Assert
        act.Should()
            .Be(value);
    }

    [Fact(DisplayName = "Try setting an field with method SetField - Should returns an exception")]
    [Trait("Category", "Set private properties")]
    [Obsolete]
    public void PrivateProperty_SetPrivateField_ReturnsException()
    {
        // Arrange
        var value = "Fake";
        var obj = new FakeClassNonPublicProperties();


        // Act
        Action act = () => obj.SetPrivateField("_propPrivate", value);


        // Assert
        act.Should()
            .Throw<FieldNotFoundException>()
            .WithMessage("'_propPrivate' not found");
    }

    [Fact(DisplayName = "Set a protected field")]
    [Trait("Category", "Set protected properties")]
    [Obsolete]
    public void ProtectedField_SetValue()
    {
        // Arrange
        var value = "Fake";
        var obj = new FakeClassNonPublicProperties();


        // Act
        obj.SetPrivateField("ProtectedField", value);


        // Assert
        obj.GetValueOfProtectedField().Should()
            .Be(value);
    }
}
