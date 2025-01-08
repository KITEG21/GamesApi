using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamesApi.Models;

namespace gamesApi.Interfaces
{
    public interface ITokenService
    {   
        // Interface for TokenService
        public abstract string CreateToken(AppUser user);
    }
}