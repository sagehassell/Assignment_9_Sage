using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_9_Sage.Models
{
    public class MovieListDBContext: DbContext
    {
        //constructor
        public MovieListDBContext (DbContextOptions<MovieListDBContext> options): base (options)
        {

        }

        //set the DB Movie table 
        public DbSet<Movie> Movies { get; set; }

        
    }
}
