using AppAgriculture.Controls;
using AppAgriculture.Models.UserInfo;
using AppAgriculture.Views.Home;
using AppAgriculture.Views.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgriculture.ViewsModels.Login
{
    public class LoadingPageViewModel
    {
        public LoadingPageViewModel()
        {
            CheckUserLogin();
        }

        private async void CheckUserLogin()
        {
            string infoSession = Preferences.Get(nameof(App.UserInfoSession), "");
            if (string.IsNullOrWhiteSpace(infoSession))
            {
                // Navigate to Login Page
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                var userInfo = JsonConvert.DeserializeObject<UserInfo>(infoSession);
                App.UserInfoSession = userInfo;
                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
            }
        }
    }
}
