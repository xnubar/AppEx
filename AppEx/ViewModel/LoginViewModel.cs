using AppEx.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEx.ViewModel
{
   public class LoginViewModel:ViewModelBase
    {
        private readonly NavigationService navigation;
        public LoginViewModel(NavigationService navigation)
        {
            this.navigation = navigation;
        }
        private RelayCommand signUpCommand;
        public RelayCommand SignUpCommand
        {
            get => signUpCommand ?? (signUpCommand = new RelayCommand(
                (() =>
                {
                   
                    navigation.NavigateTo(ViewType.RegisterEmail);
                }
                )));
        }

    }
}
