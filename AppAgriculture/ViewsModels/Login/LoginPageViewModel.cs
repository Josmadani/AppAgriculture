using AppAgriculture.ApiRest.Login;
using AppAgriculture.Controls;
using AppAgriculture.Models.Login;
using AppAgriculture.Models.UserInfo;
using AppAgriculture.Views.Home;
using AppAgriculture.ViewsModels.Startup;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.Windows.Input;

namespace AppAgriculture.ViewsModels.Login
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }

        private bool _isVisible;
        private bool _isEnabled;
        private bool _isLoading;
        private LoginAuth loginAuth = new LoginAuth();
        private LoginPageModel _loginPageModel = new LoginPageModel();


        [ObservableProperty]
        private String _userName;
        
        [ObservableProperty]
        private String _passWord;

        public LoginPageModel loginPageModel
        {
            get
            {
                return _loginPageModel;
            }
            set
            {
                _loginPageModel = value;
                OnPropertyChanged(nameof(loginPageModel));
            }
        }

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }


        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () => await PerformLoginOperation());
        }

        private async Task PerformLoginOperation()
        {
            if (!String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(PassWord)){
                IsVisible = true;
                IsLoading = true;
                IsEnabled = false;
                await Task.Delay(3000);

                UserInfo userInfo = new UserInfo();
                userInfo = await loginAuth.ReadPostWebService(UserName, PassWord);
                if(userInfo != null)
                {
                    if(userInfo.UsuCombId > 0)
                    {
                        if (Preferences.ContainsKey(nameof(App.UserInfoSession)))
                        {
                            Preferences.Set("UserAlreadyLoggedIn", false);
                            Preferences.Remove(nameof(App.UserInfoSession));
                        }

                        App.UserInfoSession = userInfo;
                        String userInfoString = JsonConvert.SerializeObject(userInfo);
                        Preferences.Set("UserAlreadyLoggedIn", true);
                        Preferences.Set(nameof(App.UserInfoSession), userInfoString);
                        AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                        await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
                    }
                    else
                    {
                        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                        await Toast.Make(userInfo.NombreUsuario,
                                  ToastDuration.Long,
                                  18)
                            .Show(cancellationTokenSource.Token);
                    }
                }
                IsVisible = false;
                IsLoading = false;
                IsEnabled = true;
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                await Toast.Make("Ingrese las Credenciales!",
                          ToastDuration.Long,
                          18)
                    .Show(cancellationTokenSource.Token);
            }
        }
    }
}
