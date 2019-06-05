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

	/// <summary>View model instance</summary>
	protected MainPageViewModel ViewModel;


	/// <summary>Construct the page.</summary>
	public MainPage() {

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

		// Services
		DeviceService DeviceService = new DeviceService(((App)App.Current).BandInterface);

		// Get data
		this.ViewModel.Band = ((App)App.Current).Band;
		this.ViewModel.BandSerialNumber = await DeviceService.GetSerialNumber();

	}

}

}