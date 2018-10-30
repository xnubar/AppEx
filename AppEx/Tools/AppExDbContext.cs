using AppEx.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEx.Tools
{
   public class AppExDbContext:DbContext
    {
        public AppExDbContext() : base("AppExDbContext")
        {
            Database.SetInitializer<AppExDbContext>(null);
        }
        public DbSet<User> Users { get; set; }
    }

}
