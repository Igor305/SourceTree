using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace EducationApp.DataAccessLayer.AppContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        { }

        public DbSet<Autors> Autors { get; set; }
        public DbSet<AutorInPrintingEditions> AutorInPrintingEditions { get; set; }
        public DbSet<PrintingEditions> PrintingEditions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserInRoles> UserInRoles { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Payments> Payments { get; set; }

        
    }

}

