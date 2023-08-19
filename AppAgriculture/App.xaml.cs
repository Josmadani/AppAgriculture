using AppAgriculture.Handlers;
using AppAgriculture.Models.UserInfo;
using Microsoft.Maui.Platform;

namespace AppAgriculture;

public partial class App : Application

{
    public static UserInfo UserInfoSession;

	public App()
    {
		InitializeComponent();

        //Border less entry
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });
        
        MainPage = new AppShell();
	}
}
