using AppAgriculture.ViewsModels.Login;

namespace AppAgriculture.Views.Login;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageViewModel loadingPageViewModel)
	{
		InitializeComponent();
		this.BindingContext = loadingPageViewModel;
	}
}