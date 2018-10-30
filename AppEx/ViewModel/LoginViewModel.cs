using AppEx.Navigation;
using AppEx.Services;
using AppEx.Tools;
using AppEx.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppEx.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly NavigationService navigation;
        private readonly IAccountService accountService;
        public LoginViewModel(NavigationService navigation)
        {
            this.navigation = navigation;
            accountService = new AccountService();
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
        private string email;
        public string Email
        {
            get { return email; }
            set { Set(ref email, value); }
        }

        private string pass;
        public string Password
        {
            get { return pass; }
            set { Set(ref pass, value); }
        }
        public void CloseWindow()
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.Title == "ExtraWindow")
                        window.Close();
                }
                WindowBluringCustom.Normal();
            });
        }
        private RelayCommand _logInBtnCommand;
        public RelayCommand LogInBtnCommand => _logInBtnCommand ?? (_logInBtnCommand = new RelayCommand(
                   () =>
                   {
                       ExtraWindow extraWindow = new ExtraWindow(new LoadingViewModel(), 200, 200);
                       extraWindow.ShowInTaskbar = false;
                       System.Threading.Tasks.Task.Run(() =>
                       {

                           if (accountService.LoginControl(Email, Password))
                           {
                               CloseWindow();
                               Email = String.Empty;
                               Password = String.Empty;
                               navigation.NavigateTo(ViewType.Home);
                           }
                           else
                               MessageBox.Show("There is no any user with this email(username)/password.","Information",MessageBoxButton.OK,MessageBoxImage.Information);
                           CloseWindow();
                       }
                       );
                       WindowBluringCustom.Bluring();
                       extraWindow.ShowDialog();
                       WindowBluringCustom.Normal();
                   }));

    }
}
