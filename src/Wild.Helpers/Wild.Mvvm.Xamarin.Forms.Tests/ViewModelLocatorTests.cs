using System;
using FluentAssertions;
using NSubstitute;
using Wild.Mvvm.Xamarin.Forms.Tests.Stubs.ViewModels;
using Wild.Mvvm.Xamarin.Forms.Tests.Stubs.Views;
using Xunit;

namespace Wild.Mvvm.Xamarin.Forms.Tests;

public class ViewModelLocatorTests
{
    private readonly StubPageViewModel _viewModel;

    public ViewModelLocatorTests()
    {
        _viewModel = new StubPageViewModel();

        var serviceProvider = Substitute.For<IServiceProvider>();
        serviceProvider
            .GetService(Arg.Is<Type>(t => t == typeof(StubPageViewModel)))
            .Returns(_viewModel);

        ViewModelLocator.ServiceProvider = serviceProvider;
    }

    [Fact]
    public void ViewModelLocator_Resolve_Generic_Should_Return_Instance_Of_Expected_Type()
    {
        var vm = ViewModelLocator.Resolve<StubPageViewModel>();

        vm.Should().NotBeNull();
        vm.Should().BeOfType<StubPageViewModel>();
    }

    [Fact]
    public void ViewModelLocator_Resolve_Should_Return_Instance_Of_Expected_Type()
    {
        var vm = ViewModelLocator.Resolve(typeof(StubPageViewModel));

        vm.Should().NotBeNull();
        vm.Should().BeOfType<StubPageViewModel>();
    }

    [Fact]
    public void ViewModelLocator_GetAutowireViewModel_Should_Be_True_When_Set()
    {
        var view = new StubPage();

        ViewModelLocator.SetAutowireViewModel(view, true);

        Assert.True(ViewModelLocator.GetAutowireViewModel(view));
        ViewModelLocator.GetAutowireViewModel(view).Should().BeTrue();
    }

    [Fact]
    public void ViewModelLocator_SetAutowireViewModel_Should_Set_Binding_Context()
    {
        var view = new StubPage();

        ViewModelLocator.SetAutowireViewModel(view, true);

        view.BindingContext.Should().Be(_viewModel);
    }

    [Fact]
    public void ViewModelLocator_GetViewModelType_Should_Be_Set_Value()
    {
        var view = new StubPage();

        ViewModelLocator.SetViewModelType(view, _viewModel.GetType());

        ViewModelLocator.GetViewModelType(view).Should().Be(_viewModel.GetType());

        view.BindingContext.Should().Be(_viewModel);
    }

    [Fact]
    public void ViewModelLocator_SetViewModelType_Should_Set_Binding_Context()
    {
        var view = new StubPage();

        ViewModelLocator.SetViewModelType(view, _viewModel.GetType());

        view.BindingContext.Should().Be(_viewModel);
    }
}