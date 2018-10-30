using AppEx.Model;
using AppEx.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppEx.Services
{
    public class AccountService:IAccountService
    {
        public bool LoginControl(string Email, string Password)
        {
            using (var db = new AppExDbContext())
            {
                Password = PasswordHasher.Hash(Password);
                if (RegexChecker.CheckEmail(Email))
                {
                    if (db.Users.Any(user => user.Email == Email && user.Password == Password))
                    {
                        CurrentUser.Instance.User = db.Users.Single(user => user.Email == Email && user.Password == Password);
                        return true;
                    }

                    else
                        return false;
                }
                else if (RegexChecker.CheckUsername(Email))
                {
                    if (db.Users.Any(user => user.Username == Email && user.Password == Password))
                    {
                        CurrentUser.Instance.User = db.Users.Single(user => user.Username == Email && user.Password == Password);
                        return true;
                    }

                    else
                        return false;
                }
                return false;
            }
        }
        public bool Logout()
        {
            try
            {
                CurrentUser.Instance.User = new User();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

    }
}
