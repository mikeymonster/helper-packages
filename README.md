# Wild Helper Packages

Contains the source of nuget packages with common code used in testing and Xamarin Forms development.


## Test Helpers

Other nuget packages uses:
- FluentAssertions - I find this very helpful when writing test assertions, and I use it in all my test projects. It's used a few of the jelper methods
- AutoFixture - used for `ShouldNotAcceptNullConstructorArguments` and `ShouldNotAcceptNullOrBadConstructorArguments` 
- AutoFixture.Idioms - used in 
- AutoNSubstitute - the initial version of the test helpers assume you are using NSubstitute


## To Do

- Need to improve test coverage


## Code Repository and build pipeline 

The build pipeline will build the packages and deploy to nuget. 
It can be found at https://dev.azure.com/wildconsultingltd (signin required).
 

## References

Some useful lins on writing and building nuget packages
		https://softchris.github.io/pages/dotnet-nuget.html#create-a-nuget-package
		https://docs.microsoft.com/en-us/azure/devops/pipelines/artifacts/nuget?view=azure-devops&tabs=yaml
		https://www.josephguadagno.net/2020/04/12/build-sign-and-deploy-nuget-packages-with-azure-pipelines


## Copyright and License

Copyright 2020 Wild Consulting Limited.

Code licensed under the [MIT](https://github.com/BlackrockDigital/startbootstrap-small-business/blob/gh-pages/LICENSE) license.

Some of the property changed notifications were adapted from https://blog.ploeh.dk/2009/08/06/AFluentInterfaceForTestingINotifyPropertyChanged/
