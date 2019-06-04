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

	/// <summary>View model instance</summary>
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

		/// View model instance
		this.ViewModel = new MainPageViewModel(this);

		// Initialise the component
		this.InitializeComponent();
		this.BindingContext = this.ViewModel;

		// Run!
		this.Todo();

	}


	/// <summary>Todo demo ;)</summary>
	private async void Todo() {

		// Connect
		this.Band = (await this.BandClient.GetPairedBands())[0];
		BandInterface client = await this.BandClient.GetConnection(this.Band);

		// Services
		DeviceService DeviceService = new DeviceService(client);

		// Get data
		this.ViewModel.Band = this.Band;
		this.ViewModel.BandSerialNumber = await DeviceService.GetSerialNumber();

		// Disconnect
		await client.Disconnect();

	}

}

}
