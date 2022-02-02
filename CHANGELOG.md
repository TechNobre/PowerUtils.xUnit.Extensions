# Changelog




## [2.2.0] - 2022-02-02
[Full Changelog](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v2.1.0...v2.2.0)


### New Features

- Added new helper to invoke non public methods `ObjectInvoker.Invoke`;




## [2.1.0] - 2021-12-15
[Full Changelog](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v2.0.0...v2.1.0)


### New Features

- Added new helper to invoke non public methods `ObjectInvoker.Invoke`;


### Enhancements

- Improved the methods `InvokeNonPublicMethod` and `InvokeNonPublicMethodAsync` to return better exceptions;




## [2.0.0] - 2021-11-20
[Full Changelog](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v1.3.0...v2.0.0)


### Updates

- Added support to .NET 6


### Breaking Changes
- Discontinued the method `PrivatePropertyExtensions.SetPrivateProperty`. New method `SetNonPublicProperty`;
- Discontinued the method `PrivatePropertyExtensions.SetPrivateField`. New method `SetNonPublicField`;
- Discontinued the method `PrivatePropertyExtensions.InvokePrivateMethod`. New method `InvokeNonPublicMethod`;
- Discontinued the method `PrivatePropertyExtensions.InvokePrivateMethodAsync`. New method `InvokeNonPublicMethodAsync`;




## [1.3.0] - 2021-08-28
[Full Changelog](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v1.2.0...v1.3.0)


### New Features
- Added new exception `ConstructorNotFoundException`;
- Added new factory to create objects by non public constructor;




## [1.2.0] - 2021-08-06
[Full Changelog](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v1.1.0...v1.2.0)


### New Features
- Added new exceptions `PropertyNotFoundException` and `FieldNotFoundException`;
- Added new extensions to set private properties and fields;




## [1.1.0] - 2021-07-24
[Full Changelog](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v1.0.0...v1.1.0)


### New Features

- Added async private method invocations
  - `obj.InvokePrivateMethodAsync<TResult>();`
  - `obj.InvokePrivateMethodAsync();`




## [1.0.0] - 2021-07-23

- Start project