# Wild Helper Packages

Contains the source of nuget packages with common code used in testing and Xamarin Forms development.


## Wild.Mvvm.Xamarin.Forms

Contains useful classes for working with MVVM in Xamarin Forms.

Available from nuget - https://www.nuget.org/packages/Wild.Mvvm.Xamarin.Forms/


#### ViewModelLocator
 TODO: Add an example of how to use

For example, in a xaml file include the following to set the data context
to a viewmodel called `MainViewModel` in namepace `Your.Project.Namespace`:

```
xmlns:local="clr-namespace:Your.Project.Namespace;assembly=Tl.Search.Mobile"
xmlns:vm="clr-namespace:Your.Project.ViewModels;assembly=Your.Project"
local:ViewModelLocator.ViewModelType="{x:Type vm:MainViewModel}"
```

`ViewModelLocator.ServiceProvider` is a static property that must be set during startup:

```
//Required - ViewModelLocator needs to be told where the ServiceProvider is.
ViewModelLocator.ServiceProvider = ServiceProvider;
``` 


## Test Helpers

Test helper methods and extensions for working with Xamarin Forms xUnit projects.

Other nuget packages used:
- FluentAssertions - I find this very helpful when writing test assertions, and I use it in all my test projects. It's used a few of the jelper methods
- AutoFixture - used for `ShouldNotAcceptNullConstructorArguments` and `ShouldNotAcceptNullOrBadConstructorArguments` 
- AutoFixture.Idioms - used in 
- AutoNSubstitute - the initial version of the test helpers assume you are using NSubstitute

Available from nuget - https://www.nuget.org/packages/Wild.TestHelpers/


## To Do

- Need to improve test coverage, especially in the TestHelpers project.


## Code Repository and build pipeline 

Code is in GitHub - https://github.com/mikeymonster/wild-helper-packages

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
