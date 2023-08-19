namespace AppAgriculture.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

		if(App.UserInfoSession != null)
		{
            lblUserName.Text = App.UserInfoSession.UserName;
            lblNombreUsuario.Text = App.UserInfoSession.NombreUsuario;
        }
    }
}