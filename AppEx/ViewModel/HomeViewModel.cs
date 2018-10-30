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
    public class HomeViewModel : ViewModelBase
    {
        private readonly NavigationService navigation;
        private readonly AccountService accountService;
        public HomeViewModel(NavigationService navigation)
        {
            this.navigation = navigation;
            accountService = new AccountService();
        }
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { Set(ref currentViewModel, value); }
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
        private RelayCommand logOutCommand;
        public RelayCommand LogOutCommand => logOutCommand ?? (logOutCommand = new RelayCommand(
                   () =>
                   {
                       ExtraWindow extraWindow = new ExtraWindow(new LoadingViewModel(), 200, 200);
                       extraWindow.ShowInTaskbar = false;

                       System.Threading.Tasks.Task.Run(() =>
                       {
                           accountService.Logout();
                           navigation.NavigateTo(ViewType.LogIn);
                           CloseWindow();
                       });



                       WindowBluringCustom.Bluring();
                       extraWindow.ShowDialog();
                       WindowBluringCustom.Normal();
                   }));
        private RelayCommand homeCommand;
        public RelayCommand HomeCommand => homeCommand ?? (homeCommand = new RelayCommand(
                   () =>
                   {
                       CurrentViewModel = new CardOptionsViewModel(navigation);
                   }));

        private RelayCommand dataExchangeCommand;
        public RelayCommand DataExchangeCommand => dataExchangeCommand ?? (dataExchangeCommand = new RelayCommand(
                   () =>
                   {

                   }));

        private RelayCommand filterCommand;
        public RelayCommand FilterCommand => filterCommand ?? (filterCommand = new RelayCommand(
                   () =>
                   {
                       CurrentViewModel = new FilterViewModel(navigation);
                   }));

        private RelayCommand messageCommand;
        public RelayCommand MessageCommand => messageCommand ?? (messageCommand = new RelayCommand(
                   () =>
                   {

                   }));
    }
}
