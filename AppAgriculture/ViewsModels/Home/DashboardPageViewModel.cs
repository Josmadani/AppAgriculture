using AppAgriculture.Views.Login;
using AppAgriculture.ViewsModels.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppAgriculture.ViewsModels.Home
{

    public partial class DashboardPageViewModel : BaseViewModel
    {
        public ICommand LogoutCommand { get; }

        public DashboardPageViewModel()
        {
            Title = "Solicitudes de Trabajo";
            LogoutCommand = new Command(PerformLogoutOperation);
        }

        private async void PerformLogoutOperation(object obj)
        {
            Preferences.Clear();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
