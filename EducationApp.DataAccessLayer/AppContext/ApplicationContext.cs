using EducationApp.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.AppContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        { }

        public DbSet<Autors> Autors { get; set; }
        public DbSet<PrintingEditions> PrintingEditions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Payments> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInRoles>()
                .HasKey(bc => new { bc.UserId, bc.RoleId });
            modelBuilder.Entity<UserInRoles>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserInRoly)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UserInRoles>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.UserInRoly)
                .HasForeignKey(bc => bc.RoleId);


            modelBuilder.Entity<AutorInPrintingEditions>()
                .HasKey(bc => new { bc.AutorId, bc.PrintingEditionId });
            modelBuilder.Entity<AutorInPrintingEditions>()
                .HasOne(bc => bc.Autor)
                .WithMany(b => b.AutorInPrintingEditionss)
                .HasForeignKey(bc => bc.AutorId);
            modelBuilder.Entity<AutorInPrintingEditions>()
                .HasOne(bc => bc.PrintingEdition)
                .WithMany(c => c.AutorInPrintingEditionss)
                .HasForeignKey(bc => bc.PrintingEditionId);

        }
    }
  

}
