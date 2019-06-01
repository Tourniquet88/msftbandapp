using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using MSFTBandLib;

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
		List<Band> devices = await this.BandClient.GetPairedBands();
		Band device = devices[0];
		BandInterface BC = await this.BandClient.GetConnection(device);
		string name = device.GetName();
		string address = device.GetAddress();
		await this.DisplayAlert(name, address, "OK");
		System.Diagnostics.Debug.WriteLine("Reading device time...");
		byte[] res = await BC.Read(MSFTBandLib.Command.GetDeviceTime, 16);
		System.Diagnostics.Debug.WriteLine("Got time!");
		System.Diagnostics.Debug.WriteLine("[" + string.Join(", ", res) + "]");
		await BC.Disconnect();
	}

}

}
