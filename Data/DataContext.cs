using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Etudiant> Etudiant { get; set; }
        public DbSet<admins> admins { get; set; }
    }
}
