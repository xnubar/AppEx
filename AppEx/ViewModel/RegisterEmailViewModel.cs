using AppEx.Navigation;
using AppEx.Tools;
using AppEx.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppEx.ViewModel
{
    public class RegisterEmailViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly NavigationService navigation;
        EmailHelper GetEmail = new EmailHelper();

        public RegisterEmailViewModel(NavigationService navigation)
        {
            this.navigation = navigation;
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { Set(ref email, value); }
        }
        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(
            () =>
            {
                System.Threading.Tasks.Task.Run(() =>
                {
                    Email = String.Empty;
                    navigation.NavigateTo(ViewType.LogIn);
                    CloseWindow();

                });
            }
            ));
        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName.Equals(nameof(Email)))
                {
                    if (!RegexChecker.CheckEmail(Email))
                        result = "Enter your email correctly!";
                    else if (RegexChecker.CheckEmail(Email))
                    {
                        //using (var db = new AppExDbContext())
                        //{
                            //if (db.Users.ToList().Exists(user => user.Email == Email))
                            //{
                               // result = "This mail already exists!!!";
                            //}
                        //}
                    }
                }


                return result;
            }
        }


        public string Error => throw new NotImplementedException();

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


        private RelayCommand sendConfirmationCodeCommand;
        public RelayCommand SendConfirmationCodeCommand => sendConfirmationCodeCommand ?? (sendConfirmationCodeCommand = new RelayCommand(
                () =>
                {
                    ExtraWindow extraWindow = new ExtraWindow(new LoadingViewModel(), 200, 200);
                    extraWindow.ShowInTaskbar = false;

                    System.Threading.Tasks.Task.Run(
                        () =>
                        {

                            if (RegexChecker.CheckEmail(Email))
                            {

                                GetEmail.SendRegisterActivationCode(Email);
                                CloseWindow();
                                navigation.NavigateTo(ViewType.ConfirmCode);
                                MessageBox.Show($"Confirmation code is sent to {Email}, please, check your email and enter it to box.", "Email", MessageBoxButton.OK, MessageBoxImage.Information);
                                Email = String.Empty;
                            }
                            
                            CloseWindow();
                        });
                    WindowBluringCustom.Bluring();
                    extraWindow.ShowDialog();
                    WindowBluringCustom.Normal();

                }
            ));


    }
}
