# [3.0.0](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v2.2.0...v3.0.0) (2022-07-18)


### Bug Fixes

* Fixed pipelines and global.json to version 6.0.200 ([2f59368](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/commit/2f5936872982b1ed30d075608f8e9286a5455bd8))


### Code Refactoring

* Remove `PrivateMethodExtensions.InvokePrivateMethod()` ([eb58cb6](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/commit/eb58cb6582fd8d604b287c272fa7c6ba78d41723))
* Remove `PrivatePropertyExtensions.SetPrivateField()` ([38c7b50](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/commit/38c7b507db5b9222bc66d0a693a1be653ae4a159))
* Remove `PrivatePropertyExtensions.SetPrivateProperty()` ([15ee56d](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/commit/15ee56d4c8485cc12481b58a6d7e070f28a52a39))


### Features

* Add support to debug in runtime `Microsoft.SourceLink.GitHub` ([1f16a1f](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/commit/1f16a1fe30daa0f77aad07c2c9ab82d72db73400))


### BREAKING CHANGES

* Remove discontinued extensions `PrivatePropertyExtensions.SetPrivateField()`
* Remove discontinued extensions `PrivatePropertyExtensions.SetPrivateProperty()`
* Remove discontinued extensions `PrivateMethodExtensions.InvokePrivateMethod()`

# [2.2.0](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v2.1.0...v2.2.0) (2022-02-03)


### Features

* Added const `PriorityOrderer.Name` and `PriorityOrderer.Assembly` to facilitate the ordering of tests;




# [2.1.0](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v2.0.0...v2.1.0) (2021-12-15)


### Features

* Added new helper to invoke non public methods `ObjectInvoker.Invoke`;


### Enhancements

* Improved the methods `InvokeNonPublicMethod` and `InvokeNonPublicMethodAsync` to return better exceptions;




# [2.0.0](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v1.3.0...v2.0.0) (2021-11-20)


### Updates

* Added support to .NET 6


### Breaking Changes
* Discontinued the method `PrivatePropertyExtensions.SetPrivateProperty`. New method `SetNonPublicProperty`;
* Discontinued the method `PrivatePropertyExtensions.SetPrivateField`. New method `SetNonPublicField`;
* Discontinued the method `PrivatePropertyExtensions.InvokePrivateMethod`. New method `InvokeNonPublicMethod`;
* Discontinued the method `PrivatePropertyExtensions.InvokePrivateMethodAsync`. New method `InvokeNonPublicMethodAsync`;




# [1.3.0](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v1.2.0...v1.3.0) (2021-08-28)


### Features
* Added new exception `ConstructorNotFoundException`;
* Added new factory to create objects by non public constructor;




# [1.2.0](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v1.1.0...v1.2.0) (2021-08-06)


### Features
* Added new exceptions `PropertyNotFoundException` and `FieldNotFoundException`;
* Added new extensions to set private properties and fields;




# [1.1.0](https://github.com/TechNobre/PowerUtils.xUnit.Extensions/compare/v1.0.0...v1.1.0) (2021-07-24)


### Features

* Added async private method invocations
  * `obj.InvokePrivateMethodAsync<TResult>();`
  * `obj.InvokePrivateMethodAsync();`




# 1.0.0 (2021-07-23)

* Start project
