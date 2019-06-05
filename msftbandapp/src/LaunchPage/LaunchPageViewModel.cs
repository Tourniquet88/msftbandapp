using MSFTBandApp.Common;

namespace MSFTBandApp.LaunchPage {

/// <summary>Launch page view model</summary>
public class LaunchPageViewModel : ViewModel {

	/// <summary>Construct the view model.</summary>
	/// <param name="View">Launch page view instance.</param>
	public LaunchPageViewModel(LaunchPage View) : base(View) {}


	/// <summary>App has initialisation error</summary>
	public bool Error {
		get => this.PropertyAccess<bool>();
		set => this.PropertyChange(value);
	}


	/// <summary>App is currently loading/initialising</summary>
	public bool Loading {
		get => this.PropertyAccess<bool>();
		set => this.PropertyChange(value);
	}


	/// <summary>Error field</summary>
	public bool _Error = false;

	/// <summary>Loading field</summary>
	public bool _Loading = true;

}

}