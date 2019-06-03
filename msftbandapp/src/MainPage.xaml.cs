using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using MSFTBandLib;
using MSFTBandLib.Device;
using MSFTBandLib.Time;

namespace MSFTBandApp {

/// <summary>Main page component.</summary>
public partial class MainPage : ContentPage {

	/// <summary>Band client</summary>
	BandClient BandClient;


	/// <summary>Construct the page.</summary>
	/// <param name="BandClient">BandClient</param>
	public MainPage(BandClient BandClient) {

		// Band client
		this.BandClient = BandClient;

		// Initialise
		this.InitializeComponent();

	}


	/// <summary>Button clicked.</summary>
	/// <param name="sender">sender</param>
	/// <param name="e">e</param>
	private async void Button_Clicked(object sender, EventArgs e) {
		Band device = (await this.BandClient.GetPairedBands())[0];
		BandInterface client = await this.BandClient.GetConnection(device);
		DeviceService DeviceService = new DeviceService(client);
		TimeService TimeService = new TimeService(client);

		// Device
		string name = device.GetName();
		string address = device.GetAddress();
		System.Diagnostics.Debug.WriteLine($"Connected {name} {address}.");

		// Time
		System.Diagnostics.Debug.WriteLine("Reading device time...");
		TimeDomain Time = await TimeService.GetDeviceTime();
		System.Diagnostics.Debug.WriteLine($"Device time: {Time}");

		// Serial
		System.Diagnostics.Debug.WriteLine("Getting serial number...");
		string serial = await DeviceService.GetSerialNumber();
		System.Diagnostics.Debug.WriteLine($"Serial number: {serial}");

		// Disconnect
		await client.Disconnect();
	}

}

}
