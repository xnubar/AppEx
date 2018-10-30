using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace AppEx.Tools
{
  public  class RegexChecker
    {
        public static bool CheckEmail(string email)
        {
            try
            {
                if (email == null)
                    return false;
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"); //Butun emaillar
                Match match = regex.Match(email);
                if (match.Success)
                    return true;
            }
            catch (Exception err)
            {
               MessageBox.Show(err.Message);
            }
            return false;
        }
        public static bool CheckUsername(string username)
        {
            try
            {
                if (username == null)
                    return false;
                Regex regex = new Regex(@"^[a-zA-Z0-9_]{5,20}$");
                Match match = regex.Match(username);
                if (match.Success)
                    return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return false;

        }

    }
}
