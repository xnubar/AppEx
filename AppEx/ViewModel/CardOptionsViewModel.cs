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
    public class CardOptionsViewModel:ViewModelBase
    {
        private readonly NavigationService navigation;
        public CardOptionsViewModel(NavigationService navigation)
        {
            this.navigation = navigation;
        }

        private RelayCommand idCardCommand;
        public RelayCommand IDCardCommand => idCardCommand ?? (idCardCommand = new RelayCommand(
          () =>
          {

          }));

        private RelayCommand newIDCardCommand;
        public RelayCommand NewIDCardCommand => newIDCardCommand ?? (newIDCardCommand = new RelayCommand(
           () =>
           {

           }));

        private RelayCommand passportCommand;
        public RelayCommand PassportCommand => passportCommand ?? (passportCommand = new RelayCommand(
          () =>
          {

          }));

        private RelayCommand driverLicenseCommand;
        public RelayCommand DriverLicenseCommand => driverLicenseCommand ?? (driverLicenseCommand = new RelayCommand(
                   () =>
                   {

                   }));
    }
}
