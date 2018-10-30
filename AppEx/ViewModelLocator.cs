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
        public SignUpViewModel signUpViewModel;
        public HomeViewModel homeViewModel;
        public CodeConfirmationViewModel codeConfirmationViewModel;
        public ViewModelLocator()
        {
            navigationService = new NavigationService();

            appViewModel = new AppViewModel();
            signUpViewModel = new SignUpViewModel(navigationService);
            homeViewModel = new HomeViewModel(navigationService);
            loginViewModel = new LoginViewModel(navigationService);
            registerEmailViewModel = new RegisterEmailViewModel(navigationService);
            codeConfirmationViewModel = new CodeConfirmationViewModel(navigationService);

            navigationService.AddPage(loginViewModel, ViewType.LogIn);
            navigationService.AddPage(homeViewModel, ViewType.Home);
            navigationService.AddPage(codeConfirmationViewModel, ViewType.ConfirmCode);
            navigationService.AddPage(registerEmailViewModel, ViewType.RegisterEmail);
            navigationService.AddPage(signUpViewModel, ViewType.SignUp);


            navigationService.NavigateTo(ViewType.LogIn);
        }
    }
}
