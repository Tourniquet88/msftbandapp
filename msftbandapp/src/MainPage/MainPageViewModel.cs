using MSFTBandApp.Common;

namespace MSFTBandApp.MainPage {

public class MainPageViewModel : ViewModel {
	
	public string BandSerialNumber {
		get => PropertyAccess<string>();
		set => PropertyChange(value);
	}

	public string _BandSerialNumber = "FOOBAR";

	public MainPageViewModel(MainPage host) : base(host) {}

}

}