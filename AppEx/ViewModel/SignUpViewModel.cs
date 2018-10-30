using AppEx.Model;
using AppEx.Navigation;
using AppEx.Services;
using AppEx.Tools;
using AppEx.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppEx.ViewModel
{
   public class SignUpViewModel:ViewModelBase
    {
        private readonly NavigationService navigation;
        private readonly IUserService userService;
        public SignUpViewModel(NavigationService navigation)
        {
            userService = new UserService();
        }

        private string fullName = "";
        public string FullName
        {
            get { return fullName; }
            set { Set(ref fullName, value); }
        }

        private string password = "";
        public string Password
        {
            get { return password; }
            set { Set(ref password, value); }
        }


        private string username = "";
        public string UserName
        {
            get { return username; }
            set { Set(ref username, value); }
        }

        private string rePassword = "";
        public string RePassword
        {
            get { return rePassword; }
            set { Set(ref rePassword, value); }
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

        private RelayCommand _registerCommand;
        public RelayCommand RegisterCommand => _registerCommand ?? (_registerCommand = new RelayCommand(
            () =>
            {

                ExtraWindow extraWindow = new ExtraWindow(new LoadingViewModel(), 200, 200);
                extraWindow.ShowInTaskbar = false;

                Task.Run(()
                  =>
                {
                    User user = new User();
                   //user.Email = CurrentUser.Instance.User.Email;
                    user.FullName = FullName;
                    user.Password = Password;
                    user.Username = UserName;
                    userService.CreateAsync(user);
                    FullName = String.Empty;
                    UserName = String.Empty;
                    Password = String.Empty;
                    RePassword = String.Empty;
                   // CurrentUser.Instance.User = new User();
                    navigation.NavigateTo(ViewType.LogIn);
                    CloseWindow();

                });
                WindowBluringCustom.Bluring();
                extraWindow.ShowDialog();
                WindowBluringCustom.Normal();
            }
            ));

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(
            () =>
            {
                System.Threading.Tasks.Task.Run(() =>
                {
                    navigation.NavigateTo(ViewType.RegisterEmail);
                    CloseWindow();

                });
            }
            ));
    }
}
