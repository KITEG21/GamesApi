using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamesApi.Helpers
{   
    //Object for Queries
    public class QueryObject
    {   
        //Select elements by Developers
        public string? Developers { get; set; } = null;
        
        //Set the page number
        public int PageNumber { get; set; } = 1;
        
        //Set the amount of elements by page
        public int PageSize { get; set; } = 5;

    }
}