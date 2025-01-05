using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamesApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gamesApi.Data
{   
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public required DbSet<Game> Games { get; set; }
        public new DbSet<AppUser>? Users { get; set; }
        
    }
}