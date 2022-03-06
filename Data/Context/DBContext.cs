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
        public DbSet <RoleOfUser> RoleOfUser { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Settings: set Primary keys

         

            modelBuilder.Entity<Role>().HasKey(c => c.RoleId);

         modelBuilder.Entity<User>().HasKey(u=>u.userId);

            modelBuilder.Entity<RoleOfUser>().HasKey(u => u.roleofuserId);




            #endregion

            #region Settings: set one to many relations
            // setting :key
            modelBuilder.Entity<RoleOfUser>().HasOne(r => r.role).WithMany(n => n.roleOfUsers).HasForeignKey(x => x.FK_Role);

            modelBuilder.Entity<RoleOfUser>().HasOne(r => r.user).WithMany(n => n.roleOfUsers).HasForeignKey(x => x.Fk_User);






            #endregion
        }

    }
   
}
