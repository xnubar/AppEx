using AppEx.Navigation;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEx.ViewModel
{
    public class FilterViewModel:ViewModelBase
    {
        private readonly NavigationService navigation;
        public FilterViewModel(NavigationService navigation)
        {
            this.navigation = navigation;
        }
    }
}
