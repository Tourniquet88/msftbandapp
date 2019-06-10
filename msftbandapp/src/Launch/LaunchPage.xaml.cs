using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSFTBandApp.Launch {

/// <summary>Launch page</summary>
public partial class LaunchPage : ContentPage {

	/// <summary>View model instance</summary>
	protected LaunchPageViewModel ViewModel;

	
	/// <summary>Construct the page.</summary>
	public LaunchPage() {
		this.ViewModel = new LaunchPageViewModel(this);
		this.BindingContext = this.ViewModel;
		this.InitializeComponent();
	}


	/// <summary>Render view for an error.</summary>
	public void DisplayError() {
		this.ViewModel.Loading = false;
		this.ViewModel.Error = true;
	}

}

}