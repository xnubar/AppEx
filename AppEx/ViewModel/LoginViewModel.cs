using AppEx.Navigation;
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
   public class LoginViewModel:ViewModelBase
    {
        private readonly NavigationService navigation;
        ResourceDictionary dict = new ResourceDictionary();
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
        private RelayCommand azLangCommand;
        public RelayCommand AzLangCommand
        {
            get => azLangCommand ?? (azLangCommand = new RelayCommand(
                (() =>
                {
                    dict.Source = new Uri(String.Format("Resources/Lang.{0}.xaml", "ru-RU"), UriKind.Relative);
         

                    ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                                  where d.Source.OriginalString.StartsWith("Resources/Lang.")
                                                  select d).First();
                    if (oldDict != null)
                    {
                        int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                        Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                        Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                    }
                    else
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
                )));
        }
        private RelayCommand engLangCommand;
        public RelayCommand EngLangCommand
        {
            get => engLangCommand ?? (engLangCommand = new RelayCommand(
                (() =>
                {
                    dict.Source = new Uri(String.Format("Resources/Lang.xaml"), UriKind.Relative);

                    ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                                  where d.Source.OriginalString.StartsWith("Resources/Lang.")
                                                  select d).First();
                    if (oldDict != null)
                    {
                        int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                        Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                        Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                    }
                    else
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
                )));
        }
    }
}
