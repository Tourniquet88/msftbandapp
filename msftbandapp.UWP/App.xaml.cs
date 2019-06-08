using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MSFTBandApp.UWP {

/// <summary>MSFTBandApp</summary>
sealed partial class App : Application {

    /// <summary>
    /// Construct new app instance.
    /// 
    /// This constructor is the first line of executed user code 
    /// and as such represents the entrypoint to the application.
    /// </summary>
    public App() {
        this.InitializeComponent();
        this.Suspending += this.OnSuspending;
    }


    /// <summary>Application has been launched by the user.</summary>
    /// <param name="e">Arguments associated with the launch.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e) {
        Frame application = Window.Current.Content as Frame;

        if (application == null) {
            application = new Frame();
            application.NavigationFailed += this.OnNavigationFailed;
            Xamarin.Forms.Forms.Init(e);
            Window.Current.Content = application;
        }

        if (e.PrelaunchActivated == false) {
            if (application.Content == null) {
                application.Navigate(typeof(MainPage), e.Arguments);
            }
            Window.Current.Activate();
        }
    }


    /// <summary>Navigation to a page failed.</summary>
    /// <param name="sender">Frame which failed navigation</param>
    /// <param name="e">Arguments associated with the failure</param>
    /// <exception cref="Exception">Throws as failed.</exception>
    private void OnNavigationFailed(
        object sender, NavigationFailedEventArgs e) {

        string page = e.SourcePageType.FullName;
        throw new Exceptions.PageLoadException(e.SourcePageType.FullName);
    }


    /// <summary>Application is being suspended; save state.</summary>
    /// <param name="sender">Source of suspend request.</param>
    /// <param name="e">Arguments associated with suspension.</param>
    private void OnSuspending(object sender, SuspendingEventArgs e) {
        SuspendingDeferral def = e.SuspendingOperation.GetDeferral();
        def.Complete();
    }

}

}