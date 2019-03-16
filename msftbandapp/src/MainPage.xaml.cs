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
	public MainPage(BandClient BandClient) {

		// Band client
		this.BandClient = BandClient;

		// Initialise
		this.InitializeComponent();

	}


	private async void Button_Clicked(object sender, EventArgs e) {
		List<Band> devices = await this.BandClient.GetPairedBands();
		Band device = devices[0];
		await this.DisplayAlert(device.GetName(), device.GetAddress(), "OK");
	}

}

}
