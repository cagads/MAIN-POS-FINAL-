namespace MAIN_POS.MVVM.Views;

public partial class FeatureView : FlyoutPage
{
	public FeatureView()
	{
		InitializeComponent();
	}

    private void Home_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new HomeView();
    }

    private void Users_Clicked(object sender, EventArgs e)
    {

    }

    private void Notifications_Clicked(object sender, EventArgs e)
    {

    }

    private void Settings_Clicked(object sender, EventArgs e)
    {

    }
}