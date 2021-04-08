using System.Collections.Generic;
using System.Linq;
using Users.WebApi.Model;

namespace Users.WebApi.Data
{
    public class UsersContextSeed
    {
        public static void SeedAsync(UsersWebApiContext context)
        {
            if(!context.User.Any())
            {
                var users = new List<User>()
                {
                    new User
                    {
                        UserId = 1,
                        Username = "Siddharth",
                        Password = "password"
                    },
                    new User
                    {
                        UserId = 2,
                        Username = "Tarun",
                        Password = "password"
                    }
                };
                context.User.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
