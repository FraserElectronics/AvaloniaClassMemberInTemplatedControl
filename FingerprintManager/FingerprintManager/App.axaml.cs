using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using FingerprintManager.ViewModels;
using FingerprintManager.Views;

using Microsoft.Extensions.DependencyInjection;

using R503FingerprintComms.Classes;
using R503FingerprintComms.Interfaces;

using System;

namespace FingerprintManager;

public partial class App : Application
{
    // ###########################################################################################################
    // # Properties
    // ###########################################################################################################
    #region Properties

    /// <summary>
    /// Gets the current <see cref="App"/> instance in use
    /// </summary>
    public new static App? Current => ( App? )Application.Current;

    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
    /// </summary>
    public IServiceProvider? Services { get; protected set; }

    #endregion Properties

    // ###########################################################################################################
    // # Methods
    // ###########################################################################################################
    #region Methods

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load( this );
        Services = ConfigureServices();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt( 0 );

        if ( ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop )
        {
            desktop.Exit += Desktop_Exit;
            desktop.MainWindow = new MainWindow
            {
                DataContext = App.Current?.Services?.GetService<IMainViewModel>()
            };
        }
        else if ( ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform )
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = App.Current?.Services?.GetService<IMainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    /// <summary>
    /// Called when the application is being closed.
    /// To ensure the user gets the chance to save any data, a system wide event will
    /// be raised.
    /// </summary>
    /// <param name="sender">The main application instance.</param>
    /// <param name="e">The event arguments.</param>
    private void Desktop_Exit( object? sender, ControlledApplicationLifetimeExitEventArgs e )
    {
     }

    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IR503Comms, R503Comms>();

        services.AddSingleton<IMainViewModel, MainViewModel>();


        return services.BuildServiceProvider();
    }

    #endregion Methods
}
