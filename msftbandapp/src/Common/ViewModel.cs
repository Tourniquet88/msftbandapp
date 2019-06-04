using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MSFTBandApp.Common {

/// <summary>View model base</summary>
public class ViewModel : INotifyPropertyChanged {

	public object host;

	public event PropertyChangedEventHandler PropertyChanged;

	public ViewModel(object host) {
		this.host = host;
	}


	/// <summary>
	/// Getting value of a view model property.
	/// 
	/// Gets the value from the corresponding private property.</summary>
	/// <typeparam name="T">Type to get</typeparam>
	/// <param name="prop">Property name</param>
	/// <returns>Type value</returns>
	public T PropertyAccess<T>([CallerMemberName] string prop=null) {
		return (T) this.GetField($"_{prop}").GetValue(this);
	}


	/// <summary>
	/// View model property changed.
	/// 
	/// Sets the corresponding private property and reports the change.
	/// </summary>
	/// <typeparam name="T">Type of property</typeparam>
	/// <param name="value">Value to set</param>
	/// <param name="prop">Property name being set</param>
	public void PropertyChange<T>(
		T value, [CallerMemberName] string prop=null) {

		this.GetField($"_{prop}").SetValue(this, value);
		this.OnPropertyChanged();
	}


	public FieldInfo GetField(string prop) {
		return this.GetType().GetRuntimeField(prop);
	}


	protected virtual void OnPropertyChanged([CallerMemberName] string name="") {
		this.PropertyChanged?.Invoke(this.host, new PropertyChangedEventArgs(name));
	}

}

}