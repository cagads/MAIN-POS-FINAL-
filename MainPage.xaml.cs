using MAIN_POS.MVVM.ViewModels;
using MAIN_POS.MVVM.Views;
namespace MAIN_POS
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            BindingContext =new LoginViewModel();
            
        }

        
    }
}
