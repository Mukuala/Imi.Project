using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Imi.Project.Mobile.Utils
{
    public static class GetJwtToken
    {
        public static string JwtToken = Preferences.Get("JwtToken", null);
    }
}
