using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MSFTBandApp.Common {

/// <summary>
/// View model base
/// 
/// A basic MVVM implementation.
/// 
/// Extend and add properties using getter/setter pattern to 
/// invoke `PropertyAccess`/`PropertyChange` respectively, which 
/// handle accessing property data in a corresponding private 
/// field (which must be named as the property name with a `_` 
/// prefix) and invoking `OnPropertyChanged` to update XAML bindings.
/// 
/// You can also use `OnPropertyChanged` manually to update a 
/// property in the view (`View`, which is passed at construction). 
/// </summary>
public class ViewModel : INotifyPropertyChanged {

	/// <summary>View instance the model is attached to</summary>
	public object View;

	/// <summary>Property changed event handler for changes</summary>
	public event PropertyChangedEventHandler PropertyChanged;


	/// <summary>Construct with a given view instance.</summary>
	/// <param name="view">View instance the model is attached to</param>
	public ViewModel(object view) {
		this.View = view;
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
		this.OnPropertyChanged(prop);
	}


	/// <summary>Get the `FieldInfo` for a given field name.</summary>
	/// <param name="prop">field</param>
	/// <returns>FieldInfo</returns>
	public FieldInfo GetField(string field) {
		return this.GetType().GetRuntimeField(field);
	}


	/// <summary>
	/// `INotifyPropertyChanged` implementation.
	/// 
	/// Notifies `this.View` – the view the model is attached to.
	/// </summary>
	/// <param name="name">The property which changed</param>
	protected virtual void OnPropertyChanged(
		[CallerMemberName] string name="") {

		this.PropertyChanged?.Invoke(
			this.View, new PropertyChangedEventArgs(name)
		);
	}

}

}