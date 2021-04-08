using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users.WebApi.Model;

namespace Users.WebApi.Data
{
    public class UsersWebApiContext : DbContext
    {
        public UsersWebApiContext (DbContextOptions<UsersWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<Users.WebApi.Model.User> User { get; set; }
    }
}
