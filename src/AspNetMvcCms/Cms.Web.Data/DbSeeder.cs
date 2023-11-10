using Cms.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Web.Data
{
    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedRoleEntity(modelBuilder);
        }

        private static void SeedRoleEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = 1, Name = "Patient" },
                new RoleEntity { Id = 2, Name = "Doctor" },
                new RoleEntity { Id = 3, Name = "Admin" });
        }
    }
}
