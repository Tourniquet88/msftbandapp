using MSFTBandLib;
using MSFTBandApp.Common;

namespace MSFTBandApp.MainPage {

/// <summary>Main page view model</summary>
public class MainPageViewModel : ViewModel {

	/// <summary>Construct the view model.</summary>
	/// <param name="View">Main page view instance</param>
	public MainPageViewModel(MainPage View) : base(View) {}


	/// <summary>Band instance</summary>
	public Band Band {
		get => this.PropertyAccess<Band>();
		set => this.PropertyChange(value);
	}

	
	/// <summary>Band serial number</summary>	
	public string BandSerialNumber {
		get => this.PropertyAccess<string>();
		set => this.PropertyChange(value);
	}


	/// <summary>Band instance field</summary>
	public Band _Band;


	/// <summary>Band serial number field</summary>
	public string _BandSerialNumber;

}

}