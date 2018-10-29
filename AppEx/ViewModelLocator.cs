using AppEx.Navigation;
using AppEx.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using NavigationService = AppEx.Navigation.NavigationService;

namespace AppEx
{
    public class ViewModelLocator
    {
        private NavigationService navigationService;
        public AppViewModel appViewModel;
        public LoginViewModel loginViewModel;
        public RegisterEmailViewModel registerEmailViewModel;
        public ViewModelLocator()
        {
            navigationService = new NavigationService();
            appViewModel = new AppViewModel();
            loginViewModel = new LoginViewModel(navigationService);
            registerEmailViewModel = new RegisterEmailViewModel(navigationService);

            navigationService.AddPage(loginViewModel, ViewType.LogIn);
            navigationService.AddPage(loginViewModel, ViewType.RegisterEmail);

            navigationService.NavigateTo(ViewType.LogIn);
        }
    }
}
