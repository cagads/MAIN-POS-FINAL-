using MAIN_POS.MVVM.ViewModels;
using MAIN_POS.MVVM.Models;
using MAIN_POS.MVVM.Views;

namespace MAIN_POS.MVVM.Views;

public partial class UserManagementView : ContentPage
{
    private UserManagementViewModel vm;

    public UserManagementView()
    {
        InitializeComponent();
        vm = new UserManagementViewModel();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.LoadUsersCommand.Execute(null);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new RegistrationView();
    }

    private void Editbtn_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var selectedUser = button?.BindingContext as User;

        if (selectedUser != null)
        {
            Application.Current.MainPage = new EditUserView(selectedUser);
        }
    }
}