using System;
using Xamarin.Forms;
using App.Android;

[assembly: Dependency (typeof (BaseUrl_Android))]
namespace App.Android 
{
	public class BaseUrl_Android : IBaseUrl 
	{
		public string Get () 
		{
			return "file:///android_asset/";
		}
	}
}