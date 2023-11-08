using Cms.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Buraya dbsetler, roller, konfigürasyonlar gelecek
        public DbSet<AccountTableEntity> AccountTables { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<AppointmentTableEntity> AppointmentTables { get; set; }
        public DbSet<BlogPostEntity> BlogPosts { get; set; }
        public DbSet<ContactFormEntity> ContactForms { get; set; }
        public DbSet<CustomerReviewEntity> CustomerReviews { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<PolyclinicEntity> Polyclinics { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<SecretaryEntity> Secretaries { get; set; }
        public DbSet<StaticEntity> Statics { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<VisitTableEntity> VisitTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roles = new RoleEntity[]
            {
                new RoleEntity{Id = 1, Name = "Patient"},
                new RoleEntity{Id = 2, Name = "Doctor"},
                new RoleEntity{Id = 3, Name = "Admin"}
            };

            modelBuilder.Entity<RoleEntity>().HasData(roles);

            base.OnModelCreating(modelBuilder);
        }
    }
}
