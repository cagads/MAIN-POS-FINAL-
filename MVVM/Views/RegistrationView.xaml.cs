using MAIN_POS.MVVM.ViewModels;
namespace MAIN_POS.MVVM.Views;

public partial class RegistrationView : ContentPage
{
	public RegistrationView()
	{
		InitializeComponent();
        BindingContext = new RegistrationViewModel();
    }

    

    
}