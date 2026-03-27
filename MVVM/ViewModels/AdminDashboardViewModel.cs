using MAIN_POS.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAIN_POS.MVVM.ViewModels
{
    public class AdminDashboardViewModel
    {
        public ICommand GoToUserManagementCommand { get; set; }

        public AdminDashboardViewModel() 
        {
            GoToUserManagementCommand = new Command( async () =>
            {
                Application.Current.MainPage= new UserManagementView();
            });
        }
    }
}
