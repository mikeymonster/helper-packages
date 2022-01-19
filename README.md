# Wild Helper Packages

Contains the source of nuget packages with common code used in testing and Xamarin Forms development.


## Wild.Mvvm.Xamarin.Forms

Contains useful classes for working with MVVM in Xamarin Forms.

Available from nuget - https://www.nuget.org/packages/Wild.Mvvm.Xamarin.Forms/


#### ViewModelLocator
 TODO: Add an example of how to use

For example, in a xaml file include the following to set the data context
to a view model called `MainViewModel` in namespace `Your.Project.Namespace`:

```
xmlns:mvvm="clr-namespace:Wild.Mvvm.Xamarin.Forms;assembly=Wild.Mvvm.Xamarin.Forms"
xmlns:vm="clr-namespace:Your.Project.ViewModels;assembly=Your.Project"
mvvm:ViewModelLocator.ViewModelType="{x:Type vm:MainViewModel}"
```

`ViewModelLocator.ServiceProvider` is a static property that must be set during startup:

```
//Required - ViewModelLocator needs to be told where the ServiceProvider is.
ViewModelLocator.ServiceProvider = ServiceProvider;
``` 


## Test Helpers

Contains test helper methods and extensions for working with Xamarin Forms xUnit projects.

Other nuget packages used:
- FluentAssertions - I find this very helpful when writing test assertions, and I use it in all my test projects. It's used a few of the helper methods
- AutoFixture - used for `ShouldNotAcceptNullConstructorArguments` and `ShouldNotAcceptNullOrBadConstructorArguments` 
- AutoFixture.Idioms - used in 
- AutoNSubstitute - the initial version of the test helpers assume you are using NSubstitute

Available from nuget - https://www.nuget.org/packages/Wild.TestHelpers/


## Nuget versioning

Nuget package versions are in the `.csproj` file for the packages.
When a new version is ready to be deployed, update the version hthere. For example:
```
<Version>0.3.0</Version>
```


## To Do

- Need to improve test coverage, especially in the TestHelpers project.


## Code Repository and build pipeline 

Code is in GitHub - https://github.com/mikeymonster/wild-helper-packages

The build pipeline will build the packages and deploy to nuget. 
It can be found at https://dev.azure.com/wildconsultingltd (sign-in required).
 

## References

Some useful links on writing and building nuget packages
		https://softchris.github.io/pages/dotnet-nuget.html#create-a-nuget-package
		https://docs.microsoft.com/en-us/azure/devops/pipelines/artifacts/nuget?view=azure-devops&tabs=yaml
		https://www.josephguadagno.net/2020/04/12/build-sign-and-deploy-nuget-packages-with-azure-pipelines


## Copyright and License

Copyright 2020-2022 Wild Consulting Limited.

Code licensed under the [MIT](https://github.com/BlackrockDigital/startbootstrap-small-business/blob/gh-pages/LICENSE) license.

Some of the property changed notifications were adapted from https://blog.ploeh.dk/2009/08/06/AFluentInterfaceForTestingINotifyPropertyChanged/
