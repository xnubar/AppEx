using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEx.Model
{
    public class CurrentUser:ViewModelBase
    {
        private CurrentUser()
        {

        }
        private static CurrentUser instance;
        public static CurrentUser Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new CurrentUser();
                }
                return instance;
            }
        }
        private User user;
        public User User
        {
            get { return user; }
            set { Set(ref user, value); }
        }

    }
}
