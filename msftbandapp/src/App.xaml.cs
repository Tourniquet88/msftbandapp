using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSFTBandLib;
using MSFTBandApp.MainPage;

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


	/// <summary>App constructor.</summary>
	public App() {
		this.InitializeComponent();
	}


	/// <summary>App constructor with a Band client.</summary>
	public App(BandClient BandClient) {
		this.InitializeComponent();
		this.Main(BandClient);
		this.MainPage = new LaunchPage.LaunchPage();
	}


	/// <summary>Connect to Band and render main page.</summary>
	/// <param name="BandClient">Band client instance</param>
	public async void Main(BandClient BandClient) {
		this.BandClient = BandClient;
		this.Band = (await this.BandClient.GetPairedBands())[0];
		this.BandInterface = await this.BandClient.GetConnection(this.Band);
		this.MainPage = new MainPage.MainPage();
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