﻿using aidcopress.org.Domain.Entities.BusServiceRoute;
using aidcopress.org.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aidcopress.org.Application.Interfaces.Contexts
{
    public interface IDataBaseContext 
    {

         DbSet<User> Users { get; set; }

         DbSet<Role> Roles { get; set; }

         DbSet<UserInRole> UsersInRoles { get; set; }

         DbSet<Personel> Personels { get; set; }

        public DbSet<BusServiceRoute> BusServiceRoutes { get; set; }


        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,CancellationToken cancellationToken =  new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }


   
}
