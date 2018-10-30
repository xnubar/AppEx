using AppEx.Navigation;
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
    public class CodeConfirmationViewModel:ViewModelBase
    {
        private readonly NavigationService navigation;

        public CodeConfirmationViewModel(NavigationService navigation)
        {
            this.navigation = navigation;
        }
        private string confirmationCode;
        public string ConfirmationCode
        {
            get { return confirmationCode; }
            set
            {
                Set(ref confirmationCode, value);
            }
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
        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(
            () =>
            {
                System.Threading.Tasks.Task.Run(() =>
                {
                    ConfirmationCode = String.Empty;
                    navigation.NavigateTo(ViewType.RegisterEmail);
                    CloseWindow();

                });
            }
            ));
        private RelayCommand confirmCommand;
        public RelayCommand ConfirmCommand => confirmCommand ?? (confirmCommand = new RelayCommand(
                () =>
                {
                    ExtraWindow extraWindow = new ExtraWindow(new LoadingViewModel(), 200, 200);
                    Task.Run(()
                      =>
                    {
                        if (Randomizer.RandomKey.Equals(ConfirmationCode))
                        {
                            navigation.NavigateTo(ViewType.SignUp);
                        }                       
                        else
                        {
                            ConfirmationCode = String.Empty;
                            MessageBox.Show("Confirmation code is not correct!", "Warning",MessageBoxButton.OK, MessageBoxImage.Warning);
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
