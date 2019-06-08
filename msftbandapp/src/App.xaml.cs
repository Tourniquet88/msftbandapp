using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSFTBandLib;
using MSFTBandApp.Launch;
using MSFTBandApp.Main;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MSFTBandApp {

/// <summary>MSFTBandApp</summary>
public partial class App : Application {
	
	/// <summary>Band</summary>
	public BandInterface Band;

	/// <summary>Band client</summary>
	public BandClientInterface BandClient;

	/// <summary>Launch page instance</summary>
	public LaunchPage LaunchPage;


	/// <summary>App constructor.</summary>
	public App() {
		this.InitializeComponent();
	}


	/// <summary>App constructor with MSFTBand.</summary>
	/// <param name="BandClient">Band client instance</param>
	public App(BandClientInterface BandClient) {

		/// Xamarin
		this.InitializeComponent();

		/// Render launch page
		this.LaunchPage = new LaunchPage();
		this.MainPage = this.LaunchPage;

		/// Launch app
		this.Launch(BandClient);

	}


	/// <summary>Get Band connection and render main page.</summary>
	/// <param name="BandClient">Band client instance</param>
	protected async void Launch(BandClientInterface BandClient) {
		try {

			// Connect to Band
			this.BandClient = BandClient;
			this.Band = (await this.BandClient.GetPairedBands())[0];
			await this.Band.Connect();

			// Render main page!
			this.MainPage = new MainPage(this.Band);
		}
		catch (Exception) {
			this.LaunchPage.DisplayError();
		}
	}


	/// <summary>App has started.</summary>
	protected override void OnStart() {
		// TODO
	}


	/// <summary>App is suspending.</summary>
	protected override void OnSleep() {
		// TODO
		// await this.Band.Disconnect();
	}


	/// <summary>App is resuming.</summary>
	protected override void OnResume() {
		// TODO
	}

}

}