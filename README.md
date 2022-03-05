# PowerUtils.xUnit.Extensions
Utils, helpers and extensions to create tests with xUnti

![Tests](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/actions/workflows/test-project.yml/badge.svg)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.xUnit.Extensions&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.xUnit.Extensions)

[![NuGet](https://img.shields.io/nuget/v/PowerUtils.xUnit.Extensions.svg)](https://www.nuget.org/packages/PowerUtils.xUnit.Extensions)
[![Nuget](https://img.shields.io/nuget/dt/PowerUtils.xUnit.Extensions.svg)](https://www.nuget.org/packages/PowerUtils.xUnit.Extensions)
[![License: MIT](https://img.shields.io/github/license/TechNobre/PowerUtils.xUnit.Extensions.svg)](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/blob/main/LICENSE)




## Support to
- .NET 2.0 or more
- .NET Framework 4.6.2 or more
- .NET Standard 2.1 or more




## Features

- [Installation](#Installation)
- [Extensions](#Extensions)
  - [InvokeNonPublicMethod](#object.InvokeNonPublicMethod)
  - [SetNonPublicProperty and SetNonPublicField](#object.SetNonPublicProperty)
- [Helpers](#Helpers)
  - [Sort tests by priority](#SortTestsByPriority)
  - [InvokeStaticNonPublicMethod](#InvokeStaticNonPublicMethod)
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

#### object.InvokeNonPublicMethod(); <a name="object.InvokeNonPublicMethod"></a>
Extension to invoke non-public methods

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

var result1 = sampleClass.InvokeNonPublicMethod<bool>("_methodName1", 1);
var result2 = sampleClass.InvokeNonPublicMethod<bool>("_methodName2");

sampleClass.InvokeNonPublicMethod("_methodName3", 532);
sampleClass.InvokeNonPublicMethod("_methodName4");

var result3 = await sampleClass.InvokeNonPublicMethodAsync<bool>("_methodName5Async", 1);
await sampleClass.InvokeNonPublicMethodAsync("_methodName6Async");
```



#### object.SetNonPublicProperty(); and object.SetNonPublicField() <a name="object.SetNonPublicProperty"></a>
Extensions to set non-public properties and fields

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

sampleClass.SetNonPublicProperty(p => p.PropSetPrivate, "Value");
sampleClass.SetNonPublicProperty("_propPrivate", "Value");
sampleClass.SetNonPublicField("_privateField", "Value");
```


### Helpers <a name="Helpers"></a>

#### Sort tests by priority <a name="SortTestsByPriority"></a>

```csharp
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
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

#### InvokeStaticNonPublicMethod <a name="InvokeStaticNonPublicMethod"></a>

```csharp
public static class SampleClass
{
    private static bool _methodName1(int value)
    {
        return false;
    }

    private static bool _methodName2()
    {
        return true;
    }

    private static void _methodName3(int value)
    {
    }

    private static void _methodName4()
    {
    }

    private static Task<bool> _methodName5Async()
    {
    }

    private static Task _methodName6Async()
    {
    }
}
```

```csharp
var result1 = ObjectInvoker.Invoke<bool>(typeof(SampleClass), "_methodName1", 1);
var result2 = ObjectInvoker.Invoke<bool>(typeof(SampleClass), "_methodName2");

ObjectInvoker.Invoke(typeof(SampleClass), "_methodName3", 532);
ObjectInvoker.Invoke(typeof(SampleClass), "_methodName4");

var result3 = await ObjectInvoker.InvokeAsync<bool>(typeof(SampleClass), "_methodName5Async", 1);
await ObjectInvoker.InvokeAsync(typeof(SampleClass), "_methodName6Async");
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



## :warning: Warning
The methods `SetPrivateProperty`, `SetPrivateField`, `InvokePrivateMethod`, `InvokePrivateMethodAsync` will be removed in 2021/05/31.




## Contribution

*Help me to help others*




## LICENSE

[MIT](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/blob/main/LICENSE)



## Changelog

[Here](./CHANGELOG.md)
