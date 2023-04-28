using Xamarin.Forms;

namespace App
{
    public class WebPage : ContentPage
    {
        public WebPage()
        {
            var browser = new WebView();
            browser.Source = "https://Some.web.com";
            Content = browser;
        }
    }
}

