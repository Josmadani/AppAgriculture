using AppAgriculture.ViewsModels.Home;

namespace AppAgriculture.Views.Home;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardPageViewModel dashboardPageViewModel)
	{
		InitializeComponent();
        this.BindingContext = new DashboardPageViewModel();
    }
}