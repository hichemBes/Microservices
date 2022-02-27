using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User>Users { get; set; }
        public DbSet<Role>Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Settings: set Primary keys

         

            modelBuilder.Entity<Role>().HasKey(c => c.RoleId);

         modelBuilder.Entity<User>().HasKey(u=>u.userId);



            #endregion

            #region Settings: set one to many relations
            //Project_Task
           
            modelBuilder.Entity<User>()
                                   .HasOne(r => r.Role)
                                   .WithMany(n => n.User)
                                   .HasForeignKey(n => n.fk_RoleId);
            modelBuilder.Entity<Role>()
      .HasMany(c => c.User)
      .WithOne(e => e.Role);


            #endregion
        }

    }
   
}
