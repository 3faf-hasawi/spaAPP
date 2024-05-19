using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using spa.Models;

namespace spa.Data
{
    public class spaContext : DbContext
    {
        public spaContext (DbContextOptions<spaContext> options)
            : base(options)
        {
        }

        public DbSet<spa.Models.Customer> Customerz { get; set; } = default!;

        public DbSet<Admin> Adminz { get; set; }
    }
}
