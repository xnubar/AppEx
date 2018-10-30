using AppEx.Model;
using AppEx.Navigation;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Person> people;
        public ObservableCollection<Person> People
        {
            get { return people; }
            set { Set(ref people,value); }
        }

    }
}
