using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Forms;
using MSFTBandLib;
using MSFTBandLib.UWP;

namespace MSFTBandApp.UWP {

/// <summary>Main page.</summary>
public sealed partial class MainPage {

	/// <summary>Construct the page.</summary>
	public MainPage() {
		this.InitializeComponent();
		this.LoadApplication(new MSFTBandApp.App(new BandClientUWP()));
	}

}

}