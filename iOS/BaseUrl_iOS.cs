using Xamarin.Forms;
using App.iOS;
using Foundation;

[assembly: Dependency (typeof (BaseUrl_iOS))]

namespace App.iOS 
{
	public class BaseUrl_iOS : IBaseUrl 
	{
		public string Get () 
		{
			return NSBundle.MainBundle.BundlePath;
		}
	}
}