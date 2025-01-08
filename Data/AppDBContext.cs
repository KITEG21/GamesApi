using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamesApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gamesApi.Data
{   
    public class AppDBContext(DbContextOptions dbContextOptions) : IdentityDbContext<AppUser>(dbContextOptions)
    {
        public required DbSet<Game> Games { get; set; }
        public required new DbSet<AppUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Declare the avaible roles for login
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            //seed the roles into the DB
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}