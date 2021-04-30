using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> students { get; set; }

    }
}
