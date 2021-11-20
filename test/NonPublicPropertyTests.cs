﻿using FluentAssertions;
using PowerUtils.xUnit.Extensions.Exceptions;
using PowerUtils.xUnit.Extensions.Tests.Fakes;
using System;
using Xunit;
namespace PowerUtils.xUnit.Extensions.Tests
{
    public class NonPublicPropertyTests
    {
        [Fact(DisplayName = "Try setting a private set property with null object - Should returns an exception")]
        [Trait("Category", "Set private properties")]
        public void PrivateSetProperty_NullObject_ReturnsException()
        {
            // Arrange
            var value = "Fake";
            FakeClassNonPublicProperties obj = null;


            // Act
            Action act = () => obj.SetNonPublicProperty(p => p.PropSetPrivate, value);


            // Assert
            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'source')");
        }

        [Fact(DisplayName = "Set a public property with private set")]
        [Trait("Category", "Set private properties")]
        public void PrivateProperty_PrivateSet_Success()
        {
            // Arrange
            var value = "Fake";
            var obj = new FakeClassNonPublicProperties();


            // Act
            obj.SetNonPublicProperty(p => p.PropSetPrivate, value);


            // Assert
            obj.PropSetPrivate.Should()
                .Be(value);
        }

        [Fact(DisplayName = "Set an existing private property")]
        [Trait("Category", "Set private properties")]
        public void PrivateProperty_ExistingProperty_SetValue()
        {
            // Arrange
            var value = "Fake";
            var obj = new FakeClassNonPublicProperties();


            // Act
            obj.SetNonPublicProperty("_propPrivate", value);
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
            Action act = () => obj.SetNonPublicProperty("_private", value);


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
            Action act = () => obj.SetNonPublicProperty(nameof(FakeClassNonPublicProperties.PropSetPrivate), value);


            // Assert
            act.Should()
                .Throw<PropertyNotFoundException>()
                .WithMessage("'PropSetPrivate' not found");
        }

        [Fact(DisplayName = "Set a private property with null object - Should returns an exception")]
        [Trait("Category", "Set private properties")]
        public void PrivateProperty_NullObject_ReturnsException()
        {
            // Arrange
            var value = "Fake";
            FakeClassNonPublicProperties obj = null;


            // Act
            Action act = () => obj.SetNonPublicProperty(nameof(FakeClassNonPublicProperties.PropSetPrivate), value);


            // Assert
            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'source')");
        }

        [Fact(DisplayName = "Try setting a private field with null object - Should returns an exception")]
        [Trait("Category", "Set private properties")]
        public void PrivateField_NullObject_ReturnsException()
        {
            // Arrange
            var value = "Fake";
            FakeClassNonPublicProperties obj = null;


            // Act
            Action act = () => obj.SetNonPublicField("_privateField", value);


            // Assert
            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'source')");
        }

        [Fact(DisplayName = "Try setting an unexisting field - Should returns an exception")]
        [Trait("Category", "Set private properties")]
        public void PrivateField_UnexistingField_ReturnsException()
        {
            // Arrange
            var value = "Fake";
            var obj = new FakeClassNonPublicProperties();


            // Act
            Action act = () => obj.SetNonPublicField("_private", value);


            // Assert
            act.Should()
                .Throw<FieldNotFoundException>()
                .WithMessage("'_private' not found");
        }

        [Fact(DisplayName = "Set an existing private field")]
        [Trait("Category", "Set private properties")]
        public void PrivateField_ExistingValue_SetValue()
        {
            // Arrange
            var value = "Fake";
            var obj = new FakeClassNonPublicProperties();


            // Act
            obj.SetNonPublicField("_privateField", value);
            var act = obj.GetValueOf_privateField();


            // Assert
            act.Should()
                .Be(value);
        }

        [Fact(DisplayName = "Try setting an field with method SetField - Should returns an exception")]
        [Trait("Category", "Set private properties")]
        public void PrivateProperty_SetPrivateField_ReturnsException()
        {
            // Arrange
            var value = "Fake";
            var obj = new FakeClassNonPublicProperties();


            // Act
            Action act = () => obj.SetNonPublicField("_propPrivate", value);


            // Assert
            act.Should()
                .Throw<FieldNotFoundException>()
                .WithMessage("'_propPrivate' not found");
        }

        [Fact(DisplayName = "Set a protected property with private set")]
        [Trait("Category", "Set protected properties")]
        public void ProtectedProperty_PrivateSet()
        {
            // Arrange
            var value = "Fake";
            var obj = new FakeClassNonPublicProperties();


            // Act
            obj.SetNonPublicProperty("PropProtected", value);


            // Assert
            obj.GetValueOfPropProtected().Should()
                .Be(value);
        }

        [Fact(DisplayName = "Set a protected field")]
        [Trait("Category", "Set protected properties")]
        public void ProtectedField_SetValue()
        {
            // Arrange
            var value = "Fake";
            var obj = new FakeClassNonPublicProperties();


            // Act
            obj.SetNonPublicField("ProtectedField", value);


            // Assert
            obj.GetValueOfProtectedField().Should()
                .Be(value);
        }
    }
}