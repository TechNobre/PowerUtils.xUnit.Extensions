# PowerUtils.xUnit.Extensions


# :warning: DEPRECATED

This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.


![Logo](https://raw.githubusercontent.com/TechNobre/PowerUtils.xUnit.Extensions/main/assets/logo/logo_128x128.png)

***Utils, helpers and extensions to create tests with xUnit***

[![License: MIT](https://img.shields.io/github/license/TechNobre/PowerUtils.xUnit.Extensions.svg)](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/blob/main/LICENSE)


- [Support to](#support-to)
- [Dependencies](#dependencies)
- [How to use](#how-to-use)
  - [Install NuGet package](#install-nuget-package)
  - [Extensions](#extensions)
    - [object.InvokeNonPublicMethod();](#objectinvokenonpublicmethod)
    - [object.SetNonPublicProperty(); and object.SetNonPublicField()](#objectsetnonpublicproperty-and-objectsetnonpublicfield)
  - [Helpers](#helpers)
    - [Sort tests by priority](#sort-tests-by-priority)
    - [InvokeStaticNonPublicMethod](#invokestaticnonpublicmethod)
  - [Factories](#factories)
    - [ObjectFactory](#objectfactory)
- [Contribution](#contribution)



## Support to<a name="support-to"></a>
- .NET 9.0
- .NET 8.0
- .NET 7.0
- .NET 6.0
- .NET 5.0
- .NET 3.1
- .NET Standard 2.1
- .NET Framework 4.6.2 or more



## Dependencies<a name="dependencies"></a>

- xunit.extensibility.core [NuGet](https://www.nuget.org/packages/xunit.extensibility.core/)



## How to use<a name="how-to-use"></a>

### Install NuGet package<a name="Installation"></a>
This package is available through Nuget Packages: https://www.nuget.org/packages/PowerUtils.xUnit.Extensions

**Nuget**
```bash
Install-Package PowerUtils.xUnit.Extensions
```

**.NET CLI**
```
dotnet add package PowerUtils.xUnit.Extensions
```

### Extensions<a name="Extensions"></a>

#### object.InvokeNonPublicMethod();<a name="object.InvokeNonPublicMethod"></a>
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



#### object.SetNonPublicProperty(); and object.SetNonPublicField()<a name="object.SetNonPublicProperty"></a>
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


### Helpers<a name="Helpers"></a>

#### Sort tests by priority<a name="SortTestsByPriority"></a>

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

#### InvokeStaticNonPublicMethod<a name="InvokeStaticNonPublicMethod"></a>

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


### Factories<a name="Factories"></a>

#### ObjectFactory<a name="Factories-ObjectFactory"></a>
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



## Contribution<a name="contribution"></a>

If you have any questions, comments, or suggestions, please open an [issue](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/issues/new/choose) or create a [pull request](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare)
