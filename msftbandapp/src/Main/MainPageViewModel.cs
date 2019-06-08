using MSFTBandLib;
using MSFTBandLib.Includes;
using MSFTBandApp.Common;
using System;

namespace MSFTBandApp.Main {

/// <summary>Main page view model</summary>
public class MainPageViewModel : ViewModel {

	/// <summary>Construct the view model.</summary>
	/// <param name="View">Main page view instance</param>
	public MainPageViewModel(MainPage View) : base(View) {}


	/// <summary>Band instance</summary>
	public BandInterface Band {
		get => this.PropertyAccess<BandInterface>();
		set => this.PropertyChange(value);
	}

	/// <summary>Band time</summary>
	public MSFTBandLib.Includes.DateTime BandTime {
		get => this.PropertyAccess<MSFTBandLib.Includes.DateTime>();
		set {
			this.PropertyChange(value);
			this.OnPropertyChanged("BandTimeString");
		}
	}


	/// <summary>Band time as string</summary>
	public string BandTimeString {
		get => ((this._BandTime != null) ? this.BandTime.ToString() : "");
		set => throw new Exception("Cannot set property directly!");
	}

	
	/// <summary>Band serial number</summary>	
	public string BandSerialNumber {
		get => this.PropertyAccess<string>();
		set => this.PropertyChange(value);
	}


	/// <summary>Band instance field</summary>
	public BandInterface _Band;

	/// <summary>Band time field</summary>
	public MSFTBandLib.Includes.DateTime _BandTime;

	/// <summary>Band serial number field</summary>
	public string _BandSerialNumber;

}

}