using Xamarin.Forms;

namespace App
{
    public interface IBaseUrl { string Get(); }

    public class LocalHtmlBaseUrl : ContentPage
    {
        public LocalHtmlBaseUrl()
        {
            var browser = new WebView();
            var htmlSource = new HtmlWebViewSource();

            htmlSource.Html = @"<html>
                                <head>
                                <link rel='stylesheet' href='default.css'>
                                </head>
                                <body>
                                <div style='background: #595F72; text-align: center;'>
                                    <img style='margin: 10px;' src='lokalizace.png' alt='Logo'>
                                </div>
                                <p>Webová stránka není k dispozici.</p>
                                <p>Zkontrolujte si připojení k internetu.</p>
                                </body>
                                </html>";

            htmlSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();
            browser.Source = htmlSource;
            Content = browser;
        }
    }
}
