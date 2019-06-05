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
		this.ViewModel = new MainPageViewModel(this);
		this.BindingContext = this.ViewModel;
		this.InitializeComponent();
		this.Render();
	}


	/// <summary>Render!<summary>
	private async void Render() {

		// Services
		DeviceService DeviceService = new DeviceService(((App)App.Current).BandInterface);

		// Get data
		this.ViewModel.Band = ((App)App.Current).Band;
		this.ViewModel.BandSerialNumber = await DeviceService.GetSerialNumber();

	}

}

}