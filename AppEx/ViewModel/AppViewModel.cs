using AppEx.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppEx.ViewModel
{
    public class AppViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { Set(ref currentViewModel, value); }
        }
      

       
        public AppViewModel()
        {
         
            Messenger.Default.Register<ViewModelBase>(this,
            param => CurrentViewModel = param);
        }

     
        public void Closewindow()
        {

            App.Current.Dispatcher.Invoke(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.Title.Equals("AppEX"))
                    {
                        window.Close();
                    }
                }
            });
        }

        private RelayCommand _maximizeCommand;
        public RelayCommand MaximizeCommand
        {
            get => _maximizeCommand ?? (_maximizeCommand = new RelayCommand(
                (() =>
                {
                    if (App.Current.MainWindow.WindowState == System.Windows.WindowState.Maximized)
                    {
                        App.Current.MainWindow.ResizeMode = ResizeMode.CanResize;
                        App.Current.MainWindow.WindowState = WindowState.Normal;
                    }
                    else
                    {
                        App.Current.MainWindow.ResizeMode = ResizeMode.NoResize;
                        App.Current.MainWindow.WindowState = WindowState.Maximized;
                    }
                })));
        }
        private RelayCommand _minimizeCommand;
        public RelayCommand MinimizeCommand
        {
            get => _minimizeCommand ?? (_minimizeCommand = new RelayCommand(
                (() => App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized)));
        }
        private RelayCommand _closeCommand;
        public RelayCommand CloseCommand
        {
            get => _closeCommand ?? (_closeCommand = new RelayCommand(
                (() => App.Current.MainWindow.Close())));
        }



    }


}
