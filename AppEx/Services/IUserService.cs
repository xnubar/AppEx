using AppEx.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEx.Services
{
    interface IUserService
    {
        Task CreateAsync(User user);

    }
}
