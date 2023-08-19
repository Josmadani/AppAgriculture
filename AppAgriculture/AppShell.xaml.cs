using AppAgriculture.Views.Home;

namespace AppAgriculture;

public partial class AppShell : Shell
{ 
    public AppShell()
    {
        InitializeComponent();
        var getLoggedId = Preferences.Get("UserAlreadyLoggedIn", false);
        getLoggedId = false;

        if (getLoggedId == true)
        {
            MyAppShell.CurrentItem = MyDashboard;
        }
        else
        {
            MyAppShell.CurrentItem = MyLoginPage;
        }
    }
}
