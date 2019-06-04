using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using MSFTBandLib;
using MSFTBandLib.Device;
using MSFTBandLib.Time;
using MSFTBandApp.Common;

namespace MSFTBandApp.MainPage {

/// <summary>Main page component.</summary>
public partial class MainPage : ContentPage, INotifyPropertyChanged {

	/// <summary>Connected Band</summary>
	protected Band Band;

	/// <summary>Band client</summary>
	protected BandClient BandClient;

	protected MainPageViewModel ViewModel;


	/// <summary>Construct the page.</summary>
	public MainPage() {
		this.InitializeComponent();
	}


	/// <summary>Construct the page with a Band client.</summary>
	/// <param name="BandClient">BandClient</param>
	public MainPage(BandClient BandClient) {

		// Band client
		this.BandClient = BandClient;

		this.ViewModel = new MainPageViewModel(this);

		// Initialise
		this.InitializeComponent();
		this.BindingContext = this.ViewModel;

	}


	/// <summary>Button clicked.</summary>
	/// <param name="sender">sender</param>
	/// <param name="e">e</param>
	private async void Button_Clicked(object sender, EventArgs e) {
		this.Band = (await this.BandClient.GetPairedBands())[0];
		BandInterface client = await this.BandClient.GetConnection(this.Band);
		DeviceService DeviceService = new DeviceService(client);
		TimeService TimeService = new TimeService(client);

		// Device
		string name = this.Band.GetName();
		string address = this.Band.GetAddress();
		System.Diagnostics.Debug.WriteLine($"Connected {name} {address}.");

		// Time
		System.Diagnostics.Debug.WriteLine("Reading device time...");
		TimeDomain Time = await TimeService.GetDeviceTime();
		System.Diagnostics.Debug.WriteLine($"Device time: {Time}");

		// Serial
		System.Diagnostics.Debug.WriteLine("Getting serial number...");
		string serial = await DeviceService.GetSerialNumber();
		this.ViewModel.BandSerialNumber = serial;
		System.Diagnostics.Debug.WriteLine($"Serial number: {this.ViewModel.BandSerialNumber}");

		// Disconnect
		await client.Disconnect();
	}

}

}
