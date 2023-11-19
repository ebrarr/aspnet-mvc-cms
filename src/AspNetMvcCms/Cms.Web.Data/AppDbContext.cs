using Cms.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cms.Web.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		// DbSet'ler, roller, konfigürasyonlar buraya eklenecek

		public DbSet<AccountTableEntity> AccountTables { get; set; }
		public DbSet<AdminEntity> Admins { get; set; }
		public DbSet<AppointmentTableEntity> AppointmentTables { get; set; }
		public DbSet<BlogPostEntity> BlogPosts { get; set; }
        public DbSet<BlogCommentEntity> BlogComments { get; set; }
        public DbSet<ContactFormEntity> ContactForms { get; set; }
		public DbSet<CustomerReviewEntity> CustomerReviews { get; set; }
        public DbSet<DoctorPolyclinicRelationEntity> DoctorPolyclinicRelations { get; set; }
        public DbSet<PolyclinicEntity> Polyclinics { get; set; }
		public DbSet<RoleEntity> Roles { get; set; }
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<VisitTableEntity> VisitTables { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// RoleEntity için veri ekleme
			modelBuilder.Entity<RoleEntity>().HasData(
				new RoleEntity { Id = 1, Name = "Patient" },
				new RoleEntity { Id = 2, Name = "Doctor" },
				new RoleEntity { Id = 3, Name = "Admin" },
                new RoleEntity { Id = 3, Name = "Secretary" }
                );
		}
	}
}
