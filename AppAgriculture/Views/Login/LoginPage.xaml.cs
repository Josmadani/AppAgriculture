using AppAgriculture.ViewsModels.Login;

namespace AppAgriculture.Views.Login;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
        this.BindingContext = loginPageViewModel;
    }
}