using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamesApi.Dtos
{
    public class NewUserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}