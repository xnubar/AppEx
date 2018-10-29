using AppEx.Navigation;
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
        private INavigationService navigationService;
        public ViewModelLocator()
        {
            navigationService = new NavigationService();
        }
    }
}
