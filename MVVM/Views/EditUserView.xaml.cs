using MAIN_POS.MVVM.Models;
using MAIN_POS.MVVM.ViewModels;

namespace MAIN_POS.MVVM.Views;

public partial class EditUserView : ContentPage
{
    public EditUserView(User selectedUser)
    {
        InitializeComponent();
        BindingContext = new EditUserViewModel(selectedUser);
    }
}