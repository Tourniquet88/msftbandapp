using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSFTBandLib;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MSFTBandApp {

/// <summary>MSFTBandApp</summary>
public partial class App : Application {
	
	/// <summary>Band</summary>
	public Band Band;

	/// <summary>Band client</summary>
	public BandClient BandClient;

	/// <summary>Band interface instance</summary>
	public BandInterface BandInterface;

	/// <summary>Launch page instance</summary>
	public LaunchPage.LaunchPage LaunchPage;


	/// <summary>App constructor.</summary>
	public App() {
		this.InitializeComponent();
	}


	/// <summary>App constructor with a Band client.</summary>
	public App(BandClient BandClient) {

		/// Xamarin
		this.InitializeComponent();

		/// Render launch page
		this.LaunchPage = new LaunchPage.LaunchPage();
		this.MainPage = this.LaunchPage;

		/// Launch app
		this.Launch(BandClient);

	}


	/// <summary>Connect to Band and render main page.</summary>
	/// <param name="BandClient">Band client instance</param>
	protected async void Launch(BandClient BandClient) {
		try {
			this.BandClient = BandClient;
			this.Band = (await this.BandClient.GetPairedBands())[0];
			this.BandInterface = await this.BandClient.GetConnection(this.Band);
			this.MainPage = new MainPage.MainPage();
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
		// await this.BandClient.Disconnect();
	}


	/// <summary>App is resuming.</summary>
	protected override void OnResume() {
		// TODO
	}

}

}