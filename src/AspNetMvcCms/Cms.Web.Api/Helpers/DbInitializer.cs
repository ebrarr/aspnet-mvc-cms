using Cms.Web.Data;
using Cms.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cms.Web.Api.Helpers
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // EnsureCreated metodunu kullanmak yerine sadece Migrate metodunu kullanın
            context.Database.Migrate();

            if (!context.Roles.Any())
            {
                context.Roles.Add(new RoleEntity
                {
                    Name = "Administrator",
                    LastName = "Admin",
                    Email = "assliisildak@gmail.com",
                    PasswordHash = "hashedpassword"
                });

                context.SaveChanges();
            }
        }
    }
}
