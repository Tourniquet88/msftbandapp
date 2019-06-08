using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using MSFTBandLib;
using MSFTBandApp.Common;

namespace MSFTBandApp.Main {

/// <summary>Main page component.</summary>
public partial class MainPage : ContentPage, INotifyPropertyChanged {

	/// <summary>Band</summary>
	protected BandInterface Band;

	/// <summary>View model instance</summary>
	protected MainPageViewModel ViewModel;


	/// <summary>Construct the page.</summary>
	/// <param name="Band">Band instance</param>
	public MainPage(BandInterface Band) {
		this.Band = Band;
		this.ViewModel = new MainPageViewModel(this);
		this.BindingContext = this.ViewModel;
		this.InitializeComponent();
		this.Render();
	}


	/// <summary>Render!<summary>
	private async void Render() {
		this.ViewModel.Band = this.Band;
		this.ViewModel.BandTime = await this.Band.GetDeviceTime();
		this.ViewModel.BandSerialNumber = await this.Band.GetSerialNumber();
		this.ViewModel.LastSleep = await this.Band.GetLastSleep();
	}

}

}