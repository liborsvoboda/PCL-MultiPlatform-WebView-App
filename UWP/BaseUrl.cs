﻿using App.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl))]
namespace App.UWP
{
    public class BaseUrl : IBaseUrl
    {
        public string Get()
        {
            return "ms-appx-web:///";
        }
    }
}
