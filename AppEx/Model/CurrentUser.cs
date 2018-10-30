using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEx.Model
{
    public class CurrentUser
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
    }
}
