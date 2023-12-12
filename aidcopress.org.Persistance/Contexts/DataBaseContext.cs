using aidcopress.org.Application.Interfaces.Contexts;
using aidcopress.org.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aidcopress.org.Persistence.Contexts;
using aidcopress.org.Common.Role;
using aidcopress.org.Domain.Entities.BusServiceRoute;

namespace aidcopress.org.Persistence.Contexts
{
    public class DataBaseContext:DbContext, IDataBaseContext
    {
         public DataBaseContext(DbContextOptions options) : base(options) 
        {
        } 

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserInRole> UsersInRoles { get; set; }

        public DbSet<Personel> Personels { get; set; }

        public DbSet<BusServiceRoute> BusServiceRoutes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = UserRoles.Admin });//ما در اینجا کاری باید انجام دهیم که نقش ها به صورت ای اف به دیتا بیس منتقل شود چرا که هر وقت بخواهیم پروژه را در جایی راه اندازی نماییم این نقشها منتقل شود
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = UserRoles.Confirmation });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = UserRoles.Client });
        }

    }

    
    
    
}
