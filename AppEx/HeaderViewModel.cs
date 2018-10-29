using AppEx.Navigation;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEx
{
    public class HeaderViewModel : ViewModelBase
    {
        private readonly NavigationService navigation;

        public HeaderViewModel(NavigationService navigation)
        {
            this.navigation = navigation;
        }
    }
}
