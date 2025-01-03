using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace gamesApi.Data
{   
    public class AppDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public required DbSet<Game> Games { get; set; }
        
    }
}