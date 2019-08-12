using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace EducationApp.DataAccessLayer.AppContext
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        { }

        public System.Data.Entity.DbSet<Autors> Autors { get; set; }
        public System.Data.Entity.DbSet<AutorInPrintingEditions> AutorInPrintingEditions { get; set; }
        public System.Data.Entity.DbSet<PrintingEditions> PrintingEditions { get; set; }
        public System.Data.Entity.DbSet<Users> Users { get; set; }
        public System.Data.Entity.DbSet<UserInRoles> UserInRoles { get; set; }
        public System.Data.Entity.DbSet<Roles> Roles { get; set; }
        public System.Data.Entity.DbSet<Orders> Orders { get; set; }
        public System.Data.Entity.DbSet<OrderItems> OrderItems { get; set; }
        public System.Data.Entity.DbSet<Payments> Payments { get; set; }
 
    }

}

