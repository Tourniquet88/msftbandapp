using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MSFTBandApp.Android {

[
	Activity(
		Label = "MSFTBandApp.Android",
		Icon = "@mipmap/icon",
		Theme = "@style/MainTheme",
		MainLauncher = true,
		ConfigurationChanges = (
			ConfigChanges.ScreenSize | ConfigChanges.Orientation
		)
	)
]
/// <summary>Main activity entrypoint.</summary>
public class MainActivity : 
global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {

	/// <summary>App constructor.</summary>
	protected override void OnCreate(Bundle savedInstanceState) {
		TabLayoutResource = Resource.Layout.Tabbar;
		ToolbarResource = Resource.Layout.Toolbar;
		base.OnCreate(savedInstanceState);
		global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
		LoadApplication(new MSFTBandApp.App());
	}

}

}