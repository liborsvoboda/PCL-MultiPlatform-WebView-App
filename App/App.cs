using System;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App
{
    public partial class App : Application
    {
        private static Timer serverAccessTimer = new Timer() { Enabled = true, Interval = 5000,  };
        private static Page targetPage = new WebPage { Title = "Web Page" };
        //private static string Platform = checkPlatform();

        public App()
        {
            MainPage = targetPage;


        }

        public void startDispatcherTimer(object sender, object e)
        {
            if (MainPage.Title != targetPage.Title) MainPage = targetPage;
        }

        protected override void OnStart()
        {
            serverAccessTimer.Elapsed += new ElapsedEventHandler(OnserverAccessElapsedTime);
        }

        private void OnserverAccessElapsedTime(object source, ElapsedEventArgs e)
        {
            if (checkOnline("https://some.web.com", 80))
            {
                targetPage = new WebPage { Title = "Web Page" };
            }
            else
            {
                targetPage = new LocalHtmlBaseUrl { Title = "Local Page" };
            }

            Device.BeginInvokeOnMainThread(() => {
                //MainPage = (MainPage.Title == "Web Page") ? (Page)new LocalHtmlBaseUrl { Title = "Local Page" } : (Page)new WebPage { Title = "Web Page" };
                if (MainPage.Title != targetPage.Title) MainPage = targetPage;
            });
        }

        private static bool checkOnline(string address, int port)
        {
            try
            {
                if (!Plugin.Connectivity.CrossConnectivity.IsSupported)
                {
                    return true;
                }

                var current = Plugin.Connectivity.CrossConnectivity.Current;
                if (current.IsConnected == false)
                {
                    return false;
                }
                else
                {
                    if (current.IsRemoteReachable(address, port, 3000).Result == false)
                    {
                        return false;
                    }
                    else return true;

                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Plugin.Connectivity.CrossConnectivity.Dispose();
            }
        }

        private static string checkPlatform()
        {
            string platform;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    platform = "iOS";
                    break;
                case Device.Android:
                    platform = "Android";
                    break;
                case Device.UWP:
                    platform = "UWP";
                    break;
                default:
                    platform = "";
                    break;
            }
            return platform;
        }
    }
}

