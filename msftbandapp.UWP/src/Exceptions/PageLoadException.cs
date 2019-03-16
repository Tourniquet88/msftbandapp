using System;

namespace MSFTBandApp.UWP.Exceptions {

/// <summary>Page load exception.</summary>
public class PageLoadException : Exception {

	/// <summary>Page name</summary>
	public string page;


	/// <summary>Construct exception.</summary>
	/// <param name="page">Page name</param>
	public PageLoadException(
		string page) : base("Failed load \"" + page + "\".") {
		
		this.page = page;
	}

}

}