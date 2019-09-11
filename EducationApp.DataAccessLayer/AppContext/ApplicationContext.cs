using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EducationApp.DataAccessLayer.AppContext
{
    public class ApplicationContext : IdentityDbContext<Users, Role, Guid>
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        { }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<PrintingEdition> PrintingEditions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserInRole>()
                .HasKey(bc => new { bc.UserId, bc.RoleId });
            modelBuilder.Entity<UserInRole>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserInRoly)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UserInRole>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.UserInRoly)
                .HasForeignKey(bc => bc.RoleId);


            modelBuilder.Entity<AutorInPrintingEdition>()
                .HasKey(bc => new { bc.AutorId, bc.PrintingEditionId });
            modelBuilder.Entity<AutorInPrintingEdition>()
                .HasOne(bc => bc.Autor)
                .WithMany(b => b.AutorInPrintingEdition)
                .HasForeignKey(bc => bc.AutorId);
            modelBuilder.Entity<AutorInPrintingEdition>()
                .HasOne(bc => bc.PrintingEdition)
                .WithMany(c => c.AutorInPrintingEdition)
                .HasForeignKey(bc => bc.PrintingEditionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
