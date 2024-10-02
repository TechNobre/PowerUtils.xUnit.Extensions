using System;
using FluentAssertions;
using PowerUtils.xUnit.Extensions.Exceptions;
using PowerUtils.xUnit.Extensions.Tests.Fakes;
using Xunit;

namespace PowerUtils.xUnit.Extensions.Tests
{
    public class NonPublicPropertyTests
    {
        [Fact]
        public void PrivateSetPropertyAndNullObject_SetNonPublicProperty_ArgumentNullException()
        {
            // Arrange
            var value = "Fake";
            FakeClassNonPublicProperties obj = null;


            // Act
            var act = Record.Exception(() =>
                obj.SetNonPublicProperty(p => p.PropSetPrivate, value)
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentNullException>();
            act.Message.Should()
                .Be("Value cannot be null. (Parameter 'source')");
        }

        [Fact]
        public void PrivatePropertyWithPrivateSet_SetNonPublicProperty_SetProperty()
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

        [Fact]
        public void PrivatePropertyExistentProperty_SetNonPublicProperty_SetValue()
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

        [Fact]
        public void PrivatePropertyUnexistentProperty_SetNonPublicProperty_PropertyNotFoundException()
        {
            // Arrange
            var value = "Fake";
            var obj = new FakeClassNonPublicProperties();


            // Act
            var act = Record.Exception(() =>
                obj.SetNonPublicProperty("_private", value)
            );


            // Assert
            act.Should()
                .BeOfType<PropertyNotFoundException>();
            act.Message.Should()
                .Be("'_private' not found");
        }

        [Fact]
        public void PrivatePropertyOnlyPrivateSet_SetNonPublicProperty_PropertyNotFoundException()
        {
            // Arrange
            var value = "Fake";
            var obj = new FakeClassNonPublicProperties();


            // Act
            var act = Record.Exception(() =>
                obj.SetNonPublicProperty(nameof(FakeClassNonPublicProperties.PropSetPrivate), value)
            );


            // Assert
            act.Should()
                .BeOfType<PropertyNotFoundException>();
            act.Message.Should()
                .Be("'PropSetPrivate' not found");
        }

        [Fact]
        public void PrivatePropertyAndNullObject_SetNonPublicProperty_ArgumentNullException()
        {
            // Arrange
            var value = "Fake";
            FakeClassNonPublicProperties obj = null;


            // Act
            var act = Record.Exception(() =>
                obj.SetNonPublicProperty(nameof(FakeClassNonPublicProperties.PropSetPrivate), value)
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentNullException>();
            act.Message.Should()
                .Be("Value cannot be null. (Parameter 'source')");
        }

        [Fact]
        public void PrivateFieldAndNullObject_SetNonPublicField_ArgumentNullException()
        {
            // Arrange
            var value = "Fake";
            FakeClassNonPublicProperties obj = null;


            // Act
            var act = Record.Exception(() =>
                obj.SetNonPublicField("_privateField", value)
            );


            // Assert
            act.Should()
                .BeOfType<ArgumentNullException>();
            act.Message.Should()
                .Be("Value cannot be null. (Parameter 'source')");
        }

        [Fact]
        public void PrivateFieldUnexistentField_SetNonPublicField_FieldNotFoundException()
        {
            // Arrange
            var value = "Fake";
            var obj = new FakeClassNonPublicProperties();


            // Act
            var act = Record.Exception(() =>
                obj.SetNonPublicField("_private", value)
            );


            // Assert
            act.Should()
                .BeOfType<FieldNotFoundException>();
            act.Message.Should()
                .Be("'_private' not found");
        }

        [Fact]
        public void PrivateFieldExistebtValue_SetNonPublicField_SetValue()
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

        [Fact]
        public void PrivatePropertyAndSetPrivateField_SetNonPublicField_FieldNotFoundException()
        {
            // Arrange
            var value = "Fake";
            var obj = new FakeClassNonPublicProperties();


            // Act
            var act = Record.Exception(() =>
                obj.SetNonPublicField("_propPrivate", value)
            );


            // Assert
            act.Should()
                .BeOfType<FieldNotFoundException>();
            act.Message.Should()
                .Be("'_propPrivate' not found");
        }

        [Fact]
        public void ProtectedProperty_SetNonPublicProperty_SetProperty()
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

        [Fact]
        public void ProtectedField_SetNonPublicField_SetValue()
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
