# PowerUtils.xUnit.Extensions
Utils, helpers and extensions to create tests with xUnti

![CI](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/actions/workflows/main.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/PowerUtils.xUnit.Extensions.svg)](https://www.nuget.org/packages/PowerUtils.xUnit.Extensions)
[![Nuget](https://img.shields.io/nuget/dt/PowerUtils.xUnit.Extensions.svg)](https://www.nuget.org/packages/PowerUtils.xUnit.Extensions)




## Support to
- .NET 2.0 or more
- .NET Framework 4.6.2 or more
- .NET Standard 2.0 or more




## Features

- [Installation](#Installation)
- [Extensions](#Extensions)
  - [InvokePrivateMethod](#object.InvokePrivateMethod)
  - [SetPrivateProperty and SetPrivateField](#object.SetPrivateProperty)
- [Helpers](#Helpers)
  - [Sort tests by priority](#SortTestsByPriority)
- [Factories](#Factories)
  - [ObjectFactory](#Factories-ObjectFactory)


## Documentation

### Dependencies

- xunit.extensibility.core [NuGet](https://www.nuget.org/packages/xunit.extensibility.core/)

### How to use

#### Install NuGet package <a name="Installation"></a>
This package is available through Nuget Packages: https://www.nuget.org/packages/PowerUtils.xUnit.Extensions

**Nuget**
```bash
Install-Package PowerUtils.xUnit.Extensions
```

**.NET CLI**
```
dotnet add package PowerUtils.xUnit.Extensions
```

### Extensions <a name="Extensions"></a>

#### object.InvokePrivateMethod(); <a name="object.InvokePrivateMethod"></a>
Extension to invoke private methods

```csharp
public class SampleClass
{
    private bool _methodName1(int value)
    {
        return false;
    }

    private bool _methodName2()
    {
        return true;
    }

    private void _methodName3(int value)
    {
    }

    private void _methodName4()
    {
    }

    private Task<bool> _methodName5Async()
    {
    }

    private Task _methodName6Async()
    {
    }
}
```

```csharp
var sampleClass = new SampleClass();

var result1 = sampleClass.InvokePrivateMethod<bool>("_methodName1", 1);
var result2 = sampleClass.InvokePrivateMethod<bool>("_methodName2");

sampleClass.InvokePrivateMethod("_methodName3", 532);
sampleClass.InvokePrivateMethod("_methodName4");

var result3 = await sampleClass.InvokePrivateMethodAsync<bool>("_methodName5Async", 1);
await sampleClass.InvokePrivateMethodAsync("_methodName6Async");
```



#### object.SetPrivateProperty(); and object.SetPrivateField() <a name="object.SetPrivateProperty"></a>
Extensions to set private properties and fields

```csharp
public class SampleClass
{
    public string PropSetPrivate { get; private set; }
    private string _propPrivate { get; set; }
    private string _privateField;
}
```

```csharp
var sampleClass = new SampleClass();

obj.SetPrivateProperty(p => p.PropSetPrivate, "Value");
obj.SetPrivateProperty("_propPrivate", "Value");
obj.SetPrivateField("_privateField", "Value");
```


### Helpers <a name="Helpers"></a>

#### Sort tests by priority <a name="SortTestsByPriority"></a>

```csharp
[TestCaseOrderer("PowerUtils.xUnit.Extensions.OrderTests.PriorityOrderer", "PowerUtils.xUnit.Extensions")]
public class Tests
{
    [Fact, TestPriority(2)]
    public void Test1()
    {
    }

    [Fact, TestPriority(1)]
    public void Test2()
    {
    }
}
```


### Factories <a name="Factories"></a>

#### ObjectFactory <a name="Factories-ObjectFactory"></a>
Factory to create an object by non public constructor

```csharp
public class TestObject
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    private TestObject()
    {
        this.Name = "Example name";
        this.Age = 21;
    }

    protected TestObject(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}

var obj1 = ObjectFactory.Create<TestObject>();
var obj2 = ObjectFactory.Create<TestObject>("My name", 50);
```



## Contribution

*Help me to help others*




## LICENSE

[MIT](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/blob/main/LICENSE)




## Release Notes


### v2.0.0 - 2021/11/19
#### Updates
- Added support to .NET 6

#### Breaking Changes
- Discontinued the method `PrivatePropertyExtensions.SetPrivateProperty`;
- Discontinued the method `PrivatePropertyExtensions.SetPrivateField`;
- Discontinued the method `PrivatePropertyExtensions.InvokePrivateMethod`;
- Discontinued the method `PrivatePropertyExtensions.InvokePrivateMethodAsync`;


### v1.3.0 - 2021/08/28

#### New Features
- Added new exception `ConstructorNotFoundException`;
- Added new factory to create objects by non public constructor;



### v1.2.0 - 2021/08/06

#### New Features
- Added new exceptions `PropertyNotFoundException` and `FieldNotFoundException`;
- Added new extensions to set private properties and fields;



### v1.1.0 - 2021/07/24

#### New Features
- Added async private method invocations
  - `obj.InvokePrivateMethodAsync<TResult>();`
  - `obj.InvokePrivateMethodAsync();`



### v1.0.0 - 2021/07/23

- Kick start project