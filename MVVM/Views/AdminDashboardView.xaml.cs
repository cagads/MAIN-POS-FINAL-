using MAIN_POS.MVVM.ViewModels;

namespace MAIN_POS.MVVM.Views;

public partial class AdminDashboardView : ContentPage
{
	public AdminDashboardView()
	{
		InitializeComponent();
		BindingContext = new AdminDashboardViewModel();
	}

    
}