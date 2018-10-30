using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AppEx.Model;
using AppEx.Tools;

namespace AppEx.Services
{
    public class UserService : IUserService
    {
        public async Task CreateAsync(User user)
        {

            try
            {
                if (user != null)
                {
                    using (var dbContext = new AppExDbContext())
                    {

                        if (dbContext.Users.ToList().Exists(x => x.Username == user.Username) &&
                            dbContext.Users.ToList().Exists(x => x.Email == user.Email))
                        {
                            throw new Exception("User with this username already exists.");
                        }
                        user.Password = PasswordHasher.Hash(user.Password);
                        dbContext.Users.Add(user);
                        await dbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.ToString());
            }
        }
    }
}
