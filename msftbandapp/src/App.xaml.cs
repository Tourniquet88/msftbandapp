using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSFTBandLib;
using MSFTBandApp.MainPage;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MSFTBandApp {

/// <summary>MSFTBandApp</summary>
public partial class App : Application {

	/// <summary>Band client</summary>
	BandClient BandClient;


	/// <summary>App constructor.</summary>
	public App() {
		this.InitializeComponent();
	}


	/// <summary>App constructor with a Band client.</summary>
	public App(BandClient BandClient) {

		// Band client
		this.BandClient = BandClient;
		
		// Initialise
		this.InitializeComponent();

		// Construct main page
		this.MainPage = new MainPage.MainPage(this.BandClient);

	}


	/// <summary>App has started.</summary>
	protected override void OnStart() {
		// TODO
	}


	/// <summary>App is suspending.</summary>
	protected override void OnSleep() {
		// TODO
	}


	/// <summary>App is resuming.</summary>
	protected override void OnResume() {
		// TODO
	}

}

}