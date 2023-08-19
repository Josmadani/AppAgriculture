using AppAgriculture.Views.Home;
using AppAgriculture.Views.Login;
using AppAgriculture.ViewsModels.Home;
using AppAgriculture.ViewsModels.Login;
using CommunityToolkit.Maui;

namespace AppAgriculture;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//WebServices
/*		builder.Services.AddHttpClient("LoadAllBrands",
            httpClientLoadAllBrands => httpClientLoadAllBrands.BaseAddress =
			new Uri("http://10.0.2.2:18535/Brands/LoadAllBrands"));
*/
		//Views
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddSingleton<DashboardPage>();

        //View Models
        builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<LoadingPageViewModel>();
        builder.Services.AddSingleton<DashboardPageViewModel>();

        return builder.Build();
	}
}
