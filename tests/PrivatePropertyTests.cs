﻿using System;
using PowerUtils.xUnit.Extensions.Exceptions;
using PowerUtils.xUnit.Extensions.Tests.Fakes;

namespace PowerUtils.xUnit.Extensions.Tests;

public class PrivatePropertyTests
{
    [Fact(DisplayName = "Try setting a private set property with null object - Should returns an exception")]
    [Trait("Category", "Set private properties")]
    [Obsolete]
    public void PrivateSetProperty_NullObject_ReturnsException()
    {
        // Arrange
        var value = "Fake";
        FakeClassNonPublicProperties obj = null;


        // Act
        Action act = () => obj.SetPrivateProperty(p => p.PropSetPrivate, value);


        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'source')");
    }

    [Fact(DisplayName = "Set a public property with private set")]
    [Trait("Category", "Set private properties")]

    public void PrivateProperty_PrivateSet()
    {
        // Arrange
        var value = "Fake";
        var obj = new FakeClassNonPublicProperties();


        // Act
#pragma warning disable CS0618 // Type or member is obsolete
        obj.SetPrivateProperty(p => p.PropSetPrivate, value);
#pragma warning restore CS0618 // Type or member is obsolete


        // Assert
        obj.PropSetPrivate.Should()
            .Be(value);
    }

    [Fact(DisplayName = "Set an existing private property")]
    [Trait("Category", "Set private properties")]
    [Obsolete]
    public void PrivateProperty_ExistingProperty_SetValue()
    {
        // Arrange
        var value = "Fake";
        var obj = new FakeClassNonPublicProperties();


        // Act
        obj.SetPrivateProperty("_propPrivate", value);
        var act = obj.GetValueOf_propPrivate();


        // Assert
        act.Should()
            .Be(value);
    }

    [Fact(DisplayName = "Set an unexisting private property - Should returns an exception")]
    [Trait("Category", "Set private properties")]
    public void PrivateProperty_UnexistingProperty_ReturnsException()
    {
        // Arrange
        var value = "Fake";
        var obj = new FakeClassNonPublicProperties();


        // Act
        Action act = () => obj.SetPrivateProperty("_private", value);


        // Assert
        act.Should()
            .Throw<PropertyNotFoundException>()
            .WithMessage("'_private' not found");
    }

    [Fact(DisplayName = "Try to set a property only with private set - Should returns an exception")]
    [Trait("Category", "Set private properties")]
    public void PrivateProperty_OnlyPrivateSet_ReturnsException()
    {
        // Arrange
        var value = "Fake";
        var obj = new FakeClassNonPublicProperties();


        // Act
#pragma warning disable CS0618 // Type or member is obsolete
        Action act = () => obj.SetPrivateProperty(nameof(FakeClassNonPublicProperties.PropSetPrivate), value);
#pragma warning restore CS0618 // Type or member is obsolete


        // Assert
        act.Should()
            .Throw<PropertyNotFoundException>()
            .WithMessage("'PropSetPrivate' not found");
    }

    [Fact(DisplayName = "Set a private property with null object - Should returns an exception")]
    [Trait("Category", "Set private properties")]
    [Obsolete]
    public void PrivateProperty_NullObject_ReturnsException()
    {
        // Arrange
        var value = "Fake";
        FakeClassNonPublicProperties obj = null;


        // Act
        Action act = () => obj.SetPrivateProperty(nameof(FakeClassNonPublicProperties.PropSetPrivate), value);


        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'source')");
    }

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

    [Fact(DisplayName = "Set a protected property with private set")]
    [Trait("Category", "Set protected properties")]
    [Obsolete]
    public void ProtectedProperty_PrivateSet()
    {
        // Arrange
        var value = "Fake";
        var obj = new FakeClassNonPublicProperties();


        // Act
        obj.SetPrivateProperty("PropProtected", value);


        // Assert
        obj.GetValueOfPropProtected().Should()
            .Be(value);
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